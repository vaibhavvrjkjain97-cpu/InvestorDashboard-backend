using AutoMapper;
using InvestorCommitmentsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestorCommitmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommitmentsController : ControllerBase
    {
        private readonly ICommitmentService _service;
        private readonly IMapper _mapper;
        public CommitmentsController(ICommitmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var commitments = await _service.GetAllAsync();
                return Ok(commitments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving commitments: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var commitment = await _service.GetByIdAsync(id);
                if (commitment == null)
                    return NotFound();

                return Ok(commitment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the commitment: {ex.Message}");
            }
        }

        [HttpGet("GetByInvestorId/{investorId}")]
        public async Task<IActionResult> GetByInvestorId(int investorId, [FromQuery] string? assetClass)
        {
            try
            {
                var commitments = await _service.GetByInvestorIdAsync(investorId, assetClass);
                if (commitments == null || !commitments.Any())
                    return NotFound();

                return Ok(commitments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving commitments for the investor: {ex.Message}");
            }
        }
    }
}
