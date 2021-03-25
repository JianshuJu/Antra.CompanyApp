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
    public class ReviewRepository//:IRepositoryAsync<Review>
    {
        public async Task<int> DeleteAsync(int movieId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM Review WHERE MovieId=@MovieId, UserId=@UserId";
                var result = await connection.ExecuteAsync(cmd, new { MovieId = movieId, UserId = userId });
                return result;
            }
        }
        public async Task<Review> GetByIdAsync(int movieId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Review WHERE MovieId=@MovieId, UserId=@UserId";
                var result = await connection.QueryFirstOrDefaultAsync<Review>(cmd, new { MovieId=movieId, UserId=userId });
                return result;
            }
        }
        public async Task<int> InsertAsync(Review review)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO Review VALUES(@Name, @Gender, @TmdbUrl, @ProfilePath)";
                var result = await connection.ExecuteAsync(cmd, review);
                return result;
            }
        }
        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Review";
                var result = await connection.QueryAsync<Review>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(Review review)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE Review SET Rating=@Rating, ReviewText=@ReviewText WHERE MovieId=@MovieId AND UserId=@UserId";
                var result = await connection.ExecuteAsync(cmd, review);
                return result;
            }
        }

    }
}
