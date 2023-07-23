using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public class JsonFileService : IFileService
    {
        public List<Employee> OpenFile(string fileName)
        {
            List<Employee> employees = new List<Employee>();
            using(FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                employees = JsonSerializer.Deserialize<List<Employee>>(stream);
            }
            return employees;
        }

        public void SaveFile(string fileName, List<Employee> employees)
        {
            using(FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(stream, employees);
            }
        }
    }
}
