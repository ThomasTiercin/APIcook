DROP TABLE [dbo].[RecipeIngredient] ;
DROP TABLE [dbo].[Recipe] ;
DROP TABLE [dbo].[Ingredient] ;
DROP TABLE [dbo].[Measure];


CREATE TABLE [dbo].[Recipe] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Name]              VARCHAR (100) NOT NULL,
    [Description]          VARCHAR (200),
    [Instructions]          VARCHAR (200),
    [CreatedDate]        DATETIME      NOT NULL
);

CREATE TABLE [dbo].[Ingredient] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1)     NOT NULL,
    [Name]              VARCHAR (100) NOT NULL
);

CREATE TABLE [dbo].[Measure] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1)   NOT NULL,
    [Name]              VARCHAR (100) NOT NULL,
);
CREATE TABLE [dbo].[RecipeIngredient] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [RecipeId]         INT  NOT NULL,
    [IngredientId]         INT  NOT NULL,
    [MeasureId]         INT  ,
    [Amount]         BIGINT        ,
        CONSTRAINT fk_recipe FOREIGN KEY(RecipeId) REFERENCES Recipe(Id), 
	CONSTRAINT fk_ingredient FOREIGN KEY(IngredientId) REFERENCES Ingredient(Id), 
	CONSTRAINT fk_measure FOREIGN KEY(MeasureId) REFERENCES Measure(Id) 
);
