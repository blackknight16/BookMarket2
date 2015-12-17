USE [BookMarketDb]
declare @incrementVal INT = 4
declare @TagId INT = 3
if object_id('[dbo].[T1]', 'U') IS NOT NULL
	DROP TABLE [dbo].[T1];
CREATE TABLE T1(
Row INT,
Id INT, 
Name NVARCHAR(MAX),
Year INT,
PageCount INT,
ImageName NVARCHAR(MAX),
Description NVARCHAR(MAX),
LanguageId INT);
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
[my2].[Row] BETWEEN (CONVERT(INT, [sys].[sequences].[current_value])) AND (CONVERT(INT, [sys].[sequences].[current_value])+@incrementVal));

SELECT [Row], [Id], [Name], [Year], [PageCount], [ImageName], [Description], [LanguageId]
FROM [dbo].[T1];