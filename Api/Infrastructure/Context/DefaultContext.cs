using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DefaultContext : DbContext
    {
        public DbSet<HotelEntity> Hotels { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
