using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPF.Model
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Names");
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyname));
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Names":
                        if (string.IsNullOrEmpty(_name))
                            error = "First Name required";
                        break;

                    case "Age":
                        if ((_age < 18) || (_age > 85))
                            error = "Age out of range.";
                        break;
                    case "Description":
                        if (string.IsNullOrEmpty(_description))
                            error = "Last Name required";
                        break;
                }
                return (error);
            }
        }
    }
}
