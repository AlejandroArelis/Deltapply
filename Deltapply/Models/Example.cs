using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models
{
    public class Example
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public List<string> Meanings { get; set; }
        public int KanjiId { get; set; }

        public List<Char> Chars { get; set; }
    }
}
