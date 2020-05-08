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

namespace DatabaseDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                SelectData(textBox1.Text);
            }
        }

        private void SelectData(string cmdText)
        {
            try
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename=C:\Users\littu\OneDrive\Desktop\MTA 98-361\Lesson06\NORTHWIND.mdf;" + 
                  @"Integrated Security=True;" + 
                  @"Connect Timeout=30";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdText, con);
                DataTable tbl = new DataTable();
                dataAdapter.Fill(tbl);
                dataGridView1.DataSource = tbl;
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
