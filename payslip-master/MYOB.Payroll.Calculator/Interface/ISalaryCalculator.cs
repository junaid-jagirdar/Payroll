namespace MYOB.Payroll.Calculator
{
    public interface ISalaryCalculator
    {
        SalaryDto CalculateSalary(decimal grossSalary, decimal superPercantage);
    }
}
