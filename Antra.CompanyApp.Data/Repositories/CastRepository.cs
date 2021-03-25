using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;


namespace Antra.CompanyApp.Data.Repositories
{
    public class CastRepository: IRepositoryAsync<Cast>
    {
        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM Cast WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, new { id = id });
                return result;
            }
        }
        public async Task<Cast> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Cast WHERE Id=@id";
                var result = await connection.QueryFirstOrDefaultAsync<Cast>(cmd, new { id = id });
                return result;
            }
        }
        public async Task<int> InsertAsync(Cast cast)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO Cast VALUES(@Name, @Gender, @TmdbUrl, @ProfilePath)";
                var result = await connection.ExecuteAsync(cmd, cast);
                return result;
            }
        }
        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Cast";
                var result = await connection.QueryAsync<Cast>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(Cast cast)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE Cast SET Name=@Name, Gender=@Gender, TmdbUrl=@TmdbUrl, ProfilePath=@ProfilePath WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, cast); 
                return result;
            }
        }

    }
}
