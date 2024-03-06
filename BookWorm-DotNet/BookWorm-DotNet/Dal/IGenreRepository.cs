using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface IGenreRepository
    {
        
        void AddGenre (Genre genre);
         List<Genre> GetGenre();
        void DeleteGenreById(long id);
        void UpdateGenre(Genre genre);
        Genre  GetGenreById(long id);
        Genre GetGenreByName(string name);
    }
}

