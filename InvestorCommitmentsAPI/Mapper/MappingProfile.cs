
using AutoMapper;
using InvestorCommitmentsAPI.ApiModels;
using InvestorCommitmentsAPI.EntityModels;
using InvestorCommitmentsAPI.ServiceModels;

namespace InvestorCommitmentsAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity -> Service DTO
            CreateMap<Investor, InvestorServiceModel>().ForMember(dest => dest.TotalCommitment,
            opt => opt.MapFrom(src => src.Commitments != null
            ? src.Commitments.Sum(c => c.Amount) / 1_000_000_000
            : 0)).ReverseMap();
            CreateMap<Commitment, CommitmentServiceModel>().ReverseMap();

            // Service DTO -> API DTO
            CreateMap<InvestorServiceModel, InvestorApiModel>().ReverseMap();
            CreateMap<CommitmentServiceModel, CommitmentApiModel>().ReverseMap();
        }
    }

}
