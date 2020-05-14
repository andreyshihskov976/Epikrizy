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
    public partial class Pacienty : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;
        string ID_Operacii = null;

        public Pacienty(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Gcgp_ComboBox, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Pacienty, null, textBox1.Text, textBox2.Text, textBox3.Text, date, textBox4.Text, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Gcgp_ComboBox, null, comboBox1.Text));
                ID = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_Last_ID);
                groupBox1.Visible = true;
                MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, dataGridView1, ID);
                dataGridView1.Columns[0].Visible = false;
                button1.Enabled = false;
                button2.Text = "Закрыть";
            }
            else
                MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string date = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Pacienty, ID, textBox1.Text, textBox2.Text, textBox3.Text, date, textBox4.Text, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Gcgp_ComboBox, null, comboBox1.Text));
                this.Close();
            }
            else
                MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Pacienty_FormClosed(object sender, FormClosedEventArgs e)
        {
            Pacienty_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Pacienty_Closed;


        private void button4_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Perenesennye_Operacii, null, ID, date, textBox2.Text, textBox3.Text) != "1")
            {
                if (textBox5.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Perenesennye_Operacii, null, ID, date, textBox5.Text, textBox6.Text);
                    textBox5.Text = "";
                    textBox6.Text = "";
                    MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Perenesennye_Operacii, dataGridView1, ID);
                    dataGridView1.Columns[0].Visible = false;
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Операция с введенными вами датой проведения и действиями уже существует.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Operacii = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            button6.Enabled = false;
            button4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Perenesennye_Operacii, null, ID, date, textBox2.Text, textBox3.Text) != "1")
            {
                if (textBox5.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Perenesennye_Operacii, ID_Operacii, ID, date, textBox2.Text, textBox3.Text);
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Операция с введенными вами датой проведения и действиями уже существует или изменение не были внесены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox5.Text = "";
            textBox6.Text = "";
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Perenesennye_Operacii, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
            button4.Enabled = false;
            button6.Enabled = true;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Perenesennye_Operacii, row.Cells[0].Value.ToString());
            dataGridView1.ClearSelection();
        }

    }
}
