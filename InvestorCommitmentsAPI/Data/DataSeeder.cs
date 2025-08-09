namespace InvestorCommitmentsAPI.Data
{
    using CsvHelper;
    using InvestorCommitmentsAPI.EntityModels;
    using System;
    using System.Globalization;

    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Investors.Any()) return; // Skip if already seeded

            var csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "InvestorsCommitments.csv");
            if (!File.Exists(csvPath)) return;

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // This will automatically map CSV headers to class properties
            var records = csv.GetRecords<InvestorRowCsv>().ToList();
            var investorMap = new Dictionary<string, Investor>();

            foreach (var row in records)
            {
                if (!investorMap.ContainsKey(row.InvestorName))
                {
                    var investor = new Investor
                    {
                        Name = row.InvestorName,
                        Type = row.InvestorType,
                        Country = row.InvestorCountry,
                        DateAdded = DateTime.TryParse(row.InvestorDateAdded, out var da) ? da : null,
                        LastUpdated = DateTime.TryParse(row.InvestorLastUpdated, out var lu) ? lu : null,
                        Commitments = new List<Commitment>()
                    };

                    investorMap[row.InvestorName] = investor;
                    context.Investors.Add(investor);
                }

                var commitment = new Commitment
                {
                    AssetClass = row.CommitmentAssetClass,
                    Amount = decimal.TryParse(row.CommitmentAmount, out var amt) ? amt : 0,
                    Currency = row.CommitmentCurrency,
                    Investor = investorMap[row.InvestorName]
                };

                investorMap[row.InvestorName].Commitments.Add(commitment);
            }



            context.SaveChanges();

        }
    }

}
