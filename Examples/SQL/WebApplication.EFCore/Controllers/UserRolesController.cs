using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRolesController : ControllerBase
    {
        private ILogger<UserRolesController> Logger { get; }
        private IUserDataAccess UserDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public UserRolesController(ILogger<UserRolesController> logger, IUserDataAccess userDataAccess, IMapper mapper)
        {
            Logger = logger;
            UserDataAccess = userDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserRoles>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(UserRolesController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<UserRoles>>(await this.UserDataAccess.GetAllAsync(ct));
        }
    }
}