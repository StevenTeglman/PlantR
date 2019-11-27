CREATE TABLE [dbo].[Plant] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [cname]       VARCHAR (255) NOT NULL,
    [lname]       VARCHAR (255) NOT NULL,
    [imgurl]      VARCHAR (255) NOT NULL,
    [description] VARCHAR (255) NOT NULL,
    [sdays]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

