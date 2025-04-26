
using Dapper;
using INV.Data.Repository.Interfaces;
using INV.Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace INV.Data.Repository
{
    public class ProductRepository(IConfiguration configuration) : IProductRepository
    {
        private IDbConnection _context;
        private readonly string connection = configuration.GetConnectionString("Default");

        public async Task<int?> Add(Product product)
        {
            using (_context = new SqlConnection(connection))
            {
                try
                {
                    _context.Open();
                    var query = @"
                INSERT INTO Products(Name, Description, Price, Quantity, Available) 
                VALUES (@Name, @Description, @Price, @Quantity, @Available);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"; // <- isso retorna o ID recém-inserido

                    var dp = new DynamicParameters();
                    dp.Add("@Name", product.Name);
                    dp.Add("@Description", product.Description);
                    dp.Add("@Price", product.Price);
                    dp.Add("@Quantity", product.Quantity);
                    dp.Add("@Available", product.Available);

                    var id = await _context.ExecuteScalarAsync<int?>(query, dp);
                    return id; // pode ser nulo se falhar
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public async  Task<IEnumerable<Product>> All()
        {
            using(_context = new SqlConnection(connection))
            {
                try
                {
                    _context.Open();
                    var query = @"SELECT * FROM products";
                    var result = await _context.QueryAsync<Product>(query);

                    return result;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message+ "|" + DateTimeOffset.UnixEpoch.ToString());
                    return Enumerable.Empty<Product>();
                }
            }
        }
    }
}
