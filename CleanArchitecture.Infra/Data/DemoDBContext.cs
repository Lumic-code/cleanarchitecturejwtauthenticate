using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data
{
    public class DemoDBContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {
        }
       
        public DbSet<Product> Products { get; set; } = null!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.ModifiedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        item.Entity.IsDeleted = true;
                        break;

                    case EntityState.Added:
                        item.Entity.Id = Guid.NewGuid().ToString();
                        item.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                        
                    default:
                        break;

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
