using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }

        public string Picture { get; set; }

        public int Stars { get; set; }
    }
}
