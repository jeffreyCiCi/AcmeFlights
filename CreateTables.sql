USE [AcmeFlights]
GO

/****** Object:  Table [dbo].[Flights]    Script Date: 30/08/2018 12:42:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Flights](
	[FlightCode] [varchar](10) NOT NULL,
	[FromLocation] [varchar](50) NOT NULL,
	[ToLocation] [nchar](10) NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[FlightCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------------------

USE [AcmeFlights]
GO

/****** Object:  Table [dbo].[AvailableSeats]    Script Date: 30/08/2018 12:40:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AvailableSeats](
	[Date] [date] NOT NULL,
	[FlightCode] [varchar](10) NOT NULL,
	[VacantSeats] [int] NOT NULL,
 CONSTRAINT [PK_AvailableSeats] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[FlightCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AvailableSeats]  WITH CHECK ADD  CONSTRAINT [FK_AvailableSeats_Flights] FOREIGN KEY([FlightCode])
REFERENCES [dbo].[Flights] ([FlightCode])
GO

ALTER TABLE [dbo].[AvailableSeats] CHECK CONSTRAINT [FK_AvailableSeats_Flights]
GO
