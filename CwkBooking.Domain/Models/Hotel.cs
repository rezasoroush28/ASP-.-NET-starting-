using System.Collections.Generic;

namespace CwkBooking.Domain.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
       
        public string Country { get; set; }
        public List<Room> Rooms{ get; set; }
    }
    
}