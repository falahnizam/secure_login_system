CREATE TABLE [dbo].[Login] (
    [LoginID]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (50)  NOT NULL,
    [HashPassword]  VARCHAR (255) NOT NULL,
	[Salt] VARBINARY(16) NOT NULL,
    [LoginTime] DATETIME      NULL,
    [UserID]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([LoginID] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserDetails] ([UserID])
);

