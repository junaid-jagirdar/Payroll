using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOB.Payroll.Business.Models;
using MYOB.Payroll.Business.Transformers;
using MYOBExerciseUtilities.Exceptions;

namespace MYOBExerciseService.Tests.TransformerTests
{

    [TestClass]
    public class TransformerFactoryTests
    {
        private FileExtensionType _fileExtensionType;
        private ITransformerFactory _target;

        [TestInitialize]
        public void Init()
        {
            _target = new TransformerFactory();
        }

        [TestMethod]
        public void TransformerFactory_FetchTransformer_Returns_CSVTransformer_Instance_On_CSV_File_Upload()
        {
            //Arrange
            _fileExtensionType = FileExtensionType.CSV;

            //Act
            var result = _target.FetchTransformer(_fileExtensionType);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BaseTransformer));
            Assert.IsInstanceOfType(result, typeof(CSVTransformer));

        }

        [TestMethod]
        public void TransformerFactory_FetchTransformer_Returns_DATTransformer_Instance_On_DAT_File_Upload()
        {
            //Arrange
            _fileExtensionType = FileExtensionType.DAT;

            //Act
            var result = _target.FetchTransformer(_fileExtensionType);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BaseTransformer));
            Assert.IsInstanceOfType(result, typeof(DATTransformer));

        }

        [TestMethod]
        public void TransformerFactory_GetTransformer_Throws_FileTypeNotSupportedException_On_File_Upload_With_OTHER_Extension()
        {
            //Arrange
            _fileExtensionType = FileExtensionType.OTHER;

            //Act
            try
            {
                _target.FetchTransformer(_fileExtensionType);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(FileTypeNotSupportedException));
            }
        }
    }
}
