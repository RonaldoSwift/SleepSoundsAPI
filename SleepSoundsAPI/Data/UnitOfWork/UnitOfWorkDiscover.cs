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

    public async Task<DestacadoResponse> obtenerDestacado()
    {
        List<DestacadoEntity> listaDeDestacados = new List<DestacadoEntity>();

        try {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_DE_DESTACADO", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DestacadoEntity destacadoEntity = new DestacadoEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"]),
                    CantidadDeMusica = Convert.ToInt32(sqlDataReader["CantidadDeMusica"]),
                    NombreDeCategoria = Convert.ToString(sqlDataReader["NombreDeCategoria"])
                };
                listaDeDestacados.Add(destacadoEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Destacado ", exception);
        }

        DestacadoResponse destacadoResponse = new DestacadoResponse
        {
            listaDeDestacadosEntity = listaDeDestacados
        };
        return destacadoResponse;
    }

    public async Task<ChildResponse> obtenerListaChilds()
    {
        List<ChildEntity> listaDeChilds = new List<ChildEntity>();

        try{
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_CHILD", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ChildEntity childEntity = new ChildEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"])
                };
                listaDeChilds.Add(childEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Hijos ", exception);
        }
        ChildResponse childResponse = new ChildResponse
        {
            listaDeChildEntity = listaDeChilds
        };
        return childResponse;
    }

    public async Task<NatureResponse> obtenerListaNature()
    {
        List<NatureEntity> listaDeNatures = new List<NatureEntity>();

        try{
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_NATURE", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                NatureEntity natureEntity = new NatureEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"])
                };
                listaDeNatures.Add(natureEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Nature ", exception);
        }
        NatureResponse natureResponse = new NatureResponse
        {
            listaDeNatureEntity = listaDeNatures
        };
        return natureResponse;
    }

    public async Task<AnimalResponse> obtenerListaAnimal()
    {
        List<AnimalEntity> listaDeAnimals = new List<AnimalEntity>();

        try{
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = stringConnection.Cadena;
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("USP_OBTENER_LISTA_ANIMAL", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                AnimalEntity animalEntity = new AnimalEntity
                {
                    Id = Convert.ToInt32(sqlDataReader["Id"]),
                    Imagen = Convert.ToString(sqlDataReader["Imagen"]),
                    Nombre = Convert.ToString(sqlDataReader["Nombre"])
                };
                listaDeAnimals.Add(animalEntity);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
        }
        catch (Exception exception)
        {
            throw new Exception("Error al obtener Animal ", exception);
        }

        AnimalResponse animalResponse = new AnimalResponse
        {
            listaDeAnimalEntity = listaDeAnimals
        };
        return animalResponse;
    }
}
