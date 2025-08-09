using InvestorCommitmentsAPI.ServiceModels;

namespace InvestorCommitmentsAPI.Repository
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<InvestorServiceModel>> GetAllAsync();
        Task<InvestorServiceModel> GetByIdAsync(int id);

    }
}
