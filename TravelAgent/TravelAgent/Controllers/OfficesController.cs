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
using Microsoft.AspNetCore.Authorization;
using TravelAgent.Cross_cutting;

namespace TravelAgent.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [Authorize]
    [TrackExecutionTime]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IApartmentRepository _apartmentRepository;

        public OfficesController(IOfficeRepository officeRepository, IApartmentRepository apartmentRepository)
        {
            _officeRepository = officeRepository;
            _apartmentRepository = apartmentRepository;
        }

        [HttpGet]
        [Authorize]
        [TrackExecutionTime]
        public async Task<ActionResult<IEnumerable<Office>>> GetAll()
        {
            return Ok(await _officeRepository.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        [TrackExecutionTime]
        public async Task<ActionResult<Office>> GetById(int id)
        {
            return Ok(await _officeRepository.FindById(id));
        }

        [HttpPost]
        [Authorize]
        [TrackExecutionTime]
        public async Task<ActionResult<Office>> CreateOffice([FromBody]CreateOfficeRequest officeRequest)
        {
            try
            {
                var office = new Office
                {
                    Title = officeRequest.Title,
                    OfficeApartment = await _apartmentRepository.FindById(officeRequest.OfficeApartmentId),
                    Address = officeRequest.Address
                };
                return Ok(await _officeRepository.Create(office));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        [TrackExecutionTime]
        public async Task<ActionResult<Office>> UpdateTravel(int id, [FromBody]UpdateOfficeRequest request)
        {
            try
            {
                var office = await _officeRepository.FindById(id);

                if (request.OfficeApartmentId != 0)
                {
                    office.OfficeApartment = await _apartmentRepository.FindById(request.OfficeApartmentId);
                }
                if (request.Title != null)
                {
                    office.Title = request.Title;
                }
                if (request.Address != null)
                {
                    office.Address = request.Address;
                }

               await _officeRepository.Update(office);
                return Ok(await _officeRepository.FindById(id));
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
        [Authorize]
        [TrackExecutionTime]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            try
            {
                var office = await _officeRepository.FindById(id);
                //await _apartmentRepository.Delete(office.OfficeApartment);
                await _officeRepository.Delete(office);
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
    }
}
