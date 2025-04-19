

using Dapper;
using INV.Data.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace INV.Data.Repository
{
    public class ProductRepository(IConfiguration configuration) : IProductRepository
    {
        private readonly IConfiguration _configuration = configuration;
        private IDbConnection _context;

        public async Task<bool> Add(Product product)
        {
           
            using(_context = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                try
                {
                    _context.Open();
                    var query = "INSERT INTO Products(Name,Description,Price,Quantity,Available) " +
                        $"VALUES (@Name" +
                        $",@Description" +
                        $",@Price," +
                        $"'@Quantity'," +
                        $"'@Available');";
                    var dp = new DynamicParameters();

                    dp.Add("@Name", product.Name);
                    dp.Add("@Description", product.Description);
                    dp.Add("@Price", product.Price);
                    dp.Add("@Quantity", product.Quantity);
                    dp.Add("@Available", product.Available);

                    await _context.ExecuteAsync(query, dp);

                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
              
            }
        }
    }
}
