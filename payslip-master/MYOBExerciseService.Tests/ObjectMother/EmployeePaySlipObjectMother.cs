using MYOB.Payroll.Business.Models;
using System.Collections.Generic;

namespace MYOBExerciseService.Tests.ObjectMother
{
    public static class EmployeePaySlipObjectMother
    {

        public static EmployeeMonthlyPaySlip GetEmployeeMonthlyPaySlip(string firstName, string lastName, int annualSalary, int superRate, string paymentStartDate)
        {
            return new EmployeeMonthlyPaySlip
            {
                FirstName = firstName,
                LastName = lastName,
                AnnualSalary = annualSalary,
                SuperRate = superRate,
                PaymentStartDate = paymentStartDate
            };
        }

        public static List<EmployeeMonthlyPaySlip> GetEmployeesMonthlyPaySlip()
        {
            return GetEmployeesMonthlyPaySlip(
                GetEmployeeMonthlyPaySlip("Chun", "Wing", 98000, 30, "01 Jul - 31 Jul"),
                GetEmployeeMonthlyPaySlip("Hu", "Tui", 88000, 20, "01 Jun - 31 Jun"),
                GetEmployeeMonthlyPaySlip("Ram", "Rahim", 78000, 10, "01 Aug - 31 Aug"),
                GetEmployeeMonthlyPaySlip("Siva", "Ganesh", 58000, 40, "01 Sep - 31 Sep"),
                GetEmployeeMonthlyPaySlip("Ku", "Vij", 68000, 35, "01 Nov - 31 Nov"),
                GetEmployeeMonthlyPaySlip("Dan", "Kil", 48000, 39, "01 Jan - 31 Jan")
            );
        }

        public static List<EmployeeMonthlyPaySlip> GetEmployeesMonthlyPaySlip(params EmployeeMonthlyPaySlip[] employeesMonthlyPaySlip)
        {
            var _employeesMonthlyPaySlip = new List<EmployeeMonthlyPaySlip>();
            foreach (var employeeMonthlyPaySlip in employeesMonthlyPaySlip)
            {
                _employeesMonthlyPaySlip.Add(employeeMonthlyPaySlip);
            }
            return _employeesMonthlyPaySlip;
        }
    }
}
