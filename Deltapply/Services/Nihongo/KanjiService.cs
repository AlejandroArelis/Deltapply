using AutoMapper;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo.Interfaces;

namespace Deltapply.Services.Nihongo
{
    public class KanjiService
    {
        private readonly IKanjiRepository _kanjiRepository;
        private readonly IMapper _mapper;

        public KanjiService(IKanjiRepository kanjiRepository, IMapper mapper)
        {
            _kanjiRepository = kanjiRepository;
            _mapper = mapper;
        }

        public async Task<List<KanjiDTO>> GetAllKanjis()
        {
            var kanjis = await _kanjiRepository.GetAllKanjis();
            return _mapper.Map<List<KanjiDTO>>(kanjis);
        }

        public async Task<KanjiDTO> GetKanjiById(int id)
        {
            var kanji = await _kanjiRepository.GetKanjiById(id);
            if (kanji == null) return null;
            return _mapper.Map<KanjiDTO>(kanji);
        }

        public async Task<KanjiDTO> CreateKanji(KanjiDTO kanjiDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    throw new ArgumentException("Kanji data is invalid");
            //}

            var kanji = _mapper.Map<Kanji>(kanjiDTO);
            var createdKanji = await _kanjiRepository.CreateKanji(kanji);
            return _mapper.Map<KanjiDTO>(createdKanji);
        }
    }
}
