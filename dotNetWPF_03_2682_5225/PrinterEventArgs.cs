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

        public bool IsCritic
        {
            get
            {
                return isCritic;
            }

            set
            {
                isCritic = value;
            }
        }

        public DateTime ErrorTime
        {
            get
            {
                return errorTime;
            }

            set
            {
                errorTime = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string PrinterName
        {
            get
            {
                return printerName;
            }

            set
            {
                printerName = value;
            }
        }

        public PrinterEventArgs(bool _isCritic, string _message, string _printerName )
        {
            IsCritic = _isCritic;
            ErrorTime = DateTime.Now;
            Message = _message;
            PrinterName = _printerName;
        }
    }
}
