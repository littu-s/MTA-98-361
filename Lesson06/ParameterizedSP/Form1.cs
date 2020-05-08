using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParameterizedSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetTotalSalesButton_Click(object sender, EventArgs e)
        {
            TotalSalesLabel.Text = String.Format("Total Sales: {0}", GetTotalSales(CustomerIdTextBox.Text));
        }

        private object GetTotalSales(string id)
        {
            double totalSales = -1;
            try
            {
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\littu\OneDrive\Desktop\MTA 98-361\Lesson06\NORTHWIND.mdf;" +
                  @"Integrated Security=True;" +
                  @"Connect Timeout=30";

                int cust_id = int.Parse(id);

                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCustomerSales";
                cmd.Parameters.AddWithValue("@CustomerId", cust_id); 
                cmd.Parameters.AddWithValue("@TotalSales", null);
                cmd.Parameters["@TotalSales"].DbType = DbType.Currency;
                cmd.Parameters["@TotalSales"].Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                totalSales = Double.Parse(cmd.Parameters["@TotalSales"].Value.ToString());

                con.Close();

            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }

            return totalSales;

        }
    }
}
