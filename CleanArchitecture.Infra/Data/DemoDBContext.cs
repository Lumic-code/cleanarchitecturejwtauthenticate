using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {
        }
        public DbSet<UserAdmin> UserAdmins { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
