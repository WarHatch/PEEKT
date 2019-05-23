using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTravelController : ControllerBase
    {
        private readonly IEmployeeTravelRepository _employeeTravelRepository;

        public EmployeeTravelController(IEmployeeTravelRepository employeeTravelRepository)
        {
            _employeeTravelRepository = employeeTravelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTravel>>> GetAll()
        {
            return Ok(await _employeeTravelRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return Ok(await _employeeTravelRepository.FindById(id));
        }

        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<Employee>> GetByEmployeeId(int id)
        {
            return Ok(await _employeeTravelRepository.FindByEmployeeId(id));
        }
    }
}
