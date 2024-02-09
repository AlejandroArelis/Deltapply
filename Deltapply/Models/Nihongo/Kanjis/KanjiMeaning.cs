using Deltapply.Models.General;

namespace Deltapply.Models.Nihongo.Kanjis
{
    public class KanjiMeaning:Generic
    {
        public int KanjiId { get; set; }
        public Kanji? Kanji { get; set; }

    }
}
