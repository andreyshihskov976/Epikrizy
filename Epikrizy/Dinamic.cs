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
    public partial class Dinamic : Form
    {
        MySqlOperations MySqlOperations = null;
        public Dinamic(MySqlOperations mySqlOperations)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
            MySqlOperations.Select_ComboBox(MySqlOperations.MySqlQueries.Select_Diagnozy_ComboBox, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            DataTable dataTable = MySqlOperations.Select_DataTable(MySqlOperations.MySqlQueries.Select_Dinamic, MySqlOperations.Select_Text(MySqlOperations.MySqlQueries.Select_ID_Diagnozy_ComboBox, null, comboBox1.Text));
            chart.Text = "Динамика заболеваемости по "+'"'+comboBox1.Text+'"';
            chart.chart1.Series[0].Name = "Количество заболевших";
            chart.chart1.Series[0].Points.Clear();
            chart.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                chart.chart1.Series[0].Points.AddXY(dataTable.Rows[i][1].ToString(), int.Parse(dataTable.Rows[i][0].ToString()));
            }
            chart.Show();
            this.Close();
        }
    }
}
