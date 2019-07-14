using MYOB.Payroll.Business.Models;
using MYOB.Payroll.Business.Transformers;
using MYOB.Payroll.Calculator;
using System;
using System.Collections.Generic;
using System.IO;

namespace MYOB.Payroll.Business
{
    public class EmployeePaySlipService : IEmployeePaySlipService
    {
       
        private readonly ITransformerFactory _transformerfactory;
        private readonly ISalaryCalculator _salaryCalculator;
        private ITransformer _transformer;

        public EmployeePaySlipService(ITransformerFactory transformerfactory, ISalaryCalculator salaryCalculator)
        {
            _transformerfactory = transformerfactory;
            _salaryCalculator = salaryCalculator;
        }

        public List<EmployeeMonthlyPaySlip> GetEmployeesPaySlip(StreamReader fileStream, FileExtensionType fileExtensionType)
        {
            try
            {
                _transformer = _transformerfactory.FetchTransformer(fileExtensionType);
                var employeesMonthlyPaySlip = _transformer.Transform(fileStream);
                foreach (var employee in employeesMonthlyPaySlip)
                {
                    var salary = _salaryCalculator.CalculateSalary(employee.AnnualSalary,employee.SuperRate);
                    employee.Salary = new Salary()
                    {
                        GrossSalary = salary.GrossSalary,
                        IncomeTax = salary.IncomeTax,
                        NetIncome = salary.NetIncome,
                        Super = salary.Super
                    };
                   
                }

                return employeesMonthlyPaySlip;
            }
            catch (Exception)
            {
                throw;
                //log messages
            }
        }
    }
}
