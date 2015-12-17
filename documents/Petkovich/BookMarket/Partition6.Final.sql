/*CREATE PROCEDURE [dbo].[GetAllBooksByTagId] @TagId int, @FromVal int, @ToVal int AS  
BEGIN*/
declare @TagId INT = 1,
 @FromVal INT = 1,
 @ToVal INT = 5,
 @BooksCount INT;
exec dbo.GetAllBooksCountByTagId 1, @BooksCount out;
IF (@ToVal) > @BooksCount
SET @ToVal = @BooksCount;

/* Если закончился результирующие строки, return NULL */
exec ('ALTER SEQUENCE BookSequence  RESTART WITH ' + @FromVal + ' INCREMENT BY 1 MINVALUE ' + @FromVal + ' MAXVALUE ' + @BooksCount + ' NO CYCLE ');

/*declare @TagId INT = 1*/
if object_id('[dbo].[T1]', 'U') IS NOT NULL
	DROP TABLE [dbo].[T1];
CREATE TABLE T1(
Row INT,
Id1 INT NOT NULL,
Name NVARCHAR(MAX) NULL,
Year INT NOT NULL,
PageCount INT NOT NULL,
ImageName NVARCHAR(MAX) NULL,
Description NTEXT NULL,
LanguageId INT NOT NULL
);
/*SET IDENTITY_INSERT [dbo].[Books] ON;*/

WITH my2 AS
(
SELECT ROW_NUMBER() OVER(ORDER BY [BookTagBooks].[Book_Id] ASC) AS Row,
[Book_Id] 
FROM [dbo].[BookTagBooks]
WHERE [BookTag_Id] = (@TagId)
)
INSERT INTO [dbo].[T1]
SELECT
NEXT VALUE FOR [dbo].[BookSequence], [Books].[Id],
[Books].[Name], [Year], [PageCount], [ImageName], [Description], [LanguageId]
FROM [dbo].[Books]
WHERE [Books].[Id] IN (
SELECT 
[BookTagBooks].[Book_Id] 
FROM [dbo].[BookTagBooks], [my2], [sys].[sequences]
WHERE [BookTagBooks].[Book_Id] = [my2].[Book_Id] AND 
[my2].[Row] BETWEEN (CONVERT(INT, [sys].[sequences].[current_value])) AND (@ToVal));

SELECT [Row], [Id1], [Name], [Year], [PageCount], [ImageName], [Description], [LanguageId]
FROM [dbo].[T1];

/*END;*/