using MYOB.Payroll.Business.Models;
using MYOBExerciseUtilities.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MYOB.Payroll.Business.Transformers
{
    public abstract class BaseTransformer : ITransformer
    {
        //TODO
        //Read all constants frm config
        protected const int HEADER_LINE_INDEX = 1;
        protected const int FILE_COLUMN_COUNT = 5;
        protected const char DELIMITER = ',';
        protected string[] expectedColumnHeaders = new string[] { "First Name", "Last Name", "Annual Salary", "Super Rate (%)", "Payment Start Date" };


        protected virtual void EmptyFileValidation(StreamReader fileStream)
        {
            if (fileStream.Peek() <= 0)
                throw new EmptyFileUploadException();
        }

        protected virtual void FileHeaderValidation(string[] headerColumns)
        {
            ColumnCountValidation(headerColumns);
            HeaderColumnSequenceValidation(headerColumns);
        }

        protected virtual void ColumnCountValidation(string[] columns, int columnCount = FILE_COLUMN_COUNT)
        {
            if (columns != null)
            {
                if (columns.Length > columnCount)
                    throw new InvalidFileFormatException("File has more columns than the standarad format. Cannot process the file.");
                if (columns.Length < columnCount)
                    throw new InvalidFileFormatException("File has lesser columns than the standarad format. Cannot process the file.");
            }
        }

        protected virtual void HeaderColumnSequenceValidation(string[] headerColumns)
        {
            if (headerColumns == null)
                throw new InvalidFileFormatException("File has an empty row. Cannot process the file.");
            var errorList = new StringBuilder();
            int i = 0;
            for (i = 0; i < FILE_COLUMN_COUNT; i++)
            {
                if (headerColumns[i].ToUpperInvariant() != expectedColumnHeaders[i].ToUpperInvariant())
                {
                    errorList.Append(headerColumns[i]);
                    errorList.Append(", ");
                }
            }
            if (!string.IsNullOrWhiteSpace(errorList.ToString()))
            {
                errorList.ToString().TrimStart(',', ' ');
                errorList.ToString().TrimEnd(',', ' ');
                throw new InvalidFileFormatException("The columns " + errorList.ToString() + " are incorrect or not in correct sequence.");
            }
        }

        public abstract List<EmployeeMonthlyPaySlip> Transform(StreamReader fileStream);
        
    }
}
