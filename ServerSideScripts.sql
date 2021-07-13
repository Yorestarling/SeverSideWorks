Create database NewsServerSide

Go

CREATE TABLE Categories
(
CategoryId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CategoryId PRIMARY KEY, 
CategoryName VARCHAR(30) NOT NULL,
);
GO

CREATE TABLE Sources
(
SourcesId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_SourcesId PRIMARY KEY, 
SourcesName VARCHAR(30) NOT NULL,
);
GO


CREATE TABLE Countries
(
CountriesId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CountriesId PRIMARY KEY, 
ContriesName VARCHAR(70) NOT NULL,
);
GO


CREATE TABLE Articles
(
	ArticleId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ArticleId PRIMARY KEY,
	Author Nvarchar(60),
	Title NVARCHAR(255) NOT NULL,
	descriptions NVARCHAR(MAX),
	ulr nvarchar(max),
	ulrToImage nvarchar(max),
	PublishedAt DATETIME,	
	Content NVARCHAR(MAX),
	SourcesId INT NOT NULL CONSTRAINT FK_SourcesIds FOREIGN KEY REFERENCES Sources(SourcesId),
	CategoryId INT NOT NULL CONSTRAINT FK_CategoryId FOREIGN KEY REFERENCES Categories(CategoryId),	
	CountriesId INT NOT NULL CONSTRAINT FK_CountriesId FOREIGN KEY REFERENCES Countries(CountriesId),	
);
GO

Select * from Articles



--Insert  into Sources values 
--('CNN'),
--('BBC News')

--Insert  into Categories values 
--('General'),
--('Business'),
--('Entertainment'),
--('Sealth'),
--('Science'),
--('Sports'),
--('Technology')


--Insert  into Countries values 
--('Austria'),
--('Belgium'),
--('Brazil'),
--('Bulgaria'),
--('Canada'),
--('China'),
--('Colombia'),
--('Cuba'),
--('Czech Republic'),
--('Egypt'),
--('France'),
--('Germany'),
--('Greece'),
--('Hong Kong'),
--('Hungary'),
--('India'),
--('Indonesia'),
--('Ireland'),
--('Israel'),
--('Italy'),
--('Japan'),
--('Latvia'),
--('Lithuania'),
--('Malaysia'),
--('Mexico'),
--('Morocco'),
--('Netherlands'),
--('New Zealand'),
--('Nigeria'),
--('Norway'),
--('Philippines'),
--('Poland'),
--('Portugal'),
--('Romania'),
--('Russian Federation'),
--('Saudi Arabia'),
--('Serbia'),
--('Singapore'),
--('Slovakia'),
--('Slovenia'),
--('South Africa'),
--('Korea'),
--('Sweden'),
--('Switzerland'),
--('Taiwan'),
--('Thailand'),
--('Turkey'),
--('Ukraine'),
--('United Arab Emirates'),
--('United Kingdom of Great Britain and Northern Ireland'),
--('United States of America'),
--('Venezuela')