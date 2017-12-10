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
        public MainWindow()
        {
            InitializeComponent();
            PrinterUserControl CurrentPrinter;
            Queue<PrinterUserControl> queue;

            queue = new Queue<PrinterUserControl>();
            foreach(Control item in printersGrid.Children)
            {
            
                queue.Enqueue(printer);
            }
            CurrentPrinter = queue.Dequeue();


        }

        private void PrinterOnPageMissing(object sender, PrinterEventArgs printerEventArgs)
        {
            throw new NotImplementedException();
        }

        private void PrinterOnInkEmpty(object sender, PrinterEventArgs printerEventArgs)
        {
            throw new NotImplementedException();
        }


        private void printButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PrinterUserControl.print();
        }
    }
}
