using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.EFCore.Models;
using WebApplication.EFCore.Services;

namespace WebApplication.EFCore.Controllers
{
    public class UserRolesController : Controller
    {
        private IUserRolesService UserRolesService { get; }
        
        public UserRolesController(IUserRolesService userRolesService)
        {
            UserRolesService = userRolesService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.UserRolesService.GetUserRoles());
        }

        public IActionResult Details(UserRoles model)
        {
            return this.View(model);
        }
    }
}