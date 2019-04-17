
drop table [Ragnar].[dbo].[LegRunner] 
go

drop table [Ragnar].[dbo].[Team] 
go
drop table [Ragnar].[dbo].[Runner] 
go
drop table [Ragnar].[dbo].[Leg] 
go
drop table [Ragnar].[dbo].[Exchanges] 
go

create table [Ragnar].[dbo].[Team] 
(
	[TeamID] int not null identity constraint [Team PK] primary key ,
	[Name] varchar(200)
)
go

create table [Ragnar].[dbo].[Runner] 
(
	[RunnerID] int not null identity constraint [Runner PK] primary key, 
	[Name] varchar(100),
	[DisplayName] varchar(100), 
	[Pace] decimal(5, 2), 
	[Cell] varchar(20), 
	[Email] varchar(100),
	[EmergencyContact] varchar(100),
	Type int
)
go

create table [Ragnar].[dbo].[Leg]
(
	[LegID] int not null constraint [Leg PK] primary key, 
	[Order] int, 
	[Van] int, 
	[Distance] decimal(6,2),
	[Difficulty] int
)
go


create table [Ragnar].[dbo].[Exchanges]
(
	[Id] int not null constraint [Exchanges PK] primary key,
	[Name] [varchar](200) NULL,
	[Address] [varchar](200) NULL,
	[Van] [int] NULL,
	[Latitude] [varchar](20) NULL,
	[Longitude] [varchar](20) NULL
)
go


create table [Ragnar].[dbo].[LegRunner]
(
	[LegRunnerID] int not null constraint [LegRunner PK] primary key,
	[TeamID] int constraint [LegRunner FK1] foreign key references [Team],
	[LegID] int constraint [LegRunner FK2] foreign key references [Leg],
	[StartTime] date,
	[EndTime] date,
	[Runner1ID] int constraint [LegRunner FK3] foreign key references [Runner],
	[Runner2ID] int constraint [LegRunner FK4] foreign key references [Runner],
	[Pace] decimal(5, 2)
)
go




delete exchanges;

INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('0', 'Waukegan Sports Park', '3391 W Beach Rd, Waukegan, IL 60085', '42.418895', '-87.885220', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('1', 'Christ Community Church', '2500 Dowie Memorial Dr, Zion, IL 60099', '42.448798671', '-87.834122088', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('2', 'Village Park', '2700 9th St, Winthrop Harbor, IL 60096', '42.479123', '-87.834782', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('3', 'Anderson Park', '8730 22nd Ave, Kenosha, WI 53143', '42.547787617', '-87.836356653', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('4', 'Pennoyer Park', '3601 7th Ave, Kenosha, WI 53140', '42.605369261', '-87.819596182', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('5', 'Trail Head', '3177 Chicory Rd, Racine, WI 53403', '42.682140678', '-87.816858574', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('6', 'Pershing Park', '783 Pershing Park, Racine, WI 53403', '42.724535', '-87.778962', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('7', 'Cliffside Park', '7320 Michna Rd, Racine, WI 53402', '42.81918994', '-87.817973499', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('8', 'Crawford Park', '5199 Chester Ln, Racine, WI 53402', '42.787637731', '-87.805404249', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('9', 'Parkway Apostolic Church', '10940 Nicholson Road, Oak Creek, WI 53154', '42.845279539', '-87.893518226', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('10', 'Lake Vista Park', '4001 Lake Vista Parkway, Oak Creek, WI 53154', '42.876656841', '-87.844951286', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('11', 'Sheridan Park', '4800 S. Lake Dr, Cudahy, WI 53110', '42.957520062', '-87.849161975', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('12', 'Summerfest', '650 E. Erie St, Milwaukee, WI 53202', '43.027149721', '-87.902196144', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('13', 'Oak Leaf Trail @ Lincoln Memo', '3233 Oak Leaf Trail, Milwaukee, WI 53211', '43.068575989', '-87.867626525', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('14', 'Lincoln Park', '4700 N Green Bay Ave, Milwaukee, WI 53209', '43.104666909', '-87.927480744', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('15', 'Brown Deer Park', '525R+8W, Milwaukee, WI 53209', '43.158410908', '-87.956901166', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('16', 'Christ Alone Evangelical Church', '10001 N Cedarburg Rd, Mequon, WI 53092', '43.199221378', '-87.968036106', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('17', 'Trinity Lutheran Church', '10729 W Freistadt Rd, Mequon, WI 53097', '43.235840332', '-88.044105166', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('18', 'Vincent High School', '7501 N Granville Rd, Milwaukee, WI 53224', '43.155790169', '-88.031632861', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('19', 'Chase Bank', '12701 W Hampton Ave, Butler, WI 53007', '43.104559993', '-88.071029164', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('20', 'Brookfield Soccer Complex', '19485 Lisbon Rd, Menomonee Falls, WI 53045', '43.104439889', '-88.154569105', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('21', 'Meijer', 'N51 W24953 Lisbon Rd, Pewaukee, WI 53072', '43.111578289', '-88.244334047', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('22', 'Centennial Park', 'N55 W29505 County Hwy K, Hartland, WI 53029', '43.11944587', '-88.335397934', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('23', 'St. Joan of Arc Parish', '120 Nashotah Rd, Nashotah, WI 53058', '43.093524507', '-88.414838626', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('24', 'St. Jerome Catholic Parish', '995 Silver Lake St, Oconomowoc, WI 53066', '43.096119993', '-88.493521417', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('25', 'Monterey Park Soccer Fields', '5F8W+6J, Monterey, WI 53066', '43.165270483', '-88.505186711', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('26', 'Saint Paul''s Evangelical Luthern School', 'W1955 Gopher Hill Rd, Ixonia, WI 53036', '43.172615902', '-88.63083031', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('27', 'Webster Elementary School', '634 S 12th St, Watertown, WI 53094', '43.184380555', '-88.713626797', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('28', 'Ebenezer Moravian Church', 'N8095 High Rd, Watertown, WI 53094', '43.138290618', '-88.737847277', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('29', 'Johnson Creek High School', '455 Aztalan St, Johnson Creek, WI 53038', '43.07169942', '-88.786676167', 1);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('30', 'Seljan Company', '100 S C.P. Ave, Lake Mills, WI 53551', '43.077050517', '-88.897341209', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('31', 'London Lumber Co', '34 Depot Rd, Cambridge, WI 53523', '43.046052', '-89.015748', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('32', 'Deerfield Luthern Church', '206 S Main Street, Deerfield, WI 53531', '43.050346', '-89.075027', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('33', 'Fireman Park', '4116 Vilas Road, Cottage Grove, WI 53527', '43.074181', '-89.207407', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('34', 'New Life Church', '7564 Cottage Grove Rd, Madison, WI 53178', '43.088312', '-89.248691', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('35', 'Olbrich Park', '3527 Atwood Avenue, Madison, WI 53174', '43.089569', '-89.330299', 2);
INSERT INTO [dbo].[Exchanges] ([Id],[Name],[Address],[Latitude],[Longitude],[Van]) VALUES ('36', 'Olin Park', '1156 Olin-Turville Ct., Madison, WI 53715', '43.054890162', '-89.376365692', 2);


