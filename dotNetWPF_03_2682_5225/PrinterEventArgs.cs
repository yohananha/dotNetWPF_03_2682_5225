using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetWPF_03_2682_5225
{
    class PrinterEventArgs
    {
        private bool isCretic;
        private DateTime date;
        private string masg;
        private string printerName;

        public PrinterEventArgs(bool i, DateTime d, string m, string p)
        {
            isCretic = i;
            date = d;
            masg = m;
            printerName = p;
        }
    }
}
