using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MySqlServerTest
{
    public partial class Form1 : Form
    {
        OleDbConnection myConn;
        OleDbCommand myComm;
        OleDbDataAdapter myDataAdapter;
        DataSet myDataSet;
        DataTable myDataTable;

        public Form1()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDataSet = new DataSet();
            myDataTable = new DataTable();
            myConn = new OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=TestVb;Data Source=OFFICE\\WINCC");
            myConn.Open();

            String sql = "select * from dbo.dog";
            myComm = new OleDbCommand(sql, myConn);
            myDataAdapter = new OleDbDataAdapter();
            myDataAdapter.SelectCommand = myComm;
            myDataAdapter.Fill(myDataTable);
            //myDataAdapter.Fill(myDataSet,"dog"); //alternative method


            dataGridViewShow.DataSource = myDataTable;
            //dataGridViewShow.DataMember = "dog"; //alternative method

            myConn.Close();

        }
    }
}
