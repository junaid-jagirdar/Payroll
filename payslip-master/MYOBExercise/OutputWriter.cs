using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using MYOB.Payroll.Business.Models;

namespace MYOB.PayRoll.UI
{
    public class OutputWriter : IOutputWriter
    {
        public void Write(List<EmployeeMonthlyPaySlip> employeesMonthlyPaySlip)
        {
            string outputFilePath = ConfigurationManager.AppSettings["outputfilepath"];
            string myFileName = String.Format("{0}__{1}", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), "OutputFile.txt");
            string myFullPath = Path.Combine(outputFilePath, myFileName);
            using (var w = new StreamWriter(myFullPath))
            {
                var header1 = "name";
                var header2 = "pay period";
                var header3 = "gross income";
                var header4 = "income tax";
                var header5 = "net income";
                var header6 = "super";
                var headerLine = string.Format("{0},{1},{2},{3},{4},{5}", header1, header2, header3, header4, header5, header6);
                w.WriteLine(headerLine);
                w.Flush();

                foreach (var employeeMonthlyPaySlip in employeesMonthlyPaySlip)
                {
                    var name = employeeMonthlyPaySlip.Name;
                    var payPeriod = employeeMonthlyPaySlip.PayPeriod;
                    var grossIncome = employeeMonthlyPaySlip.Salary.GrossSalary;
                    var incomeTax = employeeMonthlyPaySlip.Salary.IncomeTax;
                    var netIncome = employeeMonthlyPaySlip.Salary.NetIncome;
                    var super = employeeMonthlyPaySlip.Salary.Super;
                    var line = string.Format("{0},{1},{2},{3},{4},{5}", name, payPeriod, grossIncome, incomeTax, netIncome, super);
                    w.WriteLine(line);
                    w.Flush();
                }
                MessageBox.Show("Output file has been created successfully and placed at C:\\MYOBExercise");
            }
        }
    }
}
