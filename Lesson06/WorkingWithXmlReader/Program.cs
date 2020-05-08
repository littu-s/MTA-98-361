using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WorkingWithXmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using(XmlReader reader = XmlReader.Create("Customer.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "CompanyName":
                                    if (reader.Read())
                                    {
                                        Console.Write("Company Name: {0}, ", reader.Value);
                                    }
                                    break;
                                case "CustomerPhone":
                                    if (reader.Read())
                                    {
                                        Console.Write("Customer Phone: {0}, ", reader.Value);
                                    }
                                    break;
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
