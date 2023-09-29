using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.DTOs.FootballTeam;
using Football_League_App.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Football_League_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;

        public FootballTeamController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<FootballTeam> footballTeams = _baseRepository.GetAll<FootballTeam>();

            if (footballTeams.Count() != 0)
            {
                List<GetFootballTeamDTO> getFootballTeamDTOs =
                    FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballTeams);
                return Ok(getFootballTeamDTOs);
            }

            return NotFound("No football teams were found.");
        }

        [HttpGet]
        [Route($"{nameof(GetByID)}")]
        public IActionResult GetByID(int id)
        {
            FootballTeam footballTeam = _baseRepository.GetByID<FootballTeam>(id);

            if (footballTeam != null)
            {
                GetFootballTeamDTO getFootballTeamDTO = 
                    FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballTeam);
                return Ok(getFootballTeamDTO);
            }

            return NotFound("The football team with the given id was not found.");
        }

        [HttpPost]
        public IActionResult Post(CreateFootballTeamDTO createFootballTeamDTO)
        {
            FootballLeague footballLeague =
                _baseRepository.GetByID<FootballLeague>(createFootballTeamDTO.FootballLeagueID);

            if (footballLeague == null)
            {
                return NotFound("The football league for the team was not found.");
            }

            FootballTeam footballTeam = FootballTeamMapper.MapCreateFootballTeamDTOToModel(createFootballTeamDTO,
                footballLeague);
            int id = _baseRepository.Create<FootballTeam>(footballTeam);

            return Created($"{nameof(GetByID)}", id);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateFootballTeamDTO updateFootballTeamDTO)
        {
            FootballTeam footballTeam = _baseRepository.GetByID<FootballTeam>(id);
            if (footballTeam == null)
            {
                return NotFound("Football team was not found.");
            }

            FootballLeague footballLeague =
                _baseRepository.GetByID<FootballLeague>(updateFootballTeamDTO.FootballLeagueID);

            if (footballLeague == null)
            {
                return NotFound("The football league for the team was not found.");
            }

            footballTeam = FootballTeamMapper.MapUpdateFootballTeamDTOToModel(updateFootballTeamDTO,
                footballLeague,
                footballTeam);
            _baseRepository.Update<FootballTeam>(footballTeam);

            GetFootballTeamDTO getFootballTeamDTO =
                    FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballTeam);
            return Ok(getFootballTeamDTO);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            FootballTeam footballTeamFromDb = _baseRepository.GetByID<FootballTeam>(id);
            if (footballTeamFromDb == null)
            {
                return NotFound("The football team was not found.");
            }

            _baseRepository.Delete<FootballTeam>(footballTeamFromDb);

            return Ok("The football team was successfully deleted.");
        }
    }
}
