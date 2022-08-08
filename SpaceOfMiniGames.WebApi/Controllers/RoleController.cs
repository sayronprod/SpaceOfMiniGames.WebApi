using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceOfMiniGames.WebApi.Models.Interfaces;
using SpaceOfMiniGames.WebApi.Models.ModelsDto.RoleController;

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

        [HttpPost]
        public async Task<GetRolesResponse> GetRoles()
        {
            ICollection<string> roles = await roleService.GetRoles();

            GetRolesResponse response = new GetRolesResponse();
            response.Roles = roles;
            response.SetSuccess();

            return response;
        }

        [HttpPost]
        public async Task<AddRoleResponse> AddRole(AddRoleRequest request)
        {
            await roleService.AddRole(request.RoleName);

            AddRoleResponse response = new AddRoleResponse();
            response.SetSuccess();

            return response;
        }

        [HttpPost]
        public async Task<DeleteRoleResponse> DeleteRole(DeleteRoleRequest request)
        {
            await roleService.DeleteRole(request.RoleName);

            DeleteRoleResponse response = new DeleteRoleResponse();
            response.SetSuccess();

            return response;
        }
    }
}
