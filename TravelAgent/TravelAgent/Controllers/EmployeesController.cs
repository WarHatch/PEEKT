using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Responses;
using Microsoft.AspNetCore.Authorization;
using TravelAgent.Cross_cutting;

namespace TravelAgent.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [TrackExecutionTime]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [TrackExecutionTime]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {

            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet ("{id}")]
        [TrackExecutionTime]
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
