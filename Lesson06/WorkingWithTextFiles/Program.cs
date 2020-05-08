using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            CopyDataToTextFile(myDocumentPath + @"\CustomerList.Txt");
            DisplayTextFile(myDocumentPath + @"\CustomerList.Txt");
            Console.ReadLine();
        }

        private static void CopyDataToTextFile(string fileName)
        {
            try
            {
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\littu\OneDrive\Desktop\MTA 98-361\Lesson06\NORTHWIND.mdf;" +
                  @"Integrated Security=True;" +
                  @"Connect Timeout=30";

                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT CustomerId, CompanyName, ContactName, CustomerPhone FROM Customer";

                using (con)
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    using(StreamWriter sw = new StreamWriter(fileName))
                    {
                        while (reader.Read())
                        {
                            string customerRow = String.Format("{0}, {1}, {2}, {3}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                            sw.WriteLine(customerRow);
                        }
                    }
                }

            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        private static void DisplayTextFile(string fileName)
        {
            try
            {
                using(StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
        
    }
}
