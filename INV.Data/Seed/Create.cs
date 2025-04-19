

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace INV.Data.Seed
{
    public class Create : ICreate
    {
        private IDbConnection _context;
        private readonly IConfiguration _configuration;
        
        public Create(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Create Table
        public async Task CreateTable()
        {
            using(_context = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                try
                {
                    _context.Open();
                    string command = @"
                     IF OBJECT_ID('products', 'U') IS NULL
                       BEGIN
                       CREATE TABLE products (
                           Id INT IDENTITY(1,1) PRIMARY KEY,
                                  Description VARCHAR(250) NOT NULL,
                                  Name VARCHAR(250) NOT NULL,
                                  Price DECIMAL(10,2) NOT NULL,
                                  Quantity INT NOT NULL,
                                  Available BIT);
                        END";

                    await _context.ExecuteAsync(command);
                }
                catch(Exception x)
                {
                    Console.WriteLine(x.Message);
                }
              
            }
        }
        #endregion

        #region Create DB
        public async Task CreateDb()
        {
            using (_context = new SqlConnection(_configuration.GetConnectionString("WithoutDbCreated")))
            {
                try
                {
                    _context.Open();
                    string command = @"IF DB_ID('inventory') IS NULL
                                     BEGIN
                                       CREATE DATABASE inventory
                                     END";

                    await _context.ExecuteAsync(command);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }

            }
        }
        #endregion
    }
}
