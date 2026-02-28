namespace InsurancePolicyManagementSystem.Models
{
    public class CarInsurancePolicy : Policy
    {
        public int DriverAge { get; set; }
        public int NumberOfAccidents { get; set; }

        public override double CalculatePremium()
        {
            double premium = 1000;

            if (DriverAge < 25)
                premium += 500;

            premium += NumberOfAccidents * 200;

            if (RiskLevel == RiskLevel.High)
                premium *= 1.3;
            else if (RiskLevel == RiskLevel.Medium)
                premium *= 1.15;

            return premium;
        }
    }
}