using Dapper;
using Pantry_Helper_API.Models;
using System.Data;

namespace Pantry_Helper_API.Data
{
    public class GroceryListItemRepository : IGroceryListItemRepository
    {
        // Depedency injection for connecting to the database
        private readonly IDbConnection _connection;
        public GroceryListItemRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public Task<int> AddAsync(GroceryListItem item)
        {
            string sql = "INSERT INTO GroceryListItems (Name, Barcode, QuantityNeeded, IsPurchased, DateAdded) " +
                "VALUES(@Name, @Barcode, @QuantityNeeded, @IsPurchased, @DateAdded);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            return _connection.QuerySingleAsync<int>(sql, item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string sql = "DELETE FROM GroceryListItems WHERE Id = @Id";
            int rowsAffected = await _connection.ExecuteAsync(sql, id);
            return rowsAffected > 0;
        }

        public Task<IEnumerable<GroceryListItem>> GetAllAsync()
        {
            string sql = "SELECT * FROM GroceryListItems";
            return _connection.QueryAsync<GroceryListItem>(sql);
        }

        public Task<IEnumerable<GroceryListItem>> GetAllUnpurchasedAsync()
        {
            string sql = "SELECT * FROM GroceryListItems WHERE IsPurchased = FALSE";
            return _connection.QueryAsync<GroceryListItem>(sql);
        }

        public Task<IEnumerable<GroceryListItem>> GetAllByCategoryAsync(string category)
        {
            string sql = "SELECT * FROM GroceryListItems WHERE Category = @Category";
            return _connection.QueryAsync<GroceryListItem>(sql, category);
        }

        public Task<GroceryListItem?> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM GroceryListItems WHERE Id = @Id";
            return _connection.QuerySingleOrDefaultAsync<GroceryListItem>(sql, id);
        }

        public async Task<bool> UpdateAsync(GroceryListItem item)
        {
            string sql = "UPDATE GroceryListItems SET QuantityNeeded = @QuantityNeeded, " +
                "IsPurchased = @IsPurchased, " +
                "WHERE Id = @Id";
            int rowsAffected = await _connection.ExecuteAsync(sql, item);
            return rowsAffected > 0;
        }
    }
}
