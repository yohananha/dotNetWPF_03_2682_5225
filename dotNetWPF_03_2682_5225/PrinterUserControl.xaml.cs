using System;
using System.Collections.Generic;
using System.Globalization;
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
            PrinterName =  "printer" + Convert.ToString(printNum++);
            InitializeComponent();
        }  
        //Ink handling consts
        private const double MAX_INK = 100;
        private const double MIN_ADD_INK = MAX_INK/10.0;
        private const double MAX_PRINT_INK = 70;
        //Pages handling consts
        private const int MAX_PAGES = 400;
        private const int MIN_ADD_PAGES = MAX_PAGES/10;
        private const int MAX_PRINT_PAGES =300;

        private static string printerName;
        private static double inkCount;
        private static int pageCount;
        private static int printNum = 1;
        static Random rnd = new Random();

        //public delegate void EventHandler<PrinterEventArgs> PageMissing();

        //protected delegate void EventHandler<PrinterEventArgs> InkEmpty();

        public static event EventHandler<PrinterEventArgs> PageMissing;
        public static event EventHandler<PrinterEventArgs> InkEmpty; 

        public static void print()
        {
            double inkUse = rnd.Next((int)MIN_ADD_INK,(int)MAX_PRINT_INK);
            int pageUse = rnd.Next(MIN_ADD_PAGES,MAX_PRINT_PAGES);
            PageCount -= pageUse;
            if (PageCount>=0)
            {
                pageLabel.Foreground = Brushes.Red;
                PrinterEventArgs noPages = new PrinterEventArgs(true, DateTime.Now, "Missing "+ Convert.ToString((PageCount*(-1)))+" Pages" , PrinterName);
                if (PageMissing != null) PageMissing(this, noPages);
            }
            InkCount -= inkUse;
            if(InkCount<=15&&InkCount>10)
            {
                inkLabel.Foreground = Brushes.Yellow;
                PrinterEventArgs lowInk = new PrinterEventArgs(false, DateTime.Now, "Low ink, only " + Convert.ToString(InkCount, CultureInfo.InvariantCulture) + "% ink remain.", printerName);
                if (InkEmpty != null) InkEmpty(this, lowInk);
            }
            else if (InkCount<=10&&InkCount>0)
            {
                inkLabel.Foreground = Brushes.Orange;
                PrinterEventArgs veryLowInk = new PrinterEventArgs(false, DateTime.Now, "Very low ink, only " + Convert.ToString(InkCount, CultureInfo.CurrentCulture) + "% ink remain.", printerName);
                if (InkEmpty != null) InkEmpty(this, veryLowInk);
            }
            else if (inkCount<=0)
            {
                inkLabel.Foreground = Brushes.Red;
                PrinterEventArgs criticInk = new PrinterEventArgs(true, DateTime.Now, "No ink left. Please add ink", printerName);
                if (InkEmpty != null) InkEmpty(this, criticInk);
            }
        }


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

        public static double InkCount
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

        public static int PageCount
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
    }
}