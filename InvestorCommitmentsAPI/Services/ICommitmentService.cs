using InvestorCommitmentsAPI.ApiModels;
using InvestorCommitmentsAPI.ServiceModels;

namespace InvestorCommitmentsAPI.Services
{
    public interface ICommitmentService
    {
        Task<IEnumerable<CommitmentApiModel>> GetAllAsync();
        Task<CommitmentApiModel> GetByIdAsync(int id);
        Task<IEnumerable<CommitmentApiModel>> GetByInvestorIdAsync(int investorId, string? assetClass);

    }
}
