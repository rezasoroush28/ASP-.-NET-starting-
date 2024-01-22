using System.Collections.Generic;
using CwkBooking.Domain.Models;

namespace CwkBooking.Api
{
    public class DataSource
    {

        public DataSource()
        {
            Hotels = GetHotels();
        }
        public List<Hotel> Hotels { get; set; }
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