# Database Setup

## Prerequisites
- SQL Server LocalDB or SQL Server Express
- SQL Server Management Studio (SSMS)

## Setup Instructions

1. Open SSMS and connect to `(localdb)\MSSQLLocalDB`
2. Execute scripts in order:
   - `01_CreateDatabase.sql` - Creates the PantryHelperDB database
   - `02_CreateTables.sql` - Creates Items and GroceryListItems tables

## Connection String

Add this to your `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PantryHelperDB;Trusted_Connection=True;"
}
```

## Database Schema

### Items Table
Stores individual pantry items with auto-ordering options.

### GroceryListItems Table
Stores grocery list entries for shopping purposes.