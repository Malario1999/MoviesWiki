CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Image] NVARCHAR(50) NULL, 
    [ReleaseYear] CHAR(10) NULL, 
    PlatformIcons VARCHAR(MAX)
)
