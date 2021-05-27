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

namespace Diploma
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();

            // Столбцы таблицы

            DataGridViewEquipment.ColumnCount = 6;
            DataGridViewEquipment.Columns[0].HeaderCell.Value = "Стоимость обслуживания еденицы оборудования";
            DataGridViewEquipment.Columns[1].HeaderCell.Value = "Стоимость еденицы оборудования";
            DataGridViewEquipment.Columns[2].HeaderCell.Value = "Время, выделаемое на работу оборудования";
            DataGridViewEquipment.Columns[3].HeaderCell.Value = "Средний коэффициент загрузки станка";
            DataGridViewEquipment.Columns[4].HeaderCell.Value = "Количество оборудования на производстве";
            DataGridViewEquipment.Columns[5].HeaderCell.Value = "Максимальное количество оборудования";

            // Строки таблицы
            DataGridViewEquipment.RowCount = Help.Equipment.Length;
            for (int i = 0; i < Help.Equipment.Length; i++)
            {
                DataGridViewEquipment.Rows[i].HeaderCell.Value = Help.Equipment[i];
            }


            // Внешний вид таблицы
            Help.LookLike(DataGridViewEquipment, 200,50);
        }

        /// <summary>
        /// Кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // Убираем видимость формы
            Hide();

            // Возвращаем видимость другой формы
            var form = new MainWindow();
            form.Show();

            // Заполняем листбокс оборудования
            form.listBoxEquipment.Items.AddRange(Help.Equipment);

            // Заполняем листбокс деталей
            form.listBoxDetail.Items.AddRange(Help.Detail);

            // Удаление новых записанных строк
            Help.DeleteText("#Множество станков и деталей");
        }

        /// <summary>
        /// Кнопка отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }

        // Двумерный массив под сохранение данных
        public static string[,] EqArr = new string[5,Help.Equipment.Length];

        /// <summary>
        /// Кнопка Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            // Проверка на дурака
            if (Help.CheckTo(DataGridViewEquipment))
            {
                if (double.TryParse(textBoxResult.Text, out double Res)) { }
                else
                {
                    MessageBox.Show("Некорректно введены данные денежного ресурса");
                    return;
                }
                File.AppendAllText(Help.path, "#Деньги" + Environment.NewLine);
                File.AppendAllText(Help.path, "param C_0:=0;" + Environment.NewLine);
                File.AppendAllText(Help.path, "param D:=" + textBoxResult.Text + ";" + Environment.NewLine);

                // Записываем данные таблицы
                Help.Save(DataGridViewEquipment, EqArr, 5, Help.Equipment.Length);

                // Запись в файл данных об оборудовании
                File.AppendAllText(Help.path, "#Параметры станка" + Environment.NewLine);
                for (int i = 0; i < DataGridViewEquipment.ColumnCount; i++)
                {
                    if (i == 0) File.AppendAllText(Help.path, "param b_j:=" + Environment.NewLine);
                    if (i == 1) File.AppendAllText(Help.path, "param d_j:=" + Environment.NewLine);
                    if (i == 2) File.AppendAllText(Help.path, "param V_j:=" + Environment.NewLine);
                    if (i == 3) File.AppendAllText(Help.path, "param mu_j:=" + Environment.NewLine);
                    if (i == 4) File.AppendAllText(Help.path, "param M_j:=" + Environment.NewLine);
                    for (int j = 0; j < DataGridViewEquipment.RowCount; j++)
                    {
                        File.AppendAllText(Help.path, @"""" + DataGridViewEquipment.Rows[j].HeaderCell.Value
                            + @"""" + " " + DataGridViewEquipment[i, j].Value.ToString().Replace(',', '.')
                            + Environment.NewLine);
                    }
                    File.AppendAllText(Help.path, ";" + Environment.NewLine);
                }

                // Убираем видимость формы
                Hide();

                // Видимость новой формы
                var form3 = new Detail();
                form3.Show();
            }
        }

        private void Equipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {

        }

        private void DataGridViewEquipment_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            return;
        }
    }
}

