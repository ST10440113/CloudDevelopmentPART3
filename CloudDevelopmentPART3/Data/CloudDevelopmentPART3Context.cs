using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudDevelopmentPART3.Models;

namespace CloudDevelopmentPART3.Data
{
    public class CloudDevelopmentPART3Context : DbContext
    {
        public CloudDevelopmentPART3Context (DbContextOptions<CloudDevelopmentPART3Context> options)
            : base(options)
        {
        }

        public DbSet<CloudDevelopmentPART3.Models.EventTypeModel> EventTypeModel { get; set; } = default!;
        public DbSet<CloudDevelopmentPART3.Models.Event> Event { get; set; } = default!;
        public DbSet<CloudDevelopmentPART3.Models.Venue> Venue { get; set; } = default!;
        public DbSet<CloudDevelopmentPART3.Models.Booking> Booking { get; set; } = default!;
    }
}
