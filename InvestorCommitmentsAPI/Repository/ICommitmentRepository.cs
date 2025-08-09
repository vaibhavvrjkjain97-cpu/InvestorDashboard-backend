using InvestorCommitmentsAPI.EntityModels;
using InvestorCommitmentsAPI.ServiceModels;

namespace InvestorCommitmentsAPI.Repository
{
    public interface ICommitmentRepository
    {
        Task<IEnumerable<CommitmentServiceModel>> GetAllAsync();
        Task<CommitmentServiceModel> GetByIdAsync(int id);
        Task<IEnumerable<CommitmentServiceModel>> GetByInvestorIdAsync(int investorId, string? assetClass);
    }
}
