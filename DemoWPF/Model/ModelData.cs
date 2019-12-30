using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPF.Model
{
    public class ModelData
    {
        public DataTable getData()
        {
            DataTable ndt = new DataTable("1234");
            ndt.Columns.Add(new DataColumn("Name"));
            ndt.Columns.Add(new DataColumn("Age"));
            ndt.Columns.Add(new DataColumn("Description"));
            ndt.Columns.Add(new DataColumn("Error"));

            ndt.Rows.Add("Joe", "22", "Janitor High", "None");
            ndt.Rows.Add("John", "23", "Janitor High", "None");
            ndt.Rows.Add("Josh", "24", "Janitor High", "No mop");

            return ndt;
        }
    }
}
