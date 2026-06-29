using Pantry_Helper_API.Models;

namespace Pantry_Helper_API.Data
{
    public interface IGroceryListItemRepository
    {
        /*CREATE*/
        Task<int> AddAsync(GroceryListItem item); // Single addition to grocery list

        /*READ*/
        Task<GroceryListItem?> GetByIdAsync(int id); //Nullable - id may no longer be valid
        Task<IEnumerable<GroceryListItem>> GetAllByCategoryAsync(string category);
        Task<IEnumerable<GroceryListItem>> GetAllAsync(); //Returns the grocery list
        Task<IEnumerable<GroceryListItem>> GetAllUnpurchasedAsync();

        /*UPDATE*/
        Task<bool> UpdateAsync(GroceryListItem item); //mark as purchased or update quantity needed

        /*DELETE*/
        Task<bool> DeleteAsync(int id); //boolean to indicate success or failure of deletion from list
    }
}
