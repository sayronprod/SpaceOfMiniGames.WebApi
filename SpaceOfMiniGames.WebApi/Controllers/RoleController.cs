using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDto;

namespace SpaceOfMiniGames.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoleController : BaseApiController
    {
        private readonly ILogger<UserController> logger;
        private readonly IRoleService roleService;

        public RoleController(ILogger<UserController> logger, IRoleService roleService)
        {
            this.logger = logger;
            this.roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<string>))]
        public async Task<ICollection<string>> GetRoles()
        {
            ICollection<string>? roles = await roleService.GetRoles();
            return roles;
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(MessageDto))]
        public async Task<object> AddRole(AddRoleRequestDto request)
        {
            object result;
            await roleService.AddRole(request.RoleName);

            result = new MessageDto
            {
                Message = "Success"
            };
            SetStatusCode(200);

            return result;
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(MessageDto))]
        public async Task<object> DeleteRole(DeleteRoleRequestDto request)
        {
            object result;
            await roleService.DeleteRole(request.RoleName);

            result = new MessageDto
            {
                Message = "Success"
            };
            SetStatusCode(200);

            return result;
        }
    }
}
