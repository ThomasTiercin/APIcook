DROP TABLE [dbo].[Experience] ;
DROP TABLE [dbo].[Education];
DROP TABLE [dbo].[Certification];
DROP TABLE [dbo].[Professional_Skills];
DROP TABLE [dbo].[Personal_Skills];
DROP TABLE [dbo].[Production];


CREATE TABLE [dbo].[Experience] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Title]              VARCHAR (100) NOT NULL,
    [Subtitle]          VARCHAR (200),
    [Detail]          VARCHAR (5000)
);

CREATE TABLE [dbo].[Education] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Title]              VARCHAR (100) NOT NULL,
    [Subtitle]          VARCHAR (200),
    [Detail]          VARCHAR (5000)
);

CREATE TABLE [dbo].[Certification] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Title]              VARCHAR (100) NOT NULL,
    [Subtitle]          VARCHAR (200),
    [Detail]          VARCHAR (5000)
);

CREATE TABLE [dbo].[Professional_Skills] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Name]              VARCHAR (100) NOT NULL
);

CREATE TABLE [dbo].[Personal_Skills] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Name]              VARCHAR (100) NOT NULL
);

CREATE TABLE [dbo].[Production] (
    [Id]         INT PRIMARY KEY   IDENTITY(1,1) NOT NULL,
    [Title]              VARCHAR (100) NOT NULL,
    [Link]              VARCHAR (500) NOT NULL
);

