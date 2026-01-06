using Pantry_Helper_API.Models;
using System.Data;

namespace Pantry_Helper_API.Data
{
    public class GroceryListItemRepository : IGroceryListItemRepository
    {
        private readonly IDbConnection _connection;
        public GroceryListItemRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public Task<int> AddAsync(Models.GroceryListItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroceryListItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroceryListItem>> GetAllUnpurchasedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GroceryListItem?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GroceryListItem item)
        {
            throw new NotImplementedException();
        }
    }
}
