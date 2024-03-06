using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookwormContext _context;

        public LanguageRepository (BookwormContext context)
        {
            _context = context;
        }

        public List<Language> GetAllLanguage()
        {
            return _context.LanguageMasters.ToList();
        }

        public Language GetLanguageByType(string type)
        {
            return _context.LanguageMasters.Find( type );
        }

        public Language GetLanguageByTypeId(long id)
        {
            return _context.LanguageMasters.Find(id);
        }

        public void UpdateLanguage(Language language)
        {

            _context.LanguageMasters.Attach( language );
            _context.Entry(language).State = EntityState.Modified;
            _context.SaveChanges();


        }
    }
}
