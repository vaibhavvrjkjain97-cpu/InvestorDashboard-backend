using InvestorCommitmentsAPI.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace InvestorCommitmentsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Commitment> Commitments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investor>()
                .HasMany(i => i.Commitments)
                .WithOne(c => c.Investor)
                .HasForeignKey(c => c.InvestorId);
        }
    }
}
