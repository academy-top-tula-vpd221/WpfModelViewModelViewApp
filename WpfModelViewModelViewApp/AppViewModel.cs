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
        private IDialogService dialogService;
        private IFileService fileService;

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

        public AppViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

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

        private AppCommand addEmployeeCommand;
        public AppCommand AddEmployeeCommand
        {
            get
            {
                return addEmployeeCommand ??
                    (
                        addEmployeeCommand = new AppCommand(
                                param =>
                                {
                                    Employee employee = new Employee();
                                    Employees.Insert(0, employee);
                                    EmployeeSelected = employee;
                                }
                            )
                    );
            }
        }

        private AppCommand deleteEmployeeCommand;
        public AppCommand DeleteEmployeeCommand
        {
            get
            {
                return deleteEmployeeCommand ??
                    (
                        deleteEmployeeCommand = new AppCommand(
                            param =>
                            {
                                Employee employee = param as Employee;
                                if(employee is not null)
                                {
                                    int position = Employees.IndexOf(employee);
                                    Employees.Remove(employee);
                                    if(Employees.Count > 0)
                                    {
                                        if (position >= Employees.Count)
                                            position = Employees.Count - 1;
                                        EmployeeSelected = Employees[position];
                                    }
                                }
                                    
                            },
                            param => Employees.Count > 0)
                    );
            }
        }

        private AppCommand copyEmployeeCommand;
        public AppCommand CopyEmployeeCommand
        {
            get
            {
                return copyEmployeeCommand ??
                    (
                        copyEmployeeCommand = new AppCommand(
                            param =>
                            {
                                Employee employee = param as Employee;
                                Employees.Insert(0, employee);
                            },
                            param => Employees.Count > 0)
                    );
            }
        }

        private AppCommand saveFileCommand;
        public AppCommand SaveFileCommand
        {
            get
            {
                return saveFileCommand ??
                    (
                        saveFileCommand = new AppCommand(
                            param =>
                            {
                                try
                                {
                                    if(dialogService.SaveFileDialog())
                                    {
                                        fileService.SaveFile(dialogService.FilePath, Employees.ToList());
                                        dialogService.ShowMessage("List of employees saved to file");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    dialogService.ShowMessage(ex.Message);
                                }
                            })
                    );
            }
        }

        private AppCommand openFileCommand;
        public AppCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ??
                    (
                        openFileCommand = new AppCommand(
                            param =>
                            {
                                try
                                {
                                    if(dialogService.OpenFileDialog())
                                    {
                                        var employyes = fileService.OpenFile(dialogService.FilePath);
                                        Employees.Clear();
                                        foreach (var employee in employyes)
                                            Employees.Add(employee);
                                        dialogService.ShowMessage("List of employees read from file");
                                    }
                                }
                                catch(Exception ex)
                                {
                                    dialogService.ShowMessage(ex.Message);
                                }
                            })
                    );
            }
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
