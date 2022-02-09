﻿using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data.MapConfigurations;
using UtopiaCity.Models;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.FireDepartment;
using UtopiaCity.Models.PublicTransport;

namespace UtopiaCity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<FireIncidentReport> FireIncidentReports { get; set; }
        public DbSet<BusRoute> BusRoute { get; set; }
        public DbSet<BusStop> BusStop { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FireIncidentReportDbMap());
        }
    }
}
