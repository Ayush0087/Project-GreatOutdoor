
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Capgemini.GreatOutdoor.Entities;
    using Capgemini.GreatOutdoor.DataAccessLayer;
    using Capgemini.GreatOutdoor.Contracts.BLContracts;
    using Capgemini.GreatOutdoor.Exceptions;

    namespace Capgemini.GreatOutdoor.BusinessLayer
    {
        public class OfflineReturnBL : BLBase<OfflineReturn>, IOfflineReturnBL, IDisposable
        {
            //fields
            OfflineReturnDAL OfflineReturnDAL;

            /// <summary>
            /// Constructor.
            /// </summary>
            public OfflineReturnBL()
            {
                this.OfflineReturnDAL = new OfflineReturnDAL();
            }
            /// Validations on data before adding or updating.
            /// </summary>
            /// <param name="entityObject">Represents object to be validated.</param>
            /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
            protected async override Task<bool> Validate(OfflineReturn entityObject)
            {
                //Create string builder
                StringBuilder sb = new StringBuilder();
                bool valid = await base.Validate(entityObject);




                if (valid == false)
                    throw new OfflineReturnException(sb.ToString());
                return valid;
            }


            /// <summary>
            /// Adds new OfflineReturn to OfflineReturns collection.
            /// </summary>
            /// <param name="newOfflineReturn">Contains the OfflineReturn details to be added.</param>
            /// <returns>Determinates whether the new OfflineReturn is added.</returns>
            public async Task<bool> AddOfflineReturnBL(OfflineReturn newOfflineReturn)
            {
                bool OfflineReturnAdded = false;
                try
                {
                    if (await Validate(newOfflineReturn))
                    {
                        await Task.Run(() =>
                        {
                            this.OfflineReturnDAL.AddOfflineReturnDAL(newOfflineReturn);
                            OfflineReturnAdded = true;
                            Serialize();
                        });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnAdded;
            }
            /// <summary>
            /// Gets OfflineReturn based on OfflineReturnID.
            /// </summary>
            /// <param name="searchOrderID">Represents OfflineReturnID to search.</param>
            /// <returns>Returns OfflineReturn object.</returns>
            public async Task<OfflineReturn> GetOfflineReturnByOfflineReturnIDBL(Guid searchOfflineReturnID)
            {
                OfflineReturn matchingOfflineReturn = null;
                try
                {
                    await Task.Run(() =>
                    {
                        matchingOfflineReturn = OfflineReturnDAL.GetOfflineReturnByOfflineReturnIDDAL(searchOfflineReturnID);
                    });
                }
                catch (Exception)
                {
                    throw;
                }
                return matchingOfflineReturn;
            }



            /// <summary>
            /// Updates OfflineReturn based on OfflineReturnID.
            /// </summary>
            /// <param name="updateOfflineReturn">Represents OfflineReturn details including OfflineReturnID, OfflineReturnName etc.</param>
            /// <returns>Determinates whether the existing OfflineReturn is updated.</returns>
            public async Task<bool> UpdateOfflineReturnBL(OfflineReturn updateOfflineReturn)
            {
                bool OfflineReturnUpdated = false;
                try
                {
                    if ((await Validate(updateOfflineReturn)) && (await GetOfflineReturnByOfflineReturnIDBL(updateOfflineReturn.OfflineReturnID)) != null)
                    {
                        this.OfflineReturnDAL.UpdateOfflineReturnDAL(updateOfflineReturn);
                        OfflineReturnUpdated = true;
                        Serialize();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnUpdated;
            }

            /// <summary>
            /// Deletes OfflineReturn based on OfflineReturnID.
            /// </summary>
            /// <param name="deleteOfflineReturnID">Represents OfflineReturnID to delete.</param>
            /// <returns>Determinates whether the existing OfflineReturn is updated.</returns>
            public async Task<bool> DeleteOfflineReturnBL(Guid deleteOfflineReturnID)
            {
                bool OfflineReturnDeleted = false;
                try
                {
                    await Task.Run(() =>
                    {
                        OfflineReturnDeleted = OfflineReturnDAL.DeleteOfflineReturnDAL(deleteOfflineReturnID);
                        Serialize();
                    });
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnDeleted;
            }



            /// <summary>
            /// Disposes DAL object(s).
            /// </summary>
            public void Dispose()
            {
                ((OfflineReturnDAL)OfflineReturnDAL).Dispose();
            }


            /// <summary>
            /// Invokes Serialize method of DAL.
            /// </summary>
            public void Serialize()
            {
                try
                {
                    OfflineReturnDAL.Serialize();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            ///Invokes Deserialize method of DAL.
            /// </summary>
            public void Deserialize()
            {
                try
                {
                    OfflineReturnDAL.Deserialize();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }







