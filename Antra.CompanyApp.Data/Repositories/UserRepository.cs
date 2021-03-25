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
    public class UserRepository:IRepositoryAsync<User>
    {
        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "DELETE FROM User WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, new { id = id });
                return result;
            }
        }      
        public async Task<User> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM User WHERE Id=@id";
                var result = await connection.QueryFirstOrDefaultAsync<User>(cmd, new { id = id });
                return result;
            }
        }
        public async Task<int> InsertAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "INSERT INTO User VALUES(@Email, @TwoFactorEnabled, @FirstName, @LastName, @DateOfBirth, @HashedPassword, @Salt, @PhoneNumber, @LockoutEndDate, @LastLoginDateTime, @IsLocked, @AccessFailedCount)";
                var result = await connection.ExecuteAsync(cmd, user);
                return result;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "SELECT * FROM User";
                var result = await connection.QueryAsync<User>(cmd);
                return result;
            }
        }
        public async Task<int> UpdataAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.connectionString))
            {
                string cmd = "UPDATE User SET Email=@Email, TwoFactorEnabled=@TwoFactorEnabled, FirstName=@FirstName, LastName=@LastName, DateOfBirth=@DateOfBirth, HashedPassword=@HashedPassword, Salt=@Salt, PhoneNumber=@PhoneNumber, LockoutEndDate=@LockoutEndDate, LastLoginDateTime=@LastLoginDateTime, IsLocked=@IsLocked, AccessFailedCount=@AccessFailedCount WHERE Id=@id";
                var result = await connection.ExecuteAsync(cmd, user); // new { Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, RunTime, Price, CreatedDate, UpdatedDate, UpdatedBy, CreatedBy }
                return result;
            }
        }
    }
}
