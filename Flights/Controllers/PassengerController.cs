using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
using Flights.ReadModels;
using Flights.Domain.Entities;
using Flights.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly Entities _entities;

        public PassengerController(Entities entities)
        {
            _entities = entities;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(NewPassengerDto dto)
        {
            _entities.Passengers.Add(
                new Passenger(
                    dto.Email, dto.FirstName, dto.LastName, dto.Gender)
            );

            _entities.SaveChanges(); // very important

            return CreatedAtAction(nameof(Find), new {email = dto.Email});
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _entities.Passengers.FirstOrDefault(p => p.Email == email);

            if (passenger == null)
            {
                return NotFound();
            }

            var rm = new PassengerRm(passenger.Email, passenger.FirstName, passenger.LastName, passenger.Gender);

            return Ok(rm);
        }
    }
}





