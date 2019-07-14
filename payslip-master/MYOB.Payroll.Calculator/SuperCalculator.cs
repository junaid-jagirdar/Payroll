using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Payroll.Calculator
{ 
    public class SuperCalculator : ISuperCalculator
    {
        public decimal CalculateSuper(decimal netIncome, decimal superPercentage)
        {
            var superAmount = netIncome * (superPercentage / 100);
            return Math.Round(superAmount, MidpointRounding.AwayFromZero);
        }
    }
}
