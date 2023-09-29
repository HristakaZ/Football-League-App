using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.DTOs.FootballMatch;
using Football_League_App.Mappers;
using Football_League_App.Services.Contracts;
using Football_League_App.Strategies.Contracts.FootballMatch;
using Microsoft.AspNetCore.Mvc;

namespace Football_League_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballMatchController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IFootballMatchService _footballMatchService;

        public FootballMatchController(IBaseRepository baseRepository,
            IFootballMatchService footballMatchService)
        {
            _baseRepository = baseRepository;
            _footballMatchService = footballMatchService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<FootballMatch> footballMatches = _baseRepository.GetAll<FootballMatch>();

            if (footballMatches.Count() != 0)
            {
                List<GetFootballMatchDTO> getFootballMatchDTOs =
                    FootballMatchMapper.MapFootballMatchToGetFootballMatchDTO(footballMatches);

                return Ok(getFootballMatchDTOs);
            }

            return NotFound("No football matches were found.");
        }

        [HttpGet]
        [Route($"{nameof(GetByID)}")]
        public IActionResult GetByID(int id)
        {
            FootballMatch footballMatch = _baseRepository.GetByID<FootballMatch>(id);

            if (footballMatch != null)
            {
                GetFootballMatchDTO getFootballMatchDTO =
                    FootballMatchMapper.MapFootballMatchToGetFootballMatchDTO(footballMatch);

                return Ok(getFootballMatchDTO);
            }

            return NotFound("The football match with the given id was not found.");
        }

        [HttpPost]
        public IActionResult Post(CreateFootballMatchDTO createFootballMatchDTO)
        {
            if (createFootballMatchDTO.HostAndVisitorIDs.Length != 2)
            {
                return BadRequest("Please enter the host and visitor ids.");
            }

            FootballTeam host = _baseRepository.GetByID<FootballTeam>(createFootballMatchDTO.HostAndVisitorIDs[0]);

            if (host == null)
            {
                return NotFound("Host for the match with the given id was not found.");
            }

            FootballTeam visitor = _baseRepository.GetByID<FootballTeam>(createFootballMatchDTO.HostAndVisitorIDs[1]);

            if (visitor == null)
            {
                return NotFound("Visitor for the match with the given id was not found.");
            }

            FootballMatch footballMatch = FootballMatchMapper.MapCreateFootballMatchDTOToModel(createFootballMatchDTO,
                new List<FootballTeam>()
                {
                    host,
                    visitor
                });
            int id = _baseRepository.Create<FootballMatch>(footballMatch);
            IFootballMatchStrategy strategy = _footballMatchService.SetFootballMatchStrategy(footballMatch.EndResult);
            strategy.SetPoints(host, visitor);

            return Created($"{nameof(GetByID)}", id);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateFootballMatchDTO updateFootballMatchDTO)
        {
            FootballMatch footballMatch = _baseRepository.GetByID<FootballMatch>(id);
            if (footballMatch == null)
            {
                return NotFound("Football match was not found.");
            }

            if (updateFootballMatchDTO.HostAndVisitorIDs.Length != 2)
            {
                return BadRequest("Please enter the host and visitor ids.");
            }

            FootballTeam host = _baseRepository.GetByID<FootballTeam>(updateFootballMatchDTO.HostAndVisitorIDs[0]);
            if (host == null)
            {
                return NotFound("Host for the match with the given id was not found.");
            }

            FootballTeam visitor = _baseRepository.GetByID<FootballTeam>(updateFootballMatchDTO.HostAndVisitorIDs[1]);
            if (visitor == null)
            {
                return NotFound("Visitor for the match with the given id was not found.");
            }

            footballMatch = FootballMatchMapper.MapUpdateFootballTeamDTOToModel(updateFootballMatchDTO,
                new List<FootballTeam>()
                {
                    host,
                    visitor
                },
                footballMatch);

            _baseRepository.Update<FootballMatch>(footballMatch);

            GetFootballMatchDTO getFootballMatchDTO =
                    FootballMatchMapper.MapFootballMatchToGetFootballMatchDTO(footballMatch);
            IFootballMatchStrategy strategy = _footballMatchService.SetFootballMatchStrategy(footballMatch.EndResult);
            strategy.SetPoints(host, visitor);

            return Ok(getFootballMatchDTO);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            FootballMatch footballMatchFromDb = _baseRepository.GetByID<FootballMatch>(id);
            if (footballMatchFromDb == null)
            {
                return NotFound("The football match was not found.");
            }

            _baseRepository.Delete<FootballMatch>(footballMatchFromDb);

            return Ok("The football match was successfully deleted.");
        }
    }
}
