using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.Greatoutdoor.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests
{
    [TestClass]
    public class AddSalesPersonBLTest
    {
        /// <summary>
        /// Add SalesPerson to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidSalesPerson()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Name can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = null, SalesPersonMobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalespPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Smith", SalesPersonMobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Password can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Allen", SalesPersonMobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Email can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "J", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }


    [TestClass]
    public class UpdateSalesPersonBLTest
    {
        /// <summary>
        /// Update SalesPerson to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task UpdateValidSalesPerson()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Name can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = null, SalesPersonMobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalespPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Smith", SalesPersonMobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Password can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Allen", SalesPersonMobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Email can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "J", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }


    [TestClass]
    public class DeleteSalesPersonBLTest
    {

        /// <summary>
        /// delete SalesPerson to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DeleteValidSalesPersonBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonID = 1001100210031004 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.DeleteSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// delete SalesPerson to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task DeleteinValidSalesPersonBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonID = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.DeleteSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }
    }

    [TestClass]
    public class GetSalesPersonBySalesPersonIDBLTest
    {

        /// <summary>
        /// GetSalesPersonBySalesPersonIDBL to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonBySalesPersonIDBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonID = 1234567899876543 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonBySalesPersonIDBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// GetSalesPersonBySalesPersonIDBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonBySalesPersonIDBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonID = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonBySalesPersonIDBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }
    }


    [TestClass]
    public class GetSalesPersonByEmailBLTest
    {

        /// <summary>
        /// GetSalesPersonByEmailBL to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email = "salesperson@capgemini.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// GetSalesPersonByEmailBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email= null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }
    }


    [TestClass]
    public class GetSalesPersonsByNameBLTest
    {

        /// <summary>
        /// GetSalesPersonsByNameBL to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonsByNameBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { salesPersonName = "John" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonsByNameBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// GetSalesPersonsByNameBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonsByNameBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { salesPersonName = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonsByNameBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }
    }

   

    [TestClass]
    public class GetSalesPersonByEmailAndPasswordBLTest
    {

        /// <summary>
        ///  GetSalesPersonByEmailAndPasswordBL to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailAndPasswordBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email = "salesperson@capgemini.com", Password = "manager" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        ///  GetSalesPersonByEmailAndPasswordBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailAndPasswordBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email = null, Password = "manager" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        ///  GetSalesPersonByEmailAndPasswordBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailAndPasswordBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email = "salesperson@capgemini.com", Password = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        ///  GetSalesPersonByEmailAndPasswordBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetSalesPersonByEmailAndPasswordBL()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { Email = null, Password = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }



    }






}




