using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Payroll.Calculator
{
     public interface ITaxCalaculator
    {
        decimal CalculateTax(decimal grossSalary);
    }
}
