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
}
