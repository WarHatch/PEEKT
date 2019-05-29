using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Cross_cutting;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;
using TravelAgent.DataContract.Responses;

namespace TravelAgent.ClientApp
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOfficeRepository _officeRepository;

        public AccountsController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IEmployeeRepository employeeRepository, IOfficeRepository officeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeeRepository = employeeRepository;
            _officeRepository = officeRepository;
        }

        [HttpPost("register")]
        [TrackExecutionTime]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest registerAccount)
        {
            var user = new Employee
            {
                UserName = registerAccount.Email,
                Email = registerAccount.Email,
                FirstName = registerAccount.FirstName,
                LastName = registerAccount.LastName,
            };
            if(registerAccount.ProfilePhoto != null)
            {
                user.ProfilePhoto = registerAccount.ProfilePhoto;
            }
            if (registerAccount.RegisteredOfficeId != 0)
            {
                user.RegisteredOffice = await _officeRepository.FindById(registerAccount.RegisteredOfficeId);
            }

            

            var result = await _userManager.CreateAsync(user, registerAccount.Password);

            if (!result.Succeeded)
            {
                return Conflict();
            }

            return Ok(DateTime.Now);
        }

        [HttpPost("login")]
        [TrackExecutionTime]
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
        [TrackExecutionTime]
        public async Task<IActionResult> GetMe()
        {
            var userName = User.Identity.Name;
            var identityUser = await _userManager.FindByNameAsync(userName);

            var userData = new UserResponse
            {
                Email = identityUser.Email,
                FirstName = identityUser.FirstName,
                LastName = identityUser.LastName,
                ProfilePhoto = identityUser.ProfilePhoto,
                RegisteredOffice = identityUser.RegisteredOffice
            };

            return Ok(userData);
        }

        [HttpPut("me")]
        [Authorize]
        [TrackExecutionTime]
        public async Task<IActionResult> UpdateMe([FromBody]UpdateMeRequest request)
        {
            try
            {
                var userName = User.Identity.Name;
                var identityUser = await _userManager.FindByNameAsync(userName);
                if (request.FirstName != null)
                {
                    identityUser.FirstName = request.FirstName;
                }
                if (request.LastName != null)
                {
                    identityUser.LastName = request.LastName;
                }
                if (request.ProfilePhoto != null)
                {
                    identityUser.ProfilePhoto = request.ProfilePhoto;
                }
                if (request.RegisteredOfficeId != 0)
                {
                    identityUser.RegisteredOffice = await _officeRepository.FindById(request.RegisteredOfficeId);
                }

                await _employeeRepository.Update(identityUser);


                return await GetMe();
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("logout")]
        [TrackExecutionTime]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

    }
}
