CREATE TABLE [dbo].[UserDetails] (
    [UserID]    INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [RoleId]    INT          NOT NULL,
    [DOB]       DATE         NOT NULL,
    [CreatedAt] DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) -- Foreign key constraint
);
