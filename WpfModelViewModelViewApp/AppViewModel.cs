using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Employee employeeSelected;

        public ObservableCollection<Employee> Employees { set; get; }

        public Employee EmployeeSelected
        {
            get => employeeSelected;
            set
            {
                employeeSelected = value;
                OnPropertyChanged(nameof(EmployeeSelected));
            }
        }

        public AppViewModel()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new() { Name = "Bob",
                    BirthDate = new DateTime(1992, 5, 21),
                    Position = "Manager",
                    Salary = 60500 },
                new() { Name = "Tom",
                    BirthDate = new DateTime(1987, 11, 3),
                    Position = "Developer",
                    Salary = 98600 },
                new() { Name = "Joe",
                    BirthDate = new DateTime(2001, 2, 11),
                    Position = "Manager",
                    Salary = 55000 },
                new() { Name = "Sam",
                    BirthDate = new DateTime(1989, 9, 15),
                    Position = "Developer",
                    Salary = 100000 },
                new() { Name = "Leo",
                    BirthDate = new DateTime(1995, 4, 19),
                    Position = "Tester",
                    Salary = 80000 },
            };
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
