
CREATE VIEW [V_Casting] AS (
	SELECT
		C.*,
		A.[last_name] AS [actor_last_name],
		A.[first_name] AS [actor_first_name],
		A.[birth_date] AS [actor_birth_date],
		A.[image_uri] AS [actor_image_uri],
		M.[title] AS [movie_title]
	FROM [Cast] AS C
	LEFT JOIN [Movie] AS M
		ON C.[movie_id] = M.[id]
	LEFT JOIN [Actor] AS A
		ON C.[actor_id] = A.[id]
);

