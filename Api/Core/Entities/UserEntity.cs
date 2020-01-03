﻿using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            Bookings = new HashSet<BookingEntity>();
        }

        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
