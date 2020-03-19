using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLDeserialisation
{
    class Program
    {
        static string xmlFilePath = string.Empty;

        static void Main(string[] args)
        {
            Initialise();

            ProcessFile();

            Console.ReadKey();
        }

        static void Initialise()
        {
            xmlFilePath = ConfigurationManager.AppSettings["XMLFilePath"];
        }

        private static void ProcessFile()
        {
            using (var streamReader = new StreamReader(xmlFilePath))
            {
                using (var xmlReader = XmlReader.Create(streamReader))
                {
                    int departmentCount = 0;

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Department")
                        {
                            // Reached a new <Department> element.

                            using (var departmentReader = xmlReader.ReadSubtree())
                            {
                                // Create an XML reader that just reads a <Department> element.
                                // Perform deserialisation for this single <Department> element.

                                var department = DeserializeDepartment(departmentReader);

                                // Write the department to the console.
                                OutputDepartment(department);
                            }

                            departmentCount++;
                        }
                    }

                    Console.WriteLine($"Department count: { departmentCount }");
                }
            }
        }

        static Department DeserializeDepartment(XmlReader xmlReader)
        {
            // We need an instance of the XmlSerializer class to perform deserialisation.
            var serializer = new XmlSerializer(typeof(Department));

            // The object that will be the XML file will be deserialised to.
            Department department;

            // Call the Deserialize method to 'populate' the object.
            department = (Department)serializer.Deserialize(xmlReader);

            return department;
        }

        static void OutputDepartment(Department department)
        {
            Console.WriteLine("Department:");
            Console.WriteLine(department.Name);
            Console.WriteLine(department.Description);
            Console.WriteLine(department.RoomNumber);
            Console.WriteLine(department.Budget);

            Console.WriteLine();
            Console.WriteLine("Employees:");
            Console.WriteLine();

            foreach (var employee in department.Employees)
            {
                Console.WriteLine(employee.Name.PadRight(20) + $"Desk { employee.Desk }");

                Console.WriteLine("Pets:");

                foreach (string pet in employee.Pets)
                    Console.WriteLine(pet);

                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        }
    }
}
