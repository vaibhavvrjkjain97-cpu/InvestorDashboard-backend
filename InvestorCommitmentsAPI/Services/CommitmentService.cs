using AutoMapper;
using InvestorCommitmentsAPI.ApiModels;
using InvestorCommitmentsAPI.Repository;

namespace InvestorCommitmentsAPI.Services
{
    public class CommitmentService : ICommitmentService
    {
        private readonly ICommitmentRepository _repo;
        private readonly IMapper _mapper;
        public CommitmentService(ICommitmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommitmentApiModel>> GetAllAsync() => _mapper.Map<IEnumerable<CommitmentApiModel>>(await _repo.GetAllAsync());
        public async Task<CommitmentApiModel> GetByIdAsync(int id) => _mapper.Map<CommitmentApiModel>(await _repo.GetByIdAsync(id));
        public async Task<IEnumerable<CommitmentApiModel>> GetByInvestorIdAsync(int investorId, string? assetClass) => _mapper.Map<IEnumerable<CommitmentApiModel>>(await _repo.GetByInvestorIdAsync(investorId, assetClass));
    }
}
