using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetWPF_03_2682_5225
{
    public class PrinterEventArgs
    {
        //private bool isCritic;
        //private string message;
        //private string printerName;

        public bool IsCritic { get; set; }

        public DateTime ErrorTime { get; set; }

        public string Message { get; set; }

        public string PrinterName { get; set; }

        public PrinterEventArgs(bool isCritic, string message, string printerName)
        {
            PrinterName = printerName;
            Message = message;
            ErrorTime = DateTime.Now;
            IsCritic = isCritic;
        }
    }
}
