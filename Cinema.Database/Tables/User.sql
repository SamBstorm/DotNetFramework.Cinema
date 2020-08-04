CREATE TABLE [dbo].[User] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [login]            VARCHAR (255)  NOT NULL,
    [email]            VARCHAR (255)  NOT NULL,
    [last_name]        VARCHAR (50)   NOT NULL,
    [first_name]       VARCHAR (50)   NOT NULL,
    [encoded_password] VARBINARY (64) NOT NULL,
    [salt]             VARCHAR (255)  NOT NULL,
    [role]             VARCHAR (25)   DEFAULT ('SIMPLE_USER') NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UQ_User_email] UNIQUE NONCLUSTERED ([email] ASC),
    CONSTRAINT [UQ_User_login] UNIQUE NONCLUSTERED ([login] ASC),
    CONSTRAINT [UQ_User_salt] UNIQUE NONCLUSTERED ([salt] ASC)
);

