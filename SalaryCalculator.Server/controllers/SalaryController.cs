using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Server.services;

namespace SalaryCalculator.Server.controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private  ITaxCalculator taxCalculator;
    public SalaryController(ITaxCalculator taxCalculator)
    {
        this.taxCalculator = taxCalculator;
    }

    [HttpPost("calculate")]
    public IActionResult CalculateSalary([FromBody] decimal grossAnnualSalary)
    {
        try
        {
            var result = taxCalculator.CalculateSalaryDetails(grossAnnualSalary);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
