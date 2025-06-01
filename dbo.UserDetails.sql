CREATE TABLE [dbo].[UserDetails] (
    [UserID]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]        VARCHAR (50)  NOT NULL,
    [LastName]         VARCHAR (50)  NOT NULL,
    [DOB]              DATE          NOT NULL,
    [CreatedAt]        DATETIME      DEFAULT (getdate()) NOT NULL,
    [RoleID]           INT           NULL,
    [ProfileImagePath] VARCHAR (255) NULL,
    [Bio]              TEXT          NULL,
    [Gender]           NVARCHAR (50) NULL,
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);

