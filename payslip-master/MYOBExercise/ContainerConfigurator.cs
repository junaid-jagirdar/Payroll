using Microsoft.Practices.Unity;
using MYOB.Payroll.Business;
using MYOB.Payroll.Business.Transformers;
using MYOB.Payroll.Calculator;

namespace MYOB.PayRoll.UI.UnityConfiguration
{
    internal static class MYOBExerciseUnityContainer
    {
        public static IUnityContainer Container;

        static MYOBExerciseUnityContainer()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
            }
        }

    }

    public static class MYOBExerciseContainerConfigurator
    {
        public static IUnityContainer MYOBExerciseContainer { get; set; }
        public static void RegisterDependencies()
        {
            MYOBExerciseContainer = MYOBExerciseUnityContainer.Container;

            MYOBExerciseContainer.RegisterType<IEmployeePaySlipService, EmployeePaySlipService>();
            MYOBExerciseContainer.RegisterType<ITransformerFactory, TransformerFactory>();
            MYOBExerciseContainer.RegisterType<IOutputWriter, OutputWriter>();
            MYOBExerciseContainer.RegisterType<ISalaryCalculator, SalaryCalculator>();
            MYOBExerciseContainer.RegisterType<ITaxCalaculator, TaxCalculator>();
            MYOBExerciseContainer.RegisterType<ISuperCalculator, SuperCalculator>();

        }
    }
}
