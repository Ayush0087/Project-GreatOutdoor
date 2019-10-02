using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.BusinessLayer;
using Capgemini.Greatoutdoor.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.Inventory.UnitTests

{
    [TestClass]
    public class AddOnlineReturnBLTest
    {
        /// <summary>
        /// Add OnlineReturn to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidOnlineReturn()
        {
            //Arrange
            OnlineReturnBL salesPersonBL = new OnlineReturnBL();
            OnlineReturn salesPerson = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = 4, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn OrderNumber can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnOrderNumberCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = null, ProductNumber = 1, QuantityOfReturn = 4, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn Product Number can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnProductNumberCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = null, QuantityOfReturn = 4, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn QuantityOfReturn can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnQuantityOfReturnCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = null, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn Purpose can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnPurposeCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = 4, Purpose = null, ProductPrice = 100, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await BL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn ProductPrice can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnProductPriceCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = 4, Purpose = "Unsatisfactory", ProductPrice = null, ReturnAmount = 400 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await BL.AddOnlineReturnBL(onlineReturn);
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
        /// OnlineReturn ReturnAmount can't be null
        /// </summary>
        [TestMethod]
        public async Task OnlineReturnReturnAmountCanNotBeNull()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = 4, Purpose = "Unsatisfactory", ProductPrice = 100, ReturnAmount = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await BL.AddOnlineReturnBL(onlineReturn);
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
        public class UpdateOnlineReturnBLTest
        {
            /// <summary>
            /// Update OnlineReturn to the Collection if it is valid.
            /// </summary>
            [TestMethod]
            public async Task UpdateValidOnlineReturn()
            {
                //Arrange
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn onlineReturn = new OnlineReturn() { QuantityOfReturn = 4, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
                bool isAdded = false;
                string errorMessage = null;

                //Act
                try
                {
                    isAdded = await onlineReturnBL.UpdateOnlineReturnBL(onlineReturn);
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
            /// OnlineReturn QuantityOfReturn can't be null
            /// </summary>
            [TestMethod]
            public async Task OnlineReturnQuantityOfReturnCanNotBeNull()
            {
                //Arrange
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn onlineReturn = new OnlineReturn() {QuantityOfReturn = null, Purpose = "UnSatisfactory", ProductPrice = 100, ReturnAmount = 400 };
                bool isAdded = false;
                string errorMessage = null;

                //Act
                try
                {
                    isAdded = await onlineReturnBL.UpdateOnlineReturnBL(onlineReturn);
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
            /// OnlineReturn Purpose can't be null
            /// </summary>
            [TestMethod]
            public async Task OnlineReturnPurposeCanNotBeNull()
            {
                //Arrange
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn onlineReturn = new OnlineReturn() { QuantityOfReturn = 4, Purpose = null, ProductPrice = 100, ReturnAmount = 400 };
                bool isAdded = false;
                string errorMessage = null;

                //Act
                try
                {
                    isAdded = await BL.UpdateOnlineReturnBL(onlineReturn);
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
            /// OnlineReturn ProductPrice can't be null
            /// </summary>
            [TestMethod]
            public async Task OnlineReturnProductPriceCanNotBeNull()
            {
                //Arrange
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn onlineReturn = new OnlineReturn() {QuantityOfReturn = 4, Purpose = "Unsatisfactory", ProductPrice = null, ReturnAmount = 400 };
                bool isAdded = false;
                string errorMessage = null;

                //Act
                try
                {
                    isAdded = await BL.UpdateOnlineReturnBL(onlineReturn);
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
            /// OnlineReturn ReturnAmount can't be null
            /// </summary>
            [TestMethod]
            public async Task OnlineReturnReturnAmountCanNotBeNull()
            {
                //Arrange
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn onlineReturn = new OnlineReturn() { OrderNumber = 20, ProductNumber = 1, QuantityOfReturn = 4, Purpose = "Unsatisfactory", ProductPrice = 100, ReturnAmount = null };
                bool isAdded = false;
                string errorMessage = null;

                //Act
                try
                {
                    isAdded = await BL.UpdatOnlineReturnBL(onlineReturn);
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
    public class DeleteOnlineReturnBLTest
    {

        /// <summary>
        /// delete OnlineReturn to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task DeleteValidOnlineReturnBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OnlineRetuenID = 1001 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.DeleteOnlineReturnBL(onlineReturn);
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
        /// delete OnlineReturn to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task DeleteinValidOnlineReturnBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OnlineReturnID = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.DeleteOnlineReturnBL(onlineReturn);
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
    public class GetOnlineReturnByOnlineReturnIDBLTest
    {

        /// <summary>
        /// GetOnlineReturnByOnlineReturnID to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnByOnlineReturnIDBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OnlineReturnID = 1234567899876543 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnByOnlineReturnIDBL(onlineReturn);
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
        /// GetOnlineReturnByOnlineReturnID to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnByOnlineReturnIDBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { OnlineReturnID = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnByOnlineReturnIDBL(onlineReturn);
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
    public class GetOnlineReturnByOnlineRetailerIDBLTest
    {


        /// <summary>
        /// GetOnlineReturnByRetailerID to the Collection if it is isvalid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnByOnlineRetailerIDBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { RetailerID = 1234567899876543 };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnByOnlineRetailerIDBL(onlineReturn);
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
        /// GetOnlineReturnByRetailerIDBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnByRetailerIDBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { RetailerID = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnByRetailerIDBL(onlineReturn);
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
    public class GetOnlineReturnsByPurposeBLTest
    {


        /// <summary>
        /// GetOnlineReturnsByPurposeBL to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnsByPurposeBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { Purpose = "Unsatisfactory" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnsByPurposeBL(onlineReturn);
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
        /// GetOnlineReturnsByPurposeBL to the Collection if it is invalid.
        /// </summary>
        [TestMethod]
        public async Task GetOnlineReturnsByPurposeBL()
        {
            //Arrange
            OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
            OnlineReturn onlineReturn = new OnlineReturn() { Purpose = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await onlineReturnBL.GetOnlineReturnsByPurposeBL(onlineReturn);
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