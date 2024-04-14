using Deltapply.Data;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Repositories.Nihongo.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Repositories.Nihongo
{
    public class KanjiRepository: IKanjiRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public KanjiRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Kanji> CreateKanji(Kanji kanji)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKanji(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Kanji>> GetAllKanjis()
        {
            return await _dbContext.Kanjis
                .Include(k => k.Names)
                .Include(k => k.Kuns)
                .Include(k => k.Ons)
                .Include(k => k.Meanings)
                .Include(k => k.Examples)
                .ToListAsync();
        }

        public async Task<Kanji> GetKanjiById(int id)
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

        public async Task UpdateKanji(Kanji kanji)
        {
            throw new NotImplementedException();
        }
    }
}
