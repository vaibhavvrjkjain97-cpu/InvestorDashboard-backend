using AutoMapper;
using InvestorCommitmentsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestorCommitmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorsController : ControllerBase
    {

        private readonly IInvestorService _service;
        public InvestorsController(IInvestorService service, IMapper mapper)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var investors = await _service.GetAllAsync();
                return Ok(investors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving investors: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var investor = await _service.GetByIdAsync(id);
                if (investor == null)
                    return NotFound();

                return Ok(investor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the investor: {ex.Message}");
            }
        }
    }
}
