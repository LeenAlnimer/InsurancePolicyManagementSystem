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
            if (string.IsNullOrWhiteSpace(policy.CustomerName))
                throw new InvalidPolicyException("Customer name cannot be empty.");

            if (policy.CoverageAmount <= 0)
                throw new InvalidPolicyException("Coverage must be greater than zero.");
        }
    }
}