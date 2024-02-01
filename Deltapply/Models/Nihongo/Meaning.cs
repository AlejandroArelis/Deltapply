using Deltapply.Models.General;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis.Examples;

namespace Deltapply.Models.Nihongo
{
    public class Meaning : Generic
    {
        public List<KanjiMeaning> Kanjis { get; set; }
        public List<ExampleMeaning> Examples { get; set; }
    }
}
