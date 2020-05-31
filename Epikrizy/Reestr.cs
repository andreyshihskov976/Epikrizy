﻿using System;
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
    public partial class Reestr : Form
    {
        MySqlOperations MySqlOperations = null;
        string Otdelenie = null;

        public Reestr(MySqlOperations mySqlOperations, string otdelenie)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            Otdelenie = otdelenie;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperations.Print_Reestr(MySqlOperations.MySqlQueries, Otdelenie, dateTimePicker1, dateTimePicker2, saveFileDialog1);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            dateTimePicker2.Value = dateTimePicker1.Value;
        }
    }
}
