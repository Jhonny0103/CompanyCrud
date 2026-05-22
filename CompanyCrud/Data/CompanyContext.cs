using CompanyCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyCrud.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options) { }

        public DbSet<Employe> Employees { get; set; }
        public DbSet<Dept> Depts { get; set; }
    }
}
