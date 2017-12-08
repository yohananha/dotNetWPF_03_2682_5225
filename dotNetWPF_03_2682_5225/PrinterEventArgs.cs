using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetWPF_03_2682_5225
{
    public class PrinterEventArgs
    {
        private bool isCritic;
        private DateTime errorTime;
        private string message;
        private string printerName;

        public PrinterEventArgs(bool _isCritic, DateTime _errorTime, string _message, string _printerName )
        {
            isCritic = _isCritic;
            errorTime = _errorTime;
            message = _message;
            printerName = _printerName;
        }
    }
}
