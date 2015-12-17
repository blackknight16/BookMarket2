SELECT *
FROM (
	SELECT Top 30 *
	FROM (
		SELECT TOP 90 *
		FROM [dbo].[Books]
	) AS internal
	ORDER BY internal.Id DESC
) AS _external
ORDER BY _external.Id
