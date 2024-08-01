using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProductManagementSystem_MVC.Models;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        using (var connection = Connection)
        {
            return await connection.QueryAsync<Product>("SELECT * FROM Products");
        }
    }

    public async Task<Product> GetProductById(int id)
    {
        using (var connection = Connection)
        {
            return await connection.QueryFirstOrDefaultAsync<Product>(
                "SELECT * FROM Products WHERE ProductId = @Id", new { Id = id });
        }
    }

    public async Task<int> AddProduct(Product product)
    {
        using (var connection = Connection)
        {
            var sql = "INSERT INTO Products (Name, Description, Price, Stock) VALUES (@Name, @Description, @Price, @Stock)";
            return await connection.ExecuteAsync(sql, product);
        }
    }

    public async Task<int> UpdateProduct(Product product)
    {
        using (var connection = Connection)
        {
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Stock = @Stock WHERE ProductId = @ProductId";
            return await connection.ExecuteAsync(sql, product);
        }
    }


    public async Task<int> DeleteProduct(int id)
    {
        using (var connection = Connection)
        {
            var sql = "DELETE FROM Products WHERE ProductId = @Id";
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
