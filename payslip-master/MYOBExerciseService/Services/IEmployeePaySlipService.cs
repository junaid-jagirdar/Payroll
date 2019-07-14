using MYOB.Payroll.Business.Models;
using System.Collections.Generic;
using System.IO;

namespace MYOB.Payroll.Business
{
    public interface IEmployeePaySlipService
    {
        List<EmployeeMonthlyPaySlip> GetEmployeesPaySlip(StreamReader fileStream, FileExtensionType fileExtensionType);
    }
}
