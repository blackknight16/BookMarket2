declare @TagId INT = 4;
SELECT TOP 5 *
FROM (
	SELECT ROW_NUMBER() OVER(ORDER BY [Books].[Id] ASC) AS Row, [Books].*
	FROM [dbo].[Books]
	WHERE [Books].[Id] IN (
		SELECT [Book_Id]
		FROM [dbo].[BookTagBooks]
		WHERE [BookTag_Id] = (@TagId)
	) /*AS _internal*/
) AS _internal
WHERE [_internal].[Row] > 5
;