namespace InsurancePolicyManagementSystem.Models
{
    public class HealthInsurancePolicy : Policy
    {
        public int Age { get; set; }
        public bool HasChronicDisease { get; set; }

        public override double CalculatePremium()
        {
            double premium = 800;

            if (Age > 50)
                premium += 400;

            if (HasChronicDisease)
                premium += 600;

            if (RiskLevel == RiskLevel.High)
                premium *= 1.25;
            else if (RiskLevel == RiskLevel.Medium)
                premium *= 1.1;

            return premium;
        }
    }
}