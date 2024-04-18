using Deltapply.Data;
using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Repositories.Nihongo
{
    public class KunRepository: IRepository<Kun>
    {
        private readonly ApplicationDBContext _dbContext;

        public KunRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Kun>> GetAll(int? id)
        {
            return await _dbContext.Kuns.Where(k => k.KanjiId == id).ToListAsync();
        }

        public async Task<Kun> GetById(int id)
        {
            var kun = await _dbContext.Kuns.FindAsync(id);

            return kun;
        }

        public async Task<Kun> Post(Kun obj)
        {
            _dbContext.Kuns.Add(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<Kun> Put(Kun obj)
        {
            _dbContext.Kuns.Update(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(Kun onj)
        {
            _dbContext.Kuns.Remove(onj);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(string property, object value, int? parentId)
        {
            return _dbContext.Kuns.AnyAsync(k => k.KanjiId == parentId && EF.Property<object>(k, property) == value);
        }
    }
}
