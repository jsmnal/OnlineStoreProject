using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Models;
using OnlineStoreProject.Resources;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly UserManager<OnlineStoreUser> _userManager;
       private readonly IMapper _mapper;

       public UserController(UserManager<OnlineStoreUser> userManager, IMapper mapper)
       {
           _userManager = userManager;
           _mapper = mapper;
       }

       [HttpPost("create")]
        public async Task<IActionResult> Create(UserResource userResource)
        {
            var user = _mapper.Map<UserResource, OnlineStoreUser>(userResource);

            var userCreateResult = await _userManager.CreateAsync(user);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }
    }
}