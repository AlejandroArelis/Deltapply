using Deltapply.Data;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Repositories.Nihongo
{
    public class OnRepository: IRepository<On>
    {
        private readonly ApplicationDBContext _dbContext;

        public OnRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<On>> GetAll(int? id)
        {
            return await _dbContext.Ons.Where(k => k.KanjiId == id).ToListAsync();
        }

        public async Task<On> GetById(int id)
        {
            var obj = await _dbContext.Ons.FindAsync(id);

            return obj;
        }

        public async Task<On> Post(On obj)
        {
            _dbContext.Ons.Add(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<On> Put(On obj)
        {
            _dbContext.Ons.Update(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(On onj)
        {
            _dbContext.Ons.Remove(onj);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(string property, object value, int? parentId)
        {
            return _dbContext.Ons.AnyAsync(k => k.KanjiId == parentId && EF.Property<object>(k, property) == value);
        }
    }
}
