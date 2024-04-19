using AutoMapper;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo;

namespace Deltapply.Services.Nihongo
{
    public class OnService
    {
        private readonly OnRepository _repository;
        private readonly IMapper _mapper;

        public OnService(OnRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<On>> GetAll(int parentId)
        {
            var objects = await _repository.GetAll(parentId);
            return objects;
        }

        public async Task<On> GetById(int id)
        {
            var obj = await _repository.GetById(id);
            if (obj == null)
                return null;
            return obj;
        }

        public async Task<On> Post(OnDTO objectDTO)
        {
            var exists = await _repository.Exists("Value", objectDTO.Value, objectDTO.KanjiId);

            if (exists)
                return null;

            var obj = _mapper.Map<On>(objectDTO);
            var created = await _repository.Post(obj);
            return created;
        }

        public async Task<On> Put(On obj)
        {
            var exists = await _repository.Exists("Id", obj.Id, obj.KanjiId);

            if (!exists)
                return null;

            exists = await _repository.Exists("Value", obj.Value, obj.Id);

            if (exists)
                return null;

            var updated = await _repository.Put(obj);
            return updated;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return false;

            await _repository.Delete(obj);
            return true;
        }
    }
}
