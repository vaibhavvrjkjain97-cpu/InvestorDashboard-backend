using AutoMapper;
using InvestorCommitmentsAPI.Data;
using InvestorCommitmentsAPI.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace InvestorCommitmentsAPI.Repository
{
    public class InvestorRepository :IInvestorRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InvestorRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvestorServiceModel>> GetAllAsync()
        {
            var investors = await _context.Investors
                .Include(i => i.Commitments)
                .ToListAsync();
            return _mapper.Map<IEnumerable<InvestorServiceModel>>(investors);
        }

        public async Task<InvestorServiceModel> GetByIdAsync(int id)
        {
            var investor = await _context.Investors.Include(i=>i.Commitments).FirstOrDefaultAsync(i => i.InvestorId == id);
            return _mapper.Map<InvestorServiceModel>(investor);
        }
    }
}
