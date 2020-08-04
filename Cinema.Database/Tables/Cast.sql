CREATE TABLE [dbo].[Cast] (
    [movie_id]       INT           NOT NULL,
    [actor_id]       INT           NOT NULL,
    [character_name] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Cast] PRIMARY KEY CLUSTERED ([movie_id] ASC, [actor_id] ASC),
    CONSTRAINT [FK_Cast_Actor] FOREIGN KEY ([actor_id]) REFERENCES [dbo].[Actor] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Cast_Movie] FOREIGN KEY ([movie_id]) REFERENCES [dbo].[Movie] ([id]) ON DELETE CASCADE
);

