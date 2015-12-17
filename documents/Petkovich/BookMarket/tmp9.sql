/*declare @List TABLE(Id INT);*/
/*CREATE TYPE MyCat AS TABLE
(Id INT);
GO*/
CREATE PROCEDURE [dbo].[GetAllBooks1] (@List MyCat OUTPUT READONLY) AS  
BEGIN
SET NOCOUNT ON
INSERT INTO @List(Id)
SELECT [Id]
FROM [dbo].[Books];
/*select @List;*/
END