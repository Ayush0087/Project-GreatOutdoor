using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Entities;

namespace Capgemini.GreatOutdoor.Contracts.BLContracts
{
    public interface IOfflineReturnBL : IDisposable
    {
        Task<bool> AddOfflineReturnBL(OfflineReturn newOfflineReturn);
        Task<OfflineReturn> GetOfflineReturnByOfflineReturnIDBL(Guid searchOfflineReturnID);

        Task<bool> UpdateOfflineReturnBL(OfflineReturn updateOfflineReturn);
        Task<bool> DeleteOfflineReturnBL(Guid deleteOfflineReturnID);
    }
}
