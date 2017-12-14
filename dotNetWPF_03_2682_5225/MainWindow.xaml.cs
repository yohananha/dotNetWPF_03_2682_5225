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

        public MainWindow()//constructor for the printers
        {
            InitializeComponent();

            queue = new Queue<PrinterUserControl>();


            foreach (Control item in printersGrid.Children)//scan the grid for peinters and add them to a queue
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    //register to events:
                    printer.PageMissing += PageMissingFunc;
                    printer.InkEmpty += InkEmptyFunc;
                    queue.Enqueue(printer);
                }
            }
            CurrentPrinter = queue.Dequeue();//assign the firstprinter into queue
        }

        private void InkEmptyFunc(object sender, PrinterEventArgs e)//event handler for ink
        {
            if (e.IsCritic)
            {
                MessageBox.Show("at:" + e.ErrorTime + "\nMessage from printer: " + e.Message, e.PrinterName + " Ink Missing!!!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                CurrentPrinter.addInk();
                queue.Enqueue(CurrentPrinter);
                CurrentPrinter = queue.Dequeue();
            }
            else
                MessageBox.Show("at:" + e.ErrorTime + "\nMessage from printer: " + e.Message, e.PrinterName + " Ink Missing!!!!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PageMissingFunc(object sender, PrinterEventArgs e)
        {
            MessageBox.Show("at:" + e.ErrorTime + "\nMessage from printer: " + e.Message, e.PrinterName + " Page Missing!!!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                CurrentPrinter.addPages();
            if (CurrentPrinter.InkCount <= 0)//in case the ink is also missing the program activate the second event
            {
                return;
            }
            else
            {
                queue.Enqueue(CurrentPrinter);
                CurrentPrinter = queue.Dequeue();
            }

        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPrinter.Print();//activate print funtion when button clicked
        }
        
    }
}
