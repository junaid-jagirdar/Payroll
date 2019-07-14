using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Payroll.Calculator
{
    public interface ISuperCalculator
    {
        decimal CalculateSuper(decimal netIncome,decimal superPercentage);
    }
}
