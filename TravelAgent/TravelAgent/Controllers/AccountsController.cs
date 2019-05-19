using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.DataContract.Requests;

namespace TravelAgent.ClientApp
{
    [ApiController]
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

    }
}
