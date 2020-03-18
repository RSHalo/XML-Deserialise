using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLDeserialisation
{
    class Program
    {
        static string xmlFilePath = string.Empty;

        static void Main(string[] args)
        {
            Initialise();

            DeserializeObject(xmlFilePath);

            Console.ReadKey();
        }

        static void Initialise()
        {
            xmlFilePath = ConfigurationManager.AppSettings["XMLFilePath"];
        }

        static void DeserializeObject(string filename)
        {
            // Create an instance of the XmlSerializer.
            var serializer = new XmlSerializer(typeof(Department));

            // Declare an object variable of the type to be deserialized.
            Department department;

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                department = (Department)serializer.Deserialize(reader);
            }

            // Write out the properties of the object.
            Console.WriteLine(department.Name);
            Console.WriteLine(department.Description);
            Console.WriteLine(department.RoomNumber);
            Console.WriteLine(department.Budget);

            Console.WriteLine();
            Console.WriteLine("Employees:");

            foreach (var employee in department.Employees)
                Console.WriteLine(employee.Name.PadRight(20) + employee.Desk);
        }
    }
}
