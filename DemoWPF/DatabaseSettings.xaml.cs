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
        private Helper helper = new Helper();
        public DatabaseSettings()
        {
            InitializeComponent();
            UpdateConnectionString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        //private async Task<bool> TestFunc()
        //{
        //    try
        //    {
        //        db.Database.Connection.Open();
        //        return true;
        //    }
        //    catch
        //    {
        //        db.Dispose();
        //        return false;
        //    }
        //}

        private void UpdateConnectionString()
        {
            var conn = Helper.GetConnectionString();
            db = new AdventureWorks2008R2Entities(conn);
        }

        private void btnDBUpdate_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Ip"].Value = txtServerAddress.Text;
            config.AppSettings.Settings["Account"].Value = txtUsername.Text;
            config.AppSettings.Settings["Password"].Value = txtPassword.Password;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            UpdateConnectionString();
            MessageBox.Show(this, "Update success!!!");

        }

        
    }
}
