using AutoMapper;
using InvestorCommitmentsAPI.Data;
using InvestorCommitmentsAPI.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace InvestorCommitmentsAPI.Repository
{
    public class CommitmentRepository : ICommitmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CommitmentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommitmentServiceModel>> GetAllAsync()
        {
            var commitments =  await _context.Commitments.ToListAsync();
            return _mapper.Map<IEnumerable<CommitmentServiceModel>>(commitments);
        }

        public async Task<CommitmentServiceModel> GetByIdAsync(int id)
        {
            var commitment = await _context.Commitments.FirstOrDefaultAsync(c => c.CommitmentId == id);
            return _mapper.Map<CommitmentServiceModel>(commitment);
        }

        public async Task<IEnumerable<CommitmentServiceModel>> GetByInvestorIdAsync(int investorId, string? assetClass)
        {
            var commitments = await _context.Commitments
                                             .Include(c => c.Investor)
                                             .Where(c => c.Investor.InvestorId == investorId && (assetClass ==null || c.AssetClass == assetClass)).ToListAsync();
            return _mapper.Map<IEnumerable<CommitmentServiceModel>>(commitments);
        }
    }
}
