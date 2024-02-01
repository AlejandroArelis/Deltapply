namespace Deltapply.Models.Nihongo.Kanjis
{
    public class KanjiMeaning
    {
        public int Id { get; set; }
        public int KanjiId { get; set; }
        public Kanji Kanji { get; set; }
        public int MeaningId { get; set; }
        public Meaning Meaning { get; set; }

    }
}
