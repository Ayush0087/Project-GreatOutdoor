using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.Exceptions;
using Capgemini.GreatOutdoor.Contracts.BLContracts;

namespace Capgemini.GreatOutdoor.PresentationLayer
{
    public static class SalesPersonPresentation
    {
        /// <summary>
        /// Menu for SystemUser
        /// </summary>
        /// <returns></returns>
        public static async Task<int> SalesPersonMenu()
        {
            int choice = -2;

            do
            {
                //Menu
                WriteLine("\n***************SalesPerson USER***********");
                WriteLine("1. View SalesPerson Detail");
                WriteLine("2. Update SalesPerson");
                WriteLine("3. Upload Offline Order");
                WriteLine("4. Upload Offline Return");
                WriteLine("5. Update Offline Order");
                WriteLine("6. Change Password");
                WriteLine("7. Logout");
                WriteLine("8. Exit");
                Write("Choice: ");

                //Accept and check choice
                bool isValidChoice = int.TryParse(ReadLine(), out choice);
                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1: await ViewSalesPerson(); break;
                        case 2: await UpdateSalesPerson(); break;
                        // case : await AddSalesPerson(); break;
                        // case : await DeleteSalesPerson(); break;

                        // case 3: await UploadOfflineOrder(); break;
                        // case 4: await UploadOfflineReturn (); break;
                        //case 5: await UpdateOfflineOrder(); break;

                        case 6: await ChangeSalesPersonPassword(); break;
                        case 7: break;
                        case 8: break;
                        default: WriteLine("Invalid Choice"); break;
                    }
                }
                else
                {
                    choice = -2;
                }
            } while (choice != 7 && choice != 8);
            return choice;
        }


        

        /// <summary>
        /// Displays list of SalesPerson.
        /// </summary>
        /// <returns></returns>
        public static async Task ViewSalesPerson()
        {
            try
            {
                using (ISalesPersonBL salesPersonBL = new SalesPersonBL())
                {
                    //Get and display list of system users.
                    List<SalesPerson> salesPersons = await salesPersonBL.GetAllSalesPersonsBL();
                    WriteLine("SALESPERSON:");
                    if (salesPersons != null && salesPersons?.Count > 0)
                    {
                        WriteLine("#\tName\tMobile\tEmail\tCreated\tModified");
                        int serial = 0;
                        foreach (var salesPerson in salesPersons)
                        {
                            serial++;
                            WriteLine($"{serial}\t{salesPerson.SalesPersonName}\t{salesPerson.SalesPersonMobile}\t{salesPerson.Email}\t{salesPerson.CreationDateTime}\t{salesPerson.LastModifiedDateTime}");
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


        /// <summary>
        /// Updates SalesPerson.
        /// </summary>
        /// <returns></returns>
        public static async Task UpdateSalesPerson()
        {
            try
            {
                using (ISalesPersonBL salesPersonBL = new SalesPersonBL())
                {
                    //Read Sl.No
                    Write("SalesPerson #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SalesPerson> salesPersons = await salesPersonBL.GetAllSalesPersonsBL();
                        if (serial <= salesPersons.Count - 1)
                        {
                            //Read inputs
                            SalesPerson salesPerson = salesPersons[serial];
                            Write("Name: ");
                            salesPerson.SalesPersonName = ReadLine();
                            Write("Mobile: ");
                            salesPerson.SalesPersonMobile = ReadLine();
                            Write("Email: ");
                            salesPerson.Email = ReadLine();

                            //Invoke UpdateSalesPersonBL method to update
                            bool isUpdated = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
                            if (isUpdated)
                            {
                                WriteLine("SalesPerson Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid SalesPerson #.\nPlease enter a number between 1 to {salesPersons.Count}");
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

        public static async Task AddSalesPerson()
        {
            try
            {
                //Read inputs
                SalesPerson salesPerson = new SalesPerson();
                Write("Name: ");
                salesPerson.SalesPersonName = ReadLine();
                Write("Mobile: ");
                salesPerson.SalesPersonMobile = ReadLine();
                Write("Email: ");
                salesPerson.Email = ReadLine();

                Write("Password: ");
                salesPerson.Password = ReadLine();

                //Invoke AddSalesPersonBL method to add
                using (ISalesPersonBL salesPersonBL = new SalesPersonBL())
                {
                    bool isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
                    if (isAdded)
                    {
                        WriteLine("Salesperson Added");
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
        /// Delete SalesPerson.
        /// </summary>
        /// <returns></returns>
        public static async Task DeleteSalesPerson()
        {
            try
            {
                using (ISalesPersonBL salesPersonBL = new SalesPersonBL())
                {
                    //Read Sl.No
                    Write("SalesPerson #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SalesPerson> salesPersons = await salesPersonBL.GetAllSalesPersonsBL();
                        if (serial <= salesPersons.Count - 1)
                        {
                            //Confirmation
                            SalesPerson salesPerson = salesPersons[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteSalesPersonBL method to delete
                                bool isDeleted = await salesPersonBL.DeleteSalesPersonBL(salesPerson.SalesPersonID);
                                if (isDeleted)
                                {
                                    WriteLine("SalesPerson Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid SalesPerson #.\nPlease enter a number between 1 to {salesPersons.Count}");
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
        /// Updates SalesPerson's Password.
        /// </summary>
        /// <returns></returns>
        public static async Task ChangeSalesPersonPassword()
        {
            try
            {
                using (ISalesPersonBL salesPersonBL = new SalesPersonBL())
                {
                    //Read Current Password
                    Write("Current Password: ");
                    string currentPassword = ReadLine();

                    SalesPerson existingSalesPerson = await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(CommonData.CurrentUser.Email, currentPassword);

                    if (existingSalesPerson != null)
                    {
                        //Read inputs
                        Write("New Password: ");
                        string newPassword = ReadLine();
                        Write("Confirm Password: ");
                        string confirmPassword = ReadLine();

                        if (newPassword.Equals(confirmPassword))
                        {
                            existingSalesPerson.Password = newPassword;

                            //Invoke UpdateSalesPersonBL method to update
                            bool isUpdated = await salesPersonBL.UpdateSalesPersonPasswordBL(existingSalesPerson);
                            if (isUpdated)
                            {
                                WriteLine("SalesPerson Password Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"New Password and Confirm Password doesn't match");
                        }
                    }
                    else
                    {
                        WriteLine($"Current Password doesn't match.");
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