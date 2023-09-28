using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.Mappers;
using Football_League_App.ViewModels.FootballLeague;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football_League_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballLeagueController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;

        public FootballLeagueController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<FootballLeague> footballLeagues = _baseRepository.GetAll<FootballLeague>();

            return footballLeagues.Count() != 0 ? Ok(footballLeagues) : NotFound("No football leagues were found.");
        }

        [HttpGet]
        [Route($"{nameof(GetByID)}")]
        public IActionResult GetByID(int id)
        {
            FootballLeague footballLeague = _baseRepository.GetByID<FootballLeague>(id);

            return footballLeague != null ? Ok(footballLeague) : NotFound("The football league with the given id was not found.");
        }

        [HttpPost]
        public IActionResult Post(CreateFootballLeagueDTO createFootballLeagueDTO)
        {
            FootballLeague footballLeague = FootballLeagueMapper.MapCreateFootballLeagueDTOToModel(createFootballLeagueDTO);
            int id = _baseRepository.Create<FootballLeague>(footballLeague);

            return Created($"{nameof(GetByID)}", id);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateFootballLeagueDTO updateFootballLeagueDTO)
        {
            FootballLeague footballLeague = _baseRepository.GetByID<FootballLeague>(id);
            if (footballLeague == null)
            {
                return NotFound("Football league was not found.");
            }

            footballLeague.Name = updateFootballLeagueDTO.Name;
            _baseRepository.Update<FootballLeague>(footballLeague);

            return Ok(footballLeague);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            FootballLeague footballLeagueFromDb = _baseRepository.GetByID<FootballLeague>(id);
            if (footballLeagueFromDb == null)
            {
                return NotFound("The football league was not found.");
            }

            _baseRepository.Delete<FootballLeague>(footballLeagueFromDb);

            return Ok("The football league was successfully deleted.");
        }
    }
}
