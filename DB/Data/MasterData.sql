USE [urvi]
GO
INSERT [dbo].[category_master] ([id], [name]) VALUES (1, N'Lentils')
GO
INSERT [dbo].[category_master] ([id], [name]) VALUES (2, N'Frozen')
GO
INSERT [dbo].[category_master] ([id], [name]) VALUES (3, N'Snacks')
GO
INSERT [dbo].[category_master] ([id], [name]) VALUES (4, N'Flour')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (1, N'Indya')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (2, N'Britania')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (3, N'Ashoka')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (4, N'Deep')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (5, N'Priya')
GO
INSERT [dbo].[brand_master] ([id], [name]) VALUES (6, N'Haldiram')
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (1, N'Toor Dal', N'This is toor dal description', 1, 5, 4, N'1 Kg', 1)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (2, N'Toor Dal', N'This is toor dal description', 1, 5, 20, N'5 Kg', 1)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (3, N'Moong Dal', N'This is moong dal description', 1, 5, 30, N'5 Kg', 1)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (4, N'Medu Wada', N'This is medu wada description', 2, 3, 7, N'250 Gram', 3)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (5, N'Idli', N'This is idli description', 2, 5, 5, N'500 Gram', 3)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (6, N'Idli', N'This is haldiram idli description', 2, 3, 7, N'250 Gram', 6)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (7, N'Aloo Bhujiya', N'This is Aloo Bhujiya description', 3, 15, 1, N'250 Gram', 6)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (8, N'Masala Peanuts', N'This is Masala Peanuts description', 3, 10, 2, N'150 Gram', 6)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (9, N'Masala Peanuts', N'This is Masala Peanuts description', 3, 20, 3, N'250 Gram', 6)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (10, N'Khari', N'This is Khari description', 3, 4, 5, N'400 Gram', 2)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (11, N'Toast', N'This is Toast description', 3, 11, 4, N'200 Gram', 2)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (12, N'Bajari', N'This is Bajari description', 4, 12, 7, N'900 Gram', 1)
GO
INSERT [dbo].[product_master] ([id], [name], [description], [category_id], [quantity], [price], [size], [brand_id]) VALUES (13, N'Ragi', N'This is Ragi description', 4, 4, 6, N'450 Gram', 1)
GO
