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
    public partial class Statistics : Form
    {
        MySqlOperations MySqlOperations = null;
        public Statistics(MySqlOperations mySqlOperations)
        {
            InitializeComponent();
            MySqlOperations = mySqlOperations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            DataTable dataTable = MySqlOperations.Select_DataTable(MySqlOperations.MySqlQueries.Select_Statistics, null, dateTimePicker1.Value.Year.ToString()+"-01-01", dateTimePicker1.Value.Year.ToString() + "-12-31");
            chart.Text = "Статистика заболеваемости за "+dateTimePicker1.Value.Year.ToString()+" год";
            chart.chart1.Series[0].Name = "Количество заболевших";
            chart.chart1.Series[0].Points.Clear();
            chart.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                chart.chart1.Series[0].Points.AddXY(dataTable.Rows[i][1].ToString(), int.Parse(dataTable.Rows[i][0].ToString()));
            }
            chart.Show();
            this.Close();
        }
    }
}
