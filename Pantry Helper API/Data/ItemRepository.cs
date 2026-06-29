using Pantry_Helper_API.Models;
using System.Data;
using Dapper;

namespace Pantry_Helper_API.Data
{
    public class ItemRepository : IItemRepository
    {
        // Depedency injection for connecting to the database
        private readonly IDbConnection _connection;
        public ItemRepository(IDbConnection connection) { _connection = connection; }

        //Create a new item in the database and return the new item's ID
        public Task<int> AddAsync(Item item)
        {
            string sql = "INSERT INTO Items (Name, Barcode, Category, PurchaseDate, ExpirationDate, AutoAddToGroceryListWhenTrashed) " +
                "VALUES(@Name, @Barcode, @Category, @PurchaseDate, @ExpirationDate, @AutoAddToGroceryListWhenTrashed);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            
            return _connection.QuerySingleAsync<int>(sql, new
            {
                Name = item.Name,
                Barcode = item.Barcode,
                Category = item.Category,
                PurchaseDate = item.PurchaseDate,
                ExpirationDate = item.ExpirationDate,
                AutoAddToGroceryListWhenTrashed = item.AutoAddToGroceryListWhenTrashed
            });
        }

        // Delete an item from the database by its ID
        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE FROM Items WHERE Id = @Id";
            int rowsAffected = await _connection.ExecuteAsync(sql, new {Id = id});

            return rowsAffected > 0;
        }

        // Delete the oldest item with a specific barcode from the database
        public async Task<bool> DeleteOldestByBarcodeAsync(string barcode)
        {
            string sql = "DELETE FROM Items WHERE Id = (" +
                "SELECT TOP 1 Id FROM Items WHERE Barcode = @Barcode ORDER BY PurchaseDate ASC);";

            int rowsAffected = await _connection.ExecuteAsync(sql, new { Barcode = barcode });
            return rowsAffected > 0;
        }

        // Get all items from the database
        public Task<IEnumerable<Item>> GetAllAsync()
        {
            string sql = "SELECT * FROM Items";
            return _connection.QueryAsync<Item>(sql);
        }

        // Get all items with a specific barcode from the database
        public Task<IEnumerable<Item>> GetAllByBarcodeAsync(string barcode)
        {
            string sql = "SELECT * FROM Items WHERE Barcode = @Barcode";
            return _connection.QueryAsync<Item>(sql, new { Barcode = barcode });
        }

        // Get all items with a specific category from the database
        public Task<IEnumerable<Item>> GetAllByCategoryAsync(string category)
        {
            string sql = "SELECT * FROM Items WHERE Category = @Category";
            return _connection.QueryAsync<Item>(sql, new { Category = category });
        }

        // Get all expired items from the database
        public Task<IEnumerable<Item>> GetAllExpiredAsync()
        {
            string sql = "SELECT * FROM Items WHERE ExpirationDate < GETDATE()";
            return _connection.QueryAsync<Item>(sql);
        }

        // Get all items that will expire within a given number of days from the database
        public Task<IEnumerable<Item>> GetAllExpiringSoonAsync(int daysUntilExpiration)
        {
            string sql = "SELECT * FROM Items WHERE ExpirationDate >= GETDATE() AND ExpirationDate <= DATEADD(day, @DaysUntilExpiration, GETDATE())";
            return _connection.QueryAsync<Item>(sql, new { DaysUntilExpiration = daysUntilExpiration });
        }

        // Get an item by its ID from the database
        public Task<Item?> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Items WHERE Id = @Id";
            return _connection.QuerySingleOrDefaultAsync<Item>(sql, new {Id = id});
        }

        // Make changes to an existing item in the database
        public async Task<bool> UpdateItemAsync(Item item)
        {
            string sql = "UPDATE Items SET Name = @Name, " +
                "Category = @Category, " +
                "PurchaseDate = @PurchaseDate, " +
                "ExpirationDate = @ExpirationDate, " +
                "AutoAddToGroceryListWhenTrashed = @AutoAddToGroceryListWhenTrashed " +
                "WHERE Id = @Id";
            int rowsAffected = await _connection.ExecuteAsync(sql, item);
            return rowsAffected > 0;
        }

    }
}
