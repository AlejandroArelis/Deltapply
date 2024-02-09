using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis.Examples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deltapply.Data.Configurations
{
    public class ExampleMeaningConfiguration : IEntityTypeConfiguration<ExampleMeaning>
    {
        public void Configure(EntityTypeBuilder<ExampleMeaning> builder)
        {
            //builder.HasKey(km => km.Id);

            //builder.HasOne(km => km.Example)
            //    .WithMany(k => k.Meanings)
            //    .HasForeignKey(km => km.ExampleId);

            //builder.HasOne(km => km.Meaning)
            //    .WithMany(m => m.Examples)
            //    .HasForeignKey(km => km.MeaningId);
        }
    }
}
