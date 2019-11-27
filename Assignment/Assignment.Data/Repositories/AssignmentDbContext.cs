
using Assignment.Data.Domains;
using Assignment.Database.Mpas;
using Microsoft.EntityFrameworkCore;


namespace Assignment.Data.Repositories
{
    public class AssignmentDbContext: DbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext>options) : base(options)
        {

        }
        protected override void   OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Store_Order_Map(modelBuilder.Entity<STORE_ORDER>());
        }


        DbSet<STORE_ORDER> STORE_ORDER { get; set; }
    }
}
