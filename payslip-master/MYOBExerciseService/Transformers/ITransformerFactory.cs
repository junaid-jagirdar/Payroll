using MYOB.Payroll.Business.Models;
using MYOB.Payroll.Business.Transformers;

namespace MYOB.Payroll.Business.Transformers
{
    public interface ITransformerFactory
    {
        ITransformer FetchTransformer(FileExtensionType fileExtensionType);
    }
}
