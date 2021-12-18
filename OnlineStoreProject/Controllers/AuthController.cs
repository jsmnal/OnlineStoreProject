using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineStoreProject.Models;
using OnlineStoreProject.Resources;
using OnlineStoreProject.Settings;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly UserManager<OnlineStoreUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public AuthController(UserManager<OnlineStoreUser> userManager, IMapper mapper, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            var user = _mapper.Map<UserSignUpResource, OnlineStoreUser>(userSignUpResource);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (user is null) return NotFound("User not found");

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);
            if (userSigninResult) return Ok(GenerateJwt(user));

            return BadRequest("Email or password is incorrect.");
        }

        private string GenerateJwt(OnlineStoreUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}