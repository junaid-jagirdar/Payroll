using MYOB.Payroll.Business.Models;
using System.Collections.Generic;
using System.IO;

namespace MYOB.Payroll.Business.Transformers
{
    public interface ITransformer
    {
        List<EmployeeMonthlyPaySlip> Transform(StreamReader fileStream);
    }
}
