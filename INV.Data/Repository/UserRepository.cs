using Dapper;
using INV.Data.Repository.Interfaces;
using INV.Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace INV.Data.Repository
{
    public class UserRepository(IConfiguration configuration) : IUserRepository
    {
        private IDbConnection _context;
        private readonly string _connection = configuration.GetConnectionString("Default");

        public async Task<bool> RegisterNormalUser(User user)
        {
            using (_context = new SqlConnection(_connection))
            {
                string command = @"
    INSERT INTO users (Name, IsActive, Email, Password, Role)
    VALUES (@Name, @IsActive, @Email, @Password, @Role)";

                var dp = new DynamicParameters();
                dp.Add("@Name", user.Name);
                dp.Add("@IsActive", user.IsActive);
                dp.Add("@Email", user.Email);
                dp.Add("@Password", user.Password);
                dp.Add("@Role", user.Role);

                var result = await _context.ExecuteAsync(command, dp);
                if(result == 1)
                {
                    return true;
                }
                return false;
            }

        }

        public Task<bool> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
