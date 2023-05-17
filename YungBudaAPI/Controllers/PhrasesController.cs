using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YungBudaAPI.Context;
using YungBudaAPI.Models;
using Microsoft.EntityFrameworkCore;
using YungBudaAPI.Interfaces;
using AutoMapper;
using YungBudaAPI.Dto;

namespace YungBudaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase {
        private readonly IPhraseRepository _phraseRepository;
        private readonly IMapper _mapper;

        public PhrasesController(IPhraseRepository phraseRepository, IMapper mapper) {
            
            _phraseRepository = phraseRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Phrases>> GetAll() {
            try {
                var phrasesDto = _mapper.Map<List<PhraseDto>>(_phraseRepository.GetPhrases());
                if(phrasesDto is null) {
                    return NotFound("Items not found");
                }
                return Ok(phrasesDto);
            }
            catch (Exception) {

                return NotFound("Not found..");
            }
        }

        [HttpGet("{id:int}")]

        public ActionResult<IEnumerable<Phrases>> GetPhraseById(int id) {
            try {
                var phraseDto = _mapper.Map<PhraseDto>(_phraseRepository.GetPhrase(id));
                if (phraseDto is null) {
                    return NotFound("Item not found...");
                }
                return Ok(phraseDto);

            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred in request");
            }
        }



        [HttpGet("randomPhrase")]
        public ActionResult<IEnumerable<Phrases>> RandomPhrase() {
            try {

                var randomPhraseDto = _mapper.Map<PhraseDto>(_phraseRepository.GetRandomPhrase());
                
                if (randomPhraseDto is null) {
                    return NotFound("random phrase not found");
                }
                return Ok(randomPhraseDto.Phrase);


            }
            catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocurred in request");
            }
        }





    }
}
