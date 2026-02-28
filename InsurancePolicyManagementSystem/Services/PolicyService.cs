using System;
using System.Collections.Generic;
using InsurancePolicyManagementSystem.Models;
using InsurancePolicyManagementSystem.Data;
using InsurancePolicyManagementSystem.Exceptions;

namespace InsurancePolicyManagementSystem.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly Repository<Policy> _repository = new();

        public void AddPolicy(Policy policy)
        {
            ValidatePolicy(policy);
            _repository.Add(policy);
        }

        public List<Policy> GetAllPolicies()
        {
            return _repository.GetAll();
        }

        public Policy? GetPolicyById(Guid id)
        {
            foreach (var policy in _repository.GetAll())
            {
                if (policy.Id == id)
                    return policy;
            }

            return null;
        }

        private void ValidatePolicy(Policy policy)
        {
            // Common validation
            if (string.IsNullOrWhiteSpace(policy.CustomerName))
                throw new InvalidPolicyException("Customer name cannot be empty.");

            if (policy.CoverageAmount <= 0)
                throw new InvalidPolicyException("Coverage must be greater than zero.");

            // Car policy validation
            if (policy is CarInsurancePolicy carPolicy)
            {
                if (carPolicy.DriverAge <= 0)
                    throw new InvalidPolicyException("Driver age must be positive.");

                if (carPolicy.NumberOfAccidents < 0)
                    throw new InvalidPolicyException("Number of accidents cannot be negative.");
            }

            // Health policy validation
            if (policy is HealthInsurancePolicy healthPolicy)
            {
                if (healthPolicy.Age <= 0)
                    throw new InvalidPolicyException("Age must be positive.");
            }
        }
    }
}