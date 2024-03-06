using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("*")]
    public class GenreController : ControllerBase

    { 
        private readonly IGenreRepository _genreRepository;

        public GenreController (IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet("getGenres")]
        public  ActionResult<List<Genre>> GetGenres()
        {
            var genres = _genreRepository.GetGenre();
            return Ok(genres);
        }

        [HttpGet("getGenresById/{id}")]
        public ActionResult<Genre> GetGenreById(long id)
        {
            var genre =  _genreRepository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpGet("getGenreByName/{name}")]
        public  ActionResult<Genre> GetGenreByName(string name)
        {
            var genre = _genreRepository.GetGenreByName(name);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpDelete("deleteGenre/{id}")]
        public async Task<IActionResult> DeleteGenre(long id)
        {
            _genreRepository.DeleteGenreById(id);
            return NoContent();
        }

        [HttpPut("updateGenre/{id}")]
        public  IActionResult  UpdateGenre( Genre genre, long id)
        {
            if( id != genre.GenreId )
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost("addGenre")]
        public IActionResult AddGenre( Genre genre)
        {
            _genreRepository.AddGenre(genre);
            return CreatedAtAction (nameof( GetGenreById), new { id = genre.GenreId } , genre);
        }
    }

}

