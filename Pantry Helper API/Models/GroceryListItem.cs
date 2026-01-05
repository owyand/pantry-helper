namespace Pantry_Helper_API.Models
{
    public class GroceryListItem
    {
        // Properties for identification
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Barcode { get; set; }

        //Properties for grocery list management
        public int QuantityNeeded { get; set; }
        public bool IsPurchased { get; set; }
        public DateOnly DateAdded { get; set; }


    }
}
