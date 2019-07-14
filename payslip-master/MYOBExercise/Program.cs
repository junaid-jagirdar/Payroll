using Microsoft.Practices.Unity;
using MYOB.Payroll.Business;
using MYOB.PayRoll.UI.UnityConfiguration;
using System;
using System.Windows.Forms;

namespace MYOB.PayRoll.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MYOBExerciseContainerConfigurator.RegisterDependencies();
            var employeePaySlipService = MYOBExerciseContainerConfigurator.MYOBExerciseContainer.Resolve<IEmployeePaySlipService>();
            var outputFileWriter = MYOBExerciseContainerConfigurator.MYOBExerciseContainer.Resolve<IOutputWriter>();
            Application.Run(new MYOBExercise(employeePaySlipService, outputFileWriter));
        }
    }
}
