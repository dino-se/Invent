-- Table to store product information
CREATE TABLE [dbo].[Product]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [NAME] VARCHAR(50) NULL, 
    [PRICE] INT NULL, 
    [STOCK] INT NULL, 
    [UNIT] INT NULL, 
    [CATEGORY] VARCHAR(50) NULL
);

-- Table to store category information
CREATE TABLE [dbo].[Category]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CATEGORYITEM] VARCHAR(50) NULL,
);

-- Table to track the history of stock updates
CREATE TABLE [dbo].[History]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PRODUCTID] INT NULL, 
    [ADDED STOCKS] INT NULL, 
    [DATE] DATETIME NULL,
);

-- Table to store items in the shopping cart
CREATE TABLE [dbo].[Cart]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [NAME] VARCHAR(50) NULL, 
    [PRICE] INT NULL, 
    [QUANTITY] INT NULL,
    [PRODUCTID] INT NULL
);

-- Table to store transaction information
CREATE TABLE [dbo].[Transaction]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [DATE] DATETIME NULL, 
    [SUBTOTAL] INT NULL, 
    [CASH] INT NULL, 
    [PERCENT] VARCHAR(50) NULL, 
    [AMOUNT] DECIMAL(18, 2) NULL, 
    [TOTAL] INT NULL, 
    [CHANGE] DECIMAL(18, 2) NULL, 
    [UID] VARCHAR(MAX) NULL,
);

-- Table to store ordered items in a transaction
CREATE TABLE [dbo].[Orders]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UID] VARCHAR(MAX) NULL, 
    [NAME] VARCHAR(50) NULL, 
    [PRICE] INT NULL, 
    [QUANTITY] INT NULL
);
