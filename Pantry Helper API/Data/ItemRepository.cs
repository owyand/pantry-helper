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

        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE * FROM Items WHERE ID = @id";
            int rowsAffected = await _connection.ExecuteAsync(sql, new {Id = id});

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteOldestByBarcodeAsync(string barcode)
        {
            string sql = "DELETE FROM Items WHERE Id = (" +
                "SELECT TOP 1 Id FROM Items WHERE Barcode = @Barcode ORDER BY PurchaseDate ASC);";

            int rowsAffected = await _connection.ExecuteAsync(sql, new { Barcode = barcode });
            return rowsAffected > 0;
        }

        public Task<IEnumerable<Item>> GetAllAsync()
        {
            string sql = "SELECT * FROM Items";
            return _connection.QueryAsync<Item>(sql);
        }

        public Task<IEnumerable<Item>> GetAllByBarcodeAsync(string barcode)
        {
            string sql = "SELECT FROM Items WHERE Barcode = @Barcode";
            return _connection.QueryAsync<Item>(sql);
        }

        public Task<IEnumerable<Item>> GetAllByCategoryAsync(string category)
        {
            string sql = "SELECT FROM Items WHERE Category = @Category";
            return _connection.QueryAsync<Item>(sql);
        }

        public Task<IEnumerable<Item>> GetAllExpiredAsync()
        {
            string sql = "SELECT FROM Items WHERE ExpirationDate "; //is expired
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetAllExpiringSoonAsync(int daysUntilExpiration)
        {
            throw new NotImplementedException();
        }

        public Task<Item?> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Items WHERE Id = @id";
            return _connection.QuerySingleOrDefaultAsync<Item>(sql, new {Id = id});
        }

        public Task UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }
        // Implementation of IItemRepository methods would go here
    }
}
