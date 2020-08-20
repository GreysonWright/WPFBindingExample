# Data Binding to UI Elements in WPF
> File structure needs to be refactored.

## Step 1 - Create the View Model
### [NewPersonWindowViewModel.cs](./wpfApp1/NewPersonWindowViewModel.cs)
The view model should extend the `System.ComponentModel.INotifyPropertyChanged` interface for the ui binding to know when an update occurs.

```
public class NewPersonWindowViewModel : INotifyPropertyChanged
    {
    }
```

Conform to the interface by adding the event PropertyChangedEventHandler property.
```
public event PropertyChangedEventHandler PropertyChanged;
```
For convenience, declare `NotifyPropertyChanged` to fire the `PropertyChanged` event.
```
public void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
```

Declare the private fields and their corresponding public properties that will be bound to in the UI. Notice the call to the `NotifyPropertyChanged` method in the `SelectedPerson` object's setter. This call notifies the UI when to make a change once the binding is configured. It is important to note that if a list is needed, use the `System.Collections.ObjectModel.ObservableCollection<T>` instead of a list, array, or other collection to ensure the UI elements are updated when calling `Add`, `Remove`, etc.
```
string fullName;
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
```

## Configuring the View Controller
### [NewPersonWindow.xaml.cs](./wpfApp1/NewPersonWindow.xaml.cs)
In the view controller's constructor, simply instantiate the view model and assign it to the `DataContext` property.
```
viewModel = new NewPersonWindowViewModel();
DataContext = viewModel;
```

## Configure the UI
### [NewPersonWindow.xaml](./wpfApp1/NewPersonWindow.xaml)
The Last step is to add the binding on the ui element. Set the `UpdateSourceTrigger` property to `PropertyChanged` to update the bound property on change.
```
<TextBox x:Name="nameTextBox" TextWrapping="Wrap" FontSize="16" Text="{Binding FullName, UpdateSourceTrigger=PropertyChanged}"/>
```
