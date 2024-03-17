using SalaryCalculator.Server.services;

namespace SalaryCalculator.Server.UnitTests;

[TestClass]
public class TaxCalculatorTests
{
    [TestMethod]
    public void CalculateTax_WhenIncomeIsBelowBandA_ShouldTaxAtZeroPercent()
    {
        
        var income = 4000;
        var expectedTax = 0;
        
        var result = TaxCalculator.CalculateTax(income);
        
        Assert.AreEqual(expectedTax, result.AnnualTaxPaid);
    }

    [TestMethod]
    public void CalculateTax_WhenIncomeIsWithinBandB_ShouldTaxAtTwentyPercent()
    {
        
        var income = 8000;
        var expectedTax = 600;
        
        var result = TaxCalculator.CalculateTax(income);
        
        Assert.AreEqual(expectedTax, result.AnnualTaxPaid);
    }

    [TestMethod]
    public void CalculateTax_WhenIncomeIsAboveBandB_ShouldTaxAtFortyPercentForBandC()
    {
        
        var income = 12000;
        var expectedTax = 1800; 
        
        var result = TaxCalculator.CalculateTax(income);
        
        Assert.AreEqual(expectedTax, result.AnnualTaxPaid);
    }
}
