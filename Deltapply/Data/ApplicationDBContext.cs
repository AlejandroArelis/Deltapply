using Deltapply.Data.Configurations;
using Deltapply.Models.General;
using Deltapply.Models.Nihongo;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis.Examples;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
           
        }

        //Modelos
        //Kanji
        public DbSet<Kanji> Kanjis { get; set; }
        public DbSet<Kun> Kuns { get; set; }
        public DbSet<On> Ons { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Meaning> Meanings { get; set; }
        public DbSet<Example> Examples { get; set; }

        //Muchos a muchos
        public DbSet<KanjiMeaning> KanjisMeanings { get; set; }
        public DbSet<ExampleMeaning> ExamplesMeanings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KanjiMeaningConfiguration());
            modelBuilder.ApplyConfiguration(new ExampleMeaningConfiguration());
        }
    }
}
