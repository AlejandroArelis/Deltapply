using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models
{
    public class Kanji
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El kanji debe contener al menos un nombre")]
        public List<string> Names { get; set; }
        [Required(ErrorMessage = "El kanji debe tener un simbolo")]
        public char Char { get; set; }

        [Required(ErrorMessage = "El kaji debe contener al menos una pronunciación Kun")]
        public List<string> Kun { get; set; }

        [Required(ErrorMessage = "El kaji debe contener al menos una pronunciación On")]
        public List<string> On { get; set; }

        [Required(ErrorMessage = "El kaji debe contener al menos un significado")]
        public List<string> Meanings { get; set; }
        [Required(ErrorMessage = "El kaji debe contener una imagen donde se vean los trazos")]
        public string Image { get; set; }
        [Required(ErrorMessage = "El kaji debe contener un nivel")]
        public int Jlpt { get; set; }
        public bool Checked { get; set; } = false;

        public List<Example> Examples { get; set; }
    }
}
