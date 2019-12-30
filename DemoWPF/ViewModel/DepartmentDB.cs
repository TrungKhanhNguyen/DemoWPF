using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace DemoWPF.ViewModel
{
     
    public class DepartmentDB
    {
        private Helper helper = new Helper();
        //private AdventureWorks2008R2Entities db = new AdventureWorks2008R2Entities(Helper.GetConnectionString());
        private ObservableCollection<Department> _departs = new ObservableCollection<Department>();
        public ObservableCollection<Department> Departs
        {
            get { return _departs; }
            set { _departs = value; }
        }

        public DepartmentDB()
        {
            Departs = helper.GetDepartment();
        }
    }
}
