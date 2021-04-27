using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestApp
{
    public class MainModel : INotifyPropertyChanged
    {
        public string _id { get; set; }

        public string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }


        public string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("firstName");
            }
        }


        public string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("lastName");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DataModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainModel> _data;
        public ObservableCollection<MainModel> data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("data");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

   
}
