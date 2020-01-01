using DemoWPF.ViewModel;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for DemoGrid.xaml
    /// </summary>
    public partial class DemoGrid : Window
    {
        private AdventureWorks2008R2Entities db;
        public DemoGrid()
        {
            InitializeComponent();
            db = new AdventureWorks2008R2Entities(Helper.GetConnectionString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagrid1.ItemsSource = db.Departments.ToList();
        }
        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 2: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }

        //public void CalendarDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        //{
        //    CalendarTest.SelectedDate = ((PickersViewModel)DataContext).Date;
        //}

        //public void CalendarDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        //{
        //    if (!Equals(eventArgs.Parameter, "1")) return;

        //    if (!CalendarTest.SelectedDate.HasValue)
        //    {
        //        eventArgs.Cancel();
        //        return;
        //    }

        //    ((PickersViewModel)DataContext).Date = CalendarTest.SelectedDate.Value;
        //}

        public void CalendarDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            Calendar2.SelectedDate = ((PickersViewModel)DataContext).Date;
        }

        public void CalendarDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, "1")) return;

            if (!Calendar2.SelectedDate.HasValue)
            {
                eventArgs.Cancel();
                return;
            }

            ((PickersViewModel)DataContext).Date = Calendar2.SelectedDate.Value;
        }
    }
}
