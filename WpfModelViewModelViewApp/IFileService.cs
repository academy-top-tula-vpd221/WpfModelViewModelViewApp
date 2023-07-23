using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public interface IFileService
    {
        List<Employee> OpenFile(string fileName);
        void SaveFile(string fileName, List<Employee> employees);
    }
}
