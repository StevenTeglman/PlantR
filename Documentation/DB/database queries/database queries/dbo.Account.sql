CREATE TABLE [dbo].[Account] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [email] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

