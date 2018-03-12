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

namespace orderline
{
    public partial class Form1 : Form
    {
        static string ConnectionString = "" +
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Integrated Security=true;" +
            "Initial Catalog=orderline;";
        SqlConnection conn = new SqlConnection(ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("" +
                "CREATE TABLE Customer(" +
                "ID INT PRIMARY KEY," +
                "Name VARCHAR(25)," +
                "Address Varchar(50));",
                conn);
            SqlCommand cmd2 = new SqlCommand("" +
                "CREATE TABLE Orders(" +
                "ID INT PRIMARY KEY," +
                "Date Date," +
                "CustID INT," +
                "FOREIGN KEY(CustID) REFERENCES Customer(ID));",
                conn);
            SqlCommand cmd3 = new SqlCommand("" +
                "CREATE TABLE Product(" +
                "ID INT PRIMARY KEY," +
                "Price INT," +
                "Name VARCHAR(25));",
                conn);
            SqlCommand cmd4 = new SqlCommand("" +
                "CREATE TABLE OrderLine(" +
                "OID INT," +
                "PID INT," +
                "Quantity INT," +
                "FOREIGN KEY(OID) REFERENCES Orders(ID), " +
                "FOREIGN KEY(PID) REFERENCES Product(ID));",
                conn);
            using (conn)
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Progress.Text = "Connection Opened";
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    Progress.Text += "\nTables Created";

                }
            }
        }
    }
}
