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
using System.Windows.Shapes;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for DatabaseSettings.xaml
    /// </summary>
    public partial class DatabaseSettings : Window
    {
        public AdventureWorks2008R2Entities db;
        public DatabaseSettings()
        {
            InitializeComponent();
            LoadConnectionString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string ip = ConfigurationManager.AppSettings["Ip"];
            //string account = ConfigurationManager.AppSettings["Account"];
            //string password = ConfigurationManager.AppSettings["Password"];
            txtServerAddress.Text = ConfigurationManager.AppSettings["Ip"];
            txtUsername.Text = ConfigurationManager.AppSettings["Account"];
            txtPassword.Password = ConfigurationManager.AppSettings["Password"];
        }

        private void btnTestDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Database.Connection.Open();
                MessageBox.Show(this, "Connect database success!!!");
            }
            catch
            {
                MessageBox.Show(this, "Failed!!!");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void LoadConnectionString()
        {
            string ip = ConfigurationManager.AppSettings["Ip"];
            string account = ConfigurationManager.AppSettings["Account"];
            string password = ConfigurationManager.AppSettings["Password"];
            string _connStr = String.Format("metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={0};initial catalog=AdventureWorks2008R2;user id={1};password={2};MultipleActiveResultSets=True;App=EntityFramework&quot;", ip, account, password);
            var connDecoded = HttpUtility.HtmlDecode(_connStr);
            db = new AdventureWorks2008R2Entities(connDecoded);
        }

        private void btnDBUpdate_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Ip"].Value = txtServerAddress.Text;
            config.AppSettings.Settings["Account"].Value = txtUsername.Text;
            config.AppSettings.Settings["Password"].Value = txtPassword.Password;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            LoadConnectionString();
            MessageBox.Show(this, "Update success!!!");

            //string ip = ConfigurationManager.AppSettings["Ip"];
            //string account = ConfigurationManager.AppSettings["Account"];
            //string password = ConfigurationManager.AppSettings["Password"];
            //string _connStr = String.Format("metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={0};initial catalog=AdventureWorks2008R2;user id={1};password={2};MultipleActiveResultSets=True;App=EntityFramework&quot;",ip,account,password);
            //var m = HttpUtility.HtmlDecode(_connStr);
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings["AdventureWorks2008R2Entities"].ConnectionString = m;
            //config.Save(ConfigurationSaveMode.Modified, true);
            //ConfigurationManager.RefreshSection("connectionStrings");
            //LoadConnectionString();
            //MessageBox.Show(this, "Update success!!!");
        }

        
    }
}
