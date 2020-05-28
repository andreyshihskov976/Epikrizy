using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epikrizy
{
    public partial class Epikrizy : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;
        string ID_Pacienta = null;
        string ID_Otdeleniya = null;
        string ID_Diagnoza_Pacienta = null;
        string ID_Operacii = null;
        string ID_Proved_LabIssl = null;

        public Epikrizy(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Pacienty_ComboBox, comboBox1);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Otdeleniya_ComboBox, comboBox2);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Lech_Vrach_ComboBox, comboBox3, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox,null, comboBox2.Text));
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Diagnozy_ComboBox, comboBox4);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_LabIssl_ComboBox, comboBox5, null, ID_Otdeleniya);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = dateTimePicker2.Value;
            dateTimePicker3.Value = dateTimePicker2.Value.AddDays(1);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker4.MinDate = dateTimePicker3.Value;
            dateTimePicker4.Value = dateTimePicker3.Value.AddDays(1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID_Otdeleniya = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox2.Text);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Lech_Vrach_ComboBox, comboBox3, ID_Otdeleniya);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_LabIssl_ComboBox, comboBox5, null, ID_Otdeleniya);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            string date2 = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
            string date3 = dateTimePicker3.Value.Year.ToString() + '-' + dateTimePicker3.Value.Month.ToString() + '-' + dateTimePicker3.Value.Day.ToString();
            string date4 = dateTimePicker4.Value.Year.ToString() + '-' + dateTimePicker4.Value.Month.ToString() + '-' + dateTimePicker4.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Epikrizy, null,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Pacienty_ComboBox, null, comboBox1.Text),
                date1, date2,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox2.Text),
                textBox1.Text, date3, date4, textBox2.Text, comboBox3.Text);
            ID = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_Last_ID);
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Visible = true;
            button3.Visible = false;
            tabControl1.SelectedIndex += 1;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Dianozy_Pacienta, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Perenesennye_Operacii, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Proved_LabIssl, dataGridView3, ID);
            dataGridView3.Columns[0].Visible = false;
        }

        private void Epikrizy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Epikrizy_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Epikrizy_Closed;

        private void button5_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
            string date2 = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
            string date3 = dateTimePicker3.Value.Year.ToString() + '-' + dateTimePicker3.Value.Month.ToString() + '-' + dateTimePicker3.Value.Day.ToString();
            string date4 = dateTimePicker4.Value.Year.ToString() + '-' + dateTimePicker4.Value.Month.ToString() + '-' + dateTimePicker4.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Epikrizy, ID,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Pacienty_ComboBox, null, comboBox1.Text),
                date1, date2,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox2.Text),
                textBox1.Text, date3, date4, textBox2.Text, comboBox3.Text);
            button4.Enabled = false;
            tabControl1.SelectedIndex += 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Diagnozy_Pacienta, null, ID,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Diagnozy_ComboBox, null, comboBox4.Text),
                textBox3.Text, "Да");
            else
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Diagnozy_Pacienta, null, ID,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Diagnozy_ComboBox, null, comboBox4.Text),
                textBox3.Text, "Нет");
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Dianozy_Pacienta, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
            comboBox4.SelectedItem = comboBox4.Items[0];
            textBox3.Text = "";
            checkBox1.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Diagnozy_Pacienta, ID_Diagnoza_Pacienta, ID,
                    MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Diagnozy_ComboBox, null, comboBox4.Text),
                    textBox3.Text, "Да");
            else
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Diagnozy_Pacienta, null, ID,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Diagnozy_ComboBox, null, comboBox4.Text),
                textBox3.Text, "Нет");
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Dianozy_Pacienta, dataGridView1, ID);
            dataGridView1.Columns[0].Visible = false;
            button8.Visible = true;
            button6.Visible = false;
            comboBox4.SelectedItem = comboBox4.Items[0];
            textBox3.Text = "";
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Diagnoza_Pacienta = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            MySqlOperations.Search_In_ComboBox(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), comboBox4);
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "Да")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            button6.Visible = true;
            button8.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Diagnozy_Pacienta, row.Cells[0].Value.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker5.Value.Year.ToString() + '-' + dateTimePicker5.Value.Month.ToString() + '-' + dateTimePicker5.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Perenesennye_Operacii, null, ID, date, textBox4.Text, textBox5.Text);
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Perenesennye_Operacii, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker5.Value.Year.ToString() + '-' + dateTimePicker5.Value.Month.ToString() + '-' + dateTimePicker5.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Perenesennye_Operacii, ID_Operacii, ID, date, textBox4.Text, textBox5.Text);
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Perenesennye_Operacii, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
            button10.Visible = false;
            button12.Visible = true;
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Operacii = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            dateTimePicker5.Value = DateTime.Parse(dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
            textBox4.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            button12.Visible = false;
            button10.Visible = true;
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Perenesennye_Operacii, row.Cells[0].Value.ToString());
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl_Insert_Epikrizy, dataGridView4,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_LabIssl_ComboBox, null, comboBox5.Text));
            dataGridView4.Columns[0].Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker6.Value.Year.ToString() + '-' + dateTimePicker6.Value.Month.ToString() + '-' + dateTimePicker6.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Proved_LabIssl, null, ID,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_LabIssl_ComboBox, null, comboBox5.Text), date);
            ID_Proved_LabIssl = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_Last_ID);
            foreach (DataGridViewRow row in dataGridView4.Rows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Dannye_LabIssl, null, ID_Proved_LabIssl, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl_Insert_Epikrizy, dataGridView4,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_LabIssl_ComboBox, null, comboBox5.Text));
            dataGridView4.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Proved_LabIssl, dataGridView3, ID);
            dataGridView3.Columns[0].Visible = false;            
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Proved_LabIssl, row.Cells[0].Value.ToString());
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Proved_LabIssl = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            MySqlOperations.Search_In_ComboBox(dataGridView3.SelectedRows[0].Cells[1].Value.ToString(), comboBox5);
            dateTimePicker6.Value = DateTime.Parse(dataGridView3.SelectedRows[0].Cells[2].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Dannye_LabIssl, dataGridView4, ID_Proved_LabIssl);
            dataGridView4.Columns[0].Visible = false;
            comboBox5.Enabled = false;
            button13.Visible = false;
            button15.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker6.Value.Year.ToString() + '-' + dateTimePicker6.Value.Month.ToString() + '-' + dateTimePicker6.Value.Day.ToString();
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Proved_LabIssl, ID_Proved_LabIssl, ID, date);
            foreach (DataGridViewRow row in dataGridView4.Rows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Dannye_LabIssl, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString());
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl_Insert_Epikrizy, dataGridView4,
                MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_LabIssl_ComboBox, null, comboBox5.Text));
            dataGridView4.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Proved_LabIssl, dataGridView3, ID);
            dataGridView3.Columns[0].Visible = false;
            comboBox5.Enabled = true;
            button15.Visible = false;
            button13.Visible = true;
        }
    }
}
