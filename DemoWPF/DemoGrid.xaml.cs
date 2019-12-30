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
        //private AdventureWorks2008R2Entities db;
        //private Helper helper = new Helper();
        public DemoGrid()
        {
            InitializeComponent();
            //db = new AdventureWorks2008R2Entities(Helper.GetConnectionString());
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    datagrid1.ItemsSource = db.Departments.ToList();
        //}
    }
}
