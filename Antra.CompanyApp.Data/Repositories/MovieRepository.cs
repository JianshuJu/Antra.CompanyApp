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
    public class MovieRepository : IRepositoryAsync<Movie>
    {
        //private readonly IRepository<Movie> movieRepository;
        //public MovieRepository()
        //{
        //    movieRepository = new MovieRepository();
        //}

        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM Movie WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, new { id = id });
                return result;
            }
        }
        //public IEnumerable<Movie> GetByConditionAsync()
        //{
        //    using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
        //    {
        //        string cmd = "SELECT * FROM Movie ";
        //        var result = await connection.QueryAsync<Movie>(cmd);
        //        return result;
        //    }
        //}
        public async Task<Movie> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Movie WHERE Id=@id";
                var result = await connection.QueryFirstOrDefaultAsync<Movie>(cmd, new { id = id });
                return result;
            }
        }
        public async Task<int> InsertAsync(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO Movie VALUES(@Title, @Overview, @Tagline, @Budget, @Revenue, @ImdbUrl, @tmdbUrl, @PosterUrl, @BackdropUrl, @OriginalLanguage, @ReleaseDate, @RunTime, @Price, @CreatedDate, @UpdatedDate, UpdatedBy, @CreatedBy)";
                var result = await connection.ExecuteAsync(cmd, movie);
                return result;
            }
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM Movie";
                var result = await connection.QueryAsync<Movie>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE Movie SET Title=@Title, Overview=@Overview, Tagline=@Tagline, Budget=@Budget, Revenue=@Revenue, ImdbUrl=@ImdbUrl, TmdbUrl=@TmdbUrl, PosterUrl=@PosterUrl, BackdropUrl=@BackdropUrl, OriginalLanguage=@OriginalLanguage, ReleaseDate=@ReleaseDate, RunTime=@Runtime, Price=@Price, CreatedDate=@CreatedDate, UpdatedDate=@UpdatedDate, UpdatedBy=@UpdatedBy, CreatedBy=@CreatedBy WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, movie); // new { Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, RunTime, Price, CreatedDate, UpdatedDate, UpdatedBy, CreatedBy }
                return result;
            }
        }


        //public int Delete(Movie item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Movie GetByCondition(string condition)
        //{
        //    throw new NotImplementedException();
        //}

        //public Movie GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Insert(Movie item)
        //{
        //    throw new NotImplementedException();
        //}

        //public int PrintAll(IEnumerable<Movie> lst)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Updata(Movie item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
