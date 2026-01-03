namespace Pantry_Helper_API
{
    public class Item
    {
        // Properties for identification
        public int Id { get; set; }
        /*ItemName maps to DB correctly with Dapper*/
        public string ItemName { get; set; } = string.Empty;
        public string? Barcode { get; set; }
        /*[Fridge, Freezer, Pantry, Other]*/
        public string? Category { get; set; }


        // Properties for inventory management
        public DateOnly PurchaseDate { get; set; }
        public DateOnly ExpirationDate { get; set; }


        // Properties for grocery list management
        public bool AutoAddToGroceryListWhenTrashed { get; set; }
    }
}
