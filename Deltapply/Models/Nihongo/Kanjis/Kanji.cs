using System.ComponentModel.DataAnnotations;
using Deltapply.Models.General;
using Deltapply.Models.Nihongo.Kanjis.Examples;

namespace Deltapply.Models.Nihongo.Kanjis
{
    public class Kanji
    {
        [Key]
        public int Id { get; set; }
        public char Char { get; set; }
        public string Image { get; set; }
        public int Jlpt { get; set; }
        public bool Checked { get; set; } = false;
        public int Successes { get; set; } = 0;
        public int Attempts { get; set; } = 0;

        public List<Name>? Names { get; set; }
        public List<Kun>? Kuns { get; set; }
        public List<On>? Ons { get; set; }
        public List<Example>? Examples { get; set; }
        public List<KanjiMeaning>? Meanings { get; set; }
    }
}
