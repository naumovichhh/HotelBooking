using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            Bookings = new HashSet<BookingEntity>();
            RefreshTokens = new HashSet<RefreshTokenEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
        public virtual ICollection<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}
