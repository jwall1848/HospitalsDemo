using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospitals.Models;

namespace Hospitals.Data
{
    public class HospitalsContext : DbContext
    {
        public HospitalsContext (DbContextOptions<HospitalsContext> options)
            : base(options)
        {
        }

        public DbSet<Hospitals.Models.Hospital> Hospital { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
                    CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is Hospital hospital)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            hospital.UpdatedDate = utcNow;
                            entry.Property("CreatedDate").IsModified = false;
                            break;

                        case EntityState.Added:
                            hospital.UpdatedDate = utcNow;
                            hospital.CreatedDate = utcNow;
                            break;
                    }
                }
            }
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }
    }
}
