using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Person
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public string BirthDate { get; set; }

        public override string ToString()
        {
            var properties = string.Format("  Name: {0},\n  SSN: {1},\n  BirthDate: {2}", Name, SSN, BirthDate);
            var result = "Person: {\n" + properties + "\n}";
            return result;
        }
    }
}
