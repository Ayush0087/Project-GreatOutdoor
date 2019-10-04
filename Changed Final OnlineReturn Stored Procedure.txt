USE GreatOutdoor
Go
DROP TABLE Greatoutdoor.Users.OnlineReturns
Create Table Users.OnlineReturns
(
 OnlineReturn_ID varchar(255) CONSTRAINT PK_OnlineReturn Primary key,
 OrderNumber varchar(255) NOT NULL ,--CONSTRAINT FK_Orders_OrderID REFERENCES Users.Orders(Order_ID),
 ProductNumber varchar(255) NOT NULL, ---CONSTRAINT FK_Products_ProductID REFERENCES Users.Product(Product_ID),
 QuantityOfReturn int NOT NULL,
 Purpose VARCHAR(50) NOT NULL,
 Retailer_ID varchar(255) NOT NULL, --CONSTRAINT FK_Retailer_RetailerID REFERENCES Users.Retailer(Retailer_ID),
 ProductPrice Decimal NOT NULL,
 TotalAmount int NOT NULL,
 Creation_DateTime datetime,
 Last_Modified_DateTime datetime,
   
)
GO

 Select*from GreatOutdoor.Users.OnlineReturns

 --Created Table With VARCHAR OF ONLINERETURN


alter Procedure GreatOutdoor.Users.AddOnlineReturn(@onlinereturnid varchar(255), @orderNumber varchar(255), 
@totalamount int, @productprice int, @productNumber varchar(255), 
@purpose varchar(50), @quantityofreturn int, @creationdatetime datetime)
as
Begin
    
   if @onlinereturnid is null OR @onlinereturnid = ''
   throw 5001, 'Invalid Online Return ID', 1
   if @orderNumber is null OR @orderNumber = ''
   throw 5001, 'Invalid Order ID', 2
   if @productNumber is null OR @productNumber = ''
   throw 5001, 'Invalid Product ID', 3
   if @totalamount =0
   throw 5001, 'Invalid Return Amount', 5
   if @productprice = 0
   throw 5001, 'Invalid Unit Price', 6
   if @quantityofreturn = 0
   throw 5001, 'Quantity Of Return is 0', 7
   if @purpose is null OR @purpose = ''
   throw 5001, 'Purpose Not Selected', 8
   Insert into GreatOutdoor.Users.OnlineReturns(OnlineReturn_ID, OrderNumber, ProductNumber,  Purpose, 
   QuantityOfReturn, Last_Modified_DateTime, Creation_DateTime, ProductPrice, TotalAmount)
   values(@onlinereturnid, @orderNumber, @productNumber, @purpose, @quantityofreturn,
   null,@creationdatetime, @productprice, @totalamount)
end

--created procedure

Exec GreatOutdoor.Users.AddOnlineReturn '20','30', 20,20,'55', 'defective', 1,'1-oct-2019'


Create Procedure GetOnlineReturnByOnlineReturnID(@onlinereturnid VARCHAR(255))
AS
BEGIN
   begin try
   select * from GreatOutdoor.Users.OnlineReturns where OnlineReturn_ID = @onlinereturnid
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',2
	  return 0
   end catch
end
Go
--created procedure

Create Procedure GetOnlineReturnsByPurpose(@purpose VARCHAR(50))
AS
BEGIN
   begin try
   select * from GreatOutdoor.Users.OnlineReturns where Purpose = @purpose
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',3
	  return 0
   end catch
end
Go
--created procedure

Create Procedure GetOnlineReturnByRetailerID(@retailerID VARCHAR(50))
AS
BEGIN
   begin try
   select * from GreatOutdoor.Users.OnlineReturns where Retailer_ID = @retailerID
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',4
	  return 0
   end catch
end
Go
--created procedure
   
   
Create Procedure DeleteOnlineReturn(@onlinereturnid VARCHAR(255))
AS
BEGIN
   begin try
   Delete from GreatOutdoor.Users.OnlineReturns where OnlineReturn_ID = @onlinereturnid
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',5
	  return 0
   end catch
end
Go
--created procedure

Create Procedure UpdateOnlineReturn(@onlinereturnid VARCHAR(255), @purpose varchar(50), @quantityofreturn int)
AS
BEGIN
   begin try
   Update GreatOutdoor.Users.OnlineReturns set QuantityOfReturn =@quantityofreturn,Purpose=@purpose  Where   OnlineReturn_ID = @onlinereturnid
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',6
	  return 0
   end catch
end
Go
--created procedure

Create Procedure GetAllOnlineReturns(@onlinereturnid varchar(255))
AS
BEGIN
   begin try
   select * from GreatOutdoor.Users.OnlineReturns 
   end try
   begin catch
      PRINT @@ERROR;
	  throw 5000, 'Invalid Values fatched',7
	  return 0
   end catch
end
Go
--created procedure


   
   
   