using AutoMapper;
using Deltapply.DTO.General;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Migrations;
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

            var exists = await _kanjiRepository.Exists("Text", objectDTO.Text);

            if (exists)
                return null;

            if(objectDTO.Kuns != null)
            {
                objectDTO.Kuns = objectDTO.Kuns.GroupBy(x => x.Value) // Agrupa los registros
                        .Select(grp => grp.First()).ToList(); // Selecciona solo el primer elemento de cada grupo y lo guarda en una lista
            }

            if (objectDTO.Ons != null)
            {
                objectDTO.Ons = objectDTO.Ons.GroupBy(x => x.Value)
                        .Select(grp => grp.First()).ToList();
            }

            if (objectDTO.Meanings != null)
            {
                objectDTO.Meanings = objectDTO.Meanings.GroupBy(x => x.Value)
                        .Select(grp => grp.First()).ToList();
            }

            var created = await _kanjiRepository.Post(obj);
            //return _mapper.Map<KanjiDTO>(created);
            return created;
        }

        public async Task<Kanji> Put(Kanji kanji)
        {
            var exists = await _kanjiRepository.Exists("Id", kanji.Id);

            if (!exists)
                return null;

            exists = await _kanjiRepository.Exists("Text", kanji.Text);

            if (exists)
                return null;

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
