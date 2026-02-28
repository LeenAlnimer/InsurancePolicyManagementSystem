using System;

namespace InsurancePolicyManagementSystem.Models
{
    public class Claim
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        public Claim(double amount, string description)
        {
            if (amount <= 0)
                throw new Exception("Claim amount must be greater than zero.");

            Amount = amount;
            Description = description;
            Date = DateTime.Now;
        }
    }
}