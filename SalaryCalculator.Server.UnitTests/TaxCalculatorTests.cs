using SalaryCalculator.Server.services;

namespace SalaryCalculator.Server.UnitTests;

[TestClass]
public class TaxCalculatorTests
{
    private TaxCalculator _taxCalculator;

    [TestInitialize]
    public void TestInitialize()
    {
        _taxCalculator = new TaxCalculator();
    }

    [TestMethod]
    public void CalculateSalaryDetails_WhenIncomeIs5000_ReturnsCorrectSalaryDetails()
    {
        decimal income = 5000;

        var result = _taxCalculator.CalculateSalaryDetails(income);

        Assert.AreEqual(income, result.GrossAnnualSalary);
        Assert.AreEqual(income / 12, result.GrossMonthlySalary);
        Assert.AreEqual(income, result.NetAnnualSalary);
        Assert.AreEqual(income / 12, result.NetMonthlySalary);
        Assert.AreEqual(0, result.AnnualTaxPaid);
        Assert.AreEqual(0, result.MonthlyTaxPaid);
    }

    [TestMethod]
    public void CalculateSalaryDetails_WhenIncomeIs10000_ReturnsCorrectSalaryDetails()
    {
        decimal income = 10000;

        var result = _taxCalculator.CalculateSalaryDetails(income);

        Assert.AreEqual(income, result.GrossAnnualSalary);
        Assert.AreEqual(income / 12, result.GrossMonthlySalary);
        Assert.AreEqual(1000, result.AnnualTaxPaid);
    }
}