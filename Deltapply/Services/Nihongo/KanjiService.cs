using AutoMapper;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo;

namespace Deltapply.Services.Nihongo
{
    public class KanjiService
    {
        private readonly KanjiRepository _kanjiRepository;
        private readonly IMapper _mapper;

        public KanjiService(KanjiRepository kanjiRepository, IMapper mapper)
        {
            _kanjiRepository = kanjiRepository;
            _mapper = mapper;
        }

        public async Task<List<Kanji>> GetAll()
        {
            var objects = await _kanjiRepository.GetAll();
            //return _mapper.Map<List<KanjiDTO>>(objects);
            return objects;
        }

        public async Task<Kanji> GetById(int id)
        {
            var obj = await _kanjiRepository.GetById(id);
            if (obj == null)
                return null;
            //return _mapper.Map<KanjiDTO>(obj);
            return obj;
        }

        public async Task<Kanji> Post(KanjiDTO objectDTO)
        {
            var obj = _mapper.Map<Kanji>(objectDTO);

            // Validar que no exista otro objeto con el mismo Text ni elementos repetidos en las listas
            var created = await _kanjiRepository.Post(obj);
            //return _mapper.Map<KanjiDTO>(created);
            return created;
        }

        public async Task<Kanji> Put(Kanji kanji)
        {
            var exists = await _kanjiRepository.Exists(kanji.Id);

            if (!exists)
                return null;

            // Validar que no exista otro objeto con el mismo Text ni elementos repetidos en las listas

            var updated = await _kanjiRepository.Put(kanji);
            return updated;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _kanjiRepository.GetById(id);

            if (obj == null)
                return false;

            await _kanjiRepository.Delete(obj);
            return true;
        }
    }
}
