using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PortfolioDbContext : DbContext
    {
        public DbSet<Certification> Certification { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<PersonalSkills> PersonalSkills { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<ProfessionalSkills> ProfessionalSkills { get; set; }
        public DbSet<User> User { get; set; }
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        { }

    }
}
