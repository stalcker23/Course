USE [Hotel]
GO
DELETE FROM dbo.[Client] WHERE id_client=1
GO
DELETE FROM dbo.[Client] WHERE id_client=2
GO
DELETE FROM dbo.[HotelRoom] WHERE id_room=1
GO
DELETE FROM dbo.[Reserve] WHERE id_reserve=1
GO