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
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;

        public AccountsController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest registerAccount)
        {
            var user = new Employee
            {
                UserName = registerAccount.UserName,
                Email = registerAccount.Email
            };

            var result = await userManager.CreateAsync(user, registerAccount.Password);

            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok(DateTime.Now);
        }

    }
}
