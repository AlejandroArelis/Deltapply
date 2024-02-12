using AutoMapper;
using Deltapply.DTO.General;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.DTO.Nihongo.Kanjis.Examples;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis.Examples;

namespace Deltapply.Data
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<KanjiDTO, Kanji>();
            CreateMap<GenericDTO, Kun>();
            CreateMap<GenericDTO, On>();
            CreateMap<GenericDTO, Name>();
            CreateMap<GenericDTO, KanjiMeaning>();
            CreateMap<ExampleDTO, Example>();
        }
    }
}
