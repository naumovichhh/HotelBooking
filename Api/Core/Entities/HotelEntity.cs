using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class HotelEntity
    {
        public HotelEntity(int id, string name, string address, string locality, string country, string image)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Locality = locality ?? throw new ArgumentNullException(nameof(locality));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }

        public string Image { get; set; }
    }
}
