using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models
{
    public class Char
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Special { get; set; }
        public int ExampleId { get; set; }
    }
}
