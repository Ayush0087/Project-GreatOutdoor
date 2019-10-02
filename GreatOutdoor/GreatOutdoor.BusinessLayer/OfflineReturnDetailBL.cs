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
        public class OfflineReturnDetailBL : BLBase<OfflineReturnDetail>, IOfflineReturnDetailBL, IDisposable
        {
            //fields
            OfflineReturnDetailDAL OfflineReturnDetailDAL;

            /// <summary>
            /// Constructor.
            /// </summary>
            public OfflineReturnDetailBL()
            {
                this.OfflineReturnDetailDAL = new OfflineReturnDetailDAL();
            }
            /// Validations on data before adding or updating.
            /// </summary>
            /// <param name="entityObject">Represents object to be validated.</param>
            /// <returns>Returns a boolean value, that indicates whether the data is valid or not.</returns>
            protected async override Task<bool> Validate(OfflineReturnDetail entityObject)
            {
                //Create string builder
                StringBuilder sb = new StringBuilder();
                bool valid = await base.Validate(entityObject);




                if (valid == false)
                    throw new OfflineOrderException(sb.ToString());
                return valid;
            }


            /// <summary>
            /// Adds new OfflineReturnDetail to OfflineReturnDetails collection.
            /// </summary>
            /// <param name="newOfflineReturnDetail">Contains the OfflineReturnDetail details to be added.</param>
            /// <returns>Determinates whether the new OfflineReturnDetail is added.</returns>
            public async Task<bool> AddOfflineReturnDetailBL(OfflineReturnDetail newOfflineReturnDetail)
            {
                bool OfflineReturnDetailAdded = false;
                try
                {
                    if (await Validate(newOfflineReturnDetail))
                    {
                        await Task.Run(() =>
                        {
                            this.OfflineReturnDetailDAL.AddOfflineReturnDetailDAL(newOfflineReturnDetail);
                            OfflineReturnDetailAdded = true;
                            Serialize();
                        });
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnDetailAdded;
            }
            /// <summary>
            /// Gets OfflineReturnDetail based on OfflineReturnDetailID.
            /// </summary>
            /// <param name="searchOrderID">Represents OfflineReturnDetailID to search.</param>
            /// <returns>Returns OfflineReturnDetail object.</returns>
            public async Task<OfflineReturnDetail> GetOfflineReturnDetailByOfflineReturnDetailIDBL(Guid searchOfflineReturnDetailID)
            {
                OfflineReturnDetail matchingOfflineReturnDetail = null;
                try
                {
                    await Task.Run(() =>
                    {
                        matchingOfflineReturnDetail = OfflineReturnDetailDAL.GetOfflineReturnDetailByOfflineReturnDetailIDDAL(searchOfflineReturnDetailID);
                    });
                }
                catch (Exception)
                {
                    throw;
                }
                return matchingOfflineReturnDetail;
            }



            /// <summary>
            /// Updates OfflineReturnDetail based on OfflineReturnDetailID.
            /// </summary>
            /// <param name="updateOfflineReturnDetail">Represents OfflineReturnDetail details including OfflineReturnDetailID, OfflineReturnDetailName etc.</param>
            /// <returns>Determinates whether the existing OfflineReturnDetail is updated.</returns>
            public async Task<bool> UpdateOfflineReturnDetailBL(OfflineReturnDetail updateOfflineReturnDetail)
            {
                bool OfflineReturnDetailUpdated = false;
                try
                {
                    if ((await Validate(updateOfflineReturnDetail)) && (await GetOfflineReturnDetailByOfflineReturnDetailIDBL(updateOfflineReturnDetail.OfflineReturnDetailID)) != null)
                    {
                        this.OfflineReturnDetailDAL.UpdateOfflineReturnDetailDAL(updateOfflineReturnDetail);
                        OfflineReturnDetailUpdated = true;
                        Serialize();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnDetailUpdated;
            }

            /// <summary>
            /// Deletes OfflineReturnDetail based on OfflineReturnDetailID.
            /// </summary>
            /// <param name="deleteOfflineReturnDetailID">Represents OfflineReturnDetailID to delete.</param>
            /// <returns>Determinates whether the existing OfflineReturnDetail is updated.</returns>
            public async Task<bool> DeleteOfflineReturnDetailBL(Guid deleteOfflineReturnDetailID)
            {
                bool OfflineReturnDetailDeleted = false;
                try
                {
                    await Task.Run(() =>
                    {
                        OfflineReturnDetailDeleted = OfflineReturnDetailDAL.DeleteOfflineReturnDetailDAL(deleteOfflineReturnDetailID);
                        Serialize();
                    });
                }
                catch (Exception)
                {
                    throw;
                }
                return OfflineReturnDetailDeleted;
            }



            /// <summary>
            /// Disposes DAL object(s).
            /// </summary>
            public void Dispose()
            {
                ((OfflineReturnDetailDAL)OfflineReturnDetailDAL).Dispose();
            }


            /// <summary>
            /// Invokes Serialize method of DAL.
            /// </summary>
            public void Serialize()
            {
                try
                {
                    OfflineReturnDetailDAL.Serialize();
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
                    OfflineReturnDetailDAL.Deserialize();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }









