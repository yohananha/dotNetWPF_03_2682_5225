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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrinterUserControl CurrentPrinter;
        Queue<PrinterUserControl> queue;

        public MainWindow()
        {
            InitializeComponent();
           
            queue = new Queue<PrinterUserControl>();
            

            foreach (Control item in printersGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    printer.PageMissing += pageMissingFunc;
                    printer.InkEmpty += inkEmptyFunc;
                    queue.Enqueue(printer);
                }
            }
            CurrentPrinter = queue.Dequeue();
        }

        private void inkEmptyFunc(object sender, PrinterEventArgs e)
        {
            MessageBox.Show("at:" + e.ErrorTime + "\nMessage from printer:" + e.Message, e.PrinterName + " Ink Missing!!!!!!");
        }

        private void pageMissingFunc(object sender, PrinterEventArgs e)
        {
            MessageBox.Show("at:" + e.ErrorTime + "\nMessage from printer:" + e.Message ,e.PrinterName + " Page Missing!!!!!!");
            queue.Enqueue(CurrentPrinter);
            CurrentPrinter = queue.Dequeue();
        }
    }
}
