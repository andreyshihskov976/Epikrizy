using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowState = System.Windows.Forms.FormWindowState;

namespace Epikrizy
{
    public partial class MainWin : Form
    {
        MySqlQueries MySqlQueries = null;
        MySqlOperations MySqlOperations = null;
        string identify = string.Empty;
        public MainWin()
        {
            InitializeComponent();
            MySqlQueries = new MySqlQueries();
            MySqlOperations = new MySqlOperations(MySqlQueries);
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
                MySqlOperations.Search(toolStripTextBox1, dataGridView1);
            else
            {
                dataGridView1.ClearSelection();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    row.Visible = true;
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlOperations.OpenConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("Не обнаружена база данных или сервер не активен." + '\n' + "Обратитесь к системному администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void отделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdeleniya, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "otdeleniya";
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "doljnosti";
        }

        private void персоналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Personal, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "personal";
        }

        private void филиалыГЦГПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Gcgp, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "gcgp";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Insert_Otdeleniya();
        }

        private void Insert_Otdeleniya()
        {
            Otdeleniya otdeleniya = new Otdeleniya(MySqlOperations);
            otdeleniya.button1.Visible = true;
            otdeleniya.button3.Visible = false;
            otdeleniya.AcceptButton = otdeleniya.button1;
            otdeleniya.Otdeleniya_Closed += отделенияToolStripMenuItem_Click;
            otdeleniya.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Хотите отредактировать запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Edit_String();
        }

        private void Edit_String()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (identify == "otdeleniya")
                    Update_Otdeleniya(row);
            }
        }

        private void Update_Otdeleniya(DataGridViewRow row)
        {
            Otdeleniya otdeleniya = new Otdeleniya(MySqlOperations, row.Cells[0].Value.ToString());
            otdeleniya.textBox1.Text = row.Cells[1].Value.ToString();
            otdeleniya.button3.Visible = true;
            otdeleniya.button1.Visible = false;
            otdeleniya.AcceptButton = otdeleniya.button3;
            otdeleniya.Otdeleniya_Closed += отделенияToolStripMenuItem_Click;
            otdeleniya.Show();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_String();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите удалить запись(-и)?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Delete_String();
                if (identify == "otdeleniya")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Otdeleniya, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    identify = "otdeleniya";
                }
            }
        }

        private void Delete_String()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (identify == "otdeleniya")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Otdeleniya, row.Cells[0].Value.ToString());
            }
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (identify == "otdeleniya")
                Insert_Otdeleniya();
        }
    }
}
