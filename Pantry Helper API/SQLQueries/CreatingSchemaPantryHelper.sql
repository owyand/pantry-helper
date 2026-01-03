CREATE DATABASE PantryHelperDB

CREATE TABLE Items (
	Id int PRIMARY KEY IDENTITY(1,1),
	ItemName varchar(255) NOT NULL,
	Barcode varchar(255),
	Category varchar(255),
	PurchaseDate date NOT NULL,
	ExpirationDate date NOT NULL,
	AutoAddToGroceryListWhenTrashed BIT,
);

INSERT INTO Items (ItemName, PurchaseDate, ExpirationDate) 
	VALUES('TestItem', '0010-10-01', '1101-01-10');

SELECT * FROM Items
