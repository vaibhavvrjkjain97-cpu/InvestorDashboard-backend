using InvestorCommitmentsAPI.ApiModels;
using InvestorCommitmentsAPI.ServiceModels;

namespace InvestorCommitmentsAPI.Services
{
    public interface IInvestorService
    {
        Task<IEnumerable<InvestorApiModel>> GetAllAsync();
        Task<InvestorApiModel> GetByIdAsync(int id);
    }
}
