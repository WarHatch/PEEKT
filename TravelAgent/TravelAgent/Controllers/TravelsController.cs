using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;

namespace TravelAgent.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TravelsController(ITravelRepository travelRepository, IOfficeRepository officeRepository, IEmployeeRepository employeeRepository)
        {
            _travelRepository = travelRepository;
            _officeRepository = officeRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetAll()
        {
            return Ok(await _travelRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> GetById(int id)
        {
            return Ok(await _travelRepository.FindById(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<Travel>> CreateTravel([FromBody]CreateTravelRequest request)
        {
            try
            {
                var travel = new Travel
                {
                    Name = request.Name,
                    TravelTo = await _officeRepository.FindById(request.TravelToId),
                    TravelFrom = await _officeRepository.FindById(request.TravelToId),
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Cost = request.Cost,
                    OrganizedBy = await _employeeRepository.FindById(request.OrganizedById)
                };
                return Ok(await _travelRepository.Create(travel));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTravel(int id, Travel updateTravel)
        {
            try
            {
                updateTravel.Id = id;
                await _travelRepository.Update(updateTravel);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
