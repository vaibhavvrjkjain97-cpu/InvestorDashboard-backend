using AutoMapper;
using InvestorCommitmentsAPI.ApiModels;
using InvestorCommitmentsAPI.Repository;

namespace InvestorCommitmentsAPI.Services
{
    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _repo;
        private readonly IMapper _mapper;
        public InvestorService(IInvestorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvestorApiModel>> GetAllAsync() => _mapper.Map<IEnumerable<InvestorApiModel>>( await _repo.GetAllAsync());
        public async Task<InvestorApiModel> GetByIdAsync(int id) => _mapper.Map<InvestorApiModel>(await _repo.GetByIdAsync(id));
    }
}
