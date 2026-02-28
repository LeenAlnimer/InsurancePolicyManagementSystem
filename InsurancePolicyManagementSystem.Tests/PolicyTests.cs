using Xunit;
using InsurancePolicyManagementSystem.Models;
using InsurancePolicyManagementSystem.Services;
using InsurancePolicyManagementSystem.Exceptions;

namespace InsurancePolicyManagementSystem.Tests
{
    public class PolicyTests
    {
        // HEALTH POLICY TESTS
        

        [Fact]
        public void CalculatePremium_HealthPolicy_ReturnsCorrectValue()
        {
            // Arrange
            var policy = new HealthInsurancePolicy
            {
                CustomerName = "Test",
                Age = 22,
                HasChronicDisease = true,
                CoverageAmount = 200000
            };

            // Act
            var premium = policy.CalculatePremium();

            // Assert
            Assert.True(premium > 0);
        }

        [Fact]
        public void HealthPolicy_InvalidAge_ShouldThrowException()
        {
            // Arrange
            var service = new PolicyService();
            var policy = new HealthInsurancePolicy
            {
                CustomerName = "Test",
                Age = -5,
                HasChronicDisease = false,
                CoverageAmount = 100000
            };

            // Act & Assert
            Assert.Throws<InvalidPolicyException>(() => service.AddPolicy(policy));
        }

        // CAR POLICY TESTS

        [Fact]
        public void CalculatePremium_CarPolicy_ReturnsCorrectValue()
        {
            // Arrange
            var policy = new CarInsurancePolicy
            {
                CustomerName = "Test",
                DriverAge = 25,
                NumberOfAccidents = 1,
                CoverageAmount = 100000
            };

            // Act
            var premium = policy.CalculatePremium();

            // Assert
            Assert.True(premium > 0);
        }

        [Fact]
        public void CarPolicy_InvalidDriverAge_ShouldThrowException()
        {
            // Arrange
            var service = new PolicyService();
            var policy = new CarInsurancePolicy
            {
                CustomerName = "Test",
                DriverAge = 0,
                NumberOfAccidents = 0,
                CoverageAmount = 100000
            };

            // Act & Assert
            Assert.Throws<InvalidPolicyException>(() => service.AddPolicy(policy));
        }

        // CLAIM TESTS

        [Fact]
        public void SubmitClaim_ExceedCoverage_ShouldThrowException()
        {
            // Arrange
            var policy = new CarInsurancePolicy
            {
                CustomerName = "Test",
                DriverAge = 30,
                NumberOfAccidents = 0,
                CoverageAmount = 1000
            };

            // Act & Assert
            Assert.Throws<Exception>(() => policy.SubmitClaim(2000, "Big Accident"));
        }

        [Fact]
        public void SubmitClaim_ValidAmount_ShouldIncreaseClaimsCount()
        {
            // Arrange
            var policy = new CarInsurancePolicy
            {
                CustomerName = "Test",
                DriverAge = 30,
                NumberOfAccidents = 0,
                CoverageAmount = 10000
            };

            // Act

            policy.SubmitClaim(1000, "Minor Accident");
            // Assert
            Assert.Single(policy.Claims);
        }
    }
}