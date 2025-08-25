using Microsoft.EntityFrameworkCore;
using StudentPortalBackend.Model.Domain;

namespace StudentPortalBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReceiptAvailability> ReceiptAvailabilities { get; set; }
    }
}
