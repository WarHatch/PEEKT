using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Responses;

namespace TravelAgent.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {

            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            Employee employee = await _employeeRepository.FindById(id);

            var user = new EmployeeResponse
            {
                Id = employee.Id,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ProfilePhoto = employee.ProfilePhoto,
                RegisteredOffice = employee.RegisteredOffice,
                Available = employee.Available
            };

            return Ok(user);
        }
    }
}
