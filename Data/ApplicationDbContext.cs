using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Models; 

namespace SmartCampusPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<IncidentReport> IncidentReports { get; set; }

    }
}
