using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLDeserialisation
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomNumber { get; set; }
        public decimal Budget { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
