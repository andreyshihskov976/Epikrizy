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
                this.Close();
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
    }
}
