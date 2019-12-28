using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AdventureWorks2008R2Entities db;
        public MainWindow()
        {
            InitializeComponent();
            ReloadConnectionStr();
        }
        
        private void ReloadConnectionStr()
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorks2008R2Entities"].ConnectionString;
            db = new AdventureWorks2008R2Entities(conn);
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtPassword.BorderBrush = new SolidColorBrush(Colors.Orange);
            try
            {
                db.Database.Connection.Open();
                MessageBox.Show(this, "Connect database success!!!");
            }
            catch
            {
                MessageBox.Show(this, "FAILED!!!");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void BtnChangeUser(object sender, RoutedEventArgs e)
        {
            var m = HttpUtility.HtmlDecode("metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-0L3UA8A;initial catalog=AdventureWorks2008R2;user id=newuser;password=123456;MultipleActiveResultSets=True;App=EntityFramework&quot;");
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["AdventureWorks2008R2Entities"].ConnectionString = m;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            ReloadConnectionStr();
            MessageBox.Show(this, "Update success!!!");
            
        }

        private void btnCheckDBConn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
