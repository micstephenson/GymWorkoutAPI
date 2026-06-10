USE [Workouts]
GO
/****** Object:  Table [dbo].[GymSessions]    Script Date: 10/06/2026 16:07:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GymSessions](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[SessionDate] [datetime] NULL,
	[OverallDuration] [float] NOT NULL,
	[TrainerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionWorkout]    Script Date: 10/06/2026 16:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionWorkout](
	[SessionID] [int] NOT NULL,
	[WorkoutID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC,
	[WorkoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 10/06/2026 16:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workouts]    Script Date: 10/06/2026 16:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workouts](
	[WorkoutID] [int] IDENTITY(1,1) NOT NULL,
	[WorkoutName] [varchar](100) NULL,
	[WorkoutSets] [int] NULL,
	[Reps] [int] NULL,
	[Duration] [float] NULL,
	[Difficulty] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GymSessions]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[Trainers] ([TrainerID])
GO
ALTER TABLE [dbo].[SessionWorkout]  WITH CHECK ADD FOREIGN KEY([SessionID])
REFERENCES [dbo].[GymSessions] ([SessionID])
GO
ALTER TABLE [dbo].[SessionWorkout]  WITH CHECK ADD FOREIGN KEY([WorkoutID])
REFERENCES [dbo].[Workouts] ([WorkoutID])
GO
