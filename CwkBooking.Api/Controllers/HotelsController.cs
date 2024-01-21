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
        public HotelsController()
        {
            
        }
        [HttpGet]
        public IActionResult ShowAllHotels()
        {
            var hotels = GetHotels();
            return Ok(GetHotels());
        }
        
        


        [Route("{name}")]
        [HttpGet]
        public IActionResult GetHotelbyName(string name)
        {
            var hotels = GetHotels();
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
            var hotels = GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelbyName), new { name = hotel.Name }, hotel);
        }

        [HttpPut]
        [Route("{name}")]

        public IActionResult UpdateHotel([FromBody] Hotel toBeUpdatedHotel , string name)
        {
            var hotels = GetHotels();
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
            var hotels = GetHotels();
            var toBeDeletedHotel = hotels.FirstOrDefault(h => h.Name == name);
            if (toBeDeletedHotel == null)
            {
                return NotFound("no hotels with this name found");

            }

            hotels.Remove(toBeDeletedHotel);
            return NoContent();
        }
        
        
        private List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    HotelId = 1,
                    Name = "Ghasr",
                    Stars = 5,
                    Address = "tehran - somwhere",
                    City = "tehran",
                    Country = "iran",
                }
            };
        }
    }
}