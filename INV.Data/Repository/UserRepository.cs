using Dapper;
using INV.Data.Repository.Interfaces;
using INV.Data.Results;
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

        public async Task<User?> Login(string email, string password)
        {
            using(_context = new SqlConnection(_connection))
            {
                string query = @"SELECT * FROM users WHERE Email = @Email AND Password = @Password";

                var dp = new DynamicParameters();

                dp.Add("@Email", email);
                dp.Add("@Password", password);

                return await _context.QueryFirstOrDefaultAsync<User>(query, dp);
            }
        }

        public async Task<ResultServices> RegisterNormalUser(User user)
        {
            using (_context = new SqlConnection(_connection))
            {
                string command = @"
INSERT INTO users (Id, Name, IsActive, Email, Password, Role)
VALUES (@Id, @Name, @IsActive, @Email, @Password, @Role);";

                Guid newId = Guid.NewGuid(); 

                var dp = new DynamicParameters();
                dp.Add("@Id", newId);
                dp.Add("@Name", user.Name);
                dp.Add("@IsActive", user.IsActive);
                dp.Add("@Email", user.Email);
                dp.Add("@Password", user.Password);
                dp.Add("@Role", user.Role);

                try
                {
                    await _context.ExecuteAsync(command, dp);

                    ResultServices resultService = new()
                    {
                        HasError = false,
                        Message = "User successfully created",
                        _Entity = newId
                    };
                    return resultService;
                }
                catch (Exception x)
                {
                    return new ResultServices()
                    {
                        HasError = true,
                        Message = x.Message,
                        _Entity = null
                    };
                }
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
