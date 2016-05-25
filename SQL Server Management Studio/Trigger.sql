	CREATE TRIGGER ADD_Reserve ON dbo.Reserve
	AFTER INSERT AS
	BEGIN
	 DECLARE @id INTEGER = (SELECT Reserve.id_category FROM Reserve)
	 IF @id > 0
	  BEGIN
	   UPDATE Category
	   SET sum_places = sum_places-1
	   WHERE id_category = @id
	  END
	 ELSE
	  BEGIN
	  PRINT 'INCORRECT ID!!!'
	  UPDATE Client
	   SET id_client = 0
	   WHERE id_client = @id
	  END
	END


	CREATE TRIGGER Validate_Client ON dbo.Client
	AFTER UPDATE AS
	BEGIN
	 SET NOCOUNT ON;
	 IF (SELECT pasport FROM inserted).LEN <> 10
	 ROLLBACK
	 PRINT 'INCORRECT PASSPORT''S NUMBER!!!'
	END

	CREATE TRIGGER Validate_Service ON dbo.Service
	 INSTEAD OF INSERT AS
	BEGIN
	 SET NOCOUNT ON;
	 IF (SELECT tax_service FROM inserted) < 0
	 ROLLBACK
	 PRINT '¬ведена некорректна€ цена!'
	END


	CREATE TRIGGER Validate_HotelRoom ON dbo.HotelRoom
	AFTER INSERT AS
	BEGIN
	 SET NOCOUNT ON;
	 IF (SELECT status FROM inserted) = 1
	 ROLLBACK
	 PRINT '¬ведена некорректна€ комната, котора€ уже зан€та!'
	END

	CREATE TRIGGER Delete_Category ON dbo.Category
	AFTER DELETE AS
	IF (SELECT COUNT(*) FROM deleted WHERE deleted.id_category > 0) > 0
	BEGIN
	 ROLLBACK TRANSACTION
	END

	CREATE TRIGGER Delete_Room ON dbo.HotelRoom
	AFTER DELETE AS
	IF (SELECT COUNT(*) FROM deleted WHERE deleted.status = 1) > 0
	BEGIN
	 ROLLBACK TRANSACTION
	END

	CREATE TRIGGER ADD_CLIENT_INS ON dbo.Client
	INSTEAD OF INSERT AS
	DECLARE @fio NVARCHAR(10) = (SELECT FIO FROM inserted where FIO IS NOT NULL)
	  BEGIN
	   UPDATE Category
	   SET sum_places = sum_places-1
	  END

