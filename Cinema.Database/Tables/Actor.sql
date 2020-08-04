CREATE TABLE [dbo].[Actor] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [last_name]  VARCHAR (50)  NOT NULL,
    [first_name] VARCHAR (50)  NOT NULL,
    [birth_date] DATE          NULL,
    [image_uri]  VARCHAR (255) NULL,
    CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED ([id] ASC)
);

