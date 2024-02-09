using Deltapply.Models.General;

namespace Deltapply.Models.Nihongo.Kanjis.Examples
{
    public class Example : Generic
    {
        public int KanjiId { get; set; }
        public Kanji? Kanji { get; set; }
        public List<ExampleMeaning>? Meanings { get; set; }
        public List<ExampleChar>? Chars { get; set; }
    }
}
