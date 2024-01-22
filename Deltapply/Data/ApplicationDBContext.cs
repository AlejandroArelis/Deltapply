using Deltapply.Models;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //Modelos
        public DbSet<Kanji> Kanjis { get; set; }
    }
}
