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
    public class MovieGenreRepository//: IRepositoryAsync<MovieGenre>
    {
        public async Task<int> DeleteAsync(int movieId, int genreId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM MovieGenre WHERE MovieId=@MovieId, GenreId=@GenreId";
                var result = await connection.ExecuteAsync(cmd, new { MovieId=movieId, GenreId=genreId });
                return result;
            }
        }
        public async Task<MovieGenre> GetByIdAsync(int movieId, int genreId)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM MovieGenre WHERE MovieId=@MovieId, GenreId=@GenreId";
                var result = await connection.QueryFirstOrDefaultAsync<MovieGenre>(cmd, new { MovieId = movieId, GenreId = genreId });
                return result;
            }
        }
        public async Task<int> InsertAsync(MovieGenre movieGenre)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO MovieGenre VALUES(@MovieId, @GenreId)";
                var result = await connection.ExecuteAsync(cmd, movieGenre);
                return result;
            }
        }
        public async Task<IEnumerable<MovieGenre>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM MovieGenre";
                var result = await connection.QueryAsync<MovieGenre>(cmd);
                return result;
            }
        }       
    }
}
