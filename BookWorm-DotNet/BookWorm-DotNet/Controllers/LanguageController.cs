using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors("*")]

    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository LanguageRepository)
        {
            _languageRepository = LanguageRepository;
        }
 
        [HttpPut("update/{id}")]
        public IActionResult  UpdateLanguage(int id, Language language)
        {
            _languageRepository.UpdateLanguage(language);
            return NoContent();
        }

        [HttpGet("getAll")]
        public  ActionResult<List<Language>> GetAllLanguages()
        {
            var languages = _languageRepository.GetAllLanguage();
            return Ok(languages);
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Language> GetLanguageById(long id)
        {
            var language =  _languageRepository.GetLanguageByTypeId(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [HttpGet("getByType/{type}")]
        public ActionResult<Language> GetLanguageByType(string type)
        {
            var language = _languageRepository.GetLanguageByType(type);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }
    }





}
