using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLDeserialisation
{
    public class Employee
    {
        public string Name { get; set; }
        public int Desk { get; set; }

        // Since we are capturing just strings in the list and not a class that we have created, we can not rely on automatic mapping between class names and XML element names.
        // Therefore, we specify what XML element we want to capture and put inside the list. OneNote notes go into more detail.
        [XmlArrayItem("Pet")]
        public List<string> Pets { get; set; }
    }
}
