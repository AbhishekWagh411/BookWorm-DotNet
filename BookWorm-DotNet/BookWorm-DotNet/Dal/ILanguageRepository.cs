using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface ILanguageRepository
    {
      


        void UpdateLanguage( Language language);
        List<Language>  GetAllLanguage();
        Language  GetLanguageByTypeId(long id);
        Language  GetLanguageByType(string type);
    }


}

