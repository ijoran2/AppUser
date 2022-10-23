
using Dapper;
using Microsoft.Extensions.Configuration;
using Repositorio.modelos;
using System.Data.SqlClient;
namespace Repositorio.Respository
{
    public class EmpleadosRepository:IEmpleadosRepository
    {
        private readonly string _connectionString;

        public EmpleadosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Usuarios>> Get()
        {

            
                var sqlQuery = "SELECT * FROM Usuarios";
                using (var connection = new SqlConnection(_connectionString))
                {
                    return await connection.QueryAsync<Usuarios>(sqlQuery);
                }

        }

        public async Task<Usuarios> Get(int Id)
        {

            try
            {
                var sqlQuery = "SELECT * FROM Usuarios WHERE Id=@Id";

                using (var connection = new SqlConnection(_connectionString))
                {
                    return await connection.QueryFirstOrDefaultAsync<Usuarios>(sqlQuery, new { Id = Id });
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Usuarios> Create(Usuarios usuario)
        {
            var sqlQuery = "INSERT INTO Usuarios (Nombre, ApellidoP,ApellidoM,Telefono,Email,Activo) VALUES (@Nombre, @ApellidoP,@ApellidoM,@Telefono,@Email,@Activo)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    usuario.Nombre,
                    usuario.ApellidoP,
                    usuario.ApellidoM,
                    usuario.Telefono,
                    usuario.Email,
                    usuario.Activo

                });

                return usuario;
            }
        }

        public async Task Update(Usuarios usuario)
        {
            var sqlQuery = "UPDATE Usuarios SET Nombre=@Nombre, ApellidoP=@ApellidoP,ApellidoM=@ApellidoM,Telefono=@Telefono,Email=@Email,Activo=@Activo WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    usuario.Id,
                    usuario.Nombre,
                    usuario.ApellidoP,
                    usuario.ApellidoM,
                    usuario.Telefono,
                    usuario.Email,
                    usuario.Activo,
                });
            }
        }

        public async Task Delete(int Id)
        {
            var sqlQuery = "DELETE from Usuarios WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = Id });
            }
        }


    }
}
