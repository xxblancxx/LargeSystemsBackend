-- SQL for creating tables for Ferry Case system.

-- To drop all tables
 --SELECT 'DROP TABLE [' + SCHEMA_NAME(schema_id) + '].[' + name + ']' FROM sys.tables
 --SELECT * FROM sys.tables
-- Use statement above to get a list of drop queries.
-- Might need to run twice given that those with foreign keys will have references in first run.

CREATE TABLE [dbo].[Customer]
(
	[ID] INT NOT NULL PRIMARY KEY, 
	[Name] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL
)
CREATE TABLE [dbo].[TravelingEntity]
(
	[ID] INT NOT NULL PRIMARY KEY
)
CREATE TABLE [dbo].[Passenger] 
(
  	[ID] INT NOT NULL PRIMARY KEY, 
   	[IsLocal] BIT DEFAULT ((0)) NOT NULL,
	[TravelingEntity] INT NOT NULL,
	CONSTRAINT [FK_PASSENGER_ENTITY] FOREIGN KEY ([TravelingEntity]) REFERENCES [TravelingEntity]([ID])
)
CREATE TABLE [dbo].[Vehicle] 
(
    [ID] INT NOT NULL PRIMARY KEY, 
    [IsLargeVehicle] BIT DEFAULT ((0)) NOT NULL,
	[ContainingEntity] INT NOT NULL,
	CONSTRAINT [FK_VEHICLE_ENTITY] FOREIGN KEY ([ContainingEntity]) REFERENCES [TravelingEntity]([ID])
)


CREATE TABLE [dbo].[Ferry]
(
	[ID] INT NOT NULL PRIMARY KEY, 
	[Name] NVARCHAR(50) NOT NULL,
	[PeopleCapacity] INT NOT NULL,
	[VehicleCapacity] INT NOT NULL,
	[WeightCapacity] INT NOT NULL,
	[IsReserve] BIT DEFAULT ((0)) NOT NULL
)
CREATE TABLE [dbo].[Departure]
(
	[ID] INT NOT NULL PRIMARY KEY, 
	[Ferry] INT NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
	CONSTRAINT [FK_DEPARTURE_FERRY] FOREIGN KEY ([Ferry]) REFERENCES [Ferry]([ID])
)

CREATE TABLE [dbo].[Reservation]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[ReservationNumber] INT NOT NULL, 
	[HasArrived] BIT DEFAULT ((0)) NOT NULL,
	[Customer] INT NOT NULL,
	CONSTRAINT [FK_RESERVATION_CUSTOMER] FOREIGN KEY ([Customer]) REFERENCES [Customer]([ID])
	
)
CREATE TABLE [dbo].[Route]
(
	[ID] INT NOT NULL PRIMARY KEY,
 	[Origin] NVARCHAR(50) NOT NULL,
	[Destination] NVARCHAR(50) NOT NULL,
	[Duration] TIME NOT NULL

)
CREATE TABLE [dbo].[Ticket]
(
    [ID] INT NOT NULL PRIMARY KEY,
	[Price] FLOAT NOT NULL, 
    [Reservation] INT NOT NULL, 
	[Route] INT NOT NULL,
	[Departure] INT NOT NULL,
	[TravelingEntity] INT NOT NULL,
 	CONSTRAINT [FK_TICKET_ENTITY] FOREIGN KEY ([TravelingEntity]) REFERENCES [TravelingEntity]([ID]), 
 	CONSTRAINT [FK_TICKET_ROUTE] FOREIGN KEY ([Route]) REFERENCES [Route]([ID]), 	
 	CONSTRAINT [FK_TICKET_DEPARTURE] FOREIGN KEY ([Departure]) REFERENCES [Departure]([ID]), 
	CONSTRAINT [FK_TICKET_RESERVATION] FOREIGN KEY ([Reservation]) REFERENCES [Reservation]([ID]) 
)
