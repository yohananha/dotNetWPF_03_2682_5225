using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNetWPF_03_2682_5225
{
    /// <summary>
    /// Interaction logic for PrinterUserControl.xaml
    /// </summary>
    public partial class PrinterUserControl : UserControl
    {
 
        public PrinterUserControl()
        {
            InitializeComponent();
            PrinterName = "printer" + Convert.ToString(printNum++);
        }
        static Random r = new Random();

        private const double MAX_INK = 100;
        private const double MIN_ADD_INK = 10.0;
        private const double MAX_PRINT_INK = 70;

        private const int MIN_ADD_PAGES = 10;
        private const int MAX_PRINT_PAGES = 300;

        private string printerName;
        private double inkCount;
        private int pageCount;
        private static int printNum = 1;
        

        private void printerNameLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            printerNameLabel.FontSize *= 2;
        }

        private void printerNameLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            printerNameLabel.FontSize /= 2;
        }

        private void inkCountProgressBar_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            inkCountProgressBar.ToolTip = inkCountProgressBar.Value;
        }
        EventHandler<PrinterEventArgs> PageMissing;
        EventHandler<PrinterEventArgs> InkEmpty;

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

        public double InkCount
        {
            get
            {
                return inkCount;
            }

            set
            {
                inkCount = value;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                pageCount = value;
            }
        }

        public void print()
        {
            InkCount -= r.Next((int)MIN_ADD_INK, (int)MIN_ADD_INK);
            PageCount -= r.Next(MIN_ADD_PAGES, MIN_ADD_PAGES);
            if (0 > PageCount)
            {
                pageLabel.Foreground = Brushes.Red;
                PrinterEventArgs p = new PrinterEventArgs(true, DateTime.Now, "page miss", PrinterName);
                PageMissing(this, p);
            }
            if(InkCount>=10 && InkCount <= 15)
            {
                inkLabel.Foreground = Brushes.Yellow;
                PrinterEventArgs p = new PrinterEventArgs(false, DateTime.Now, "Ink miss", PrinterName);
                InkEmpty(this, p);
            }
            if (InkCount >= 1 && InkCount <= 10)
            {
                inkLabel.Foreground = Brushes.Orange;
                PrinterEventArgs p = new PrinterEventArgs(false, DateTime.Now, "Ink miss", PrinterName);
                InkEmpty(this, p);
            }
            if (InkCount >= 0)
            {
                inkLabel.Foreground = Brushes.Red;
                PrinterEventArgs p = new PrinterEventArgs(true, DateTime.Now, "Ink miss", PrinterName);
                InkEmpty(this, p);
            }
        }
    }
}