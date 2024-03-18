using SalaryCalculator.Server.models;

namespace SalaryCalculator.Server.services;

public interface ITaxCalculator
{
    public SalaryDetails CalculateSalaryDetails(decimal income);
}
