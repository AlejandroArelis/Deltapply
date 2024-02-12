using Deltapply.DTO.General;
using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models.General
{
    public class Generic : GenericDTO
    {
        [Key]
        public int Id { get; set; }
    }
}
