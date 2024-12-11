using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ruben_Booking.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;

namespace Ruben_Booking.API.Tests.Database
{
    public class TestCopyDbContext : RubenContext
    {
        public TestCopyDbContext(DbContextOptions<RubenContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
