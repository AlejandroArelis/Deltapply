using Deltapply.DTO.General;
using Deltapply.Models.General;
using Deltapply.Models.Nihongo.Kanjis.Examples;

namespace Deltapply.DTO.Nihongo.Kanjis.Examples
{
    public class ExampleDTO:GenericDTO
    {
        public List<GenericDTO>? Meanings { get; set; }
        public List<GenericDTO>? Chars { get; set; }
    }
}
