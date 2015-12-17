USE [BookMarketDb]
declare @incrementVal INT = 79
if object_id('[dbo].[T1]', 'U') IS NOT NULL
	DROP TABLE [dbo].[T1];
CREATE TABLE T1(
Id INT,
Name NVARCHAR(MAX));
INSERT INTO [dbo].[T1]
SELECT NEXT VALUE FOR [dbo].[BookSequence] /*OVER(ORDER BY [Name] ASC)*/, [Name]
FROM (
SELECT [Books].[Id], [Books].[Name]
FROM [dbo].[Books], [sys].[sequences]
/*ORDER BY [Books].[Id]
OFFSET 0 ROWS FETCH FIRST 5 ROWS ONLY) AS D;*/
WHERE [Books].[Id] BETWEEN (CONVERT(INT, [sys].[sequences].[current_value])) AND (CONVERT(INT, [sys].[sequences].[current_value])+@incrementVal) ) AS D;
SELECT *
FROM [dbo].[T1];