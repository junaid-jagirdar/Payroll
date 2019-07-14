using MYOBExerciseUtilities.Exceptions;
using System.Text.RegularExpressions;

namespace MYOBExerciseUtilities
{
    public static class Extensions
    {
        public static int ToNumber(this string value, string columnName, int rowNumber)
        {
            int number = 0;
            if (columnName == "Super Rate (%)")
            {
                string[] super = Regex.Split(value, @"%");
                foreach (string superPercentage in super)
                {
                    int superRate;
                    if (int.TryParse(superPercentage, out superRate))
                    { 
                        if (superRate >=0 && superRate <=50)
                        return superRate;
                        else
                        {
                            var errorMessage = "Super must be between 0% - 50%. Invalid value in column: " + columnName + " on Linenumber: " + rowNumber + ".";
                            throw new InvalidFileFormatException(errorMessage);
                        }
                    }                   
                    else
                    {
                        var errorMessage = "Invalid value in column: " + columnName + " on Linenumber: " + rowNumber + ".";
                        throw new InvalidFileFormatException(errorMessage);
                    }                        
                }

            }
            if (int.TryParse(value, out number))
                return number;
            else
            {
                var errorMessage = "Invalid value in column: " + columnName + " on Linenumber: " + rowNumber + ".";
                throw new InvalidFileFormatException(errorMessage);
            }
        }
    }
}
