ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Posts_Blogs];

DROP TABLE [dbo].[Posts];

DROP TABLE [dbo].[Blogs];

CREATE TABLE [dbo].[Blogs] (
    [BlogId]    INT            IDENTITY (1, 1) NOT NULL,
    [Author]    NVARCHAR (255) NOT NULL,
    [Date]      NVARCHAR (255) NOT NULL,
    [Name]      NVARCHAR (255) NOT NULL,
    [Permalink] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([BlogId] ASC),
    UNIQUE NONCLUSTERED ([BlogId] ASC)
);

CREATE TABLE [dbo].[Posts] (
    [PostId]    INT            IDENTITY (1, 1) NOT NULL,
    [BlogId]    INT            NOT NULL,
    [Title]     NVARCHAR (255) NOT NULL,
    [Date]      NVARCHAR (255) NOT NULL,
    [Permalink] NVARCHAR (255) NOT NULL,
    [Content]   NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([PostId] ASC),
    UNIQUE NONCLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Posts_Blogs] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blogs] ([BlogId])
);

