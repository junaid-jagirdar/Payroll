using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace MYOB.Payroll.Calculator.Tests
{
    [TestClass]
    public class TaxCalculatorTests
    {
        [TestMethod]
        public void Should_Be_Zero_Tax_When_Income_Is_Not_In_Tax_Bracket()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(18200);
            tax.ShouldEqual(0);
        }

        [TestMethod]
        public void Should_Be_Caclulated_According_To_19_Percent_Rule_Tax_When_Income_Is_18001_Lower_EdgeCase()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(18201);
            tax.ShouldEqual(0);
        }
        [TestMethod]
        public void Should_Be_Caclulated_According_To_19_Percent_Rule_Tax_When_Income_Is_37000_Higher_EdgeCase()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(37000);
            tax.ShouldEqual(298);
        }
        [TestMethod]
        public void Should_Be_Caclulated_According_To_19_Percent_Rule_Tax_When_Income_Is_Between_18000_And_37000()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(30000);
            tax.ShouldEqual(187);
        }

        [TestMethod]
        public void Should_Be_Caclulated_According_To_32_Percent_Tax_Rule_When_Income_Is_Between_37000_And_8700()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax =calculator.CalculateTax(60050);
            tax.ShouldEqual(922);
        }

        [TestMethod]
        public void Should_Be_Caclulated_According_To_37_Percent_Tax_Rule_When_Income_Is_Between_87000_And_180000()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(90000);
            tax.ShouldEqual(1771);
        }

        [TestMethod]
        public void Should_Be_Caclulated_According_To_45_Percent_Tax_Rule_When_Income_Is_Above_180000()
        {
            TaxCalculator calculator = new TaxCalculator();
            var tax = calculator.CalculateTax(189000);
            tax.ShouldEqual(4883);
        }
    }
}
