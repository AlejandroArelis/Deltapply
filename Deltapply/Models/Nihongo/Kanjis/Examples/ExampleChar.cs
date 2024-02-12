using Deltapply.Models.General;
using System.ComponentModel.DataAnnotations;

namespace Deltapply.Models.Nihongo.Kanjis.Examples
{
    public class ExampleChar : Generic
    {
        public int ExampleId { get; set; }

        public Example? Example { get; set; }
    }
}
