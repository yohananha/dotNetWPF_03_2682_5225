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
            PrinterName =  "printer " + Convert.ToString(printNum++);
            this.printerNameLabel.Content = PrinterName;
            addInk();
            addPages();
        }  
        //Ink handling consts
        private const double MAX_INK = 100;
        private const double MIN_ADD_INK = 1;
        private const double MAX_PRINT_INK = 15;
        //Pages handling consts
        private const int MAX_PAGES = 400;
        private const int MIN_ADD_PAGES = 10;
        private const int MAX_PRINT_PAGES =40;

        public static  double MaxPages => MAX_PAGES;

        private string printerName;
        private double inkCount;
        private int pageCount;
        private static int printNum = 1;

        public static Random rnd = new Random();

        public event EventHandler<PrinterEventArgs> PageMissing;
        public event EventHandler<PrinterEventArgs> InkEmpty;

        public void Print()
        {
            double inkUse = rnd.Next((int)MIN_ADD_INK,(int)MAX_PRINT_INK);
            int pageUse = rnd.Next(MIN_ADD_PAGES,MAX_PRINT_PAGES);
            PageCount -= pageUse;
            this.pageCountSlider.Value = PageCount;
            InkCount -= inkUse;
            this.inkCountProgressBar.Value = InkCount;
            if (PageCount<=0)
            {
                pageLabel.Foreground = Brushes.Red;
                PrinterEventArgs noPages = new PrinterEventArgs(true, "Missing "+ Convert.ToString((PageCount*(-1)))+" Pages" , PrinterName);
                PageMissing(this, noPages);
            }
            if(InkCount<=15&&InkCount>10)
            {
                inkLabel.Foreground = Brushes.Yellow;
                PrinterEventArgs lowInk = new PrinterEventArgs(false, "Low ink, only " + Convert.ToString(InkCount) + "% ink remain.", printerName);
                InkEmpty(this, lowInk);
            }
            else if (InkCount<=10&&InkCount>0)
            {
                inkLabel.Foreground = Brushes.Orange;
                PrinterEventArgs veryLowInk = new PrinterEventArgs(false, "Very low ink, only " + Convert.ToString(InkCount) + "% ink remain.", printerName);
                InkEmpty(this, veryLowInk);
            }
            else if (inkCount<=0)
            {
                inkLabel.Foreground = Brushes.Red;
                PrinterEventArgs criticInk = new PrinterEventArgs(true, "No ink left. Please add ink", printerName);
                InkEmpty(this, criticInk);
            }
        }

        public void addInk()
        {
            InkCount = 0;
            InkCount += rnd.Next((int)MIN_ADD_INK, (int)MAX_INK);
            this.inkLabel.Foreground = Brushes.Black;
            this.inkCountProgressBar.Value = InkCount;
        }
        public void addPages()
        {
            PageCount = 0;
            PageCount += rnd.Next(MIN_ADD_PAGES, MAX_PAGES);
            this.pageLabel.Foreground = Brushes.Black;
            this.pageCountSlider.Value = PageCount;
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

        private void pageCountSlider_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            pageCountSlider.ToolTip = pageCountSlider.Value;
        }

      
    }
}