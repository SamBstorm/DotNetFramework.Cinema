CREATE TABLE [dbo].[Category] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)  NOT NULL,
    [description] VARCHAR (255) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UQ_Category_name] UNIQUE NONCLUSTERED ([name] ASC)
);

