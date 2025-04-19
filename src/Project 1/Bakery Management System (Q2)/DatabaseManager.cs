using Microsoft.Data.SqlClient;

namespace Bakery_Management_System
{
    public class DatabaseManager(string connectionString)
    {
        // Test the database connection
        public bool TestConnection()
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var query = "SELECT * FROM Products";

                // Execute the query and read the results
                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                        Category = reader["Category"]?.ToString() ?? string.Empty,
                        Price = Convert.ToSingle(reader["Price"]),
                        QuantityInStock = Convert.ToInt32(reader["QuantityInStock"]),
                    };
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                // Logging (Because why not?)
                Console.WriteLine($"Error retrieving products: {ex.Message}");
            }

            return products;
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                string query =
                    @"INSERT INTO Products (ProductName, Category, Price, QuantityInStock)
                                   VALUES (@ProductName, @Category, @Price, @QuantityInStock);
                                   SELECT SCOPE_IDENTITY();";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);

                // Get the newly created ID and assign it to the product
                product.ProductID = Convert.ToInt32(command.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                // Logging (Because why not?)
                Console.WriteLine($"Error creating product: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                string query =
                    @"UPDATE Products
                                   SET ProductName = @ProductName,
                                       Category = @Category,
                                       Price = @Price,
                                       QuantityInStock = @QuantityInStock
                                   WHERE ProductID = @ProductID";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Category", product.Category);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);

                var rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Logging (Because why not?)
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var query = "DELETE FROM Products WHERE ProductID = @ProductID";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                var rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Logging (Because why not?)
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> results = new List<Product>();

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                string query =
                    @"SELECT * FROM Products
                                   WHERE ProductName LIKE @SearchTerm
                                   OR Category LIKE @SearchTerm
                                   OR CAST(ProductID AS VARCHAR) LIKE @SearchTerm";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                        Category = reader["Category"]?.ToString() ?? string.Empty,
                        Price = Convert.ToSingle(reader["Price"]),
                        QuantityInStock = Convert.ToInt32(reader["QuantityInStock"]),
                    };
                    results.Add(product);
                }
            }
            catch (Exception ex)
            {
                // Logging (Because why not?)
                Console.WriteLine($"Error searching products: {ex.Message}");
            }

            return results;
        }
    }
}
