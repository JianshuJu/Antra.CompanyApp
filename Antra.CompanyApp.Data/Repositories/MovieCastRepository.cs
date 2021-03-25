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
    public class MovieCastRepository//:IRepositoryAsync<MovieCast>
    {
        public async Task<int> DeleteAsync(int movieId, int castId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM MovieCast WHERE MovieId=@MovieId, CastId=@CastId";
                var result = await connection.ExecuteAsync(cmd, new { MovieId = movieId, CastId = castId });
                return result;
            }
        }
        public async Task<MovieCast> GetByIdAsync(int movieId, int castId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM MovieCast WHERE MovieId=@MovieId, CastId=@CastId";
                var result = await connection.QueryFirstOrDefaultAsync<MovieCast>(cmd, new { MovieId = movieId, CastId = castId });
                return result;
            }
        }
        public async Task<int> InsertAsync(MovieCast movieCast)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO MovieCast VALUES(@MovieId, @CastId, @Character)";
                var result = await connection.ExecuteAsync(cmd, movieCast);
                return result;
            }
        }
        public async Task<IEnumerable<MovieCast>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM MovieCast";
                var result = await connection.QueryAsync<MovieCast>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(MovieCast movieCast)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE MovieCast SET Character=@Character WHERE MovieId=@MovieId AND CastId=@CastId";
                var result = await connection.ExecuteAsync(cmd, movieCast);
                return result;
            }
        }

    }
}
