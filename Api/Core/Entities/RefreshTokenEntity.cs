using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public partial class RefreshTokenEntity
    {
        public string Value { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int User { get; set; }
        public string Successor { get; set; }
        public bool WasUsed { get; set; }


        public virtual UserEntity UserNavigation { get; set; }
        public virtual RefreshTokenEntity SuccessorNavigation { get; set; }
        public virtual RefreshTokenEntity PrecursorNavigation { get; set; }
    }
}
