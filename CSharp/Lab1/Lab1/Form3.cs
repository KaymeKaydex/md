using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minSumOfSale = 0;

            try
            {
                minSumOfSale = Convert.ToInt32(textBox1.Text);

            } catch
            {
                MessageBox.Show("вы указали значение не верного формата");

                return;
            }

            // string myDBPath = @".\db.accdb";

            string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db.accdb";
            OleDbConnection connection = new OleDbConnection(conStr);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            connection.Open();


            OleDbCommand command = new OleDbCommand("SELECT * FROM sales WHERE price > " + minSumOfSale.ToString(), connection); // добавляем текст SQL запроса
            connection.Close();
            adapter.SelectCommand = command;

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            adapter.Update(dataSet);

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet1.sales". При необходимости она может быть перемещена или удалена.
            //this.salesTableAdapter.Fill(this.dbDataSet1.sales);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 frm = new Form2();
            frm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            Hide();
        }
    }
}
