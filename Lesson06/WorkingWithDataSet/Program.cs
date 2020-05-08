using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSetWorking();
        }

        private static void DataSetWorking()
        {
            try {
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\littu\OneDrive\Desktop\MTA 98-361\Lesson06\NORTHWIND.mdf;" +
                  @"Integrated Security=True;" +
                  @"Connect Timeout=30";

                SqlConnection con = new SqlConnection(str);
                string customerCommandText = "SELECT * FROM Customer";
                SqlDataAdapter customerAdapter = new SqlDataAdapter(customerCommandText, con);

                string orderCommandText = "SELECT * FROM Orders";
                SqlDataAdapter orderAdapter = new SqlDataAdapter(orderCommandText, con);

                DataSet customerOrder = new DataSet();

                customerAdapter.Fill(customerOrder, "Customer");
                orderAdapter.Fill(customerOrder, "Orders");

                DataRelation relation = customerOrder.Relations.Add("customerOrder", customerOrder.Tables["Customer"].Columns["CustomerId"], customerOrder.Tables["Orders"].Columns["CustomerId"]);

                foreach (DataRow customerRow in customerOrder.Tables["Customer"].Rows)
                {
                    Console.WriteLine(customerRow["CustomerId"]);
                    foreach (DataRow orderRow in customerRow.GetChildRows(relation))
                    {
                        Console.WriteLine("\t" + orderRow["OrderId"]);
                    }
                }

                Console.WriteLine("Press Any Key to Continue!!!");
                Console.ReadKey();
            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
            
        }
    }
}
