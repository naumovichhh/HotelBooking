using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class HotelDTO
    {
        public HotelDTO(int id, string name, string address, string locality, string country, string picture)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Locality = locality ?? throw new ArgumentNullException(nameof(locality));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Picture = picture ?? throw new ArgumentNullException(nameof(picture));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }

        public string Picture { get; set; }
    }
}
