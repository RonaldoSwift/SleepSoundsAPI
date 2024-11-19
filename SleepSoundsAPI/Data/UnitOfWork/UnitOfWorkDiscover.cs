using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SleepSoundsAPI.Data.Modelo;
using SleepSoundsAPI.DBConnection;

namespace SleepSoundsAPI.Data.UnitOfWork;

public class UnitOfWorkDiscover
{
    private readonly StringConnection stringConnection;

    public UnitOfWorkDiscover(IOptions<StringConnection> stringConnection)
    {
        this.stringConnection = stringConnection.Value;
    }

    public async Task<MusicaDiscoverResponse> obtenerListaDeMusicaDiscover()
    {
        List<MusicaDiscoverEntity> listaDeMusicas = new List<MusicaDiscoverEntity>();

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_DE_MUSICA_DISCOVER", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read()) 
            {
                MusicaDiscoverEntity musicaDiscoverEntity = new MusicaDiscoverEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    Songs = Convert.ToInt32(sqlDataReader["Songs"]),
                    Instrumental = Convert.ToString(sqlDataReader["Instrumental"])
                };
                listaDeMusicas.Add(musicaDiscoverEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener lista de Musicas ", exception);
        }

        MusicaDiscoverResponse musicaDiscoverResponse = new MusicaDiscoverResponse
        {
            listaDeMusicasDiscoverEntity = listaDeMusicas
        };
        return musicaDiscoverResponse;
    } 

    public async Task<DetalleMusicaDiscoverResponse> obtenerDetalleDeMusicaPorID(int idDeMusica)
    {
        DetalleMusicaDiscoverEntity detalleMusicaDiscoverEntity = null;

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_DETALLE_DE_MUSICA_DISCOVER_POR_ID", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", idDeMusica);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                detalleMusicaDiscoverEntity = new DetalleMusicaDiscoverEntity
                {
                    IdDetalle = Convert.ToInt32(sqlDataReader["IdDetalle"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    Songs = Convert.ToInt32(sqlDataReader["Songs"]),
                    Instrumental = Convert.ToString(sqlDataReader["Instrumental"]),
                    TituloDeDetalle = Convert.ToString(sqlDataReader["TituloDeDetalle"]),
                    Detalle = Convert.ToString(sqlDataReader["Detalle"])
                };
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Detalle de Musica ", exception);
        }
        return new DetalleMusicaDiscoverResponse{DetalleDeMusica = detalleMusicaDiscoverEntity};
    }
}
