using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Payroll.Calculator
{
    public class TaxRate
    {
        public decimal Percentage { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal BaseTax { get; set; }

        public TaxRate(decimal minAmount, decimal maxAmount, decimal baseTax, decimal percentage)
        {
            Percentage = percentage;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            BaseTax = baseTax;
        }

    }



}
