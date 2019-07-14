using System.IO;
using Moq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOBExerciseService.Tests.ObjectMother;
using MYOB.Payroll.Business;
using MYOB.Payroll.Business.Transformers;
using MYOB.Payroll.Business.Models;
using MYOB.Payroll.Calculator;

namespace MYOBExerciseService.Tests.ServiceTests
{
    [TestClass]
    public class EmployeePaySlipServiceTests
    {
        private EmployeePaySlipService _target;
        private Mock<ITransformer> _transformer;
        private Mock<ITransformerFactory> _transformerFactory;
        private Mock<ISalaryCalculator> _salaryCalculator;

        [TestInitialize]
        public void Init()
        {
            _transformer = new Mock<ITransformer>();
            _transformerFactory = new Mock<ITransformerFactory>();
            _salaryCalculator = new Mock<ISalaryCalculator>();

            _transformer.Setup(x => x.Transform(It.IsAny<StreamReader>()))
                .Returns(EmployeePaySlipObjectMother.GetEmployeesMonthlyPaySlip());
            _transformerFactory.Setup(x => x.FetchTransformer(It.IsAny<FileExtensionType>())).Returns(_transformer.Object);
            _salaryCalculator.Setup(x => x.CalculateSalary(It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(new MYOB.Payroll.Calculator.SalaryDto { GrossSalary=5004, IncomeTax=182, NetIncome=5008, Super=422 });
            _target = new EmployeePaySlipService(_transformerFactory.Object, _salaryCalculator.Object);

        }

        [TestMethod]
        public void EmployeePaySlipService_GetOutputPaySlip_Returns_Right_Result_On_CSV_Upload()
        {
            //Arrange

            //Act
            var result = _target.GetEmployeesPaySlip(It.IsAny<StreamReader>(), FileExtensionType.CSV);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<EmployeeMonthlyPaySlip>));
            Assert.IsTrue((result as List<EmployeeMonthlyPaySlip>).Count > 0);
        }

        [TestMethod]
        public void EmployeePaySlipService_GetOutputPaySlip_Returns_Right_Result_On_DAT_Upload()
        {
            //Arrange

            //Act
            var result = _target.GetEmployeesPaySlip(It.IsAny<StreamReader>(), FileExtensionType.DAT);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<EmployeeMonthlyPaySlip>));
            Assert.IsTrue((result as List<EmployeeMonthlyPaySlip>).Count > 0);
        }

        [TestMethod]
        public void EmployeePaySlipService_GetOutputPaySlip_Returns_Count_Zero_On_Empty_CSV_File_Upload()
        {
            //Arrange
            _transformer.Setup(x => x.Transform(It.IsAny<StreamReader>())).Returns(new List<EmployeeMonthlyPaySlip>());

            //Act
            var result = _target.GetEmployeesPaySlip(null, FileExtensionType.CSV);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<EmployeeMonthlyPaySlip>));
            Assert.IsTrue((result as List<EmployeeMonthlyPaySlip>).Count == 0);
        }

        [TestMethod]
        public void EmployeePaySlipService_GetOutputPaySlip_Returns_Count_Zero_On_Empty_DAT_File_Upload()
        {
            //Arrange
            _transformer.Setup(x => x.Transform(It.IsAny<StreamReader>())).Returns(new List<EmployeeMonthlyPaySlip>());

            //Act
            var result = _target.GetEmployeesPaySlip(null, FileExtensionType.DAT);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<EmployeeMonthlyPaySlip>));
            Assert.IsTrue((result as List<EmployeeMonthlyPaySlip>).Count == 0);
        }
    }
}
