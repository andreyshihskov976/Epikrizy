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
    public partial class Doljnosti : Form
    {
        MySqlOperations MySqlOperations = null;
        string ID = null;

        public Doljnosti(MySqlOperations mySqlOperations, string iD = null)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Insert_Doljnosti, null, textBox1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlOperations.Insert_Update_Delete(MySqlOperations.MySqlQueries.Update_Doljnosti, ID, textBox1.Text);
            this.Close();
        }

        private void Doljnosti_FormClosed(object sender, FormClosedEventArgs e)
        {
            Doljnosti_Closed(this, EventArgs.Empty);
        }
        public event EventHandler Doljnosti_Closed;
    }
}
