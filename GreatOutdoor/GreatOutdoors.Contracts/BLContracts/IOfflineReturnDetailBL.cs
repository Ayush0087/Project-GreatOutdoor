using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Entities;

namespace Capgemini.GreatOutdoor.Contracts.BLContracts
{
    public interface IOfflineReturnDetailBL : IDisposable
    {
        Task<bool> AddOfflineReturnDetailBL(OfflineReturnDetail newOfflineReturnDetail);
        Task<OfflineReturnDetail> GetOfflineReturnDetailByOfflineReturnDetailIDBL(Guid searchOfflineReturnDetailID);
        Task<bool> UpdateOfflineReturnDetailBL(OfflineReturnDetail updateOfflineReturnDetail);
        Task<bool> DeleteOfflineReturnDetailBL(Guid deleteOfflineReturnDetailID);



    }
}


