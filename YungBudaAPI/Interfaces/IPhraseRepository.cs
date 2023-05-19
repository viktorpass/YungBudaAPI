using YungBudaAPI.Models;

namespace YungBudaAPI.Interfaces {
    public interface IPhraseRepository {

        Task<ICollection<Phrases>> GetPhrases();

        Phrases GetPhrase(int id);

        Phrases GetRandomPhrase();


    }
}
