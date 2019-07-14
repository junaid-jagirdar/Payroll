using System;

namespace MYOB.Payroll.Calculator
{
    public class SalaryCalculator: ISalaryCalculator
    {

        private readonly ITaxCalaculator _taxCalaculator;
        private readonly ISuperCalculator _superCalaculator;


        public SalaryCalculator(ITaxCalaculator taxCalaculator,ISuperCalculator superCalculator)
        {
            _taxCalaculator = taxCalaculator;
            _superCalaculator = superCalculator;
        }

        public SalaryDto CalculateSalary(decimal annualSalary,decimal superPercantage)
        {
            SalaryDto salary = new SalaryDto();
            var grossMonthlySalary = Math.Round(annualSalary / 12, MidpointRounding.AwayFromZero);
            salary.IncomeTax = _taxCalaculator.CalculateTax(grossMonthlySalary);
            var netIncome = grossMonthlySalary - salary.IncomeTax;
            salary.Super = _superCalaculator.CalculateSuper(netIncome, superPercantage);
            salary.NetIncome = Math.Round(netIncome, MidpointRounding.AwayFromZero);
            salary.GrossSalary = grossMonthlySalary;
            return salary;
        }

  
    }
}
