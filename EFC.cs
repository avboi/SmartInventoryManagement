using Microsoft.EntityFrameworkCore;

namespace SmartInventoryManagement
{
    public class EFC : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(@"Server=ANTONY-PC\SQL2025;Database=DB1;User=ASWIN;Password=123456;Trusted_Connection=True;TrustServerCertificate=True;");


                }
            }
        }

        public DbSet<Item> Items { get; set; }








    }
}
