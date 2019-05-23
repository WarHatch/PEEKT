using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;

namespace TravelAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTravelController : ControllerBase
    {
        private readonly IEmployeeTravelRepository _employeeTravelRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public EmployeeTravelController(IEmployeeTravelRepository employeeTravelRepository, IEmployeeRepository employeeRepository, ITravelRepository travelRepository, IApartmentRepository apartmentRepository)
        {
            _employeeTravelRepository = employeeTravelRepository;
            _employeeRepository = employeeRepository;
            _travelRepository = travelRepository;
            _apartmentRepository = apartmentRepository;
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
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<Travel>> CreateEmployeeTravel([FromBody]CreateEmployeeTravelRequest request)
        {
            try
            {
                var employeeTravel = new EmployeeTravel
                {
                    Employee = await _employeeRepository.FindById(request.EmployeeId),
                    Travel = await _travelRepository.FindById(request.TravelId),
                    Confirm = request.Confirm,

                };

                return Ok(await _employeeTravelRepository.Create(employeeTravel));
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
