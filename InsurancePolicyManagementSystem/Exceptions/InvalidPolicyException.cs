using System;

namespace InsurancePolicyManagementSystem.Exceptions
{
    public class InvalidPolicyException : Exception
    {
        public InvalidPolicyException(string message) : base(message)
        {
        }
    }
}