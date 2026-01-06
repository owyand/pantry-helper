using Pantry_Helper_API.Models;

namespace Pantry_Helper_API.Data
{
    public interface IGroceryListItemRepository
    {
        /*CREATE*/
        Task<int> AddAsync(GroceryListItem item); // Single addition to grocery list

        /*READ*/
        Task<GroceryListItem?> GetByIdAsync(int id); //Nullable - id may no longer be valid
        Task<IEnumerable<GroceryListItem>> GetAllAsync(); //Returns the grocery list
        Task<IEnumerable<GroceryListItem>> GetAllUnpurchasedAsync();

        /*UPDATE*/
        Task UpdateAsync(GroceryListItem item); 

        /*DELETE*/
        Task<bool> DeleteAsync(int id); //boolean to indicate success or failure of deletion from list
    }
}
