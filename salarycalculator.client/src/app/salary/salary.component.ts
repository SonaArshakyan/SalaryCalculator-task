import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


interface SalaryDetails {
  GrossAnnualSalary: number;
  GrossMonthlySalary: number;
  NetAnnualSalary: number;
  NetMonthlySalary: number;
  AnnualTaxPaid: number;
  MonthlyTaxPaid: number;
}


@Component({
  selector: 'app-salary',
  templateUrl: './salary.component.html',
  styleUrls: ['./salary.component.css']
})


export class SalaryComponent {
  grossSalaryControl = new FormControl('', [Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]);
  public salaryDetails: SalaryDetails | null = null;
  loading = false;

  constructor(private http: HttpClient) { }



  calculateSalary(): void {
    if (this.grossSalaryControl.invalid || this.loading) return;

    this.loading = true;
    const url = 'https://localhost:7015/api/Salary/calculate';

    let salary = Number(this.grossSalaryControl.value);
    this.http.post<any>(url, salary).subscribe(
      (response) => {
        if (response && response.result) {
          this.salaryDetails = {
            GrossAnnualSalary: response.result.grossAnnualSalary,
            GrossMonthlySalary: response.result.grossMonthlySalary,
            NetAnnualSalary: response.result.netAnnualSalary,
            NetMonthlySalary: response.result.netMonthlySalary,
            AnnualTaxPaid: response.result.annualTaxPaid,
            MonthlyTaxPaid: response.result.monthlyTaxPaid
          };
        }
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}
