using Microsoft.EntityFrameworkCore;
using YungBudaAPI.Context;
using YungBudaAPI.Interfaces;
using YungBudaAPI.Models;

namespace YungBudaAPI.Repository {
    public class PhraseRepository : IPhraseRepository {
        private readonly AppDbContext _context;

        public PhraseRepository(AppDbContext context) {
            _context = context;
        }


        public Phrases GetPhrase(int id) {
            return _context.Phrases.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Phrases> GetPhrases() {
           return _context.Phrases.AsNoTracking().ToList();
        }

        public Phrases GetRandomPhrase() {
            Random randomId = new Random();
            int id = randomId.Next(0, 2);

            return _context.Phrases.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
