using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> people;
        private Person selectedPerson;
        public event PropertyChangedEventHandler PropertyChanged;
        public Person SelectedPerson
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                selectedPerson = value;
                NotifyPropertyChanged("SelectedPerson");
            }
        }
        public ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
                NotifyPropertyChanged("Text");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            people = new ObservableCollection<Person>();
        }
    }
}
