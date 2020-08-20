using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp1
{
    class NewPersonWindowViewModel : INotifyPropertyChanged
    {
        string fullName;
        string ssn;
        string birthDate;
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                NotifyPropertyChanged("FullName");
            }
        }
        public string SSN
        {
            get
            {
                if (ssn != null)
                {
                    var ssnResult = Regex.Replace(ssn.ToString(), @"(\d{3})(\d{2})(\d{4})", "$1-$2-$3");
                    return ssnResult;
                }
                return null;
            }
            set
            {
                ssn = value;
                NotifyPropertyChanged("SSN");
            }
        }
        public string BirthDate
        {
            get
            {
                if (birthDate != null)
                {
                    var birthDateResult = Regex.Replace(birthDate, @"(\d{2})[\- ]?(\d{2})[\- ]?(\d{4})", "$1/$2/$3");
                    return birthDateResult;
                }
                return null;
            }
            set
            {
                birthDate = value;
                NotifyPropertyChanged("BirthDate");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
