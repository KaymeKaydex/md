using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        static private int customersCount;
        public Form1()
        {
            InitializeComponent();
        }

        public static int GetCustomersCount() => customersCount;
      
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.sales". При необходимости она может быть перемещена или удалена.
            this.salesTableAdapter.Fill(this.dbDataSet.sales);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.customers". При необходимости она может быть перемещена или удалена.
            this.customersTableAdapter.Fill(this.dbDataSet.customers);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = this.Validate();
                if (!isValid) {
                    MessageBox.Show("Data is not valid");
                }

                this.customersBindingSource.EndEdit();
                this.customersTableAdapter.Update(this.dbDataSet.customers);
                this.tableAdapterManager.UpdateAll(this.dbDataSet);

                MessageBox.Show("Update successful");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Update failed");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            Hide();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            customersCount = customersBindingSource.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            Hide();
        }
    }
}
