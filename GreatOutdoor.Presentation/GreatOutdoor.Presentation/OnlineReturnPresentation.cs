using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.Exceptions;
using Capgemini.GreatOutdoor.Contracts.BLContracts;
using Capgemini.GreatOutdoor.Contracts;

namespace Capgemini.GreatOutdoor.PresentationLayer
{
    public static class OnlineReturnPresentation
    {
        /// <summary>
        /// Menu for OnlineReturn
        /// </summary>
        /// <returns></returns>
        public static async Task<int> OnlineReturnMenu()
        {
            int choice = -2;

            do
            {
                //Menu
                WriteLine("\n***************Online Return Menu ***********");
                WriteLine("1. View Online Returns");
                WriteLine("2. Inlitialize Online Return");
                WriteLine("3. Update Online Return");
                WriteLine("4. Delete Online Return");
                WriteLine("-----------------------");

                WriteLine("0. Logout");
                WriteLine("-1. Exit");
                Write("Choice: ");


                //Accept and check choice
                bool isValidChoice = int.TryParse(ReadLine(), out choice);
                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1: await ViewOnlineReturns(); break;
                        case 2: await AddOnlineReturn(); break;
                        case 3: await UpdateOnlineReturn(); break;
                        case 4: await DeleteOnlineReturn(); break;
                        case 0: break;
                        case -1: break;
                        default: WriteLine("Invalid Choice"); break;
                    }
                }
                else
                {
                    choice = -2;
                }
            } while (choice != 0 && choice != -1);
            return choice;
        }




        /// <summary>
        /// Displays list of OnlineReturns.
        /// </summary>
        /// <returns></returns>
        public static async Task ViewOnlineReturns()
        {
            try
            {
                using (IOnlineReturnBL onlineReturnBL = new OnlineReturnBL())
                {
                    //Get and display list of OnlineReturn.
                    List<OnlineReturn> onlineReturns = await onlineReturnBL.GetAllOnlineReturnsBL();
                    WriteLine("OnlineReturns:");
                    if (onlineReturns != null && onlineReturns?.Count > 0)
                    {
                        WriteLine("#\tPurpose\tQuantityOfReturn\\tCreated\tModified");
                        int serial = 0;
                        foreach (var onlineReturn in onlineReturns)
                        {
                            serial++;
                            WriteLine($"{serial}\t{onlineReturn.Purpose}\t{onlineReturn.QuantityOfReturn}\t{onlineReturn.CreationDateTime}\t{onlineReturn.LastModifiedDateTime}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }


        public static async Task AddOnlineReturn()
        {
            OrderDetailBL orderBL = new OrderDetailBL();
            List<OrderDetail> matchingOrder = new List<OrderDetail>();
            try
            {
                using (IRetailerBL retailerBL = new RetailerBL())
                {
                    Retailer retailer = await retailerBL.GetRetailerByEmailBL(CommonData.CurrentUser.Email);
                    using (IOrderBL orderDAL = new OrderBL())
                    {
                        List<Order> RetailerOrderList = await orderDAL.GetOrdersByRetailerIDBL(retailer.RetailerID);
                        Console.WriteLine("Enter the order number which you want to Return");
                        int x = int.Parse(Console.ReadLine());
                        foreach (Order order in RetailerOrderList)
                        {
                            using (IOrderDetailBL orderDetailBL = new OrderDetailBL())
                            {
                                List<OrderDetail> RetailerOrderDetails = await orderDetailBL.GetOrderDetailsByOrderIDBL(order.OrderId);
                                matchingOrder = RetailerOrderDetails.FindAll(
                                           (item) => { return item.OrderSerial == x; }
                                       );
                                break;
                            }
                        }
                        if (matchingOrder.Count != 0)
                        {
                            int serial = 0;
                            Console.WriteLine("Products in the order are ");
                            foreach (var orderDetail in matchingOrder)
                            {
                                serial++;
                                Console.WriteLine("#\tProductID \t ProductQuantityOrdered");
                                Console.WriteLine($"{ serial}\t{ orderDetail.ProductID}\t{ orderDetail.ProductQuantityOrdered}");
                            }
                            Console.WriteLine("Enter The ProductID to be Returned");
                            int y = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter The Quantity to be Returned");
                            IOrderDetail orderDetail1 = new OrderDetail();
                            int QuantityOfReturn = int.Parse(Console.ReadLine());
                            if (QuantityOfReturn <= orderDetail1.ProductQuantityOrdered)
                            {
                                IOnlineReturn onlineReturn = new OnlineReturn();
                                //  OrderBL order = new OrderBL();
                                WriteLine("Purpose of Return:\n1.  UnsatiSfactoryProduct\n2. WrongProductShipped\n3.  WrongProductOrdered\n4. DefectiveProduct  ");
                                bool isPurposeValid = int.TryParse(ReadLine(), out int purpose);
                                if (isPurposeValid)
                                {

                                    if (purpose == 1)
                                    {
                                        onlineReturn.Purpose = Helpers.PurposeOfReturn.DefectiveProduct;
                                    }
                                    else if (purpose == 2)
                                    {
                                        onlineReturn.Purpose = Helpers.PurposeOfReturn.UnsatiSfactoryProduct;
                                    }
                                    else if (purpose == 3)
                                    {
                                        onlineReturn.Purpose = Helpers.PurposeOfReturn.WrongProductOrdered;
                                    }
                                    else if (purpose == 4)
                                    {
                                        onlineReturn.Purpose = Helpers.PurposeOfReturn.WrongProductShipped;
                                    }
                                    else
                                    {
                                        WriteLine("Invalid Option Selected ");
                                    }

                                    Write("Are you sure? (Y/N): ");
                                    string confirmation = ReadLine();

                                    if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    {

                                        WriteLine("OnlineReturn Confirmed");

                                    }

                                }
                                else
                                {
                                    WriteLine(" Purpose Of Return is Invalid");
                                }
                                //    matchingOrder[y - 1].ProductQuantityOrdered -= z;
                                //    OrderDetailDAL orderDetailDAL = new OrderDetailDAL();
                                //   orderDetailDAL.UpdateOrderDetailsDAL(matchingOrder[y - 1]);
                                //   Console.WriteLine("Product Cancelled Succesfully");

                            }
                            else
                            {
                                WriteLine("Invalid QuantityOfReturn");
                            }
                        }
                        else
                        {
                            Console.WriteLine("OrderID not Found");
                        }
                    }


                }


            }
            catch (Exception)
            {

                throw;
            }


        }




        /// <summary>
        /// Updates OnlineReturn.
        /// </summary>
        /// <returns></returns>
        public static async Task UpdateOnlineReturn()
        {
            try
            {
                using (IOnlineReturnBL onlineReturnsBL = new OnlineReturnBL())
                {
                    //Read Sl.No
                    Write("OnlineReturn #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<OnlineReturn> onlineReturns = await onlineReturnsBL.GetAllOnlineReturnsBL();
                        if (serial <= onlineReturns.Count - 1)
                        {
                            // Read inputs
                            OnlineReturn onlineReturn = onlineReturns[serial];
                            WriteLine("Purpose of Return:\n1.  UnsatiSfactoryProduct\n2. WrongProductShipped\n3.  WrongProductOrdered\n4. DefectiveProduct  ");
                            bool isPurposeValid = int.TryParse(ReadLine(), out int purpose);
                            Write("QuantityOfReturn: ");
                            onlineReturn.QuantityOfReturn = Convert.ToInt32(ReadLine());


                            //Invoke UpdateOnlineReturnBL method to update
                            bool isUpdated = await onlineReturnsBL.UpdateOnlineReturnBL(onlineReturn);
                            if (isUpdated)
                            {
                                WriteLine("OnlineReturn Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid OnlineReturn #.\nPlease enter a number between 1 to {onlineReturns.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Delete OnlineReturn.
        /// </summary>
        /// <returns></returns>
        public static async Task DeleteOnlineReturn()
        {
            try
            {
                using (IOnlineReturnBL onlineReturnBL = new OnlineReturnBL())
                {
                    //Read Sl.No
                    Write("OnlineReturn #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<OnlineReturn> onlineReturns = await onlineReturnBL.GetAllOnlineReturnsBL();
                        if (serial <= onlineReturns.Count - 1)
                        {
                            //Confirmation
                            OnlineReturn onlineReturn = onlineReturns[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteOnlineReturnBL method to delete
                                bool isDeleted = await onlineReturnBL.DeleteOnlineReturnBL(onlineReturn.OnlineReturnID);
                                if (isDeleted)
                                {
                                    WriteLine("OnlineReturn Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid OnlineReturn #.\nPlease enter a number between 1 to {onlineReturns.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }




    }
}


