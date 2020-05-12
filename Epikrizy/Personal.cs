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
    public partial class Personal : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;

        public Personal(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Otdeleniya_ComboBox, comboBox1);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Doljnosti_ComboBox, comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Personal, null, textBox1.Text, textBox2.Text, textBox3.Text, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox1.Text), MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Doljnosti_ComboBox, null, comboBox2.Text));
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Personal, ID, textBox1.Text, textBox2.Text, textBox3.Text, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox1.Text), MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Doljnosti_ComboBox, null, comboBox2.Text));
                this.Close();
            }
            else
                MessageBox.Show("Поля не заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Personal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Personal_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Personal_Closed;
    }
}
