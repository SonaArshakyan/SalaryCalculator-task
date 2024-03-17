using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Server.services;

namespace SalaryCalculator.Server.controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    public SalaryController()
    {
    }

    [HttpPost("calculate")]
    public IActionResult CalculateSalary([FromBody] double grossAnnualSalary)
    {
        try
        {
            var result = TaxCalculator.CalculateTax(grossAnnualSalary);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
