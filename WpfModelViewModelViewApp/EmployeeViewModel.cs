using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee employee;

        EmployeeViewModel(Employee employee)
        {
            this.employee = employee;
        }

        public string Name 
        {
            get => employee.Name;
            set
            {
                employee.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public DateTime BirthDate
        {
            get => employee.BirthDate;
            set
            {
                employee.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public string Position
        {
            get => employee.Position;
            set
            {
                employee.Position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public decimal Salary
        {
            get => employee.Salary;
            set
            {
                employee.Salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if(PropertyChanged is not null) 
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
