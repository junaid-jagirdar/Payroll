using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.Payroll.Business.Models
{
    public class EmployeeMonthlyPaySlip
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualSalary { get; set; }
        public int SuperRate { get; set; }
        public string PaymentStartDate { get; set; }
        public Salary Salary { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string PayPeriod
        {
            get
            {
                return PaymentStartDate;
            }
        }

    }
}
