﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TravelAgent.Cross_cutting;

namespace TravelAgent.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [TrackExecutionTime]
    public class EmployeeTravelController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IEmployeeTravelRepository _employeeTravelRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOfficeRepository _officeRepository;

        public EmployeeTravelController(UserManager<Employee> userManager, IEmployeeTravelRepository employeeTravelRepository, IEmployeeRepository employeeRepository, ITravelRepository travelRepository, IApartmentRepository apartmentRepository, IOfficeRepository officeRepository)
        {
            _userManager = userManager;
            _employeeTravelRepository = employeeTravelRepository;
            _employeeRepository = employeeRepository;
            _travelRepository = travelRepository;
            _apartmentRepository = apartmentRepository;
            _officeRepository = officeRepository;
        }

        [HttpGet]
        [TrackExecutionTime]
        public async Task<ActionResult<IEnumerable<EmployeeTravel>>> GetAll()
        {
            return Ok(await _employeeTravelRepository.GetAll());
        }

        [HttpGet("{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return Ok(await _employeeTravelRepository.FindById(id));
        }

        [HttpGet("Employee/{id}")]
        [TrackExecutionTime]
        public async Task<ActionResult<Employee>> GetByEmployeeId(int id)
        {
            return Ok(await _employeeTravelRepository.FindByEmployeeId(id));
        }

        [HttpGet("User")]
        [Authorize]
        [TrackExecutionTime]
        public async Task<ActionResult<Employee>> GetByUser()
        {
            var userName = User.Identity.Name;
            var identityUser = await _userManager.FindByNameAsync(userName);
            return Ok(await _employeeTravelRepository.FindByEmployeeId(identityUser.Id));
        }

        [HttpPost]
        [TrackExecutionTime]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<Travel>> CreateEmployeeTravel([FromBody]CreateEmployeeTravelRequest request)
        {
            try
            {
                if (!await _employeeTravelRepository.CheckTravelsByEmployeeId(request.EmployeeId, request.TravelId)) return Conflict(" This employee already has this trip ");

                var employeeTravel = new EmployeeTravel
                {
                    Employee = await _employeeRepository.FindById(request.EmployeeId),
                    Travel = await _travelRepository.FindByIdWithOrganizedBy(request.TravelId),
                    Confirm = request.Confirm,
                };
                if (request.NeedApartment)
                {
                    var _employeeTravel = await _employeeTravelRepository.Create(employeeTravel);
                    var _office = await _officeRepository.FindById(_employeeTravel.Travel.TravelTo.Id);
                    await _apartmentRepository.AddGuest(await _apartmentRepository.FindById(_office.OfficeApartment.Id),
                        _employeeTravel);

                    return Ok();
                }
                else return Ok(await _employeeTravelRepository.Create(employeeTravel));
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
        }


        [HttpPut("{id}")]
        [TrackExecutionTime]
        public async Task<IActionResult> UpdateEmployeeTravel(int id, [FromBody]UpdateEmployeeTravelRequest request)
        {
            try
            {
                var employeeTravel = await _employeeTravelRepository.FindById(id);
                employeeTravel.Confirm = request.Confirm;
                await _employeeTravelRepository.Update(employeeTravel);
                return Ok(employeeTravel);

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
        [TrackExecutionTime]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var _employeeTravel = await _employeeTravelRepository.FindById(id);
                var _office = await _officeRepository.FindById(_employeeTravel.Travel.TravelTo.Id);
                var _apartment = await _apartmentRepository.RemoveGuest(await _apartmentRepository.FindById(_office.OfficeApartment.Id), _employeeTravel);
                
                await _apartmentRepository.RemoveGuest(_apartment, _employeeTravel);
                await _employeeTravelRepository.Delete(_employeeTravel);

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
