using Deltapply.Data;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Repositories.Nihongo
{
    public class KanjiRepository: IRepository<Kanji>
    {
        private readonly ApplicationDBContext _dbContext;

        public KanjiRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Kanji>> GetAll(int? id)
        {
            return await _dbContext.Kanjis
                .Include(k => k.Names)
                .Include(k => k.Kuns)
                .Include(k => k.Ons)
                .Include(k => k.Meanings)
                .Include(k => k.Examples)
                .ToListAsync();
        }

        public async Task<Kanji> GetById(int id)
        {
            var kanji = await _dbContext.Kanjis
                .Include(k => k.Names)
                .Include(k => k.Kuns)
                .Include(k => k.Ons)
                .Include(k => k.Meanings)
                .Include(k => k.Examples)
                .FirstOrDefaultAsync(k => k.Id == id);

            return kanji;
        }

        public async Task<Kanji> Post(Kanji kanji)
        {
            _dbContext.Kanjis.Add(kanji);
            await _dbContext.SaveChangesAsync();
            return kanji;
        }

        public async Task<Kanji> Put(Kanji kanji)
        {
            _dbContext.Kanjis.Update(kanji);
            await _dbContext.SaveChangesAsync();
            return kanji;
        }

        public async Task Delete(Kanji kanji)
        {
            _dbContext.Kanjis.Remove(kanji);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(string property, object value, int? parent)
        {
            return _dbContext.Kanjis.AnyAsync(k => EF.Property<object>(k, property) == value);
        }
    }
}
