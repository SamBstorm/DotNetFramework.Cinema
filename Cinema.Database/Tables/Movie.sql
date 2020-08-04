CREATE TABLE [dbo].[Movie] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [title]        VARCHAR (100)  NOT NULL,
    [synopsis]     NVARCHAR (MAX) NULL,
    [release_year] INT            NULL,
    [poster_uri]   VARCHAR (255)  NULL,
    [category_id]  INT            NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Movie_Category] FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category] ([id]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Movie_title]
    ON [dbo].[Movie]([title] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Movie_release_year]
    ON [dbo].[Movie]([release_year] ASC);

