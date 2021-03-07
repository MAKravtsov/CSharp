using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Diploma
{
    public partial class DifficultForm : Form
    {
        // Массив под проверку на дурака
        private string[] ArrForDurak = new string[Help.Detail.Length];

        // Переменная для того, чтобы не повторялось сообщение - Не все ячейки заполнены
        private bool RepeatIndexChanges = true;

        private int OrderDetailInRoute = 1;
        public DifficultForm()
        {
            InitializeComponent();

            // Добавляем элементы в комбобокс

            comboBox.Items.AddRange(Help.Detail);

            // Создаем кучу таблиц

            for (int i = 0; i < Help.Detail.Length; i++)
            {
                // Создаем массив таблиц для маршрутов

                dataGridViews1[i] = new DataGridView();

                // Событие нажатия мышки
                dataGridViews1[i].MouseClick += new MouseEventHandler(dataGridViews1_CellMouseClick);
                this.Controls.Add(dataGridViews1[i]);
                ViewTable(dataGridViews1[i], 139, 3, 634, 73, 1, 0);
                dataGridViews1[i].Visible = false;

                // Создаем массив таблиц времени обработки деталей

                dataGridViews2[i] = new DataGridView();

                dataGridViews2[i].MouseClick += new MouseEventHandler(dataGridViews2_CellMouseClick);
                this.Controls.Add(dataGridViews2[i]);
                ViewTable(dataGridViews2[i], 139, 82, 634, 80, 1, 1);
                dataGridViews2[i].Visible = false;

                // Создаем массив таблиц времени переналадки

                dataGridViews3[i] = new DataGridView();

                dataGridViews3[i].MouseClick += new MouseEventHandler(dataGridViews3_CellMouseClick);
                this.Controls.Add(dataGridViews3[i]);
                ViewTable(dataGridViews3[i], 139, 168, 634, 82, 1, 2);
                dataGridViews3[i].Visible = false;

                // Создаем массив таблиц себестоимости деталей
                dataGridViews4[i] = new DataGridView();

                dataGridViews4[i].MouseClick += new MouseEventHandler(dataGridViews4_CellMouseClick);
                this.Controls.Add(dataGridViews4[i]);
                ViewTable(dataGridViews4[i], 139, 256, 634, 75, 1, 3);
                dataGridViews4[i].Visible = false;

            }

        }

        // Переменная под прошлые таблицы
        private int CountLast = -1;

        // массив таблиц
        public DataGridView[] dataGridViews1 = new DataGridView[Help.Detail.Length];
        public DataGridView[] dataGridViews2 = new DataGridView[Help.Detail.Length];
        public DataGridView[] dataGridViews3 = new DataGridView[Help.Detail.Length];
        public DataGridView[] dataGridViews4 = new DataGridView[Help.Detail.Length];


        /// <summary>
        /// Метод создания таблицы
        /// </summary>
        /// <param name="Table"></param>
        private void ViewTable(DataGridView Table, int loc1, int loc2, int size1, int size2, int e1, int e2)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1
                    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2
                    = new System.Windows.Forms.DataGridViewCellStyle();

            // Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            // | System.Windows.Forms.AnchorStyles.Bottom)
            // | System.Windows.Forms.AnchorStyles.Left)
            // | System.Windows.Forms.AnchorStyles.Right)));

            this.tableLayoutPanel1.Controls.Add(Table, e1, e2);
            Table.Dock = System.Windows.Forms.DockStyle.Fill;
            Table.AllowUserToAddRows = false;
            Table.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            Table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            Table.DefaultCellStyle = dataGridViewCellStyle1;
            Table.Location = new System.Drawing.Point(loc1, loc2);
            Table.Name = "Table";
            Table.Size = new System.Drawing.Size(size1, size2);
            Table.TabIndex = 0;

        }

        /// <summary>
        /// Не выделять ячейки в начале
        /// </summary>
        /// <param name="dataGridView"></param>
        private void NoSelected(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    dataGridView.Rows[j].Cells[i].Selected = false;
                }
            }
        }

        /// <summary>
        /// Заполнение первых таблиц
        /// </summary>
        /// <param name="k"></param>
        private void FirstTable(int k)
        {
            dataGridViews1[k].Visible = true;

            // Количество строк и столбцов


            dataGridViews1[k].RowCount = int.Parse(Detail.DetArr[0, k]);
            dataGridViews1[k].ColumnCount = Help.Equipment.Count();

            // Заголовки

            for (int i = 0; i < Help.Equipment.Length; i++)
            {
                dataGridViews1[k].Columns[i].HeaderCell.Value = Help.Equipment[i];
            }

            for (int i = 0; i < int.Parse(Detail.DetArr[0, k]); i++)
            {
                dataGridViews1[k].Rows[i].HeaderCell.Value = $"Маршрут{i}";
                dataGridViews1[k].Rows[i].ReadOnly = true;
            }

            // Чтобы убрать выделение ячеек в начале

            NoSelected(dataGridViews1[k]);

            // Внешний вид таблиц

            Help.LookLike(dataGridViews1[k], 100, 25);

            CountLast = k;
        }

        /// <summary>
        /// Метод под 2 и 3 таблицы
        /// </summary>
        /// <param name="k"></param>
        /// <param name="dataGridView"></param>
        private void SecondTable(int k, DataGridView dataGridView)
        {
            dataGridView.Visible = true;

            // Количество строк и столбцов
            dataGridView.RowCount = int.Parse(Detail.DetArr[0, k]);
            dataGridView.ColumnCount = Help.Equipment.Count();

            // Заголовки

            for (int i = 0; i < Help.Equipment.Length; i++)
            {
                dataGridView.Columns[i].HeaderCell.Value = Help.Equipment[i];
            }

            for (int i = 0; i < int.Parse(Detail.DetArr[0, k]); i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = $"Маршрут{i}";
            }

            // Чтобы убрать выделение ячеек в начале

            NoSelected(dataGridView);

            // Если первая таблица - зеленая, вторая и третья - не красные
            for (int i = 0; i < dataGridViews1[k].ColumnCount; i++)
            {
                for (int j = 0; j < dataGridViews1[k].RowCount; j++)
                {

                    if (dataGridViews1[k][i, j].Style.BackColor != Color.Green)
                    {
                        if (dataGridView[i, j].Value == null)
                        {
                            dataGridView[i, j].Style.BackColor = Color.Red;
                            dataGridView[i, j].ReadOnly = true;
                        }
                        else
                        {
                            dataGridView[i, j].Value = null;
                            dataGridView[i, j].Style.BackColor = Color.Red;
                            dataGridView[i, j].ReadOnly = true;
                        }
                    }
                    else
                    {
                        dataGridView[i, j].Style.BackColor = Color.White;
                        dataGridView[i, j].ReadOnly = false;
                    }
                }
            }

            // Внешний вид таблицы

            Help.LookLike(dataGridView, 100, 25);
        }

        private void ForthTable(int k)
        {
            dataGridViews4[k].Visible = true;

            // Количество строк и столбцов 
            dataGridViews4[k].RowCount = int.Parse(Detail.DetArr[0, k]);
            dataGridViews4[k].ColumnHeadersVisible = false;

            // Ее заполнение

            for (int i = 0; i < int.Parse(Detail.DetArr[0, k]); i++)
            {
                dataGridViews4[k].Rows[i].HeaderCell.Value = $"Маршрут{i}";
            }

            // Чтобы убрать выделение ячеек в начале

            NoSelected(dataGridViews4[k]);

            // Внешний вид таблицы

            Help.LookLike(dataGridViews4[k], 100, 25);
        }

        /// <summary>
        ///  Событие изменения комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepeatIndexChanges)
            {
                if (CountLast == -1 && Help.CheckTo(dataGridViews4[comboBox.SelectedIndex]) && Help.CheckTo(dataGridViews2[comboBox.SelectedIndex]) &&
                         Help.CheckTo(dataGridViews3[comboBox.SelectedIndex]))
                {
                    FirstTable(comboBox.SelectedIndex);
                    SecondTable(comboBox.SelectedIndex, dataGridViews2[comboBox.SelectedIndex]);
                    SecondTable(comboBox.SelectedIndex, dataGridViews3[comboBox.SelectedIndex]);
                    ForthTable(comboBox.SelectedIndex);
                    ArrForDurak[comboBox.SelectedIndex] = comboBox.SelectedItem.ToString();
                }

                else if (CountLast != -1 && Help.CheckTo(dataGridViews4[CountLast]) && Help.CheckTo(dataGridViews2[CountLast]) &&
                        Help.CheckTo(dataGridViews3[CountLast]))
                {
                    dataGridViews1[CountLast].Visible = false;
                    dataGridViews2[CountLast].Visible = false;
                    dataGridViews3[CountLast].Visible = false;
                    dataGridViews4[CountLast].Visible = false;
                    FirstTable(comboBox.SelectedIndex);
                    SecondTable(comboBox.SelectedIndex, dataGridViews2[comboBox.SelectedIndex]);
                    SecondTable(comboBox.SelectedIndex, dataGridViews3[comboBox.SelectedIndex]);
                    ForthTable(comboBox.SelectedIndex);
                    ArrForDurak[comboBox.SelectedIndex] = comboBox.SelectedItem.ToString();
                }
                else
                {
                    RepeatIndexChanges = false;
                    if (CountLast == -1) comboBox.SelectedIndex = 0;
                    else comboBox.SelectedIndex = CountLast;
                    return;
                }
            }
            else
            {
                RepeatIndexChanges = true;
            }
        }

        /// <summary>
        /// Нажатие Мышкой по первой таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViews1_CellMouseClick(object sender, EventArgs e)
        {
            dataGridViews1[comboBox.SelectedIndex].ClearSelection();
            if (dataGridViews1[comboBox.SelectedIndex].CurrentCell.Style.BackColor != Color.Green)
            {
                dataGridViews1[comboBox.SelectedIndex].ClearSelection();

                // Запоминаем индекс выделенного элемента
                var t = dataGridViews1[comboBox.SelectedIndex].CurrentCell.RowIndex;
                // Переменная для нахождения максимума в строке таблицы
                int max = 0;


                for (int i = 0; i < Help.Equipment.Length; i++)
                {
                    if (dataGridViews1[comboBox.SelectedIndex][i, t].Value != null)
                    {
                        // Для нахождения максимума
                        if ((int)dataGridViews1[comboBox.SelectedIndex][i, t].Value > max)
                        {
                            max = (int)dataGridViews1[comboBox.SelectedIndex][i, t].Value;
                        }
                    }
                }

                OrderDetailInRoute = max + 1;
                dataGridViews1[comboBox.SelectedIndex].CurrentCell.Value = OrderDetailInRoute;
                dataGridViews1[comboBox.SelectedIndex].CurrentCell.Style.BackColor = Color.Green;
            }
            else
            {
                dataGridViews1[comboBox.SelectedIndex].ClearSelection();

                // Запоминаем индекс выделенного элемента
                var t = dataGridViews1[comboBox.SelectedIndex].CurrentCell.RowIndex;
                // Переменная для нахождения максимума в строке таблицы
                int max = 0;

                for (int i = 0; i < Help.Equipment.Length; i++)
                {
                    if (dataGridViews1[comboBox.SelectedIndex][i, t].Value != null)
                    {
                        // Все цифры, большие нашей ячеки уменьшаются на один
                        if ((int)dataGridViews1[comboBox.SelectedIndex][i, t].Value > (int)dataGridViews1[comboBox.SelectedIndex].CurrentCell.Value)
                        {
                            dataGridViews1[comboBox.SelectedIndex][i, t].Value = (int)dataGridViews1[comboBox.SelectedIndex][i, t].Value - 1;
                        }
                        // Для нахождения максимума
                        if ((int)dataGridViews1[comboBox.SelectedIndex][i, t].Value > max)
                        {
                            max = (int)dataGridViews1[comboBox.SelectedIndex][i, t].Value;
                        }
                    }
                }
                
                OrderDetailInRoute = max + 1;
                dataGridViews1[comboBox.SelectedIndex].CurrentCell.Value = null;
                dataGridViews1[comboBox.SelectedIndex].CurrentCell.Style.BackColor = Color.White;
            }

            SecondTable(comboBox.SelectedIndex, dataGridViews2[comboBox.SelectedIndex]);
            SecondTable(comboBox.SelectedIndex, dataGridViews3[comboBox.SelectedIndex]);
        }

        private void dataGridViews2_CellMouseClick(object sender, EventArgs e)
        {
            NoSelected(dataGridViews3[comboBox.SelectedIndex]);
        }

        private void dataGridViews3_CellMouseClick(object sender, EventArgs e)
        {
            NoSelected(dataGridViews2[comboBox.SelectedIndex]);
        }

        private void dataGridViews4_CellMouseClick(object sender, EventArgs e)
        {
            NoSelected(dataGridViews2[comboBox.SelectedIndex]);
            NoSelected(dataGridViews3[comboBox.SelectedIndex]);
        }

        /// <summary>
        /// Кнопка отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }

        /// <summary>
        /// Метод для записи временных характеристик в файл
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="name"></param>
        private void TimeToFile(DataGridView[] dataGridView, string topic, string name)
        {
            File.AppendAllText(Help.path, topic + Environment.NewLine + name + Environment.NewLine);

            for (int j = 0; j < Help.Detail.Length; j++)
            {
                for (int i = 0; i < Help.Equipment.Length; i++)
                {
                    for (int l = 0; l < dataGridView[j].Rows.Count; l++)
                    {
                        if (dataGridView[j][i, l].Style.BackColor != Color.Red)
                        {
                            string str = $"[" + @"""" + Help.Equipment[i]
                                 + @"""" + "," + @"""" + Help.Detail[j]
                                 + @"""" + "," + l.ToString() + "]:= " + dataGridView[j][i, l].Value.ToString()
                                 + Environment.NewLine;
                            File.AppendAllText(Help.path, str);
                        }
                    }
                }
            }

            File.AppendAllText(Help.path, ";" + Environment.NewLine);
        }

        // Массив под запись данных первой таблицы
        public static List<string> table1 = new List<string>();
    /// Кнопка Next
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonNext_Click(object sender, EventArgs e)
        {

            // Удаляем текст, чтобы при повторном нажатии небыло дублей
            if (Regex.IsMatch(File.ReadAllText(Help.path), ".*#Какие детали, на каких станках обрабатываются.*"))
                Help.DeleteText("#Какие детали, на каких станках обрабатываются");

            //Если не все комбобоксы были выбраны, то не пойджет 
            for (int i = 0; i < ArrForDurak.Length; i++)
            {
                if (ArrForDurak[i] == null)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            if (!Help.CheckTo(dataGridViews4[CountLast]) || !Help.CheckTo(dataGridViews2[CountLast]) ||
                    !Help.CheckTo(dataGridViews3[CountLast])) return;

            // Заполнение какие детали на каких станках обрабатываются

            File.AppendAllText(Help.path, "#Какие детали, на каких станках обрабатываются" + Environment.NewLine);

            for (int j = 0; j < Help.Equipment.Length; j++)
            {
                File.AppendAllText(Help.path, $"set I_j[" + @"""" + Help.Equipment[j]
                    + @"""" + "]:= ");
                for (int i = 0; i < Help.Detail.Length; i++)
                {
                    for (int l = 0; l < dataGridViews1[i].Rows.Count; l++)
                    {
                        if (dataGridViews1[i][j, l].Style.BackColor == Color.Green)
                        {
                            File.AppendAllText(Help.path, @"""" + Help.Detail[i]
                            + @"""" + " ");
                            break;
                        }
                    }
                }
                File.AppendAllText(Help.path, ";" + Environment.NewLine);
            }

            // Заполнение маршрутов деталей

            File.AppendAllText(Help.path, "#Маршруты деталей" + Environment.NewLine);

            for (int j = 0; j < Help.Detail.Length; j++)
            {
                for (int i = 0; i < Help.Equipment.Length; i++)
                {
                    string str = $"set K_j_i[" + @"""" + Help.Equipment[i]
                            + @"""" + "," + @"""" + Help.Detail[j]
                            + @"""" + "]:= ";

                    for (int l = 0; l < dataGridViews1[j].Rows.Count; l++)
                    {
                        if (dataGridViews1[j][i, l].Style.BackColor == Color.Green)
                        {
                            str += l.ToString() + " ";
                        }
                    }
                    str += ";";

                    if (!Regex.IsMatch(str, ".*:= ;.*")) // Для проверки на то, записалось ли что-то
                    {
                        File.AppendAllText(Help.path, str + Environment.NewLine);
                    }
                }
            }

            // Заполнение времени

            TimeToFile(dataGridViews2, "#Время обработки", "param t_jik");
            TimeToFile(dataGridViews3, "#Время переналадки", "param tau_jik");

            // Заполнение себестоимости

            File.AppendAllText(Help.path, "#Себестоимость деталей" + Environment.NewLine + "param c_ik" + Environment.NewLine);

            for (int j = 0; j < Help.Detail.Length; j++)
            {
                for (int l = 0; l < dataGridViews4[j].Rows.Count; l++)
                {
                    string str = $"[" + @"""" + Help.Detail[j]
                                    + @"""" + "," + l.ToString() + "]:= " + dataGridViews4[j][0, l].Value.ToString()
                                    + Environment.NewLine;
                    File.AppendAllText(Help.path, str);
                }
            }

            File.AppendAllText(Help.path, ";" + Environment.NewLine);

            // Записываем в список данные таблцы
            int z = 0;
            for (int i = 0; i < Help.Detail.Length; i++)
            {
                for (int j = 0; j < dataGridViews1[i].RowCount; j++)
                {
                    table1.Add($"{Help.Detail[i]};{dataGridViews1[i].Rows[j].HeaderCell.Value.ToString().Substring(7)};");
                    for (int k = 0; k < dataGridViews1[i].ColumnCount; k++)
                    {
                        if (dataGridViews1[i][k, j].Style.BackColor == Color.Green && dataGridViews2[i][k, j].Style.BackColor != Color.Red)
                            table1[z] += $"{dataGridViews1[i].Columns[k].HeaderCell.Value}/{dataGridViews1[i][k, j].Value.ToString()}/{dataGridViews2[i][k, j].Value.ToString()};";
                        else
                            table1[z] += $"{dataGridViews1[i].Columns[k].HeaderCell.Value}/0;";
                    }
                    z++;
                }
            }


            try
            {
                // Вызов cmd
                ProcessStartInfo psi = new ProcessStartInfo(Help.Parent);
                psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
                Process.Start(psi);

                for (; ; )
                {
                    try
                    {
                        if (File.ReadAllLines(Help.Gusek + Help.Mistake).ToList().Any(y => y.Contains("Model has been successfully processed")))
                        {
                            var form = new LastForm();
                            form.Show();
                            break;
                        }

                        if (File.ReadAllLines(Help.Gusek + Help.Mistake).ToList().Any(y => y.Contains("PROBLEM HAS NO PRIMAL FEASIBLE SOLUTION"))
                            || File.ReadAllLines(Help.Gusek + Help.Mistake).ToList().Any(y => y.Contains("MathProg model processing error")))
                        {
                            MessageBox.Show(File.ReadAllText(Help.Gusek + Help.Mistake));
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Убираем видимость формы
            Hide();

            // Включаем предыдущую форму
            Detail detail = new Detail();
            detail.Show();

            //Показываем данные
            Help.Shows(detail.DataGridViewDetail, Detail.DetArr, 3, Help.Detail.Length);

            //Удаяем данные из текстового документа
            Help.DeleteText("#Параметры деталей");
        }

        private void DifficultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цифра в зеленой ячейке обозначает порядок обработки детали.");
        }
    }
}
