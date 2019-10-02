using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.GreatOutdoor.Contracts.BLContracts;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.PresentationLayer;
using System;
using Capgemini.GreatOutdoor.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Presentation
{
    class Class1
    {
        public static async Task CancelRetailerOrder()
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
                        List<Order> RetailerOrderList = await orderDAL.GetOrdersByRetailerIDBL(retailer.RetailerID);
                        Console.WriteLine("Enter the order number which you want to cancel");
                        int orderToBeCancelled = int.Parse(Console.ReadLine());//user input of order which he has to cancel 

                       
                        foreach (Order order in RetailerOrderList)
                        {
                            using (IOrderDetailBL orderDetailBL = new OrderDetailBL())
                            {
                                //getting the order details of required order to be cancelled
                                //List<OrderDetail> RetailerOrderDetails 
                                matchingOrder = await orderDetailBL.GetOrderDetailsByOrderNumberBL(order.OrderNumber);
                                //matchingOrder = RetailerOrderDetails.FindAll(
                                //           (item) => { return item.OrderNumber == orderToBeCancelled; }
                                //       );
                                //break;
                            }
                        }

                        if (matchingOrder.Count != 0)
                        {
                            OrderDetailBL orderDetailBL = new OrderDetailBL();
                            //cancel order if order not delivered
                            if (!(await orderDetailBL.UpdateOrderDeliveredStatusBL(matchingOrder[0].OrderId)))
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
                                int ProductToBeCancelled = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter The Product Quantity to be Cancelled");
                                int quantityToBeCancelled = int.Parse(Console.ReadLine());
                                if (matchingOrder[ProductToBeCancelled - 1].ProductQuantityOrdered >= quantityToBeCancelled)
                                {
                                    //updating order quantity and revenue
                                    matchingOrder[ProductToBeCancelled - 1].ProductQuantityOrdered -= quantityToBeCancelled;
                                    matchingOrder[ProductToBeCancelled - 1].TotalAmount -= matchingOrder[ProductToBeCancelled - 1].ProductPrice * quantityToBeCancelled;
                                    OrderDetailBL orderDetailBL1 = new OrderDetailBL();
                                    await orderDetailBL1.UpdateOrderDetailsBL(matchingOrder[ProductToBeCancelled - 1]);

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
