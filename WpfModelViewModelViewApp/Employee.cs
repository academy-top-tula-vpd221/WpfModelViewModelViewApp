using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfModelViewModelViewApp
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { set; get; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
