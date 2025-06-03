using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecruitmentApp.Application.Commands;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Application.Queries;

namespace RecruitmentApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateItemDto>> GetAllCandidates()
        {
            return await _mediator.Send(new GetAllCandidatesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateItemDto?>> GetCandidateById(int id)
        {
            try
            {
                var candidate = await _mediator.Send(new GetCandidateByIdQuery(id));
                if (candidate == null)
                {
                    return NotFound();
                }
                return candidate;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while retrieving the candidate.", Details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CandidateItemDto>> CreateCandidate(CreateCandidateCommand command)
        {
            try
            {
                var createdCandidate = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetCandidateById), new { id = createdCandidate.Id }, createdCandidate);
            }
            catch (InvalidOperationException)
            {
                return BadRequest(new { message = "Ya existe un candidato con este correo electrónico." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while creating the candidate.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, UpdateCandidateCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest("Candidate ID mismatch.");
                }
    
                var updatedCandidate = await _mediator.Send(command);
                if (updatedCandidate == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while updating the candidate.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCandidateCommand(id));
                if (!result)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An error occurred while deleting the candidate.", Details = ex.Message });
            }
        }
    }
}