using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class GenreRepository : IGenreRepository
    {

        private readonly BookwormContext _context;

        public GenreRepository (BookwormContext context)
        {
            _context = context;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void DeleteGenreById(long id)
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }

            
        }

        public List<Genre> GetGenre()
        {
            return _context.Genres.ToList();

        }

        public Genre GetGenreById(long id)
        {
            return _context.Genres.Find(id);
        }

        public Genre GetGenreByName(string name)
        {
            return _context.Genres.Find(name);
        }

        public void UpdateGenre(Genre genre)
        {
            _context.Genres.Attach(genre);
            _context.Entry(genre).State=EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
