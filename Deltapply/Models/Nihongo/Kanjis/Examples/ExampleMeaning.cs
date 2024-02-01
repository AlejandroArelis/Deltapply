namespace Deltapply.Models.Nihongo.Kanjis.Examples
{
    public class ExampleMeaning
    {
        public int Id { get; set; }
        public int ExampleId { get; set; }
        public Example? Example { get; set; }
        public int MeaningId { get; set; }
        public Meaning? Meaning { get; set; }
    }
}
