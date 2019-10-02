using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.GreatOutdoor.Entities;

namespace Capgemini.GreatOutdoor.Contracts.BLContracts
{
    public interface IAdminBL : IDisposable
    {
        Task<Admin> GetAdminByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateAdminBL(Admin updateAdmin);
        Task<bool> UpdateAdminPasswordBL(Admin updateAdmin);
        Task<Admin> GetAdminByAdminEmailBL(string Email);
    }
}