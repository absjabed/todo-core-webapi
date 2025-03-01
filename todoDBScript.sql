USE [ToDoDb0]
GO
/****** Object:  Table [dbo].[TodoTable0]    Script Date: 1/30/2021 10:23:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TodoTable](
	[iAutoID] [int] IDENTITY(1,1) NOT NULL,
	[vUserId] [varchar](100) NOT NULL,
	[vTodoId] [varchar](40) NOT NULL,
	[vTodoTitle] [varchar](100) NULL,
	[vTodoDescription] [varchar](300) NULL,
	[dDate] [date] NULL,
	[tTime] [varchar](20) NULL,
	[vLocation] [varchar](50) NULL,
	[tNotifyTime] [varchar](20) NULL,
	[vColorLabel] [varchar](25) NULL,
	[bIsDone] [bit] NULL,
	[bIsDeleted] [bit] NULL,
	[dDateOfEntry] [datetime] NULL,
 CONSTRAINT [PK_TodoTable] PRIMARY KEY CLUSTERED 
(
	[iAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfoTable]    Script Date: 1/30/2021 10:23:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfoTable](
	[iAutoId] [int] IDENTITY(1,1) NOT NULL,
	[vUserId] [varchar](100) NOT NULL,
	[vPassword] [varchar](20) NULL,
	[vFullName] [varchar](50) NULL,
	[dDateOfBirth] [date] NULL,
	[bIsActive] [bit] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[iAutoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TodoTable] ON 

INSERT [dbo].[TodoTable] ([iAutoID], [vUserId], [vTodoId], [vTodoTitle], [vTodoDescription], [dDate], [tTime], [vLocation], [tNotifyTime], [vColorLabel], [bIsDone], [bIsDeleted], [dDateOfEntry]) VALUES (2, N'absjabed', N'405CF7A5-8C95-4DB2-97C9-D8495B3D025A', N'Automation Script Task', N'Automation Script needs to be prepared for system backup.', CAST(0x63430B00 AS Date), N'08:00 PM#08:30PM', N'CTG, BD', N'20 minutes', N'Teal#29cfbf', 0, 0, CAST(0x0000ACBE00A3E276 AS DateTime))
INSERT [dbo].[TodoTable] ([iAutoID], [vUserId], [vTodoId], [vTodoTitle], [vTodoDescription], [dDate], [tTime], [vLocation], [tNotifyTime], [vColorLabel], [bIsDone], [bIsDeleted], [dDateOfEntry]) VALUES (3, N'absjabed', N'71A0F3A1-49DD-48EB-882C-04BD1C28CF54', N'Add New Todo 1', N'Adding New Todo from API', CAST(0x67430B00 AS Date), N'09:00 PM#08:30PM', N'Dhaka, BD', N'30 minutes', N'Teal#29cfbf', 1, 0, CAST(0x0000ACBE010F55EA AS DateTime))
INSERT [dbo].[TodoTable] ([iAutoID], [vUserId], [vTodoId], [vTodoTitle], [vTodoDescription], [dDate], [tTime], [vLocation], [tNotifyTime], [vColorLabel], [bIsDone], [bIsDeleted], [dDateOfEntry]) VALUES (5, N'noman', N'E5177519-CEB0-44A4-ACE0-EF63425FCF37', N'Add New Todo 2', N'5# Adding New Todo from API', CAST(0x67430B00 AS Date), N'09:00 PM#08:30PM', N'CD, BD', N'10 minutes', N'Teal#29cfbf', 0, 0, CAST(0x0000ACBE0114DBC7 AS DateTime))
INSERT [dbo].[TodoTable] ([iAutoID], [vUserId], [vTodoId], [vTodoTitle], [vTodoDescription], [dDate], [tTime], [vLocation], [tNotifyTime], [vColorLabel], [bIsDone], [bIsDeleted], [dDateOfEntry]) VALUES (6, N'noman', N'88AEB394-F1A1-484E-A200-65581C80B32D', N'## Add New Todo 2', N'5# Adding New Todo from API', CAST(0x67430B00 AS Date), N'09:00 PM#08:30PM', N'CD, BD', N'10 minutes', N'Teal#29cfbf', 0, 1, CAST(0x0000ACBE011E8BAD AS DateTime))
INSERT [dbo].[TodoTable] ([iAutoID], [vUserId], [vTodoId], [vTodoTitle], [vTodoDescription], [dDate], [tTime], [vLocation], [tNotifyTime], [vColorLabel], [bIsDone], [bIsDeleted], [dDateOfEntry]) VALUES (7, N'oneklombamailaddress@ajairamail.com', N'977C9EDE-D770-4BDC-BD09-FE944131F235', N'Add New Todo 1', N'Adding New Todo from API', CAST(0x67430B00 AS Date), N'09:00 PM#08:30PM', N'Dhaka, BD', N'30 minutes', N'Teal#29cfbf', 0, 0, CAST(0x0000ACC000A99F74 AS DateTime))
SET IDENTITY_INSERT [dbo].[TodoTable] OFF
SET IDENTITY_INSERT [dbo].[UserInfoTable] ON 

INSERT [dbo].[UserInfoTable] ([iAutoId], [vUserId], [vPassword], [vFullName], [dDateOfBirth], [bIsActive]) VALUES (1, N'absjabed', N'todo123', N'MD ABS Jabed', CAST(0xBB950A00 AS Date), 1)
INSERT [dbo].[UserInfoTable] ([iAutoId], [vUserId], [vPassword], [vFullName], [dDateOfBirth], [bIsActive]) VALUES (2, N'noman', N'123', N'noman', CAST(0x54210B00 AS Date), 1)
INSERT [dbo].[UserInfoTable] ([iAutoId], [vUserId], [vPassword], [vFullName], [dDateOfBirth], [bIsActive]) VALUES (3, N'akib', N'123', N'akib', CAST(0x54210B00 AS Date), 1)
INSERT [dbo].[UserInfoTable] ([iAutoId], [vUserId], [vPassword], [vFullName], [dDateOfBirth], [bIsActive]) VALUES (4, N'kabila', N'123', N'kabila', CAST(0x54210B00 AS Date), 1)
INSERT [dbo].[UserInfoTable] ([iAutoId], [vUserId], [vPassword], [vFullName], [dDateOfBirth], [bIsActive]) VALUES (5, N'oneklombamailaddress@ajairamail.com', N'123', N'oneklombamailaddress', CAST(0x54210B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[UserInfoTable] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TodoTable]    Script Date: 1/30/2021 10:23:54 AM ******/
ALTER TABLE [dbo].[TodoTable] ADD  CONSTRAINT [IX_TodoTable] UNIQUE NONCLUSTERED 
(
	[vTodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Table]    Script Date: 1/30/2021 10:23:54 AM ******/
ALTER TABLE [dbo].[UserInfoTable] ADD  CONSTRAINT [IX_Table] UNIQUE NONCLUSTERED 
(
	[vUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TodoTable] ADD  CONSTRAINT [DF_TodoTable_vTodoId]  DEFAULT (newid()) FOR [vTodoId]
GO
ALTER TABLE [dbo].[TodoTable] ADD  CONSTRAINT [DF_TodoTable_bIsDone]  DEFAULT ((0)) FOR [bIsDone]
GO
ALTER TABLE [dbo].[TodoTable] ADD  CONSTRAINT [DF_TodoTable_bIsDeleted]  DEFAULT ((0)) FOR [bIsDeleted]
GO
ALTER TABLE [dbo].[TodoTable] ADD  CONSTRAINT [DF_TodoTable_dDateOfEntry]  DEFAULT (getdate()) FOR [dDateOfEntry]
GO
ALTER TABLE [dbo].[UserInfoTable] ADD  CONSTRAINT [DF_UserInfoTable_bIsActive]  DEFAULT ((1)) FOR [bIsActive]
GO
ALTER TABLE [dbo].[TodoTable]  WITH CHECK ADD  CONSTRAINT [FK_TodoTable_TodoTable] FOREIGN KEY([vUserId])
REFERENCES [dbo].[UserInfoTable] ([vUserId])
GO
ALTER TABLE [dbo].[TodoTable] CHECK CONSTRAINT [FK_TodoTable_TodoTable]
GO
