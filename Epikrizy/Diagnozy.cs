using System;
using System.Windows.Forms;

namespace Epikrizy
{
    public partial class Diagnozy : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;
        string ID_Preparata = null;

        public Diagnozy(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Preparaty_ComboBox, comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Diagnozy, null, textBox1.Text) != "1")
            {
                if (textBox1.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Diagnozy, null, textBox1.Text);
                    ID = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_Last_ID);
                    groupBox2.Visible = true;
                    MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Lechenie, dataGridView2, ID);
                    dataGridView2.Columns[0].Visible = false;
                    button1.Enabled = false;
                    button2.Text = "Закрыть";
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Диагноз с введенным вами наименованием уже существует.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Закрыть")
            {
                if (dataGridView2.Rows.Count > 0)
                    this.Close();
                else if (dataGridView2.Rows.Count >= 0)
                    MessageBox.Show("Не заполнен блок " + '"' + "репараты, показанные к применению" + '"' + ", пожалуйста заполните его прежде чем закрыть окно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Diagnozy, null, textBox1.Text) != "1")
            {
                if (textBox1.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Diagnozy, ID, textBox1.Text);
                    button2.Text = "Закрыть";
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Диагноз с введенным вами наименованием уже существует или изменения не были внесены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Diagnozy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Diagnozy_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Diagnozy_Closed;

        private void button7_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Lechenie, null, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Preparaty_ComboBox, null, comboBox2.Text)) != "1")
            {
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Lechenie, null, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Preparaty_ComboBox, null, comboBox2.Text));
                comboBox2.SelectedItem = comboBox2.Items[0];
                MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Lechenie, dataGridView2, ID);
                dataGridView2.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("Данный препарат уже присутствует в списке рекомендованных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_Preparata = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            MySqlOperations.Search_In_ComboBox(dataGridView2.SelectedRows[0].Cells[1].Value.ToString(), comboBox2);
            button7.Enabled = false;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Lechenie, null, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Preparaty_ComboBox, null, comboBox2.Text)) != "1")
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Lechenie, ID_Preparata, ID, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Preparaty_ComboBox, null, comboBox2.Text));
            else
                MessageBox.Show("Данный препарат уже присутствует в списке рекомендованных или изменения не были внесены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comboBox2.SelectedItem = comboBox2.Items[0];
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Lechenie, dataGridView2, ID);
            dataGridView2.Columns[0].Visible = false;
            button5.Enabled = false;
            button7.Enabled = true;
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Delete_Lechenie, row.Cells[0].Value.ToString());
            dataGridView2.ClearSelection();
            //MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, dataGridView2, ID);
            //dataGridView2.Columns[0].Visible = false;
        }

        private void LabIssl_Shown(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }
    }
}
