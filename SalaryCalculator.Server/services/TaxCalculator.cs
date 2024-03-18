using SalaryCalculator.Server.models;

namespace SalaryCalculator.Server.services;

public class TaxCalculator : ITaxCalculator
{
    private readonly double bandAUpperLimit = 5000;
    private readonly  double bandBUpperLimit = 20000;
    private readonly double bandBRate = 0.20;
    private readonly double bandCRate = 0.40;
    public  SalaryDetails CalculateSalaryDetails(double income)
    {


        double taxBandB = CalculateTax(income, bandAUpperLimit, bandBUpperLimit, bandBRate);
        double taxBandC = CalculateTax(income, bandBUpperLimit, null, bandCRate );

        double totalTax = taxBandB + taxBandC;

        return new SalaryDetails
        {
            GrossAnnualSalary = income,
            GrossMonthlySalary = income / 12,
            NetAnnualSalary = income - totalTax,
            NetMonthlySalary = (income - totalTax) / 12,
            AnnualTaxPaid = totalTax,
            MonthlyTaxPaid = totalTax / 12
        };
    }
    private double CalculateTax(double income, double lowerLimit, double? upperLimit, double rate)
    {
        if (income > lowerLimit)
        {
            double taxableIncome = (upperLimit.HasValue && income > upperLimit.Value) ? 
                                                upperLimit.Value - lowerLimit : income - lowerLimit;
            return taxableIncome * rate;
        }
        return 0;
    }
}
