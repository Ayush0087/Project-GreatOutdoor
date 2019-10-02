
using System;
using static System.Console;
using Capgemini.GreatOutdoor;
using Capgemini.GreatOutdoor.Entities;
using Capgemini.GreatOutdoor.Exceptions;
using Capgemini.GreatOutdoor.DataAccessLayer;
using Capgemini.GreatOutdoor.BusinessLayer;
namespace Capgemini.GreatOutdoor.Presentation

{
    class Program
    {
        public static void Main()
        {
            //            try
            //            {
            //                int choice=1;
            //                do
            //                {


            //                    Console.WriteLine("Enter Your Choice");
            //                    Console.WriteLine("1.Admin \n2.Saleperson \n3.Retailer\n4.Exit");
            //                    int option = int.Parse(ReadLine());
            //                    //if user is admin
            //                    if (option == 1)
            //                    {
            //                        Admin ad = new Admin();
            //                        WriteLine("welcome admin");
            //                        WriteLine("enter your admin id");
            //                        int id = int.Parse(ReadLine());
            //                        if (AdminBL.SearchAdminBL(id) == null)
            //                        {
            //                            WriteLine("adminid is not existed");
            //                            WriteLine("incorrect adminid");
            //                            Main();
            //                            choice = 0;
            //                        }
            //                        else
            //                        {
            //                            bool login = Validatepassword(id);
            //                            if (login == false)
            //                            {
            //                                WriteLine("incorrect password ");
            //                                Main();
            //                                choice = 0;
            //                            }
            //                            else
            //                            {
            //                                Admin();

            //                            }

            //                        }


            //                    }

            //                    //user is salesperson and validating user id
            //                    else if (option == 2)
            //                {
            //                    IUser sp = new IUser();

            //                    WriteLine("welcome salesperson");

            //                    WriteLine("enter sales id");
            //                    int salespersonid = int.Parse(ReadLine());
            //                    SalesPersonDAL spid = new SalesPersonDAL();
            //                    IUser item = spid.GetSalesPersonByIDDAL(salespersonid);
            //                    if (item == null) { WriteLine("Invalid Salesperson id"); }
            //                    //user id is existed and validating password
            //                        else
            //                    {
            //                      if (ValidateSalespersonpassword(item) == true) { Retailer(); }
            //                       else
            //                            {
            //                                WriteLine("Incorrect password");
            //                                choice = 0;
            //                            }


            //                        }


            //                }

            //                else if (option == 3)//if user is retailer
            //                {
            //                    Retailer ret = new Retailer();



            //                    int option1;
            //                    WriteLine("enter option\n1.existing user\n2.new user");
            //                    option1 = int.Parse(ReadLine());
            //                    if (option1 == 1)
            //                    {
            //                        WriteLine("welcome retailer");

            //                        WriteLine("enter Retailer id");
            //                        int retailerid = int.Parse(ReadLine());
            //                        RetailersDAL rd = new RetailersDAL();
            //                        Retailer item = rd.GetRetailerByIDDAL(retailerid);
            //                        if (item == null) { WriteLine("Invalid retailer id"); }
            //                        else
            //                        {
            //                            if (ValidateRetailerpassword(item) == true) { Retailer(); }
            //                            else
            //                            {
            //                                WriteLine("Incorrect password");
            //                                choice = 0;
            //                            }


            //                        }

            //                    }
            //                    //new user registrartion
            //                    else if (option1 == 2)
            //                    {
            //                        WriteLine("please fill the following details to complete registrartion:");
            //                        AddRetailer();
            //                    }
            //                    else
            //                    {
            //                        WriteLine("Invalid option");
            //                        choice = 0;
            //                    }
            //                }
            //                    //if user is retailer
            //                    else if (option == 4)
            //                    { WriteLine("closing the application");
            //                        choice = 0;
            //                    }
            //                    else//if user enters incorrect category
            //                    {
            //                        WriteLine("Invalid option \nPlease enter valid category number");
            //                        Main();
            //                    }

            //                } while (choice <1);



            //            }
            //            catch (Exception )
            //            {

            //                Console.WriteLine("Error Occured Sorry"); ;
            //            }
            //            finally
            //            {
            //                Console.WriteLine("Retry");
            //                Program.Main();

            //            }



            //        }
            //        public static bool ValidateSalespersonpassword(IUser item)
            //        {
            //            WriteLine("enter retailer password");
            //            string pass = "";
            //            ConsoleKeyInfo key;
            //            do
            //            {
            //                key = Console.ReadKey(true);
            //                if (key.Key != ConsoleKey.Backspace)
            //                {
            //                    pass += key.KeyChar;
            //                    Write("*");
            //                }
            //                else
            //                {
            //                    Write("\b");
            //                }
            //            }
            //            while (key.Key != ConsoleKey.Enter);
            //            bool existed = false;
            //            if (pass == item.SalesPersonPassword) { existed = true; }
            //            return existed;

            //        }
            //        public static bool ValidateRetailerpassword(Retailer item)
            //        {
            //            WriteLine("enter retailer password");
            //            string pass = "";
            //            ConsoleKeyInfo key;
            //            do
            //            {
            //                key = Console.ReadKey(true);
            //                if (key.Key != ConsoleKey.Backspace)
            //                {
            //                    pass += key.KeyChar;
            //                    Write("*");
            //                }
            //                else
            //                {
            //                    Write("\b");
            //                }
            //            }
            //            while (key.Key != ConsoleKey.Enter);
            //            bool existed = false;
            //            if (pass == item.Retailerpassword) { existed = true; }
            //            return existed;
            //        }
            //        public static bool Validatepassword(int id)
            //        {
            //            WriteLine("enter admin password");
            //            string pass = "";
            //            ConsoleKeyInfo key;
            //            do
            //            {
            //                key = Console.ReadKey(true);
            //                if (key.Key != ConsoleKey.Backspace)
            //                {
            //                    pass += key.KeyChar;
            //                    Write("*");
            //                }
            //                else
            //                {
            //                    Write("\b");
            //                }
            //            }
            //            while (key.Key != ConsoleKey.Enter);


            //            bool existed = false;
            //            for (int i = 0; i < AdminDAL.AdminList.Count; i++)
            //            {
            //                if (AdminDAL.AdminList[i].AdminID == id)
            //                {
            //                    if (AdminDAL.AdminList[i].Adminpassword == pass)
            //                    {
            //                        existed = true;
            //                    }
            //                }
            //            }

            //            return existed;
            //        }

            //        public static void Retailer()
            //        {
            //            RetailerPrintMenu();
            //            Console.WriteLine("Enter Your Choice");
            //            int c = Convert.ToInt32(Console.ReadLine());
            //            switch(c)
            //            {
            //                case 1:
            //                    AddRetailer();
            //                    break;
            //                case 2:
            //                    GetRetailerByID();
            //                    break;
            //                case 3:
            //                    UpdateRetailer();
            //                    break;
            //                case 4:
            //                    DeleteRetailer();
            //                    break;
            //                case 5:
            //                    return;
            //                default:
            //                    Console.WriteLine("Invalid Choice");
            //                    break;
            //            }



            //        }

            //        private static void DeleteRetailer()
            //        {
            //            try
            //            {
            //                int deleteRetailerID;
            //                Console.WriteLine("Enter RetailerID to Delete:");
            //                deleteRetailerID = Convert.ToInt32(Console.ReadLine());
            //                RetailerBL retailerBL = new RetailerBL();
            //                Retailer deleteRetailer = retailerBL.GetRetailerByIDBL(deleteRetailerID);
            //                if (deleteRetailer != null)
            //                {
            //                    bool guestdeleted = retailerBL.DeleteRetailerBL(deleteRetailerID);
            //                    if (guestdeleted)
            //                        Console.WriteLine("Retailer Deleted");
            //                    else
            //                        Console.WriteLine("Retailer not Deleted ");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No Retailer Details Available");
            //                }




            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void UpdateRetailer()
            //        {
            //            try
            //            {
            //                int updateRetailerID;
            //                Console.WriteLine("Enter RetailerID to Update Details:");
            //                updateRetailerID = Convert.ToInt32(Console.ReadLine());
            //                RetailersDAL retailerDAL = new RetailersDAL();
            //                Retailer updatedRetailer = retailerDAL.GetRetailerByIDDAL(updateRetailerID-1);
            //                if (updatedRetailer != null)
            //                {
            //                    Console.WriteLine("New Retailer Name :");
            //                    updatedRetailer.RetailerName = Console.ReadLine();
            //                    Console.WriteLine("New PhoneNumber :");
            //                    updatedRetailer.RetailerMobile = Console.ReadLine();
            //                    Console.WriteLine("New Retailer Email");
            //                    updatedRetailer.RetailerEmail = Console.ReadLine();
            //                    bool guestUpdated = retailerDAL.UpdateRetailerDetailDAL(updatedRetailer);
            //                    if (guestUpdated)
            //                        Console.WriteLine("Retailer Details Updated");
            //                    else
            //                        Console.WriteLine("Retailer Details not Updated ");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No Retailer Details Available");
            //                }


            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void GetRetailerByID()
            //        {
            //            try
            //            {
            //                int searchRetailerID;
            //                Console.WriteLine("Enter RetailerID to Search:");
            //                searchRetailerID = Convert.ToInt32(Console.ReadLine());
            //                RetailersDAL retailersDAL = new RetailersDAL();
            //                Retailer searchRetailers = retailersDAL.GetRetailerByIDDAL(searchRetailerID);
            //                if (searchRetailers != null)
            //                {
            //                    Console.WriteLine("******************************************************************************");
            //                    Console.WriteLine("RetailerID\t\tName\t\tPhoneNumber");
            //                    Console.WriteLine("******************************************************************************");
            //                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchRetailers.RetailerID, searchRetailers.RetailerName, searchRetailers.RetailerMobile);
            //                    Console.WriteLine("******************************************************************************");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No Retailer Details Available");
            //                }

            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void AddRetailer()
            //        {
            //            try
            //            {

            //                Retailer newRetailer = new Retailer();
            //                Console.WriteLine("Enter Retailer Name :");
            //                newRetailer.RetailerName = Console.ReadLine();
            //                Console.WriteLine("Enter PhoneNumber :");
            //                newRetailer.RetailerMobile = Console.ReadLine();
            //                Console.WriteLine("Enter Retailers Email");
            //                newRetailer.RetailerEmail= Console.ReadLine(); 
            //                RetailerBL retailer = new RetailerBL();
            //                bool retailerAdded = retailer.AddRetailerBL(newRetailer);
            //                if (retailerAdded)
            //                {
            //                    Console.WriteLine("Retailer Added");
            //                    Console.WriteLine("Your Retailer ID= ", newRetailer.RetailerID);
            //                }
            //                else
            //                    Console.WriteLine("Retailer Not Added");

            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void RetailerPrintMenu()
            //        {
            //            Console.WriteLine("\n***********Retailer PhoneBook Menu***********");
            //            Console.WriteLine("1. Add Retailer");
            //            Console.WriteLine("2. Search Retailer by ID");
            //            Console.WriteLine("3. Update Retailer");
            //            Console.WriteLine("4. Delete Retailer");
            //            Console.WriteLine("5. Exit");
            //            Console.WriteLine("******************************************\n");

            //        }

            //        public static void SalesPerson()
            //        {
            //            SalesPersonPrintMenu();
            //            Console.WriteLine("Enter Your Choice");
            //            int c = Convert.ToInt32(Console.ReadLine());
            //            switch (c)
            //            {
            //                case 1:
            //                    AddSalesPerson();
            //                    break;
            //                case 2:
            //                    GetSalesPersonByID();
            //                    break;
            //                case 3:
            //                    UpdateSalesPerson();
            //                    break;
            //                case 4:
            //                    DeleteSalesPerson();
            //                    break;
            //                case 5:
            //                    return;
            //                default:
            //                    Console.WriteLine("Invalid Choice");
            //                    break;
            //            }



            //        }

            //        private static void DeleteSalesPerson()
            //        {
            //            try
            //            {
            //                int deleteSalesPersonID;
            //                Console.WriteLine("Enter SalesPersonID to Delete:");
            //                deleteSalesPersonID = Convert.ToInt32(Console.ReadLine());
            //                SalesPersonBL SalesPersonBL = new SalesPersonBL();
            //                IUser deleteSalesPerson = SalesPersonBL.GetSalesPersonByIDBL(deleteSalesPersonID);
            //                if (deleteSalesPerson != null)
            //                {
            //                    bool guestdeleted = SalesPersonBL.DeleteSalesPersonBL(deleteSalesPersonID);
            //                    if (guestdeleted)
            //                        Console.WriteLine("SalesPerson Deleted");
            //                    else
            //                        Console.WriteLine("SalesPerson not Deleted ");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No SalesPerson Details Available");
            //                }




            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void UpdateSalesPerson()
            //        {
            //            try
            //            {
            //                int updateSalesPersonID;
            //                Console.WriteLine("Enter SalesPersonID to Update Details:");
            //                updateSalesPersonID = Convert.ToInt32(Console.ReadLine());
            //                SalesPersonDAL SalesPersonDAL = new SalesPersonDAL();
            //                IUser updatedSalesPerson = SalesPersonDAL.GetSalesPersonByIDDAL(updateSalesPersonID - 1);
            //                if (updatedSalesPerson != null)
            //                {
            //                    Console.WriteLine("New SalesPerson Name :");
            //                    updatedSalesPerson.SalesPersonName = Console.ReadLine();
            //                    Console.WriteLine("New PhoneNumber :");
            //                    updatedSalesPerson.SalesPersonMobile = Console.ReadLine();
            //                    Console.WriteLine("New SalesPerson Email");
            //                    updatedSalesPerson.SalesPersonEmail = Console.ReadLine();
            //                    bool guestUpdated = SalesPersonDAL.UpdateSalesPersonDetailDAL(updatedSalesPerson);
            //                    if (guestUpdated)
            //                        Console.WriteLine("SalesPerson Details Updated");
            //                    else
            //                        Console.WriteLine("SalesPerson Details not Updated ");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No SalesPerson Details Available");
            //                }


            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void GetSalesPersonByID()
            //        {
            //            try
            //            {
            //                int searchSalesPersonID;
            //                Console.WriteLine("Enter SalesPersonID to Search:");
            //                searchSalesPersonID = Convert.ToInt32(Console.ReadLine());
            //                SalesPersonDAL SalesPersonsDAL = new SalesPersonDAL();
            //                IUser searchSalesPersons = SalesPersonsDAL.GetSalesPersonByIDDAL(searchSalesPersonID);
            //                if (searchSalesPersons != null)
            //                {
            //                    Console.WriteLine("******************************************************************************");
            //                    Console.WriteLine("SalesPersonID\t\tName\t\tPhoneNumber");
            //                    Console.WriteLine("******************************************************************************");
            //                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchSalesPersons.SalesPersonID, searchSalesPersons.SalesPersonName, searchSalesPersons.SalesPersonMobile);
            //                    Console.WriteLine("******************************************************************************");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No SalesPerson Details Available");
            //                }

            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void AddSalesPerson()
            //        {
            //            try
            //            {

            //                IUser newSalesPerson = new IUser();
            //                Console.WriteLine("Enter SalesPerson Name :");
            //                newSalesPerson.SalesPersonName = Console.ReadLine();
            //                Console.WriteLine("Enter PhoneNumber :");
            //                newSalesPerson.SalesPersonMobile = Console.ReadLine();
            //                Console.WriteLine("Enter SalesPersons Email");
            //                newSalesPerson.SalesPersonEmail = Console.ReadLine();
            //                SalesPersonBL SalesPerson = new SalesPersonBL();
            //                bool SalesPersonAdded = SalesPerson.AddSalesPersonBL(newSalesPerson);
            //                if (SalesPersonAdded)
            //                {
            //                    Console.WriteLine("SalesPerson Added");
            //                    Console.WriteLine("Your SalesPerson ID= ", newSalesPerson.SalesPersonID);
            //                }
            //                else
            //                    Console.WriteLine("SalesPerson Not Added");

            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }

            //        private static void SalesPersonPrintMenu()
            //        {
            //            Console.WriteLine("\n***********SalesPerson PhoneBook Menu***********");
            //            Console.WriteLine("1. Add SalesPerson");
            //            Console.WriteLine("2. Search SalesPerson by ID");
            //            Console.WriteLine("3. Update SalesPerson");
            //            Console.WriteLine("4. Delete SalesPerson");
            //            Console.WriteLine("5. Exit");
            //            Console.WriteLine("******************************************\n");

            //        }
            //        private static void AdminPrintMenu()
            //        {
            //            Console.WriteLine("\n***********Admin menu ***********");
            //            Console.WriteLine("1. update admin details");
            //            Console.WriteLine("2. view sales reports");
            //            Console.WriteLine("3. view retailer reports");
            //            Console.WriteLine("4. view overall reports");
            //            Console.WriteLine("5. Exit");
            //            Console.WriteLine("******************************************\n");

            //        }
            //        private static void UpdateAdmin()
            //        {
            //            try
            //            {
            //                int updateAdminID;
            //                Console.WriteLine("Enter AdminID to Update Details:");
            //                updateAdminID = Convert.ToInt32(Console.ReadLine());
            //                Admin updatedAdmin = AdminBL.SearchAdminBL(updateAdminID);
            //                if (updatedAdmin != null)
            //                {
            //                    Console.WriteLine("Update Admin Name :");
            //                    updatedAdmin.AdminName = Console.ReadLine();
            //                    Console.WriteLine("Update PhoneNumber :");
            //                    updatedAdmin.AdminContactNumber = int.Parse(Console.ReadLine());
            //                    bool AdminUpdated = AdminBL.UpdateAdminBL(updatedAdmin);
            //                    if (AdminUpdated)
            //                        Console.WriteLine("Admin Details Updated");
            //                    else
            //                        Console.WriteLine("Admin Details not Updated ");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No Admin Details Available");
            //                }


            //            }
            //            catch (GreatOutdoorException ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }
            //          public static void Admin()
            //          {
            //         AdminPrintMenu();
            //           WriteLine("Enter Your Choice");
            //         int c = int.Parse(Console.ReadLine());
            //          switch (c)
            //    {
            //        case 1:
            //            UpdateAdmin();
            //            break;
            //        case 2:
            //            ViewSalesreports();
            //            break;
            //        case 3:
            //            ViewRetailerreports();
            //            break;
            //        case 4:
            //            ViewOverallreports();
            //            break;
            //        case 5:
            //            return;
            //        default:
            //            Console.WriteLine("Invalid Choice");
            //            break;
            //    }
            //           }
            //            private static void ViewSalesreports() { }
            //            private static void ViewRetailerreports() { }
            //            private static void ViewOverallreports() { }


        }


        }
    }

