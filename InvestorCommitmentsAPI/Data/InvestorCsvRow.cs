using CsvHelper.Configuration.Attributes;

namespace InvestorCommitmentsAPI.Data
{
    public class InvestorRowCsv
    {
        [Name("Investor Name")]
        public string InvestorName { get; set; }

        [Name("Investory Type")]
        public string InvestorType { get; set; }

        [Name("Investor Country")]
        public string InvestorCountry { get; set; }

        [Name("Investor Date Added")]
        public string InvestorDateAdded { get; set; }

        [Name("Investor Last Updated")]
        public string InvestorLastUpdated { get; set; }

        [Name("Commitment Asset Class")]
        public string CommitmentAssetClass { get; set; }

        [Name("Commitment Amount")]
        public string CommitmentAmount { get; set; }

        [Name("Commitment Currency")]
        public string CommitmentCurrency { get; set; }
    }

}
