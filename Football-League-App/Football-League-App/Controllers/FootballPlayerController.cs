using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.DTOs.FootballPlayer;
using Football_League_App.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Football_League_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;

        public FootballPlayerController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<FootballPlayer> footballPlayers = _baseRepository.GetAll<FootballPlayer>();

            if (footballPlayers.Count() != 0)
            {
                List<GetFootballPlayerDTO> getFootballPlayerDTOs =
                    FootballPlayerMapper.MapFootballPlayerModelToGetFootballPlayerDTO(footballPlayers);

                return Ok(getFootballPlayerDTOs);
            }

            return NotFound("No football players were found.");
        }

        [HttpGet]
        [Route($"{nameof(GetByID)}")]
        public IActionResult GetByID(int id)
        {
            FootballPlayer footballPlayer = _baseRepository.GetByID<FootballPlayer>(id);

            if (footballPlayer != null)
            {
                GetFootballPlayerDTO getFootballPlayerDTO =

                    FootballPlayerMapper.MapFootballPlayerModelToGetFootballPlayerDTO(footballPlayer);
                return Ok(getFootballPlayerDTO);
            }

            return NotFound("The football player with the given id was not found.");
        }

        [HttpPost]
        public IActionResult Post(CreateFootballPlayerDTO createFootballPlayerDTO)
        {
            FootballTeam footballTeam =
                _baseRepository.GetByID<FootballTeam>(createFootballPlayerDTO.FootballTeamID);

            if (footballTeam == null)
            {
                return NotFound("The football team for the player was not found.");
            }

            FootballPlayer footballPlayer = FootballPlayerMapper.MapCreateFootballPlayerDTOToModel(createFootballPlayerDTO,
                footballTeam);
            int id = _baseRepository.Create<FootballPlayer>(footballPlayer);

            return Created($"{nameof(GetByID)}", id);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateFootballPlayerDTO updateFootballPlayerDTO)
        {
            FootballPlayer footballPlayer = _baseRepository.GetByID<FootballPlayer>(id);
            if (footballPlayer == null)
            {
                return NotFound("The football player was not found.");
            }

            FootballTeam footballTeam =
                _baseRepository.GetByID<FootballTeam>(updateFootballPlayerDTO.FootballTeamID);

            if (footballTeam == null)
            {
                return NotFound("The football team for the player was not found.");
            }

            footballPlayer = FootballPlayerMapper.MapUpdateFootballPlayerDTOToModel(updateFootballPlayerDTO,
                footballTeam,
                footballPlayer);
            _baseRepository.Update<FootballPlayer>(footballPlayer);

            GetFootballPlayerDTO getFootballPlayerDTO =
                    FootballPlayerMapper.MapFootballPlayerModelToGetFootballPlayerDTO(footballPlayer);

            return Ok(getFootballPlayerDTO);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            FootballPlayer footballPlayerFromDb = _baseRepository.GetByID<FootballPlayer>(id);
            if (footballPlayerFromDb == null)
            {
                return NotFound("The football player was not found.");
            }

            _baseRepository.Delete<FootballPlayer>(footballPlayerFromDb);

            return Ok("The football player was successfully deleted.");
        }
    }
}
