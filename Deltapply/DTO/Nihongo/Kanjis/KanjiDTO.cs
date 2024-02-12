using Deltapply.DTO.General;
using Deltapply.DTO.Nihongo.Kanjis.Examples;

namespace Deltapply.DTO.Nihongo.Kanjis
{
    public class KanjiDTO
    {
        public char Char { get; set; }
        public string Image { get; set; }
        public int Jlpt { get; set; }
        public bool Checked { get; set; } = false;
        public int Successes { get; set; } = 0;
        public int Attempts { get; set; } = 0;

        public List<GenericDTO>? Names { get; set; }
        public List<GenericDTO>? Kuns { get; set; }
        public List<GenericDTO>? Ons { get; set; }
        public List<GenericDTO>? Meanings { get; set; }
        public List<ExampleDTO>? Examples { get; set; }
    }
}
