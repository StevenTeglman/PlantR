CREATE TABLE [dbo].[PersonalPlant] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [pid]         INT           NOT NULL,
    [aid]         INT           NOT NULL,
    [nname]       VARCHAR (255) NOT NULL,
    [lastwatered] DATE          NOT NULL,
    [nextwatered] DATE          NOT NULL,
    [wduration]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([pid]) REFERENCES [dbo].[Plant] ([id]),
    FOREIGN KEY ([aid]) REFERENCES [dbo].[Account] ([id])
);

