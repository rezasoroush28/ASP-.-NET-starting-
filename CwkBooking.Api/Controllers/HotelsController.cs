using System.Collections.Generic;
using System.Linq;
using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : Controller
    {
        private readonly DataSource _dataSource;
        public HotelsController(DataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        [HttpGet]
        public IActionResult ShowAllHotels()
        {
            var hotels = _dataSource.Hotels;
            return Ok(_dataSource.Hotels);
        }
        
        


        [Route("{name}")]
        [HttpGet]
        public IActionResult GetHotelbyName(string name)
        {
            var hotels = _dataSource.Hotels;
            var hotel = hotels.FirstOrDefault(h => h.Name == name);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }


        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _dataSource.Hotels;
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelbyName), new { name = hotel.Name }, hotel);
        }

        [HttpPut]
        [Route("{name}")]

        public IActionResult UpdateHotel([FromBody] Hotel toBeUpdatedHotel , string name)
        {
            var hotels = _dataSource.Hotels;
            var oldHotel = hotels.FirstOrDefault(h => h.Name == name);
            if (oldHotel == null)
            {
                return NotFound("no hotels with this name found");

            }
            hotels.Remove(oldHotel);
            hotels.Add(toBeUpdatedHotel);
            return NoContent();
        }

        [HttpDelete]
        [Route("{name}")]
        public IActionResult DeleteHotel(string name)
        {
            var hotels = _dataSource.Hotels;
            var toBeDeletedHotel = hotels.FirstOrDefault(h => h.Name == name);
            if (toBeDeletedHotel == null)
            {
                return NotFound("no hotels with this name found");

            }

            hotels.Remove(toBeDeletedHotel);
            return NoContent();
        }
        
        
        
    }
}