using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;
using Application = System.Windows.Forms.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using WordApplication = Microsoft.Office.Interop.Word.Application;
using System.Threading.Tasks;
using System.Reflection;
using DataTable = System.Data.DataTable;
using XlLineStyle = Microsoft.Office.Interop.Excel.XlLineStyle;

namespace Epikrizy
{
    public class MySqlOperations
    {
        public MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=vypisnie_epikrizy; port=3306; password=; charset=utf8;");
        public MySqlQueries MySqlQueries = null;

        MySqlDataReader sqlDataReader = null;

        MySqlDataAdapter dataAdapter = null;

        DataSet dataSet = null;

        MySqlCommand sqlCommand = null;

        public MySqlOperations(MySqlQueries sqlQueries)
        {
            this.MySqlQueries = sqlQueries;
        }
        //Подключение (Закрытие подключения) к Базе Данных
        public void OpenConnection()
        {
            mySqlConnection.Open();
        }
        public void CloseConnection()
        {
            mySqlConnection.Close();
        }
        //Подключение (Закрытие подключения) к Базе Данных

        //Универсальные методы
        public void Select_DataGridView(string query, DataGridView dataGridView, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null)
        {
            try
            {
                dataGridView.DataSource = null;
                dataSet = new DataSet();
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                dataAdapter = new MySqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataSet);
                dataGridView.DataSource = dataSet.Tables[0].DefaultView;
                dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Select_DataTable(string query, string ID = null, string Value1 = null, string Value2 = null)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand sqlCommand = new MySqlCommand(query, mySqlConnection);
            sqlCommand.Parameters.AddWithValue("ID", ID);
            sqlCommand.Parameters.AddWithValue("Value1", Value1);
            sqlCommand.Parameters.AddWithValue("Value2", Value2);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void Select_ComboBox(string query, ComboBox comboBox, string ID = null, string Value1 = null, string Value2 = null)
        {
            try
            {
                comboBox.Items.Clear();
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(Convert.ToString(sqlDataReader[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                if (comboBox.Items.Count != 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public void Search_In_ComboBox(string s, ComboBox comboBox)
        {
            bool result = false;
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Contains(s))
                {
                    comboBox.SelectedIndex = i;
                    result = true;
                    break;
                }
            }
            if (!result)
            {
                comboBox.Items.Add(s);
                comboBox.SelectedItem = s;
            }
        }

        public string Select_Text(string query, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            string output = string.Empty;
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    output = Convert.ToString(sqlDataReader[0]);
                    break;
                }
                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }

        public void Select_List(string query, ref ArrayList list, string ID = null, string Value1 = null, string Value2 = null, string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null, string Value7 = null, string Value8 = null)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(Convert.ToString(sqlDataReader[0]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
            }
        }

        public void Insert_Update_Delete(string query, string ID = null, string Value1 = null, string Value2 = null,
            string Value3 = null, string Value4 = null, string Value5 = null, string Value6 = null,
            string Value7 = null, string Value8 = null, string Value9 = null, string Value10 = null, 
            string Value11 = null, string Value12 = null, string Value13 = null, string Value14 = null, 
            string Value15 = null, string Value16 = null, string Value17 = null)
        {
            try
            {
                sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("Value1", Value1);
                sqlCommand.Parameters.AddWithValue("Value2", Value2);
                sqlCommand.Parameters.AddWithValue("Value3", Value3);
                sqlCommand.Parameters.AddWithValue("Value4", Value4);
                sqlCommand.Parameters.AddWithValue("Value5", Value5);
                sqlCommand.Parameters.AddWithValue("Value6", Value6);
                sqlCommand.Parameters.AddWithValue("Value7", Value7);
                sqlCommand.Parameters.AddWithValue("Value8", Value8);
                sqlCommand.Parameters.AddWithValue("Value9", Value9);
                sqlCommand.Parameters.AddWithValue("Value10", Value10);
                sqlCommand.Parameters.AddWithValue("Value11", Value11);
                sqlCommand.Parameters.AddWithValue("Value12", Value12);
                sqlCommand.Parameters.AddWithValue("Value13", Value13);
                sqlCommand.Parameters.AddWithValue("Value14", Value14);
                sqlCommand.Parameters.AddWithValue("Value15", Value15);
                sqlCommand.Parameters.AddWithValue("Value16", Value16);
                sqlCommand.Parameters.AddWithValue("Value17", Value17);
                sqlCommand.Parameters.AddWithValue("ID", ID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Search(ToolStripTextBox textBox, DataGridView dataGridView)
        {
            if (textBox.Text != "")
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                            if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text))
                            {
                                dataGridView.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else dataGridView.ClearSelection();
        }

        public void Filter(ToolStripTextBox textBox, DataGridView dataGridView)
        {
            if (textBox.Text != "")
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                            if (dataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox.Text) == true)
                            {
                                dataGridView.CurrentCell = dataGridView.Rows[i].Cells[1];
                                dataGridView.Rows[i].Visible = true;
                                break;
                            }
                            else
                            {
                                dataGridView.Rows[i].Visible = false;
                                break;
                            }
                }
            }
            else dataGridView.ClearSelection();
        }

        private void Replace(string Identify, string Text, Document document)
        {
            var range = document.Content;
            range.Find.Execute(FindText: Identify, ReplaceWith: Text);
        }

        public void Print_Epikriz(SaveFileDialog saveFileDialog, string ID, DialogResult dialog)
        {
            WordApplication WordApp = null;
            Documents Documents = null;
            Document Document = null;
            string output = null;
            string fileName = null;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            saveFileDialog.DefaultExt = "Документ Word|*.docx";
            saveFileDialog.Filter = "Документ Word|*.docx|Документ Word 93-2003|*.doc|PDF|*.pdf";
            saveFileDialog.Title = "Сохранить выписной эпикриз как";
            output = Select_Text(MySqlQueries.Print_Epikrizy, ID);
            saveFileDialog.FileName = output.Split(';')[0];
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Выписные эпикризы\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = saveFileDialog.FileName;
                    WordApp = new WordApplication();
                    Documents = WordApp.Documents;
                    Document = Documents.Open(Application.StartupPath + "\\blanks\\epikriz.docx");
                    string pol = Select_Text(MySqlQueries.Select_Pol_Pacienta, ID);
                    if (pol == "М")
                    {
                        Replace("{graj}", "Гражданин", Document);
                        Replace("{proj}", "проживающий", Document);
                        Replace("{nahod}", "находился", Document);
                    }
                    else if(pol == "Ж")
                    {
                        Replace("{graj}", "Гражданка", Document);
                        Replace("{proj}", "проживающая", Document);
                        Replace("{nahod}", "находилась", Document);
                    }
                    Replace("{id}", output.Split(';')[1], Document);
                    Replace("{pacient}", output.Split(';')[2], Document);
                    Replace("{adress_pacienta}", output.Split(';')[3], Document);
                    Replace("{filial}", output.Split(';')[4].Split(' ')[2], Document);
                    Replace("{otdelenie}", output.Split(';')[5], Document);
                    Replace("{date_n}", output.Split(';')[6], Document);
                    Replace("{date_k}", output.Split(';')[7], Document);
                    Replace("{sost_vypiski}", output.Split(';')[8].ToLower(), Document);
                    Replace("{lvn_n}", output.Split(';')[9], Document);
                    Replace("{lvn_k}", output.Split(';')[10], Document);
                    Replace("{recomendacii}", output.Split(';')[11], Document);
                    Replace("{lech_vrach}", output.Split(';')[12], Document);

                    dt = Select_DataTable(MySqlQueries.Print_Diagnozy_Pacienta, ID);
                    output = "";
                    foreach(DataRow row in dt.Rows)
                        output += row[0].ToString();
                    Replace("{diagnozy_pacienta}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Perenesennye_Operacii, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString();
                    Replace("{perenesennye_operacii}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Zaklucheniya_Pacienta, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString();
                    Replace("{zaklucheniya}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Preparaty, ID);
                    output = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i != dt.Rows.Count - 1)
                            output += dt.Rows[i][0].ToString() + ", ";
                        else
                            output += dt.Rows[i][0].ToString() + ".";
                    }
                    Replace("{preparaty}", output, Document);

                    output = "";
                    dt = Select_DataTable(MySqlQueries.Print_Proved_LabIssl, ID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        output += dt.Rows[i][1].ToString();
                        dt2 = Select_DataTable(MySqlQueries.Print_Dannye_LabIssl, ID, dt.Rows[i][0].ToString());
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (j != dt2.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + ", ";
                            else if (i != dt.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + "."+ '\r'+'\t';
                            else
                                output += dt2.Rows[j][0].ToString() + ".";
                        }
                    }
                    Replace("{lab_issl}", output, Document);

                    output = "";
                    dt = Select_DataTable(MySqlQueries.Print_Proved_InstrIssl, ID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        output += dt.Rows[i][1].ToString();
                        dt2 = Select_DataTable(MySqlQueries.Print_Dannye_InstrIssl, ID, dt.Rows[i][0].ToString());
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (j != dt2.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + ", ";
                            else if (i != dt.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + "." + '\r' + '\t';
                            else
                                output += dt2.Rows[j][0].ToString() + ".";
                        }
                    }
                    Replace("{instr_issl}", output, Document);

                    output = Select_Text(MySqlQueries.Print_Dop_Sved, ID);
                    if (output != "" && output != null)
                        for (int i = 0; i < 16; i++)
                            Replace("{ds" + i.ToString() + "}", output.Split(';')[i], Document);
                    else
                        for (int i = 0; i < 16; i++)
                            Replace("{ds" + i.ToString() + "}", "", Document);

                    output = Select_Text(MySqlQueries.Print_Zav_Otdeleniya, ID);
                    Replace("{zav_otdeleniya}", output, Document);

                    Document.SaveAs(fileName);
                    if (dialog == DialogResult.Yes)
                        WordApp.Quit();
                    if (dialog == DialogResult.No) 
                    {
                        WordApp.PrintPreview = true;
                        WordApp.Visible = true; 
                    }
                    if (dialog == DialogResult.Cancel) 
                    {
                        WordApp.PrintOut();
                        WordApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Marshal.ReleaseComObject(Documents);
                    Marshal.ReleaseComObject(Document);
                    Marshal.ReleaseComObject(WordApp);
                }
                finally
                {
                    Marshal.ReleaseComObject(Documents);
                    Marshal.ReleaseComObject(Document);
                    Marshal.ReleaseComObject(WordApp);
                }
            }
        }

        public void Rukovodstvo()
        {
            WordApplication WordApp = null;
            Documents Documents = null;
            Document Document = null;
            WordApp = new WordApplication();
            Documents = WordApp.Documents;
            Document = Documents.Open(Application.StartupPath + "\\blanks\\spravka.docx");
            WordApp.Visible = true;
        }

        public void Print_Kartochka(SaveFileDialog saveFileDialog, string ID, DialogResult dialog)
        {
            WordApplication WordApp = null;
            Documents Documents = null;
            Document Document = null;
            string output = null;
            string fileName = null;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            saveFileDialog.DefaultExt = "Документ Word|*.docx";
            saveFileDialog.Filter = "Документ Word|*.docx|Документ Word 93-2003|*.doc|PDF|*.pdf";
            saveFileDialog.Title = "Сохранить личную карточку пациента как";
            output = Select_Text(MySqlQueries.Print_Kartochka_Pacienta, ID);
            saveFileDialog.FileName = output.Split(';')[0];
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Личные карточки\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = saveFileDialog.FileName;
                    WordApp = new WordApplication();
                    Documents = WordApp.Documents;
                    Document = Documents.Open(Application.StartupPath + "\\blanks\\kartochka.docx");
                    string pol = Select_Text(MySqlQueries.Select_Pol_Pacienta_Kartochka, ID);
                    if (pol == "М")
                    {
                        Replace("{graj}", "Гражданин", Document);
                        Replace("{proj}", "проживает", Document);
                        Replace("{nahod}", "НАХОДИЛСЯ", Document);
                    }
                    else if (pol == "Ж")
                    {
                        Replace("{graj}", "Гражданка", Document);
                        Replace("{proj}", "проживающая", Document);
                        Replace("{nahod}", "НАХОДИЛАСЬ", Document);
                    }
                    Replace("{id}", output.Split(';')[1], Document);
                    Replace("{pacient}", output.Split(';')[2], Document);
                    Replace("{pacient}", output.Split(';')[2], Document);
                    Replace("{adress_pacienta}", output.Split(';')[3], Document);
                    Replace("{filial}", output.Split(';')[4].Split(' ')[2], Document);

                    dt = Select_DataTable(MySqlQueries.Print_Otdeleniya_Pacienta, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString() + '\r' + '\t';
                    Replace("{otdelenie}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Perenes_Zabol_Pacienta, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString() + '\r' + '\t';
                    Replace("{zaklucheniya}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Perenesennye_Operacii_Pacienta, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString() + '\r' + '\t';
                    Replace("{perenesennye_operacii}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Recomendacii_Pacienta, ID);
                    output = "";
                    foreach (DataRow row in dt.Rows)
                        output += row[0].ToString()+'\r'+'\t';
                    Replace("{recomendacii}", output, Document);

                    dt = Select_DataTable(MySqlQueries.Print_Preparaty_Pacienta, ID);
                    output = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i != dt.Rows.Count - 1)
                            output += dt.Rows[i][0].ToString() + ", ";
                        else
                            output += dt.Rows[i][0].ToString() + ".";
                    }
                    Replace("{preparaty}", output, Document);

                    output = "";
                    dt = Select_DataTable(MySqlQueries.Print_Proved_LabIssl_Pacienta, ID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        output += dt.Rows[i][1].ToString();
                        dt2 = Select_DataTable(MySqlQueries.Print_Dannye_LabIssl_Pacienta, ID, dt.Rows[i][0].ToString());
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (j != dt2.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + ", ";
                            else if (i != dt.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + "." + '\r' + '\t';
                            else
                                output += dt2.Rows[j][0].ToString() + ".";
                        }
                    }
                    Replace("{lab_issl}", output, Document);

                    output = "";
                    dt = Select_DataTable(MySqlQueries.Print_Proved_InstrIssl_Pacienta, ID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        output += dt.Rows[i][1].ToString();
                        dt2 = Select_DataTable(MySqlQueries.Print_Dannye_InstrIssl_Pacienta, ID, dt.Rows[i][0].ToString());
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (j != dt2.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + ", ";
                            else if (i != dt.Rows.Count - 1)
                                output += dt2.Rows[j][0].ToString() + "." + '\r' + '\t';
                            else
                                output += dt2.Rows[j][0].ToString() + ".";
                        }
                    }
                    Replace("{instr_issl}", output, Document);

                    Document.SaveAs(fileName);
                    if (dialog == DialogResult.Yes)
                        WordApp.Quit();
                    if (dialog == DialogResult.No)
                    {
                        WordApp.PrintPreview = true;
                        WordApp.Visible = true;
                    }
                    if (dialog == DialogResult.Cancel)
                    {
                        WordApp.PrintOut();
                        WordApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Marshal.ReleaseComObject(Documents);
                    Marshal.ReleaseComObject(Document);
                    Marshal.ReleaseComObject(WordApp);
                }
                finally
                {
                    Marshal.ReleaseComObject(Documents);
                    Marshal.ReleaseComObject(Document);
                    Marshal.ReleaseComObject(WordApp);
                }
            }
        }

        public void Print_Reestr(MySqlQueries mySqlQueries, string otdelenie, DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2, SaveFileDialog saveFileDialog, DialogResult dialog)
        {
            ExcelApplication ExcelApp = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            Worksheet worksheet = null;
            string fileName = null;
            saveFileDialog.DefaultExt = "Книга Excel|*.xlsx";
            saveFileDialog.Filter = "Книга Excel|*.xlsx|Книга Excel 93-2003|*.xls|PDF|*.pdf";
            saveFileDialog.Title = "Сохранить реестр эпикризов как";
            saveFileDialog.FileName = "Реестр эпикризов отделения " + otdelenie + " с " + dateTimePicker1.Value.ToShortDateString() + " по " + dateTimePicker2.Value.ToShortDateString();
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Реестры эпикризов\\";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                string id = Select_Text(MySqlQueries.Select_ID_Otdeleniya_ComboBox, null, otdelenie);
                string date1 = dateTimePicker1.Value.Year.ToString() + '-' + dateTimePicker1.Value.Month.ToString() + '-' + dateTimePicker1.Value.Day.ToString();
                string date2 = dateTimePicker2.Value.Year.ToString() + '-' + dateTimePicker2.Value.Month.ToString() + '-' + dateTimePicker2.Value.Day.ToString();
                DataTable data = Select_DataTable(MySqlQueries.Print_Reestr, id, date1, date2);
                try
                {
                    ExcelApp = new ExcelApplication();
                    workbooks = ExcelApp.Workbooks;
                    workbook = workbooks.Open(Application.StartupPath + "\\blanks\\reestr.xlsx");
                    worksheet = workbook.Worksheets.get_Item(1) as Worksheet;
                    ExcelApp.Cells[1, 1] = "Реестр выписных эпикризов отделения " + '"' + otdelenie + '"';
                    ExcelApp.Cells[2, 1] = "c " + dateTimePicker1.Value.ToShortDateString() + " по " + dateTimePicker2.Value.ToShortDateString();
                    int ExCol = 1;
                    int ExRow = 5;
                    for (int i = 0; i < data.Rows.Count - 0; i++)
                    {
                        ExCol = 1;
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            ExcelApp.Cells[ExRow, ExCol] = data.Rows[i][j].ToString();
                            ExCol++;
                        }
                        ExRow++;
                    }
                    var cells = worksheet.get_Range("A4 ", "E" + (ExRow - 1).ToString());
                    cells.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                    cells.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                    cells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    cells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    cells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    cells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    workbook.SaveAs(fileName);
                    if (dialog == DialogResult.Yes)
                        ExcelApp.Quit();
                    if (dialog == DialogResult.No)
                    {
                        workbook.PrintPreview();
                        ExcelApp.Visible = true;
                    }
                    if (dialog == DialogResult.Cancel)
                    {
                        workbook.PrintOut();
                        ExcelApp.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(ExcelApp);
                }
            }
        }

        public static Task<object> GetTaskFromEvent(object @object, string @event)
        {
            if (@object == null || @event == null) throw new ArgumentNullException("Arguments cannot be null");

            EventInfo EventInfo = @object.GetType().GetEvent(@event);
            if (EventInfo == null)
            {
                throw new ArgumentException(String.Format("*{0}* has no *{1}* event", @object, @event));
            }

            TaskCompletionSource<object> TaskComleteSource = new TaskCompletionSource<object>();
            MethodInfo MethodInfo = null;
            Delegate Delegate = null;
            EventHandler Handler = null;

            Handler = (s, e) =>
            {
                MethodInfo = Handler.Method;
                Delegate = Delegate.CreateDelegate(EventInfo.EventHandlerType, Handler.Target, MethodInfo);
                EventInfo.RemoveEventHandler(s, Delegate);
                TaskComleteSource.TrySetResult(null);
            };

            MethodInfo = Handler.Method;
            Delegate = Delegate.CreateDelegate(EventInfo.EventHandlerType, Handler.Target, MethodInfo);
            EventInfo.AddEventHandler(@object, Delegate);
            return TaskComleteSource.Task;
        }
    }
}
