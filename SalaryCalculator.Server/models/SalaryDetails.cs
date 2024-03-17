namespace SalaryCalculator.Server.models;

public class SalaryDetails
{
    public double GrossAnnualSalary { get; set; }
    public double GrossMonthlySalary { get; set; }
    public double NetAnnualSalary { get; set; }
    public double NetMonthlySalary { get; set; }
    public double AnnualTaxPaid { get; set; }
    public double MonthlyTaxPaid { get; set; }
}