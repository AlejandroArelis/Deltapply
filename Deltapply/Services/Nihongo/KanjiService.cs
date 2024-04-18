using AutoMapper;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo;

namespace Deltapply.Services.Nihongo
{
    public class KanjiService
    {
        private readonly KanjiRepository _kanjiRepository;
        private readonly KunRepository _kunRepository;
        private readonly IMapper _mapper;

        public KanjiService(KanjiRepository kanjiRepository, KunRepository kunRepository, IMapper mapper)
        {
            _kanjiRepository = kanjiRepository;
            _kunRepository = kunRepository;
            _mapper = mapper;
        }

        public async Task<List<Kanji>> GetAll()
        {
            var objects = await _kanjiRepository.GetAll(null);
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

            var exists = await _kanjiRepository.Exists("Text", objectDTO.Text, null);

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

            if (objectDTO.Names != null)
            {
                objectDTO.Names = objectDTO.Names.GroupBy(x => x.Value)
                        .Select(grp => grp.First()).ToList();
            } 

            var obj = _mapper.Map<Kanji>(objectDTO);
            var created = await _kanjiRepository.Post(obj);
            //return _mapper.Map<KanjiDTO>(created);
            return created;
        }

        public async Task<Kanji> Put(Kanji obj)
        {
            var exists = await _kanjiRepository.Exists("Id", obj.Id, null);

            if (!exists)
                return null;

            //// Eliminación de posibles repetidos
            //if (obj.Kuns != null)
            //{
            //    obj.Kuns = obj.Kuns.GroupBy(x => x.Value) // Agrupa los registros
            //            .Select(grp => grp.First()).ToList(); // Selecciona solo el primer elemento de cada grupo y lo guarda en una lista

            //    List<Kun> kunsAux = new List<Kun>();
            //    foreach(var kun in obj.Kuns)
            //    {
            //        exists = await _kunRepository.Exists("Value", kun.Value, obj.Id);

            //        if (!exists)
            //            kunsAux.Add(kun);
            //    }
            //}

            //if (obj.Ons != null)
            //{
            //    obj.Ons = obj.Ons.GroupBy(x => x.Value)
            //            .Select(grp => grp.First()).ToList();

            //    List<On> onsAux = new List<On>();
            //    foreach (var on in obj.Ons)
            //    {
            //        exists = await _kunRepository.Exists("Value", on.Value, obj.Id);

            //        if (!exists)
            //            onsAux.Add(on);
            //    }

            //if (obj.Meanings != null)
            //{
            //    obj.Meanings = obj.Meanings.GroupBy(x => x.Value)
            //            .Select(grp => grp.First()).ToList();

            //    List<KanjiMeaning> meaningAux = new List<KanjiMeaning>();
            //    foreach (var meaning in obj.Meanings)
            //    {
            //        exists = await _kunRepository.Exists("Value", meaning.Value, obj.Id);

            //        if (!exists)
            //            meaningAux.Add(meaning);
            //    }
            //}

            //    obj.Kuns = null;
            //    obj.Ons = null;
            //    obj.Meanings = null;
            //    obj.Examples = null;

            var updated = await _kanjiRepository.Put(obj);
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
