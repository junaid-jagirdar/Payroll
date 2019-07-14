using MYOB.Payroll.Business.Models;
using System.Collections.Generic;

namespace MYOB.PayRoll.UI
{
    public interface IOutputWriter
    {
        void Write(List<EmployeeMonthlyPaySlip> employeesMonthlyPaySlip);
    }
}
