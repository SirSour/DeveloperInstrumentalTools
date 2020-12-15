using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IUserRolesService
    {
        Task<IEnumerable<UserRoles>> GetUserRoles();
    }
}