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
    public class ApartamentsController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartamentsController(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetAll()
        {
            return Ok(await _apartmentRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetById(int id)
        {
            return Ok(await _apartmentRepository.FindById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Apartment>> CreateApartment([FromBody]Apartment apartmentRequest)
        {
            try
            {
                return Ok(await _apartmentRepository.Create(apartmentRequest));
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }
    }
}
