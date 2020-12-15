using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.EFCore.Models;

namespace WebApplication.EFCore.Services
{
    public interface IUserRolesService
    {
        Task<IEnumerable<UserRoles>> GetUserRoles();
    }
}