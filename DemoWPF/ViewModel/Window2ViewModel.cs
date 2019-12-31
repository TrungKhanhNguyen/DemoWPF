using DemoWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace DemoWPF.ViewModel
{
    public class Window2ViewModel : INotifyPropertyChanged
    {
        //ModelData _myModel = new ModelData();
        private Helper helper = new Helper();
        
        //public PagedCollectionView Departs { get; private set; }

        //private ObservableCollection<Person> _empdata = new ObservableCollection<Person>();
        //public ObservableCollection<Person> Empdata
        //{
        //    get { return _empdata; }
        //    set
        //    {
        //        _empdata = value;
        //        OnPropertyChanged("Empdata");
        //    }
        //}

        public Window2ViewModel()
        {
            //initializeload();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //private void initializeload()
        //{
        //    DataTable table = _myModel.getData();

        //    for (int i = 0; i < table.Rows.Count; ++i)
        //        Empdata.Add(new Person
        //        {
        //            Name = table.Rows[i][0].ToString(),
        //            Age = Convert.ToInt32(table.Rows[i][1]),
        //            Description = table.Rows[i][2].ToString(),
        //        });
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged(string propertyname)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(propertyname));
        //}
    }
}
