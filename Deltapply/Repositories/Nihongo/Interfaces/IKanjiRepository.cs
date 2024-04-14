using Deltapply.Models.Nihongo.Kanjis;

namespace Deltapply.Repositories.Nihongo.Interfaces
{
    public interface IKanjiRepository
    {
        Task<List<Kanji>> GetAllKanjis();
        Task<Kanji> GetKanjiById(int id);
        Task<Kanji> CreateKanji(Kanji kanji);
        Task UpdateKanji(Kanji kanji);
        Task DeleteKanji(int id);
    }
}
