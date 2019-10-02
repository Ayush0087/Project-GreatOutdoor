using System;
using System.Collections.Generic;
using System.Text;
using Capgemini.GreatOutdoor.DataAccessLayer;
using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.GreatOutdoor.Contracts;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.Exceptions;
using Capgemini.GreatOutdoor.Helpers;
using Capgemini.GreatOutdoor.Contracts.BLContracts;
using Capgemini.GreatOutdoor.PresentationLayer;
using GreatOutdoors.Contracts.DALContracts;

namespace GreatOutdoor.Presentation
{
    class OrderPresentation
    {
        
        public static async void CancelRetailerOrder()
        {
            List<OrderDetail> matchingOrder = new List<OrderDetail>();//list maintains the order details of the order which user wishes to cancel
            try
            {
                using (IRetailerBL retailerBL = new RetailerBL())
                {
                    //gives the current retailer
                    Retailer retailer = await retailerBL.GetRetailerByEmailBL(CommonData.CurrentUser.Email);
                    using (IOrderBL orderDAL = new OrderBL())
                    {
                        //list of orders ordered by the retailer
                        List<Order> RetailerOrderList = await orderDAL.GetOrdersByRetailerID(retailer.RetailerID);
                        Console.WriteLine("Enter the order number which you want to cancel");
                        int orderToBeCancelled = int.Parse(Console.ReadLine());//user input of order which he has to cancel 
                        foreach (Order order in RetailerOrderList)
                        {
                            using (IOrderDetailBL orderDetailBL = new OrderDetailBL())
                            {
                                //getting the order details of required order to be cancelled
                                List<OrderDetail> RetailerOrderDetails = await orderDetailBL.GetOrderDetailsByOrderIDBL(order.OrderId);
                                matchingOrder = RetailerOrderDetails.FindAll(
                                           (item) => { return item.OrderSerial == orderToBeCancelled; }
                                       );
                                break;
                            }
                        }

                        if (matchingOrder.Count != 0)
                        {
                            OrderDetailDAL orderDetaildal = new OrderDetailDAL();
                            //cancel order if order not delivered
                            if(!orderDetaildal.UpdateOrderDeliveredStatusDAL(matchingOrder[0].OrderId))
                            {
                                int serial = 0;
                                Console.WriteLine("Products in the order are ");
                                foreach (OrderDetail orderDetail in matchingOrder)
                                {
                                    //displaying order details with the products ordered
                                    serial++;
                                    Console.WriteLine("#\tProductID \t ProductQuantityOrdered");
                                    Console.WriteLine($"{ serial}\t{ orderDetail.ProductID}\t{ orderDetail.ProductQuantityOrdered}");
                                }
                                Console.WriteLine("Enter The Product to be Cancelled");
                                int y = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter The Product Quantity to be Cancelled");
                                int quantityToBeCancelled = int.Parse(Console.ReadLine());
                                if (matchingOrder[y - 1].ProductQuantityOrdered >= quantityToBeCancelled)
                                {
                                    //updating order quantity and revenue
                                    matchingOrder[y - 1].ProductQuantityOrdered -= quantityToBeCancelled;
                                    matchingOrder[y - 1].TotalAmount -= matchingOrder[y - 1].ProductPrice * quantityToBeCancelled;
                                    OrderDetailDAL orderDetailDAL = new OrderDetailDAL();
                                    orderDetailDAL.UpdateOrderDetailsDAL(matchingOrder[y - 1]);

                                    Console.WriteLine("Product Cancelled Succesfully");

                                }
                                else
                                {
                                    Console.WriteLine("PRODUCT QUANTITY EXCEEDED");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Order Can't be cancelled as it is delivered");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

