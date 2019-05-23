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
        private readonly IHotelRepository _hotelRepository;
        private readonly ITransportRepository _transportRepository;

        public TravelsController(ITravelRepository travelRepository, IOfficeRepository officeRepository, IEmployeeRepository employeeRepository, IHotelRepository hotelRepository, ITransportRepository transportRepository)
        {
            _travelRepository = travelRepository;
            _officeRepository = officeRepository;
            _employeeRepository = employeeRepository;
            _hotelRepository = hotelRepository;
            _transportRepository = transportRepository;
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
                    TravelFrom = await _officeRepository.FindById(request.TravelFromId),
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Hotels = request.Hotels,
                    Transports = request.Transports,
                    Cost = request.Cost,
                    OrganizedBy = await _employeeRepository.FindById(request.OrganizedById)
                };


                return Ok(await _travelRepository.Create(travel));
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Travel>> UpdateTravel(int id, [FromBody]UpdateTravelRequest request)
        {
            try
            {
                var travel = await _travelRepository.FindById(id);
                if (request.Name != null)
                {
                    travel.Name = request.Name;
                }
                if (request.TravelToId != 0)
                {
                    travel.TravelTo = await _officeRepository.FindById(request.TravelToId);
                }
                if (request.TravelFromId != 0)
                {
                    travel.TravelFrom = await _officeRepository.FindById(request.TravelFromId);
                }
                if (request.StartTime != null)
                {
                    travel.StartTime = request.StartTime;
                }
                if (request.EndTime != null)
                {
                    travel.EndTime = request.EndTime;
                }
                if (request.Cost <= 0)
                {
                    travel.Cost = request.Cost;
                }
                if (request.OrganizedById != 0)
                {
                    travel.OrganizedBy = await _employeeRepository.FindById(request.OrganizedById);
                }
                if (request.Hotels != null)
                {
                    travel.Hotels = request.Hotels;
                }
                if (request.Transports != null)
                {
                    travel.Transports = request.Transports;
                }

                await _travelRepository.Update(travel);
                return Ok();
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            try
            {         
                await _travelRepository.Delete(await _travelRepository.FindById(id));
                return Ok();
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
    }
}
