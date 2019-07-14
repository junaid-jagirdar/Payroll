using MYOB.Payroll.Business.Models;
using MYOBExerciseUtilities.Exceptions;

namespace MYOB.Payroll.Business.Transformers
{
    public class TransformerFactory : ITransformerFactory
    {
        public ITransformer FetchTransformer(FileExtensionType fileExtensionType)
        {
            switch (fileExtensionType)
            {
                case FileExtensionType.DAT:
                    return new DATTransformer();

                case FileExtensionType.CSV:
                    return new CSVTransformer();

                default:
                    throw new FileTypeNotSupportedException();
            }
        }
    }
}
