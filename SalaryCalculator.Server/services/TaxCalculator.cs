using SalaryCalculator.Server.models;

namespace SalaryCalculator.Server.services;

public class TaxCalculator
{
    public static SalaryDetails CalculateTax(double income)
    {
        double bandAUpperLimit = 5000;
        double bandBUpperLimit = 10000;

        double taxBandA = 0;
        double taxBandB = 0;
        double taxBandC = 0;

        if (income <= bandAUpperLimit)
        {
            taxBandA = income * 0.00;
        }
        else
        {
            taxBandA = bandAUpperLimit * 0.00;
        }

        if (income > bandAUpperLimit && income <= bandBUpperLimit)
        {
            taxBandB = (income - bandAUpperLimit) * 0.20;
        }
        else if (income > bandBUpperLimit)
        {
            taxBandB = (bandBUpperLimit - bandAUpperLimit) * 0.20;
        }

        if (income > bandBUpperLimit)
        {
            taxBandC = (income - bandBUpperLimit) * 0.40; 
        }

        double totalTax = taxBandA + taxBandB + taxBandC;

        double netAnnualSalary = income - totalTax;

        double netMonthlySalary = netAnnualSalary / 12;

        double monthlyTaxPaid = totalTax / 12;

        return new SalaryDetails
        {
            GrossAnnualSalary = income,
            GrossMonthlySalary = income / 12,
            NetAnnualSalary = netAnnualSalary,
            NetMonthlySalary = netMonthlySalary,
            AnnualTaxPaid = totalTax,
            MonthlyTaxPaid = monthlyTaxPaid
        };
    }
}
