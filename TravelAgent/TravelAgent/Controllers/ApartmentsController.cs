using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;
using TravelAgent.Cross_cutting;
using Microsoft.AspNetCore.Authorization;

namespace TravelAgent.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [TrackExecutionTime]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTravelRepository _employeeTravelRepository;

        public ApartmentsController(IApartmentRepository apartmentRepository, IEmployeeRepository employeeRepository, IEmployeeTravelRepository employeeTravelRepository)
        {
            _apartmentRepository = apartmentRepository;
            _employeeRepository = employeeRepository;
            _employeeTravelRepository = employeeTravelRepository;
        }

        [HttpGet]
        [TrackExecutionTime]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetAll()
        {
            return Ok(await _apartmentRepository.GetAll());
        }

        [HttpGet("{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Apartment>> GetById(int id)
        {
            return Ok(await _apartmentRepository.FindById(id));
        }



        [HttpPost]
        [TrackExecutionTime]
        public async Task<ActionResult<Apartment>> CreateApartment([FromBody]CreateApartmentRequest request)
        {
            try
            {
                var apartment = new Apartment
                {
                    Title = request.Title,
                    Address = request.Address,
                    FitsPeople = request.FitsPeople,
                    EmployeeTravels = new List<EmployeeTravel>()
                    
                };
                return Ok(await _apartmentRepository.Create(apartment));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpPut("{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Apartment>> UpdateApartment(int id, [FromBody]CreateApartmentRequest request)
        {
            try
            {
                var apartment = await _apartmentRepository.FindById(id);

                if (request.Title != null)
                {
                    apartment.Title = request.Title;
                }
                if (request.Address != null)
                {
                    apartment.Address = request.Address;
                }
                if (request.FitsPeople >= 0)
                {
                    apartment.FitsPeople = request.FitsPeople;
                }
                if (request.Version != null)
                {
                    apartment.Version = request.Version;
                }

                await _apartmentRepository.Update(apartment);
                return Ok(await _apartmentRepository.FindById(id));
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(ex);
            }
        }
        [HttpDelete("{id}")]
        [TrackExecutionTime]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            try
            {
                await _apartmentRepository.Delete(await _apartmentRepository.FindById(id));
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
            catch (DbUpdateException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("AddGuest/{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Apartment>> AddGuest(int id, [FromBody]AddGuestRequest request)
        {
            try
            {
                var apartment = await _apartmentRepository.FindById(id);
                var employeeTravel = await _employeeTravelRepository.FindById(request.EmployeeTravelId);

                return Ok(await _apartmentRepository.AddGuest(apartment, employeeTravel));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpPost("RemoveGuest/{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Apartment>> RemoveGuest(int id, [FromBody]AddGuestRequest request)
        {
            try
            {
                var apartment = await _apartmentRepository.FindById(id);
                var employeeTravel = await _employeeTravelRepository.FindById(request.EmployeeTravelId);

                return Ok(await _apartmentRepository.RemoveGuest(apartment, employeeTravel));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }
    }
}
