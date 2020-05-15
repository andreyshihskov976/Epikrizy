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
    public partial class Epikrizy : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;
        string ID_Pacienta = null;
        string ID_Otdeleniya = null;

        public Epikrizy(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Pacienty_ComboBox, comboBox1);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Otdeleniya_ComboBox, comboBox4);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Diagnozy_ComboBox, comboBox2);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_LabIssl_ComboBox, comboBox3);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_InstrIssl_ComboBox, comboBox5);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID_Otdeleniya = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, comboBox4.Text);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Lech_Vrach_ComboBox, comboBox6, null, ID_Otdeleniya);
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_LabIssl_ComboBox, comboBox3, null, ID_Otdeleniya);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlOperations.Select_DataGridView(MySqlOperations.MySqlQueries.Select_Pokazat_LabIssl_Insert_Epikrizy, dataGridView3, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_LabIssl_ComboBox, null, comboBox3.Text));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID_Pacienta = MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Pacienty_ComboBox, null, comboBox1.Text);
        }
    }
}
