using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.DataContract.Requests;
using TravelAgent.DataContract.Responses;

namespace TravelAgent.ClientApp
{
    [ApiController]
    [EnableCors("authPolicy")]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AccountsController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest registerAccount)
        {
            var user = new Employee
            {
                UserName = registerAccount.Email,
                Email = registerAccount.Email
            };

            var result = await _userManager.CreateAsync(user, registerAccount.Password);

            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok(DateTime.Now);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName,
                login.Password, login.RememberMe, false);


            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok(DateTime.Now);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            var userName = User.Identity.Name;
            var identityUser = await _userManager.FindByNameAsync(userName);
            //userManager.Users.SingleAsync(user => user.UserName == userName);

            var userData = new UserResponse
            {
                Email = identityUser.Email
            };

            return Ok(userData);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

    }
}
