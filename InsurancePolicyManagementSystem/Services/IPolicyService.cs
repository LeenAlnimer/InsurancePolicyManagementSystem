using System;
using System.Collections.Generic;
using InsurancePolicyManagementSystem.Models;

namespace InsurancePolicyManagementSystem.Services
{
    public interface IPolicyService
    {
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy? GetPolicyById(Guid id);
    }
}