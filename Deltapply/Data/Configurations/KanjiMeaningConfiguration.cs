using Deltapply.Models.Nihongo.Kanjis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deltapply.Data.Configurations
{
    public class KanjiMeaningConfiguration : IEntityTypeConfiguration<KanjiMeaning>
    {
        public void Configure(EntityTypeBuilder<KanjiMeaning> builder)
        {
            //builder.HasKey(km => km.Id);

            //builder.HasOne(km => km.Kanji)
            //    .WithMany(k => k.Meanings)
            //    .HasForeignKey(km => km.KanjiId);

            //builder.HasOne(km => km.Meaning)
            //    .WithMany(m => m.Kanjis)
            //    .HasForeignKey(km => km.MeaningId);
        }
    }
}
