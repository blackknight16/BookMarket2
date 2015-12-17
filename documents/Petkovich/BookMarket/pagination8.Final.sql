CREATE PROCEDURE [dbo].[GetAllBooksByTagId] @TagId int, @FromVal int, @Increment int AS  
/*declare @TagId INT = 1;*/
SELECT *
FROM [dbo].[Books]
WHERE [dbo].[Books].[Id] = (
SELECT [Book_Id]
FROM [dbo].[BookTagBooks]
WHERE [Book_Id] = [dbo].[Books].[Id] AND [BookTag_Id] = (@TagId))
ORDER BY [Id] 
OFFSET (@FromVal) ROWS
FETCH NEXT (@Increment) ROWS ONLY;