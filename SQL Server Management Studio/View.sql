use Hotel
exec sp_helptext 'View_Client'

CREATE VIEW [dbo].[View_Client_copy]
WITH ENCRYPTION
AS
SELECT        FIO, pasport
FROM            dbo.Client

exec sp_helptext 'View_Client_copy'

CREATE VIEW New_View(id_category,legend,id_room, status)
AS
SELECT Category.id_category,Category.legend,HotelRoom.id_room,HotelRoom.status
FROM Category, HotelRoom
WHERE Category.id_category=HotelRoom.id_category
WITH CHECK OPTION


SELECT * FROM New_View

INSERT INTO New_View VALUES (3,'Люкс одноместный',7,'true')

CREATE VIEW New_View_Client(id_client, FIO, pasport)
AS
SELECT       id_client, FIO, pasport
FROM            dbo.Client
WHERE LEN(pasport)<11
WITH CHECK OPTION

INSERT INTO New_View_Client VALUES(16,'Степан Викторович Мазаев',8769546378)

SELECT * FROM New_View_Client where id_client=16

UPDATE New_View_Client
SET pasport=2347123561
WHERE id_client=16

SELECT * FROM New_View_Client where id_client=16

CREATE VIEW New_Hotel_Room(id_room, tax_room,id_category,status)
AS
SELECT       id_room, tax_room,id_category,status
FROM            dbo.HotelRoom
WHERE HotelRoom.status <> 1
WITH CHECK OPTION

SELECT * FROM New_Hotel_Room

UPDATE New_Hotel_Room	
SET status = 0
WHERE status<>0

SELECT * FROM New_Hotel_Room

SET NUMERIC_ROUNDABORT OFF;

SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL,

ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON;

GO

CREATE  VIEW Client_With_INDEX(FIO,pasport)
WITH SCHEMABINDING
AS
SELECT Client.FIO, Client.pasport
FROM dbo.Client

select * from Client_With_INDEX

CREATE UNIQUE CLUSTERED INDEX
new_index ON Client_With_INDEX(pasport)

select OBJECTPROPERTY(OBJECT_ID('Client_With_INDEX'),'IsIndexable')

select * from Client_With_INDEX

select FIO, pasport from dbo.Client