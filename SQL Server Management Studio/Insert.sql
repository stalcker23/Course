USE [Hotel]
GO

INSERT INTO dbo.Client (id_client,FIO,pasport) 
VALUES(1,'�������� ������ ����������',1231231241)


INSERT INTO dbo.Client (id_client,FIO,pasport) 
VALUES(2,'������ ������� ���������',6412312141)

INSERT INTO dbo.Client (id_client,FIO,pasport) 
VALUES(3,'������� ������� ���������',2344546465)

INSERT INTO dbo.Client (id_client,FIO,pasport) 
VALUES(4,'��������� ������� ��������',2143546767)

INSERT INTO dbo.Client (id_client,FIO,pasport) 
VALUES(5,'�������� ������ �����������',568798709)

INSERT INTO dbo.Category(id_category,legend,sum_places)
VALUES(1,'������� �����������',2)

INSERT INTO dbo.Category(id_category,legend,sum_places)
VALUES(2,'������� ����������',2)

INSERT INTO dbo.Category(id_category,legend,sum_places)
VALUES(3,'���� �����������',2)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(1,50,1,0)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(2,50,1,0)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(3,60,2,0)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(4,60,2,0)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(5,70,3,0)

INSERT INTO dbo.HotelRoom(id_room,tax_room,id_category,status)
VALUES(6,70,3,1)

INSERT INTO dbo.Reserve(id_reserve,date_begin,date_end,id_category,id_client)
VALUES(1,'2016-01-12 11:00:00','2016-01-13 11:00:00',1,1)

