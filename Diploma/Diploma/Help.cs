using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace Diploma
{
    class Help
    {
        // Расположение папки Gusek
        public static string Gusek = @"C:\Users\mkravtsov\Desktop\Учеба\12 сем\Диплом\разработка";

        // Имя файла, в который сохраняем
        public static string Name = @"\ViborEquipment.txt";

        // Имя Батаво 
        public static string NameBat = @"\Text.bat";

        // Имя Результата
        public static string Result = @"\Part Select Out.txt";

        // Для Димы
        public static string Dima = @"\ForDima.txt";

        // Для ошибки
        public static string Mistake = @"\Mistake.txt";

        /// <summary>
        /// Файл для записи данных
        /// </summary>
        public static string path
        {
            get { return Gusek + Name; }
        }

        /// <summary>
        /// Полное расположение Бат файла
        /// </summary>
        public static string Parent
        {
            get { return Gusek + NameBat; }
        }

        /// <summary>
        /// Множество типов деталей
        /// </summary>
        public static string[] Detail { get; set; }

        /// <summary>
        /// Множество типов оборудования
        /// </summary>
        public static string[] Equipment { get; set; }

        /// <summary>
        /// Метод для красоты таблиц
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="RowHeadersWidth"></param>
        public static void LookLike(DataGridView dataGridView, int RowHeadersWidth, int ColumnHeadersHeight)
        {
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeight = ColumnHeadersHeight;
            dataGridView.RowHeadersWidth = RowHeadersWidth;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// Метод для удаления текста из файла
        /// </summary>
        /// <param name="text"></param>
        public static void DeleteText(string text)
        {
            int j = 0;
            StreamReader sr2 = new StreamReader(path);
            while (( sr2.ReadLine()) != text) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
            {
                j++;
            }
            sr2.Close();

            string[] rows = File.ReadAllLines(path);
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < j; i++)
                sw.WriteLine(rows[i]);
            sw.Close();
        }

        /// <summary>
        /// Проверка на дурака
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static bool CheckTo(DataGridView dataGridView)
        {
            double result;
            bool Check = true;
            // Проверка на дурака
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    if (dataGridView[i, j].Style.BackColor != Color.Green && dataGridView[i, j].Style.BackColor != Color.Red)
                    {
                        if (dataGridView[i,j].Value == null)
                        {
                            dataGridView[i, j].Style.BackColor = Color.Brown;
                            MessageBox.Show("Не все ячейки заполнены");
                            Check = false;
                            return Check;
                        }

                        if (!double.TryParse((dataGridView[i, j].Value.ToString()), out result))
                        {
                            dataGridView[i, j].Style.BackColor = Color.Brown;
                            MessageBox.Show("Некорректно введны данные");
                            Check = false;
                            return Check;
                        }
                        else
                        {
                            dataGridView[i, j].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            return Check;
        }

        /// <summary>
        /// Сохранение данных таблицы
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="Massive"></param>
        /// <param name="eq"></param>
        /// <param name="det"></param>
        public static void Save (DataGridView dataGridView, string [,] Massive, int eq, int det)
        {
            for (int i = 0; i < eq; i++)
            {
                for (int j = 0; j < det; j++)
                {
                    if (dataGridView[i, j].Style.BackColor == Color.Green)
                    {
                        Massive[i, j] = "Green";
                    }
                    else if (dataGridView[i, j].Style.BackColor == Color.Red)
                    {
                        Massive[i, j] = "Red";
                    }
                    else
                    {
                        if (dataGridView[i, j].Value != null)
                        {
                            Massive[i, j] = dataGridView[i, j].Value.ToString();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Показ сохраненных данных таблицы
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="Massive"></param>
        /// <param name="eq"></param>
        /// <param name="det"></param>
        public static void Shows(DataGridView dataGridView, string[,] Massive, int eq, int det)
        {
            for (int i = 0; i < eq; i++)
            {
                for (int j = 0; j < det; j++)
                {
                    if (Massive[i, j] == "Green")
                    {
                        dataGridView[i, j].Style.BackColor = Color.Green;
                    }
                    else if (Massive[i, j] == "Red")
                    {
                        dataGridView[i, j].Style.BackColor = Color.Red;
                        dataGridView[i, j].ReadOnly = true;
                    }
                    else
                    {
                        if (Massive[i, j] != null)
                        {
                            dataGridView[i, j].Value = Massive[i, j];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public static void Cancel ()
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
