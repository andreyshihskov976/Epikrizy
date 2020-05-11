using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epikrizy
{
    public partial class LabIssl : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;
        string ID_Pokazat = null;
        string ID_Otdeleniya = null;

        public LabIssl(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Otdeleniya_ComboBox, comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_LabIssl, null, textBox1.Text);
            ID = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_Last_ID);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
            button2.Text = "Закрыть";
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_LabIssl, ID, textBox1.Text);
            button2.Text = "Закрыть";
            //this.Close();
        }

        private void LabIssl_FormClosed(object sender, FormClosedEventArgs e)
        {
            LabIssl_Closed(this, EventArgs.Empty);
        }
        public event EventHandler LabIssl_Closed;

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Pokazat_LabIssl, null, ID, textBox2.Text, textBox3.Text);
            textBox2.Text = "";
            textBox3.Text = "";
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Otdeleniya_LabIssl, null, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox2.Text));
            comboBox2.SelectedItem = comboBox2.Items[0];
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Pokazat = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Pokazat_LabIssl, ID_Pokazat, ID, textBox2.Text, textBox3.Text);
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Otdeleniya = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), comboBox2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Otdeleniya_LabIssl, null, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, ID_Otdeleniya, comboBox2.Text));
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //if (dataGridView1.DataSource != null)
            //{
            //    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            //        MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Pokazat_LabIssl, row.Cells[0].Value.ToString());
            //    MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, dataGridView1, ID);
            //    dataGridView1.Columns[0].Visible = false;
            //}
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //if (dataGridView2.DataSource != null)
            //{
            //    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            //        MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Otdeleniya_LabIssl, row.Cells[0].Value.ToString());
            //    MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, dataGridView2, ID);
            //    dataGridView2.Columns[0].Visible = false;
            //}
        }
    }
}
