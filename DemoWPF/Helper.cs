using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DemoWPF
{
    public class Helper
    {
        private AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities(GetConnectionString());
        public static string GetConnectionString()
        {
            string ip = ConfigurationManager.AppSettings["Ip"];
            string account = ConfigurationManager.AppSettings["Account"];
            string password = ConfigurationManager.AppSettings["Password"];
            string _connStr = String.Format("metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={0};initial catalog=AdventureWorks2008R2;user id={1};password={2};MultipleActiveResultSets=True;App=EntityFramework&quot;", ip, account, password);
            var connDecoded = HttpUtility.HtmlDecode(_connStr);
            //var tempdb = new AdventureWorks2008R2Entities(connDecoded);
            return connDecoded;
        }

        public ObservableCollection<Department> GetDepartment()
        {
            var list = db.Departments.ToList();
            return new ObservableCollection<Department>(list);
        }

        
    }
}
