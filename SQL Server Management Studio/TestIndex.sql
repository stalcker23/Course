USE [Hotel]
GO

GO
/****** Object:  Table [dbo].[Client]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client2](
	[id_client] [int] NOT NULL,
	[FIO] [text] NULL,
	[pasport] [float] NULL ,
 CONSTRAINT [PK_Client2] PRIMARY KEY
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE NONCLUSTERED INDEX myIndex
ON Client2(id_client)

INSERT INTO dbo.Client(id_client,FIO,pasport) 
VALUES
(1,'�������� ������ ����������',1231231241),
(2,'������ ������� ���������',6412312141),
(3,'������� ������� ���������',2344546465),
(4,'��������� ������� ��������',2143546767),
(5,'�������� ������ �����������',568798709),
(6,'������ ������ ���������',5678908423),
(7,'������ ������� ���������',3564783746),
(8,'������� ������� ���������',1526378436),
(9,'��������� ������� ��������',6758947639),
(10,'�������� ������ �����������',8932987894),
(11,'�������� ������ ����������',3587948768),
(12,'������ ������� ���������',1242332544),
(13,'������� ������� ���������',22534434434),
(14,'��������� ������� ��������',4564587658),
(15,'�������� ������ �����������',1241142142)


SELECT Client2.FIO
FROM Client2
WHERE EXISTS (
 SELECT Client2.FIO
 FROM Client2
 WHERE Client2.id_client> 0
)
 /*IN ����������, ��������� �� ��������� �������� � ����� �� ��������, ������������ �� ��������� ������� ��� ������.*/
SELECT Client2.FIO
FROM Client2 
WHERE Client2.id_client IN
(SELECT Client2.id_client FROM
 Category AS B
 WHERE Client2.id_client = B.id_category
 AND Client2.id_client = '1');

 /*ANY/SOME ���������� ��������� �������� � ������� ��������, ��������� �� ������ �������. �������� ����� SOME � ANY ������������.*/
IF 0 < ANY (SELECT pasport FROM Client2)
PRINT 'TRUE' 
ELSE
PRINT 'FALSE';

/*ALL ���������� ��������� �������� � ������� ��������, ��������� �� ������ �������.*/
IF 0 < ALL (SELECT id_client FROM Client2)
PRINT 'TRUE' 
ELSE
PRINT 'FALSE';

/*BETWEEN ���������� �������� ��� ��������*/
SELECT Client2.FIO
FROM Client2
WHERE id_client BETWEEN 0 AND 4;

/*LIKE ����������, ��������� �� ��������� ���������� ������ � �������� ��������*/
SELECT Client2.FIO
FROM Client2
WHERE FIO LIKE '������ ������� ���������';

SELECT id_client, FIO, pasport
FROM Client2
WHERE Client2.id_client<100

SELECT Client.FIO, Client2.FIO
FROM Client
INNER JOIN Client2
ON Client2.id_client = Client.id_client;

SELECT Client.FIO, Client2.FIO
FROM Client
LEFT JOIN Client2
ON Client2.id_client = Client.id_client;

SELECT Client.FIO, Client2.FIO
FROM Client
RIGHT JOIN Client2
ON Client2.id_client = Client.id_client;

SELECT Client.FIO, Client2.FIO
FROM Client
FULL OUTER  JOIN Client2
ON Client2.id_client = Client.id_client;

SELECT Client2.FIO
FROM Client2
WHERE SUBSTRING(Client2.FIO,1,2) = '��';


SELECT tax_room
FROM HotelRoom
WHERE tax_room < 100
GROUP BY tax_room

CREATE NONCLUSTERED INDEX tax_index
ON HotelRoom(tax_room)

SELECT id_category, status
FROM HotelRoom 
WHERE tax_room < 100
GROUP BY id_category, status
HAVING status <> 0;

CREATE NONCLUSTERED INDEX id_Index
ON HotelRoom(id_category, status)

SELECT id_client FROM Client2
WHERE pasport > 0
INTERSECT
SELECT sum_places FROM Category
WHERE sum_places < 10

CREATE NONCLUSTERED INDEX id_Index
ON Client2(id_client)

CREATE NONCLUSTERED INDEX sym_places
ON Category(sum_places)