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
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Gcgp, null, maskedTextBox1.Text, textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Gcgp, ID, maskedTextBox1.Text, textBox1.Text);
            this.Close();
        }

        private void Gcgp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Gcgp_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Gcgp_Closed;
    }
}
