using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewPersonWindow.xaml
    /// </summary>

    public partial class NewPersonWindow : Window
    {

        public delegate void PersonCompletion(Person person);
        PersonCompletion completion;
        NewPersonWindowViewModel viewModel;

        public NewPersonWindow(PersonCompletion completion)
        {
            InitializeComponent();
            this.completion = completion;
            viewModel = new NewPersonWindowViewModel();
            DataContext = viewModel;
        }

        private Person buildPersonFromViewModel()
        {
            var person = new Person
            {
                Name = viewModel.FullName,
                SSN = viewModel.SSN,
                BirthDate = viewModel.BirthDate,
            };
            return person;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            completion(buildPersonFromViewModel());
            this.Close();
        }
    }
}
