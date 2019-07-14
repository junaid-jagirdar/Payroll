using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOBExerciseUtilities.Exceptions;
using MYOB.Payroll.Business.Transformers;
using MYOB.Payroll.Business.Models;

namespace MYOBExerciseService.Tests.TransformerTests
{
    [TestClass]
    public class CSVTransformerTests
    {
        private CSVTransformer _target;
        private string currentWorkingDirectoryPath;
        private StreamReader _validCSVStreamReader;
        private string _validCSVFilePath;
        private string _invalidEmptyCSVFilePath;
        private string _invalidCSVColumnsInterchangedFilePath;
        private string _invalidCSVEmptyRownInBetweenFilePath;
        private string _invalidCSVExtraColumnsFilePath;
        private string _invalidCSVWithInCorrectDataFilePath;
        private string _invalidCSVLesserColumnsFilePath;
        private string _invalidCSVWithWrongHeaderFilePath;

        [TestInitialize]
        public void Init()
        {
            currentWorkingDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            _validCSVFilePath = currentWorkingDirectoryPath + @"\TestData\CorrectDataAndFormat\CSVInputFile.csv";
            _invalidEmptyCSVFilePath = currentWorkingDirectoryPath + @"\TestData\EmptyFiles\EmptyFile.csv";
            _invalidCSVColumnsInterchangedFilePath = currentWorkingDirectoryPath + @"\TestData\ColumnsInterchanged\CSVInputFileColumnInterchanged.csv";
            _invalidCSVEmptyRownInBetweenFilePath = currentWorkingDirectoryPath + @"\TestData\EmptyRows\CSVInputFileHavingEmptyRowsInBetween.csv";
            _invalidCSVExtraColumnsFilePath = currentWorkingDirectoryPath + @"\TestData\ExtraColumns\CSVInputFileHavingExtraColumns.csv";
            _invalidCSVWithInCorrectDataFilePath = currentWorkingDirectoryPath + @"\TestData\IncorrectData\CSVInputFileInCorrectData.csv";
            _invalidCSVLesserColumnsFilePath = currentWorkingDirectoryPath + @"\TestData\LesserColumns\CSVInputFileWithLesserColumns.csv";
            _invalidCSVWithWrongHeaderFilePath = currentWorkingDirectoryPath + @"\TestData\WrongColumnHeaders\CSVInputFileWrongColumnHeaders.csv";

            _target = new CSVTransformer();
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Returns_List_Of_EmployeesMonthlyPaySlip_On_Valid_CSV_Import()
        {
            using (_validCSVStreamReader = new StreamReader(_validCSVFilePath))
            {
                var result = _target.Transform(_validCSVStreamReader);

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<EmployeeMonthlyPaySlip>));
                Assert.IsTrue((result as List<EmployeeMonthlyPaySlip>).Count > 0);
            }
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_An_Exception_On_Uploading_Empty_CSV_File()
        {
            //Arrange
            using (var emptyFileStream = new StreamReader(_invalidEmptyCSVFilePath))
            {
                try
                {
                    //Act
                    _target.Transform(emptyFileStream);
                }
                catch (Exception ex)
                {
                    //Assert
                    Assert.IsInstanceOfType(ex, typeof(EmptyFileUploadException));
                }
            }
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_An_Exception_With_Invalid_Column_Names_On_Uploading_A_CSV_File_With_Headers_In_Wrong_Sequence()
        {
            var expectedExceptionMessage = "The columns last name, first name,  are incorrect or not in correct sequence.";
            try
            {
                using (var inCorrectColumnFileStream = new StreamReader(_invalidCSVColumnsInterchangedFilePath))
                {
                    _target.Transform(inCorrectColumnFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_An_Exception_With_Row_number_On_Uploading_A_CSV_File_With_Empty_Rows_InBetween()
        {
            var expectedExceptionMessage = "Cannot process the file as it is not in the agreed format.";
            try
            {
                using (var emptyRowsInBetweenFileStream = new StreamReader(_invalidCSVEmptyRownInBetweenFilePath))
                {
                    _target.Transform(emptyRowsInBetweenFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_An_Exception_On_Uploading_A_CSV_File_With_Extra_Columns()
        {
            var expectedExceptionMessage = "File has more columns than the standarad format. Cannot process the file.";
            try
            {
                using (var extraColumnsFileStream = new StreamReader(_invalidCSVExtraColumnsFilePath))
                {
                    _target.Transform(extraColumnsFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }        

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_An_Exception_With_Row_number_On_Uploading_A_CSV_File_With_InCorrect_Data()
        {
            var expectedExceptionMessage = "Invalid value in column: super rate (%) on Linenumber: 2.";
            try
            {
                using (var inCorrectDataFileStream = new StreamReader(_invalidCSVWithInCorrectDataFilePath))
                {
                    _target.Transform(inCorrectDataFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }

        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_A_File_Format_Exception_On_Uploading_A_CSV_File_With_Lesser_Columns_Than_Standard_Format()
        {
            var expectedExceptionMessage = "File has lesser columns than the standarad format. Cannot process the file.";
            try
            {
                using (var lesserColumnFileStream = new StreamReader(_invalidCSVLesserColumnsFilePath))
                {
                    _target.Transform(lesserColumnFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }

        
        [TestMethod]
        public void CSVTransformer_Transform_Method_Throws_A_File_Format_Exception_On_Uploading_A_CSV_File_With_Header_Values_Other_Than_Standard_Format()
        {
            var expectedExceptionMessage = "The columns Given name, Sur name, Gross salary, super, payment Month,  are incorrect or not in correct sequence.";
            try
            {
                using (var wrongHeaderFileStream = new StreamReader(_invalidCSVWithWrongHeaderFilePath))
                {
                    _target.Transform(wrongHeaderFileStream);
                }

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidFileFormatException));
                Assert.IsTrue(ex.Message.ToUpperInvariant() == expectedExceptionMessage.ToUpperInvariant());
            }
        }


    }
}
