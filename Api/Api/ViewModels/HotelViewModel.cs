using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class HotelViewModel
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
