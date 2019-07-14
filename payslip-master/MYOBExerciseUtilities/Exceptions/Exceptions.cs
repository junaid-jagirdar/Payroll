using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOBExerciseUtilities.Exceptions
{
    public class MYOBExerciseException : Exception
    {
        public MYOBExerciseException()
        {

        }

        public MYOBExerciseException(string message) : base(message)
        {

        }
    }

    public class FileTypeNotSupportedException : MYOBExerciseException
    {
        private const string _exceptionMessage = "This file extension import is not supported!";
        public FileTypeNotSupportedException() : base(_exceptionMessage)
        {

        }

        public FileTypeNotSupportedException(string message) : base(message)
        {

        }

    }

    public class ImportFileInUseException : MYOBExerciseException
    {
        private const string _exceptionMessage = "The file used for upload is currently being used by another process";

        public ImportFileInUseException() : base(_exceptionMessage)
        {

        }
        public ImportFileInUseException(string message) : base(message)
        {

        }

    }

    public class EmptyFileUploadException : MYOBExerciseException
    {
        private const string _exceptionMessage = "Empty file uploaded! Please upload a valid file.";

        public EmptyFileUploadException() : base(_exceptionMessage)
        {

        }

        public EmptyFileUploadException(string message) : base(message)
        {

        }
    }

    public class InvalidFileFormatException : MYOBExerciseException
    {
        private const string _exceptionMessage = "Cannot process the file as it is not in the agreed format.";

        public InvalidFileFormatException() : base(_exceptionMessage)
        {

        }

        public InvalidFileFormatException(string message) : base(message)
        {

        }
    }
}
