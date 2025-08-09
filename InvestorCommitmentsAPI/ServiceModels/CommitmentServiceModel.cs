namespace InvestorCommitmentsAPI.ServiceModels
{
    public class CommitmentServiceModel
    {
        public int CommitmentId { get; set; }
        public string AssetClass { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "GBP";
        public int InvestorId { get; set; }
    }
}
