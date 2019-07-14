using MYOB.Payroll.Business;
using MYOB.Payroll.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace MYOB.PayRoll.UI
{
    public partial class MYOBExercise : Form
    {
        private IEmployeePaySlipService _employeePaySlipService;
        private IOutputWriter _outputFileWriter;

        public MYOBExercise(IEmployeePaySlipService employeePaySlipService, IOutputWriter outputFileWriter)
        {
            InitializeComponent();
            _employeePaySlipService = employeePaySlipService;
            _outputFileWriter = outputFileWriter;
        }

        private void buttonFileBrowse_Click(object sender, EventArgs e)
        {
            ResetControls();
            List<EmployeeMonthlyPaySlip> employeesMonthlyPaySlip;
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to import.";
                openFileDialog.Filter = "CSV or Data files|*.dat;*.csv";
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileExtension = Path.GetExtension(openFileDialog.FileName);
                        var fileExtensionType = GetFileExtensionType(fileExtension);
                        
                            using (var fileStream = new StreamReader(openFileDialog.OpenFile()))
                            {
                                employeesMonthlyPaySlip = _employeePaySlipService.GetEmployeesPaySlip(fileStream, fileExtensionType);
                            }

                            if (employeesMonthlyPaySlip != null && employeesMonthlyPaySlip.Any())
                            {
                                _outputFileWriter.Write(employeesMonthlyPaySlip);
                            }
                        }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                    //log messages
                }
            }

        }

        private FileExtensionType GetFileExtensionType(string fileExtension)
        {
            switch (fileExtension.ToUpperInvariant())
            {
                case ".CSV":
                    return FileExtensionType.CSV;
                case ".DAT":
                    return FileExtensionType.DAT;
                default:
                    return FileExtensionType.OTHER;
            }
        }

        private void ShowErrorMessage(string message)
        {
            labelErrorMessage.Text = message;
        }

        private void ResetControls()
        {
            labelErrorMessage.Text = string.Empty;
        }
    }
}
