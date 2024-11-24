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

    public async Task<PaqueteResponse> obtenerListaDePaquetes()
    {
        List<PaqueteEntity> listaDePaquetes = new List<PaqueteEntity>();

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_DE_PAQUETES", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read()) 
            {
                PaqueteEntity paqueteEntity = new PaqueteEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    CantidadDeMusica = Convert.ToInt32(sqlDataReader["CantidadDeMusica"]),
                    TiempoDeDuracion = Convert.ToInt32(sqlDataReader["TiempoDeDuracion"]),
                    NombreDeCategoria = Convert.ToString(sqlDataReader["NombreDeCategoria"])
                };
                listaDePaquetes.Add(paqueteEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener lista de Musicas ", exception);
        }

        PaqueteResponse paqueteResponse = new PaqueteResponse
        {
            listaDePaquetesEntity = listaDePaquetes
        };
        return paqueteResponse;
    } 

    public async Task<DetallePaqueteResponse> obtenerDetalleDePaquetePorID(int idDeMusica)
    {
        DetallePaqueteEntity detallePaqueteEntity = null;

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", idDeMusica);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                detallePaqueteEntity = new DetallePaqueteEntity
                {
                    IdDetalle = Convert.ToInt32(sqlDataReader["IdDetalle"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    CantidadDeMusica = Convert.ToInt32(sqlDataReader["CantidadDeMusica"]),
                    TiempoDeDuracion = Convert.ToInt32(sqlDataReader["TiempoDeDuracion"]),
                    NombreDeCategoria = Convert.ToString(sqlDataReader["NombreDeCategoria"]),
                    TituloDeDetalle = Convert.ToString(sqlDataReader["TituloDeDetalle"]),
                    Detalle = Convert.ToString(sqlDataReader["Detalle"])
                };
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Detalle de Musica ", exception);
        }
        return new DetallePaqueteResponse{DetalleDePaquete = detallePaqueteEntity};
    }
}
