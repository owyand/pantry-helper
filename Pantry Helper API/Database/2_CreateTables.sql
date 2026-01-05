/*
	Script: 2_CreateTables.sql
	Database: PantryHelperDB
	Author: Oliver Wyand
	Date: January 4, 2026

	Description: Creates the tables 'Items' and 'GroceryListItems' on PantryHelperDB for Pantry Helper API
*/

USE PantryHelperDB;
GO

CREATE TABLE Items (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,		-- VARCHAR for performance, English-language products anticipated
	Barcode VARCHAR(20),			-- Barcode length considering UPC/EAN standards
	Category VARCHAR(100),			-- Category length limited, anticipating short phrases
	PurchaseDate DATE NOT NULL,
	ExpirationDate DATE NOT NULL,
	AutoAddToGroceryListWhenTrashed BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE GroceryListItems (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,		-- VARCHAR for performance, English-language products anticipated
	Barcode VARCHAR(20),			-- Barcode length considering UPC/EAN standards
	QuantityNeeded INT NOT NULL DEFAULT 1,
	IsPurchased BIT NOT NULL DEFAULT 0,
	DateAdded DATE NOT NULL			-- Note: date item is added to the grocery list
);
GO