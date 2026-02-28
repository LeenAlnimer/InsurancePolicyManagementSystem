using System;
using InsurancePolicyManagementSystem.Models;
using InsurancePolicyManagementSystem.Services;

namespace InsurancePolicyManagementSystem
{
    class Program
    {
        static void Main()
        {
            IPolicyService service = new PolicyService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Insurance System ===");
                Console.WriteLine("1- Create Car Policy");
                Console.WriteLine("2- Create Health Policy");
                Console.WriteLine("3- View Policies");
                Console.WriteLine("4- Submit Claim");
                Console.WriteLine("5- Exit");
                Console.Write("Select option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCarPolicy(service);
                        break;
                    case "2":
                        CreateHealthPolicy(service);
                        break;
                    case "3":
                        ViewPolicies(service);
                        break;
                    case "4":
                        SubmitClaim(service);
                        break;
                    case "5":
                        running = false;
                        break;
                }
            }
        }

        static void CreateCarPolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Customer Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Driver Age: ");
                int age = int.Parse(Console.ReadLine()!);

                Console.Write("Number Of Accidents: ");
                int accidents = int.Parse(Console.ReadLine()!);

                Console.Write("Coverage Amount: ");
                double coverage = double.Parse(Console.ReadLine()!);

                CarInsurancePolicy policy = new()
                {
                    CustomerName = name,
                    DriverAge = age,
                    NumberOfAccidents = accidents,
                    CoverageAmount = coverage,
                    RiskLevel = RiskLevel.Medium
                };

                service.AddPolicy(policy);
                Console.WriteLine("Car policy created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CreateHealthPolicy(IPolicyService service)
        {
            try
            {
                Console.Write("Customer Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine()!);

                Console.Write("Has Chronic Disease (true/false): ");
                bool chronic = bool.Parse(Console.ReadLine()!);

                Console.Write("Coverage Amount: ");
                double coverage = double.Parse(Console.ReadLine()!);

                HealthInsurancePolicy policy = new()
                {
                    CustomerName = name,
                    Age = age,
                    HasChronicDisease = chronic,
                    CoverageAmount = coverage,
                    RiskLevel = RiskLevel.Medium
                };

                service.AddPolicy(policy);
                Console.WriteLine("Health policy created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ViewPolicies(IPolicyService service)
        {
            var policies = service.GetAllPolicies();

            foreach (var p in policies)
            {
                Console.WriteLine($"ID: {p.Id}");
                Console.WriteLine($"Customer: {p.CustomerName}");
                Console.WriteLine($"Premium: {p.CalculatePremium()}");
                Console.WriteLine($"Claims Count: {p.Claims.Count}");
                Console.WriteLine("----------------------");
            }
        }

        static void SubmitClaim(IPolicyService service)
        {
            Console.Write("Enter Policy ID: ");
            Guid id = Guid.Parse(Console.ReadLine()!);

            var policy = service.GetPolicyById(id);

            if (policy == null)
            {
                Console.WriteLine("Policy not found.");
                return;
            }

            Console.Write("Claim Amount: ");
            double amount = double.Parse(Console.ReadLine()!);

            Console.Write("Description: ");
            string description = Console.ReadLine()!;

            try
            {
                policy.SubmitClaim(amount, description);
                Console.WriteLine("Claim submitted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}