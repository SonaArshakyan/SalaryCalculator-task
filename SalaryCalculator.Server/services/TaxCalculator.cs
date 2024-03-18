using SalaryCalculator.Server.models;

namespace SalaryCalculator.Server.services;

public class TaxCalculator : ITaxCalculator
{
    private readonly decimal bandAUpperLimit = 5000;
    private readonly decimal bandBUpperLimit = 20000;
    private readonly decimal bandBRate = 0.20m;
    private readonly decimal bandCRate = 0.40m;

    public SalaryDetails CalculateSalaryDetails(decimal income)
    {
        decimal taxBandB = CalculateTax(income, bandAUpperLimit, bandBUpperLimit, bandBRate);
        decimal taxBandC = CalculateTax(income, bandBUpperLimit, null, bandCRate);

        decimal totalTax = taxBandB + taxBandC;

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
    private decimal CalculateTax(decimal income, decimal lowerLimit, decimal? upperLimit, decimal rate)
    {
        if (income > lowerLimit)
        {
            decimal taxableIncome = (upperLimit.HasValue && income > upperLimit.Value) ?
                                                upperLimit.Value - lowerLimit : income - lowerLimit;
            return taxableIncome * rate;
        }
        return 0;
    }
}
