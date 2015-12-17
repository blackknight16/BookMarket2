USE [BookMarketDb]
declare @incrementVal INT = 4
if object_id('[dbo].[T1]', 'U') IS NOT NULL
	DROP TABLE [dbo].[T1];
CREATE TABLE T1(
Id INT, 
Name NVARCHAR(MAX),
Year INT,
PageCount INT,
ImageName NVARCHAR(MAX),
Description NVARCHAR(MAX),
LanguageId INT);
INSERT INTO [dbo].[T1]
SELECT NEXT VALUE FOR [dbo].[BookSequence], [Name], [Year], [PageCount], [ImageName], [Description], [LanguageId]
FROM (
SELECT [Books].[Id], [Books].[Name], [Books].[Year], [Books].[PageCount], [Books].[ImageName], [Books].[Description], [Books].[LanguageId]
FROM [dbo].[Books], [sys].[sequences]
/*ORDER BY [Books].[Id]
OFFSET 0 ROWS FETCH FIRST 5 ROWS ONLY) AS D;*/
WHERE [Books].[Id] BETWEEN (CONVERT(INT, [sys].[sequences].[current_value])) AND (CONVERT(INT, [sys].[sequences].[current_value])+@incrementVal) ) AS D;
SELECT [Id], [Name], [Year], [PageCount], [ImageName], [Description], [LanguageId]
FROM [dbo].[T1];