SET IDENTITY_INSERT [dbo].[Blogs] ON
INSERT INTO [dbo].[Blogs] ([BlogId], [Author], [Date], [Name], [Permalink]) VALUES (1, N'astroguy343', N'2020-12-28T13:37:47-0400', N'Outer Space Factoids', N'https://localhost:4954/blogs/outer-space-factoids/')
INSERT INTO [dbo].[Blogs] ([BlogId], [Author], [Date], [Name], [Permalink]) VALUES (2, N'astroguy343', N'2020-12-28T11:07:49-0400', N'Blog About my Dog', N'https://localhost:4954/blogs/blog-about-my-dog/')
SET IDENTITY_INSERT [dbo].[Blogs] OFF
