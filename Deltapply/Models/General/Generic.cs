using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models.General
{
    public class Generic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
