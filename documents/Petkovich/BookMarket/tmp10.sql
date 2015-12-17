declare @Name nvarchar(max) = 'Book1', 
@Year int = 2015, 
@PageCount int = 1, 
@ImageName nvarchar(max) = 'IMG.img', 
@Description nvarchar(max) = 'description', 
@LanguageId int = 1
;
/*CREATE PROCEDURE [dbo].[AddBook] @Name nvarchar(max), @Year int, @PageCount int, @ImageName nvarchar(max), @Description ntext, @LanguageId int AS  */
INSERT INTO [dbo].[Books]([Name], [Year], [PageCount], [ImageName], [Description], [LanguageId])
OUTPUT [Inserted].*
 VALUES(
(@Name), (@Year), (@PageCount), (@ImageName), (@Description), (@LanguageId))