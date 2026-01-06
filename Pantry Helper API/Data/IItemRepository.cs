

using Pantry_Helper_API.Models;

namespace Pantry_Helper_API.Data
{
    public interface IItemRepository
    {
        /*CREATE*/
        Task<int> AddAsync(Item item); // Single item addition returns its newly created ID

        /*READ*/
        Task<Item?> GetByIdAsync(int id); //Nullable - id may no longer be valid
        Task<IEnumerable<Item>> GetAllByBarcodeAsync(string barcode);
        Task<IEnumerable<Item>> GetAllByCategoryAsync(string category);
        Task<IEnumerable<Item>> GetAllExpiredAsync(); // Get all items that are expired
        Task<IEnumerable<Item>> GetAllExpiringSoonAsync(int daysUntilExpiration); // Get all items expiring by given date
        Task<IEnumerable<Item>> GetAllAsync();

        /*UPDATE*/
        Task UpdateAsync(Item item);

        /*DELETE*/
        Task<bool> DeleteAsync(int id); //boolean to indicate success or failure of deletion
        Task<bool> DeleteOldestByBarcodeAsync(string barcode); // Deletes the oldest item belonging to a given barcode
    }
}
