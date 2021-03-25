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
    public class GenreRepository:IRepositoryAsync<Genre>
    {
        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM Genre WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, new { id = id });
                return result;
            }
        }
        public async Task<Genre> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Genre WHERE Id=@id";
                var result = await connection.QueryFirstOrDefaultAsync<Genre>(cmd, new { id = id });
                return result;
            }
        }
        public async Task<int> InsertAsync(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO Genre VALUES(@Name)";
                var result = await connection.ExecuteAsync(cmd, genre);
                return result;
            }
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Genre";
                var result = await connection.QueryAsync<Genre>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE Genre SET Name=@Name WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, genre);
                return result;
            }
        }


    }
}
