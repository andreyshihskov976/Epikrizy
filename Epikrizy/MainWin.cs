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

        private void препаратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Preparaty, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "preparaty";
        }

        private void персоналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Personal, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "personal";
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pacienty, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "pacienty";
        }

        private void филиалыГЦГПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Gcgp, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "gcgp";
        }

        private void лабораторныеИсследованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_LabIssl, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "labIssl";
        }

        private void инструментальныеИсследованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_InstrIssl, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "instrIssl";
        }

        private void диагнозыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlQueries.Select_Diagnozy, dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            identify = "diagnozy";
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

        private void Insert_Doljnosti()
        {
            Doljnosti doljnosti = new Doljnosti(MySqlOperations);
            doljnosti.button1.Visible = true;
            doljnosti.button3.Visible = false;
            doljnosti.AcceptButton = doljnosti.button1;
            doljnosti.Doljnosti_Closed += должностиToolStripMenuItem_Click;
            doljnosti.Show();
        }

        private void Insert_Preparaty()
        {
            Preparaty preparaty = new Preparaty(MySqlOperations);
            preparaty.button1.Visible = true;
            preparaty.button3.Visible = false;
            preparaty.AcceptButton = preparaty.button1;
            preparaty.Preparaty_Closed += препаратыToolStripMenuItem_Click;
            preparaty.Show();
        }

        private void Insert_Gcgp()
        {
            Gcgp gcgp = new Gcgp(MySqlOperations);
            gcgp.button1.Visible = true;
            gcgp.button3.Visible = false;
            gcgp.AcceptButton = gcgp.button1;
            gcgp.Gcgp_Closed += филиалыГЦГПToolStripMenuItem_Click;
            gcgp.Show();
        }

        private void Insert_Personal()
        {
            Personal personal = new Personal(MySqlOperations);
            personal.button1.Visible = true;
            personal.button3.Visible = false;
            personal.AcceptButton = personal.button1;
            personal.Personal_Closed += персоналToolStripMenuItem_Click;
            personal.Show();
        }

        private void Insert_Pacienty()
        {
            Pacienty pacienty = new Pacienty(MySqlOperations);
            pacienty.button1.Visible = true;
            pacienty.button3.Visible = false;
            pacienty.AcceptButton = pacienty.button1;
            pacienty.Pacienty_Closed += пациентыToolStripMenuItem_Click;
            pacienty.Show();
        }

        private void Insert_LabIssl()
        {
            LabIssl labIssl = new LabIssl(MySqlOperations);
            labIssl.button1.Visible = true;
            labIssl.button3.Visible = false;
            labIssl.AcceptButton = labIssl.button1;
            labIssl.LabIssl_Closed += лабораторныеИсследованияToolStripMenuItem_Click;
            labIssl.Show();
        }

        private void Insert_InstrIssl()
        {
            InstrIssl instrIssl = new InstrIssl(MySqlOperations);
            instrIssl.button1.Visible = true;
            instrIssl.button3.Visible = false;
            instrIssl.AcceptButton = instrIssl.button1;
            instrIssl.InstrIssl_Closed += инструментальныеИсследованияToolStripMenuItem_Click;
            instrIssl.Show();
        }

        private void Insert_Diagnozy()
        {
            Diagnozy diagnozy = new Diagnozy(MySqlOperations);
            diagnozy.button1.Visible = true;
            diagnozy.button3.Visible = false;
            diagnozy.AcceptButton = diagnozy.button1;
            diagnozy.Diagnozy_Closed += диагнозыToolStripMenuItem_Click;
            diagnozy.Show();
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (identify == "otdeleniya")
                Insert_Otdeleniya();
            if (identify == "doljnosti")
                Insert_Doljnosti();
            if (identify == "preparaty")
                Insert_Preparaty();
            if (identify == "gcgp")
                Insert_Gcgp();
            if (identify == "personal")
                Insert_Personal();
            if (identify == "pacienty")
                Insert_Pacienty();
            if (identify == "labIssl")
                Insert_LabIssl();
            if (identify == "instrIssl")
                Insert_LabIssl();
            if (identify == "diagnozy")
                Insert_Diagnozy();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Insert_Otdeleniya();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Insert_Doljnosti();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Insert_Preparaty();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Insert_Gcgp();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Insert_Personal();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Insert_Pacienty();
        }
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Insert_LabIssl();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Insert_InstrIssl();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Insert_Diagnozy();
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

        private void Update_Doljnosti(DataGridViewRow row)
        {
            Doljnosti doljnosti = new Doljnosti(MySqlOperations, row.Cells[0].Value.ToString());
            doljnosti.textBox1.Text = row.Cells[1].Value.ToString();
            doljnosti.button3.Visible = true;
            doljnosti.button1.Visible = false;
            doljnosti.AcceptButton = doljnosti.button3;
            doljnosti.Doljnosti_Closed += должностиToolStripMenuItem_Click;
            doljnosti.Show();
        }

        private void Update_Preparaty(DataGridViewRow row)
        {
            Preparaty preparaty = new Preparaty(MySqlOperations, row.Cells[0].Value.ToString());
            preparaty.textBox1.Text = row.Cells[1].Value.ToString();
            preparaty.button3.Visible = true;
            preparaty.button1.Visible = false;
            preparaty.AcceptButton = preparaty.button3;
            preparaty.Preparaty_Closed += препаратыToolStripMenuItem_Click;
            preparaty.Show();
        }

        private void Update_Gcgp(DataGridViewRow row)
        {
            Gcgp gcgp = new Gcgp(MySqlOperations, row.Cells[0].Value.ToString());
            gcgp.maskedTextBox1.Text = row.Cells[1].Value.ToString();
            gcgp.textBox1.Text = row.Cells[2].Value.ToString();
            gcgp.button3.Visible = true;
            gcgp.button1.Visible = false;
            gcgp.AcceptButton = gcgp.button3;
            gcgp.Gcgp_Closed += филиалыГЦГПToolStripMenuItem_Click;
            gcgp.Show();
        }

        private void Update_Personal(DataGridViewRow row)
        {
            Personal personal = new Personal(MySqlOperations, row.Cells[0].Value.ToString());
            personal.textBox1.Text = row.Cells[1].Value.ToString().Split(' ')[0];
            personal.textBox2.Text = row.Cells[1].Value.ToString().Split(' ')[1];
            personal.textBox3.Text = row.Cells[1].Value.ToString().Split(' ')[2];
            MySqlOperations.Search_In_ComboBox(row.Cells[2].Value.ToString(), personal.comboBox1);
            MySqlOperations.Search_In_ComboBox(row.Cells[3].Value.ToString(), personal.comboBox2);
            personal.AcceptButton = personal.button3;
            personal.Personal_Closed += персоналToolStripMenuItem_Click;
            personal.Show();
        }

        private void Update_Pacienty(DataGridViewRow row)
        {
            Pacienty pacienty = new Pacienty(MySqlOperations, row.Cells[0].Value.ToString());
            pacienty.textBox1.Text = row.Cells[1].Value.ToString().Split(' ')[0];
            pacienty.textBox2.Text = row.Cells[1].Value.ToString().Split(' ')[1];
            pacienty.textBox3.Text = row.Cells[1].Value.ToString().Split(' ')[2];
            pacienty.dateTimePicker1.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            pacienty.textBox4.Text = row.Cells[3].Value.ToString();
            MySqlOperations.Search_In_ComboBox(row.Cells[4].Value.ToString(), pacienty.comboBox1);
            pacienty.AcceptButton = pacienty.button3;
            pacienty.Pacienty_Closed += пациентыToolStripMenuItem_Click;
            pacienty.Show();
        }

        private void Update_LabIssl(DataGridViewRow row)
        {
            LabIssl labIssl = new LabIssl(MySqlOperations, row.Cells[0].Value.ToString());
            labIssl.textBox1.Text = row.Cells[1].Value.ToString();
            labIssl.groupBox1.Visible = true;
            labIssl.groupBox2.Visible = true;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl, labIssl.dataGridView1, row.Cells[0].Value.ToString());
            labIssl.dataGridView1.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_LabIssl, labIssl.dataGridView2, row.Cells[0].Value.ToString());
            labIssl.dataGridView2.Columns[0].Visible = false;
            labIssl.AcceptButton = labIssl.button3;
            labIssl.LabIssl_Closed += лабораторныеИсследованияToolStripMenuItem_Click;
            labIssl.Show();
        }

        private void Update_InstrIssl(DataGridViewRow row)
        {
            InstrIssl instrIssl = new InstrIssl(MySqlOperations, row.Cells[0].Value.ToString());
            instrIssl.textBox1.Text = row.Cells[1].Value.ToString();
            instrIssl.groupBox1.Visible = true;
            instrIssl.groupBox2.Visible = true;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_InstrIssl, instrIssl.dataGridView1, row.Cells[0].Value.ToString());
            instrIssl.dataGridView1.Columns[0].Visible = false;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Otdeleniya_InstrIssl, instrIssl.dataGridView2, row.Cells[0].Value.ToString());
            instrIssl.dataGridView2.Columns[0].Visible = false;
            instrIssl.AcceptButton = instrIssl.button3;
            instrIssl.InstrIssl_Closed += инструментальныеИсследованияToolStripMenuItem_Click;
            instrIssl.Show();
        }

        private void Update_Diagnozy(DataGridViewRow row)
        {
            Diagnozy diagnozy = new Diagnozy(MySqlOperations, row.Cells[0].Value.ToString());
            diagnozy.textBox1.Text = row.Cells[1].Value.ToString();
            diagnozy.groupBox2.Visible = true;
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Lechenie, diagnozy.dataGridView2, row.Cells[0].Value.ToString());
            diagnozy.dataGridView2.Columns[0].Visible = false;
            diagnozy.AcceptButton = diagnozy.button3;
            diagnozy.Diagnozy_Closed += диагнозыToolStripMenuItem_Click;
            diagnozy.Show();
        }

        private void Edit_String()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (identify == "otdeleniya")
                    Update_Otdeleniya(row);
                if (identify == "doljnosti")
                    Update_Doljnosti(row);
                if (identify == "preparaty")
                    Update_Preparaty(row);
                if (identify == "otdeleniya")
                    Update_Otdeleniya(row);
                if (identify == "gcgp")
                    Update_Gcgp(row);
                if (identify == "personal")
                    Update_Personal(row);
                if (identify == "pacienty")
                    Update_Pacienty(row);
                if (identify == "labIssl")
                    Update_LabIssl(row);
                if (identify == "instrIssl")
                    Update_InstrIssl(row);
                if (identify == "diagnozy")
                    Update_Diagnozy(row);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Хотите отредактировать запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Edit_String();
            dataGridView1.ClearSelection(); 
        }


        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_String();
        }

        private void Delete_String()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (identify == "otdeleniya")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Otdeleniya, row.Cells[0].Value.ToString());
                if (identify == "doljnosti")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Doljnosti, row.Cells[0].Value.ToString());
                if (identify == "preparaty")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Preparaty, row.Cells[0].Value.ToString());
                if (identify == "gcgp")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Gcgp, row.Cells[0].Value.ToString());
                if (identify == "personal")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Personal, row.Cells[0].Value.ToString());
                if (identify == "pacienty")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Pacienty, row.Cells[0].Value.ToString());
                if (identify == "labIssl")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_LabIssl, row.Cells[0].Value.ToString());
                if (identify == "instrIssl")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_InstrIssl, row.Cells[0].Value.ToString());
                if (identify == "diagnozy")
                    MySqlOperations.Insert_Update_Delete(MySqlQueries.Delete_Diagnozy, row.Cells[0].Value.ToString());
            }
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
                    dataGridView1.ClearSelection();
                    identify = "otdeleniya";
                }
                if (identify == "doljnosti")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Doljnosti, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "doljnosti";
                }
                if (identify == "preparaty")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Preparaty, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "doljnosti";
                }
                if (identify == "gcgp")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Gcgp, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "gcgp";
                }
                if (identify == "personal")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Personal, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "personal";
                }
                if (identify == "pacienty")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Pacienty, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "pacienty";
                }
                if (identify == "labIssl")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_LabIssl, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "labIssl";
                }
                if (identify == "instrIssl")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_InstrIssl, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "instrIssl";
                }
                if (identify == "diagnozy")
                {
                    MySqlOperations.Select_DataGridView(MySqlQueries.Select_Diagnozy, dataGridView1);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.ClearSelection();
                    identify = "diagnozy";
                }
            }
        }

        private void вклвыклПереносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DefaultCellStyle.WrapMode == DataGridViewTriState.False)
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            else
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DefaultCellStyle.WrapMode == DataGridViewTriState.False)
                dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            else
                dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            if (toolStripMenuItem6.Text == "->")
                toolStripMenuItem6.Text = "<-";
            else
                toolStripMenuItem6.Text = "->";
        }
    }
}
