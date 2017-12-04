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
        public string PrinterName { get; set; }
        public double InkCount { get; set; }
        public int PageCount { get; set; }

        public PrinterUserControl()
        {
            InitializeComponent();
        }
        private double inkCount;


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
 
    }
}