using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.EFCore.Models;

namespace WebApplication.EFCore.Services
{
    public class UserRolesService : IUserRolesService
    {
        private HttpClient HttpClient { get; }
        
        public UserRolesService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<UserRoles>> GetUserRoles()
        {
            using var response = await this.HttpClient.GetAsync("userroles");

            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<UserRoles>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}