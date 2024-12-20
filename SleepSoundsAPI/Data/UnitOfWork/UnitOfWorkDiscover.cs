using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SleepSoundsAPI.Domain.Models;
using SleepSoundsAPI.DBConnection;
using SleepSoundsAPI.Domain.Models.Response;

namespace SleepSoundsAPI.Data.UnitOfWork;

public class UnitOfWorkDiscover
{
    private readonly StringConnection stringConnection;

    public UnitOfWorkDiscover(IOptions<StringConnection> stringConnection)
    {
        this.stringConnection = stringConnection.Value;
    }

    public async Task<PaqueteResponse> obtenerListaDePaquetes(bool destacado)
    {
        List<PaqueteEntity> listaDePaquetes = new List<PaqueteEntity>();

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            string nombreDeStoreProcedurePSP = "";
            if (destacado == true) {
                nombreDeStoreProcedurePSP = "USP_OBTENER_LISTA_DE_PAQUETES_QUE_TENGAN_TRUE_EN_DESTACADO";
            } else {
                nombreDeStoreProcedurePSP = "USP_OBTENER_LISTA_DE_PAQUETES";
            }
            SqlCommand sqlCommand = new SqlCommand(nombreDeStoreProcedurePSP, sqlConnection);
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
                    NombreCategoria = Convert.ToString(sqlDataReader["NombreCategoria"])
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

    public async Task<DetallePaqueteResponse> obtenerDetalleDePaquetePorID(int idDePaquete)
    {
        DetallePaqueteEntity detallePaqueteEntity = null;

        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_DETALLE_DE_PAQUETE_POR_ID", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", idDePaquete);

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
                    Descripcion = Convert.ToString(sqlDataReader["Descripcion"])
                };
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Detalle de Musica ", exception);
        }
        return new DetallePaqueteResponse{DetalleDePaquete = detallePaqueteEntity};
    }

    public async Task<MusicaResponse> obtenerMusicas(int idDeMusica) 
    {
        List<MusicaEntity> listaDeMusicas = new List<MusicaEntity>();
        try 
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_MUSICA_POR_ID", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@IdPaquete", idDeMusica);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                MusicaEntity musicaEntity = new MusicaEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Artista = Convert.ToString(sqlDataReader["Artista"]),
                    Titulo = Convert.ToString(sqlDataReader["Titulo"]),
                    Album = Convert.ToString(sqlDataReader["Album"]),
                    IdDePaquete = Convert.ToInt32(sqlDataReader["IdDePaquete"]),
                    UrlDeMusica = Convert.ToString(sqlDataReader["UrlDeMusica"]),
                };
                listaDeMusicas.Add(musicaEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Musica ", exception);
        }
        
        MusicaResponse musicaResponse = new MusicaResponse
        {
            listaDeMusicasEntity = listaDeMusicas
        };

        return musicaResponse;

    }

    public async Task<CategoriaComposerResponse> obtenerListaDeCategoriaComposer(string categoriaComposer)
    {
        List<CategoriaComposerEntity> listaDeCategoriaComposer = new List<CategoriaComposerEntity>();

        try{
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_POR_CATEGORIA_COMPOSER", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@CategoriaComposer", categoriaComposer);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                CategoriaComposerEntity categoriaComposerEntity = new CategoriaComposerEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    Categoria = Convert.ToString(sqlDataReader["Categoria"])
                };
                listaDeCategoriaComposer.Add(categoriaComposerEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Categoria Composer ", exception);
        }
        CategoriaComposerResponse categoriaComposerResponse = new CategoriaComposerResponse
        {
            listaDeCategoriaComposerEntity = listaDeCategoriaComposer
        };
        return categoriaComposerResponse;
    }

}
