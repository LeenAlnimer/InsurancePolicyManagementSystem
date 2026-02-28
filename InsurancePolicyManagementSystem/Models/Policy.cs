using System;
using System.Collections.Generic;

namespace InsurancePolicyManagementSystem.Models
{
    public abstract class Policy
    {
        public Guid Id { get; private set; }
        public string CustomerName { get; set; } = string.Empty;
        public double CoverageAmount { get; set; }
        public RiskLevel RiskLevel { get; set; }

        protected List<Claim> _claims = new();
        public IReadOnlyList<Claim> Claims => _claims.AsReadOnly();

        protected Policy()
        {
            Id = Guid.NewGuid();
        }

        public abstract double CalculatePremium();

        public void SubmitClaim(double amount, string description)
        {
            double totalClaims = 0;

            foreach (var claim in _claims)
                totalClaims += claim.Amount;

            if (totalClaims + amount > CoverageAmount)
                throw new Exception("Claim exceeds coverage limit.");

            _claims.Add(new Claim(amount, description));
        }
    }
}