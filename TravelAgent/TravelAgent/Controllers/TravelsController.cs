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
    public class TravelsController : ControllerBase
    {
        private readonly ITravelRepository _travelRepository;

        public TravelsController(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
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
    }
}
