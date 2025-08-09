namespace InvestorCommitmentsAPI.ApiModels
{
    public class InvestorApiModel
    {
        public int InvestorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal TotalCommitment { get; set; }
    }
}
