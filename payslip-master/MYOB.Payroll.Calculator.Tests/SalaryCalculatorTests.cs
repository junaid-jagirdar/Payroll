using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;

namespace MYOB.Payroll.Calculator.Tests
{
    [TestClass]
    public class SalaryCalculatorTests
    {
        private Mock<ITaxCalaculator> _mockTaxCalculator;
        private Mock<ISuperCalculator> _mockSuperCalculator;
        [TestInitialize]
        public void Initialize()
        {
            _mockTaxCalculator = new Mock<ITaxCalaculator>();
            _mockSuperCalculator = new Mock<ISuperCalculator>();
          
        }

        [TestMethod]
        public void Should_Be_Correct_Super_Amount_According_To_Super_Percentage()
        {
            SuperCalculator calculator = new SuperCalculator();
            var super = calculator.CalculateSuper(5004, 9);
            super.ShouldEqual(450);
        }

        [TestMethod]
        public void Should_Be_Correct_Net_Salary()
        {
            _mockTaxCalculator.Setup(t => t.CalculateTax(It.IsAny<decimal>())).Returns(922);
            _mockSuperCalculator.Setup(t => t.CalculateSuper(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(450);
            SalaryCalculator calculator = new SalaryCalculator(_mockTaxCalculator.Object, _mockSuperCalculator.Object);
            var salary = calculator.CalculateSalary(60050, 9);
            salary.NetIncome.ShouldEqual(4082);         
        }

        [TestMethod]
        public void Should_Be_Correct_Monthly_Gross_Salary()
        {
            _mockTaxCalculator.Setup(t => t.CalculateTax(It.IsAny<decimal>())).Returns(922);
            _mockSuperCalculator.Setup(t => t.CalculateSuper(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(450);
            SalaryCalculator calculator = new SalaryCalculator(_mockTaxCalculator.Object, _mockSuperCalculator.Object);
            var salary = calculator.CalculateSalary(60050, 9);
            salary.GrossSalary.ShouldEqual(5004);
        }
    }
}
