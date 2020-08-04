
CREATE VIEW [V_Movie_Category] AS (
	SELECT
		M.*,
		C.[name] AS [category_name]
	FROM [Movie] AS M
	LEFT JOIN [Category] AS C
		ON C.[id] = M.[category_id]
);

