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
    public partial class Gcgp : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;

        public Gcgp(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Gcgp, null, maskedTextBox1.Text, textBox1.Text) != "1")
            {
                if (maskedTextBox1.Text.Length > 9 && textBox1.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Gcgp, null, maskedTextBox1.Text, textBox1.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Филиал ГЦГП с введенным вами номером и (или) адресом уже существует.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Exists_Gcgp, null, maskedTextBox1.Text, textBox1.Text) != "1")
            {
                if (maskedTextBox1.Text.Length > 9 && textBox1.Text != "")
                {
                    MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Gcgp, ID, maskedTextBox1.Text, textBox1.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Исследование с введенным вами номером и (ил адресом уже существует или изменения не были внесены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Gcgp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gcgp_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Gcgp_Closed;
    }
}
