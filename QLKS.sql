CREATE DATABASE QLKS
GO

USE QLKS
GO

--RoomStatus
CREATE TABLE RoomStatus
(
	code_room_status NVARCHAR(20) PRIMARY KEY,
	name_status NVARCHAR(100) -- 0: Trống || 1: Đang sử dụng || 2: Đã đặt
)
GO

--RoomType
CREATE TABLE RoomType
(
	code_room_type NVARCHAR(20) PRIMARY KEY,
	name_type NVARCHAR(100), 
	price FLOAT NOT NULL DEFAULT 0,
	number_min INT DEFAULT 0,
	number_max INT DEFAULT 0
)
GO

-- Room
CREATE TABLE Room
(
	code_room NVARCHAR(20) PRIMARY KEY,
	name_room NVARCHAR(100),
	code_type NVARCHAR(20) NOT NULL,
	code_status NVARCHAR(20) NOT NULL,
	note NVARCHAR(100)

	FOREIGN KEY (code_type) REFERENCES dbo.RoomType(code_room_type),
	FOREIGN KEY (code_status) REFERENCES dbo.RoomStatus(code_room_status)
)
GO

-- EmployeePosition
CREATE TABLE EmployeePosition
(
	code_employee_position NVARCHAR(20) PRIMARY KEY,
	name_position NVARCHAR(100) -- Admin || Nhân viên
)
GO

-- Employee
CREATE TABLE Employee
(
	code_employee NVARCHAR(20) PRIMARY KEY,
	name_employee NVARCHAR(100), 
	date_birth NVARCHAR(100),
	phone NVARCHAR(100),
	code_position NVARCHAR(20) NOT NULL

	FOREIGN KEY (code_position) REFERENCES dbo.EmployeePosition(code_employee_position)
)
GO

--Account
CREATE TABLE Account
(
	username NVARCHAR(50) PRIMARY KEY,
	password NVARCHAR(100),
	display_name NVARCHAR(100),
	code_position NVARCHAR(20) NOT NULL

	FOREIGN KEY (code_position) REFERENCES dbo.EmployeePosition(code_employee_position)
)
GO

-- ServiceCategory
CREATE TABLE ServiceCategory
(
	code_service_category NVARCHAR(20) PRIMARY KEY,
	name_category NVARCHAR(100)
)
GO

-- Service
CREATE TABLE Service
(
	code_service NVARCHAR(20) PRIMARY KEY,
	name_service NVARCHAR(100), 
	unit INT DEFAULT 0,
	price_service float DEFAULT 0,
	code_category NVARCHAR(20) NOT NULL,
	
	FOREIGN KEY (code_category) REFERENCES dbo.ServiceCategory(code_service_category)
)
ALTER TABLE Service DROP COLUMN unit;
GO

-- Bill
CREATE TABLE Bill
(
	id_bill INT IDENTITY PRIMARY KEY,
	code_employee NVARCHAR(20) NOT NULL,
	code_room NVARCHAR(20) NOT NULL,
	name_customer NVARCHAR(100), 
	cmnd_customer NVARCHAR(100),
	date_checkin DATETIME,
	date_checkout DATETIME,
	deposit FLOAT,
	discount FLOAT DEFAULT 0,
	status_bill INT NOT NULL DEFAULT 0, -- 1: Đã tt || 0: Chưa tt 
	date_created DATETIME DEFAULT GETDATE()

	FOREIGN KEY (code_room) REFERENCES dbo.Room(code_room),
	FOREIGN KEY (code_employee) REFERENCES dbo.Employee(code_employee)
)
GO

-- BillDetail
CREATE TABLE BillDetail
(
	id_bill_detail INT IDENTITY PRIMARY KEY,
	id_bill INT NOT NULL,
	code_service NVARCHAR(20) NOT NULL,


	FOREIGN KEY (id_bill) REFERENCES dbo.Bill(id_bill),
	FOREIGN KEY (code_service) REFERENCES dbo.Service(code_service)
)
GO

	
-- BookingInfo
CREATE TABLE BookingInfo
(
	id_booking INT IDENTITY PRIMARY KEY,
	code_room NVARCHAR(20) NOT NULL,
	name_customer NVARCHAR(100),
	phone_cusomter NVARCHAR(100), 
	date_book DATETIME,
	date_checkin DATETIME,
	date_checkout DATETIME,
	deposit FLOAT,


	FOREIGN KEY (code_room) REFERENCES dbo.Room(code_room)
)
GO

-- Customer
CREATE TABLE Cusomter
(
	code_customer NVARCHAR(20) PRIMARY KEY,
	name_customer NVARCHAR(100),
	cmnd_customer NVARCHAR(100),
	phone_customer NVARCHAR(100)
)
Go

-- Thêm thông tin chức vụ nhân viên
INSERT EmployeePosition(code_employee_position,name_position)
VALUES (N'001',N'Quản lý')
INSERT EmployeePosition(code_employee_position,name_position)
VALUES (N'002',N'Nhân viên')

-- Thêm thông tin nhân viên
INSERT Employee(code_employee,name_employee,date_birth,phone,code_position)
VALUES (N'E001',N'Nguyễn Ngọc Đăng Khoa',N'06/06/1998',N'0123465789',N'001')
INSERT Employee(code_employee,name_employee,date_birth,phone,code_position)
VALUES (N'E002',N'Nguyễn Đình Khánh Du',N'01/01/1998',N'0456789123',N'002')
INSERT Employee(code_employee,name_employee,date_birth,phone,code_position)
VALUES (N'E003',N'Phạm Huỳnh Đức',N'01/02/1998',N'0789465123',N'002')

-- Thêm thông tin account
INSERT Account(username,password,display_name,code_position)
VALUES (N'admin',N'1',N'Yang',N'001')
INSERT Account(username,password,display_name,code_position)
VALUES (N'account01',N'1',N'Du',N'002')

-- Thêm thông tin loại phòng
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'THUONG',N'Thường',3,1,120000)
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'THUONG2',N'Thường 2 giường',5,1,240000)
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'THUONG3',N'Thường 3 giường',7,1,360000)
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'VIP',N'VIP giường',3,1,200000)
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'VIP2',N'VIP 2 giường',5,1,400000)
INSERT RoomType(code_room_type,name_type,number_max,number_min,price)
VALUES (N'VIP3',N'VIP 3 giường',7,1,600000)



-- Thêm thông tin trạng thái phòng
INSERT RoomStatus(code_room_status,name_status)
VALUES (N'001',N'Trống')
INSERT RoomStatus(code_room_status,name_status)
VALUES (N'002',N'Đang sử dụng')
INSERT RoomStatus(code_room_status,name_status)
VALUES (N'003',N'Đã được đặt')

-- Thêm thông tin phòng
INSERT Room(code_room,name_room,code_status,code_type)
VALUES (N'101',N'Phòng 101',N'001',N'THUONG')
INSERT Room(code_room,name_room,code_status,code_type)
VALUES (N'102',N'Phòng 102',N'001',N'THUONG2')
INSERT Room(code_room,name_room,code_status,code_type)
VALUES (N'103',N'Phòng 103',N'001',N'THUONG3')
INSERT Room(code_room,name_room,code_status,code_type)
VALUES (N'104',N'Phòng 104',N'002',N'VIP')
INSERT Room(code_room,name_room,code_status,code_type)
VALUES (N'105',N'Phòng 105',N'003',N'VIP3')

--Thêm thông tin loại dịch vụ
INSERT ServiceCategory(code_service_category,name_category)
VALUES (N'001',N'Thức ăn')
INSERT ServiceCategory(code_service_category,name_category)
VALUES (N'002',N'Thức uống')
INSERT ServiceCategory(code_service_category,name_category)
VALUES (N'003',N'Phòng')


--Thêm thông tin dịch vụ
INSERT Service(code_service,name_service,unit,price_service,code_category)
VALUES (N'AU001',N'Cà phê sáng',1,20000,N'002')
INSERT Service(code_service,name_service,unit,price_service,code_category)
VALUES (N'AU002',N'Nước suối',1,20000,N'002')
INSERT Service(code_service,name_service,unit,price_service,code_category)
VALUES (N'AU003',N'Redbull',1,20000,N'002')
INSERT Service(code_service,name_service,unit,price_service,code_category)
VALUES (N'AU004',N'7UP',1,20000,N'002')



-- Stored Procedure Đăng nhập
CREATE PROC USP_Login
@_username nvarchar(100), @_password nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE username = @_username AND password = @_password
END
GO

EXEC dbo.USP_Login @_username = N'admin' , @_password = N'1'


-- Stored Procedure Lấy danh sách phòng
CREATE PROC USP_GetRoomList
AS
BEGIN
	SELECT code_room,name_room,name_type,name_status FROM Room a, RoomType b, RoomStatus c
	WHERE a.code_status = c.code_room_status AND a.code_type = b.code_room_type
END
GO

EXEC USP_GetRoomList

-- Store Procedure Cập nhật Account
CREATE PROC USP_UpdateAccount
@username NVARCHAR(100), @displayname NVARCHAR(100), @password NVARCHAR(100), @newpassword NVARCHAR(100)
AS 
BEGIN
	DECLARE @check INT = 0

	SELECT @check = COUNT(*) FROM Account WHERE username = @username AND password = @password

	IF (@check = 1)
	BEGIN
		UPDATE Account SET password = @newpassword WHERE username = @username
	END
END
GO

EXEC USP_UpdateAccount 



SELECT * FROM RoomType
DELETE FROM Room WHERE code_room = N'106'
UPDATE Room SET name_room = N'Phòng 105', code_type = N'VIP3', code_status = N'003', note = N'sdf' WHERE code_room = N'105'

SELECT * FROM Service

UPDATE Service SET name_service=N'Cà phê', unit = 1, price_service = 25000, code_category = N'002' WHERE code_service = N'001'

DELETE Service WHERE code_service = N'005'