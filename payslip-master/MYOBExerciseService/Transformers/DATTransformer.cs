using MYOB.Payroll.Business.Models;
using MYOBExerciseUtilities;
using MYOBExerciseUtilities.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MYOB.Payroll.Business.Transformers
{
    public class DATTransformer : BaseTransformer, ITransformer
    {
        public override List<EmployeeMonthlyPaySlip> Transform(StreamReader fileStream)
        {
            string line;
            var lineIndex = 1;
            var employeesMonthlyPaySlip = new List<EmployeeMonthlyPaySlip>();

            EmptyFileValidation(fileStream);

            while ((line = fileStream.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    throw new InvalidFileFormatException();

                line = line.Replace('\t', ' ');
                string[] columns = FormatLineToCSVSeperated(line);

                if (lineIndex == HEADER_LINE_INDEX)
                {
                    FileHeaderValidation(columns);
                    lineIndex++;
                    continue;
                }

                ColumnCountValidation(columns);

                var employeeMonthlyPaySlip = new EmployeeMonthlyPaySlip
                {
                    FirstName = columns[0].Trim(),
                    LastName = columns[1].Trim(),
                    AnnualSalary = columns[2].ToNumber("Annual Salary", lineIndex),
                    SuperRate = columns[3].ToNumber("Super Rate (%)", lineIndex),
                    PaymentStartDate = columns[4].Trim(),
                };
                employeesMonthlyPaySlip.Add(employeeMonthlyPaySlip);
                lineIndex++;
            }
            return employeesMonthlyPaySlip;
        }

        private string[] FormatLineToCSVSeperated(string line)
        {
            StringBuilder formattedLine = new StringBuilder();
            var columns = line.Split(DELIMITER);

            foreach (var column in columns)
            {
                if (!string.IsNullOrWhiteSpace(column))
                {
                    formattedLine.Append(column);
                    formattedLine.Append(DELIMITER);
                }
            }
            columns = formattedLine.ToString().TrimEnd(',').Split(DELIMITER);
            return columns;
        }
    }
}
