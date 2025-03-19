CREATE DATABASE QuanLyQuanCafe
GO
USE QuanLyQuanCafe
GO
--Food
--Table
--FoodCategory
--Account
--Bill
--BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT'No name',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống' --Trống || Có người
)
GO
CREATE TABLE Account
(
	ID INT PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT'Huy Hoang',
	UserName NVARCHAR(100),
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type int NOT NULL  DEFAULT 0-- 1: admin || 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT 'No Name',	
)
CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT 'No Name',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL
	FOREIGN KEY(idCategory) REFERENCES dbo.FoodCategory(id)
)
GO
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckin DATE NOT NULL DEFAULT GETDATE(),
	DateCheckout DATE,
	idTable INT NOT NULL,
	status INT NOT NULL  DEFAULT 0-- 1: Đã thanh toán || 0: Chưa thanh toán
	FOREIGN KEY(idTable) REFERENCES dbo.TableFood(id)
)
GO
CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	FOREIGN KEY(idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY(idFood) REFERENCES dbo.Food(id)
)

--------------------------------
--------------------------------
INSERT INTO dbo.Account
        ( ID ,
          DisplayName ,
          UserName ,
          PassWord ,
          Type
        )
VALUES  ( 1 , -- ID - int
          N'Nguyen Huy' , -- DisplayName - nvarchar(100)
          N'hoang' , -- UserName - nvarchar(100)
          N'123' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
INSERT INTO dbo.Account
        ( ID ,
          DisplayName ,
          UserName ,
          PassWord ,
          Type
        )
VALUES  ( 1 , -- ID - int
          N'Jack Nguyen' , -- DisplayName - nvarchar(100)
          N'admin' , -- UserName - nvarchar(100)
          N'12345' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO


CREATE PROC USP_GetAccountByUSerName
@userName NVARCHAR(100)
AS
BEGIN
		SELECT*FROM dbo.Account WHERE UserName = @userName
END
GO
EXEC dbo.USP_GetAccountByUSerName @userName = N'hoang' -- nvarchar(100)

GO
CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT*FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

SELECT * FROM dbo.TableFood
---Thêm bàn
DECLARE @i INT = 0
WHILE @i <= 16
BEGIN
INSERT dbo.TableFood
        ( name )
VALUES  ( N'Bàn' +  CAST (@i AS NVARCHAR(100)))
		SET @i = @i+1
END
GO

CREATE PROC USP_GetTableList
AS SELECT *FROM dbo.TableFood
GO
UPDATE dbo.TableFood SET status = N'Có Người' WHERE id = 9
EXEC dbo.USP_GetTableList

--Thêm Category
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Hải sản'  -- name - nvarchar(100)
          )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nông sản')
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Lâm sản')
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Đặc sản')
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nước')

--Thêm món ăn
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Bạch tuộc vắt chanh', -- name - nvarchar(100)
          1, -- idCategory - int
          200000  -- price - float
          )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Bề bề rang muối',1,150000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Thịt gà xé lá chanh',2,250000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Lợn quay đang sống',2,1250000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Thịt bò cobe',2,650000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Tiết canh dê núi',3,50000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Thịt gấu đang tươi',3,3050000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Rau dưa xào tóp mỡ',4,1450000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Nước mắm cá hồi',5,50000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cocacola',5,12000 )
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cafe sữa',5,15000 )

--Thêm bill
INSERT dbo.Bill
        ( DateCheckin ,
          DateCheckout ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckin - date
          NULL, -- DateCheckout - date
          1 , -- idTable - int
          0  -- status - int
        )

INSERT dbo.Bill
        ( DateCheckin ,
          DateCheckout ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckin - date
          NULL, -- DateCheckout - date
          2 , -- idTable - int
          0  -- status - int
        )

INSERT dbo.Bill
        ( DateCheckin ,
          DateCheckout ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckin - date
          GETDATE(), -- DateCheckout - date
          3 , -- idTable - int
          1  -- status - int
        )

--Thêm Bill Info
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 1, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 2, -- idBill - int
          6, -- idFood - int
          2  -- count - int
          )
INSERT dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 3, -- idBill - int
          5, -- idFood - int
          2  -- count - int
          )
GO


SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.TableFood
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory

SELECT * FROM dbo.Bill WHERE idTable = 3 AND status = 1
SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi,dbo.Bill AS b ,dbo.Food AS f 
WHERE bi.idBill = b.id AND bi.idFood =f.id AND b.status = 0  AND b.idTable = 3
GO

CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
		INSERT dbo.Bill
		        ( DateCheckin ,
		          DateCheckout ,
		          idTable ,
		          status,
				  discount
		        )
		VALUES  ( GETDATE() , -- DateCheckin - date
		          NULL , -- DateCheckout - date
		          @idTable , -- idTable - int
		          0,  -- status - int
				  0
		        )
END
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitBillInfo = id , @foodCount = b.Count
	FROM dbo.BillInfo AS b
	WHERE b.idBill = @idBill AND b.idFood = @idFood

	IF(@isExitBillInfo >0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF(@newCount >0)
		UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
		DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
		ELSE
	BEGIN
		INSERT dbo.BillInfo
			 ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
				 @idFood, -- idFood - int
				 @count  -- count - int
				 )
	END
END
GO


SELECT MAX(id) FROM dbo.Bill
SELECT * FROM dbo.BillInfo WHERE idBill =1

UPDATE dbo.Bill SET status = 1 WHERE id = 1

GO

DELETE dbo.BillInfo
DELETE dbo.Bill
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT	@idBill = idBill FROM Inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	UPDATE dbo.TableFood SET status = N'Có Người' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE 
AS 
BEGIN
		DECLARE @idBill INT

		SELECT @idBill = id FROM Inserted

		DECLARE @idTable INT

		SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

		DECLARE @count int = 0

		SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
		
		IF(@count =0)
			UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
go


ALTER TABLE dbo.Bill ADD discount INT

UPDATE dbo.Bill SET discount = 0;

SELECT * FROM dbo.Food
INSERT dbo.Food( name, idCategory, price )VALUES  ( N''0, 0.0)
UPDATE dbo.Food SET name = N'Gà xé', idCategory = 3, price = 10000 WHERE id= 4
GO


CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

ALTER TABLE dbo.Bill ADD totalPrice FLOAT
DELETE dbo.Bill

DELETE dbo.BillInfo
SELECT * FROM dbo.Bill
GO

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN 
	SELECT t.name AS [Tên Bàn], dateCheckin AS [Ngày Vào], dateCheckOut as [Ngày Ra], discount AS[Giảm Giá],b.totalPrice AS [Tổng Tiền]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE b.DateCheckin >= @checkIn AND b.DateCheckout <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

SELECT * FROM dbo.Account
GO

CREATE PROC USP_UpdateAccount
@userName Nvarchar(100), @displayName Nvarchar (100), @password Nvarchar (100), @newPassword Nvarchar(100)
AS
BEGIN
	DECLARE @isRightPass INT  = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END
        ELSE 
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	END
END
GO

