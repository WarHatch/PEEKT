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
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficesController(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetAll()
        {
            return Ok(await _officeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetById(int id)
        {
            return Ok(await _officeRepository.FindById(id));
        }
    }
}
