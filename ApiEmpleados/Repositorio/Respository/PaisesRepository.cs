using Dapper;
using Microsoft.Extensions.Configuration;
using Repositorio.modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Respository
{
    public class PaisesRepository:IPaisesRepository
    {
        private readonly string _connectionString;

        public PaisesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public async Task<IEnumerable<Paises>> Get()
        {
            var sqlQuery = "SELECT * FROM Paises";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Paises>(sqlQuery);
            }
        }

        public async Task<Paises> Get(int id)
        {
            var sqlQuery = "SELECT * FROM Paises WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Paises>(sqlQuery, new { Id = id });
            }
        }

        public async Task<Paises> Create(Paises pais)
        {
            var sqlQuery = "INSERT INTO Paises (Pais, Idioma) VALUES (@Pais, @Idioma)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    pais.Pais,
                    pais.Idioma,

                });

                return pais;
            }
        }

        public async Task Update(Paises pais)
        {
            var sqlQuery = "UPDATE Paises SET Pais=@Pais, Idioma=@Idioma WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    pais.Id,
                    pais.Pais,
                    pais.Idioma
                });
            }
        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE from Paises WHERE Id=@Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
        }
    }
}
