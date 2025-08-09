namespace InvestorCommitmentsAPI.EntityModels
{
    public class Commitment
    {
        public int CommitmentId { get; set; }
        public int InvestorId { get; set; }
        public string AssetClass { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Investor Investor { get; set; }
    }
}
