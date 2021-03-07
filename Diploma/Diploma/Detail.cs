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
    public partial class Detail : Form
    {

        public Detail()
        {
            InitializeComponent();

            // Заполнение таблицы данных о деталях
            DataGridViewDetail.ColumnCount = 3;
            DataGridViewDetail.Columns[0].HeaderCell.Value = "Количество технологических маршрутов";
            DataGridViewDetail.Columns[1].HeaderCell.Value = "Цена еденицы";
            DataGridViewDetail.Columns[2].HeaderCell.Value = "Количество";

            DataGridViewDetail.RowCount = Help.Detail.Length;
            for (int i = 0; i < Help.Detail.Length; i++)
            {
                DataGridViewDetail.Rows[i].HeaderCell.Value = Help.Detail[i];
            }

            // Внешний вид таблицы данных о деталях
            Help.LookLike(DataGridViewDetail, 100,50);
        }

        /// <summary>
        ///  Кнопка Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }


        /// <summary>
        /// Кнопка Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Убираем видимость формы
            Hide();

            // Врубаем старую форму
            Equipment equipment = new Equipment();
            equipment.Show();

            // Показываем данные в новой таблице
            Help.Shows(equipment.DataGridViewEquipment, Equipment.EqArr, 5, Help.Equipment.Length);

            // Удаление новых записанных строк
            Help.DeleteText("#Деньги");
        }

        // Двумерный массив под сохранение данных
        public static string[,] DetArr = new string[3, Help.Detail.Length];

        /// <summary>
        /// Кнопка Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonNext_Click(object sender, EventArgs e)
        {
            // Проверка на дурака
            if (Help.CheckTo(DataGridViewDetail))
            {
                // Сохранение данных
                Help.Save(DataGridViewDetail, DetArr, 3, Help.Detail.Length);

                // Запись в файл данных таблицы о данных деталей
                File.AppendAllText(Help.path, "#Параметры деталей" + Environment.NewLine);
                for (int i = 0; i < DataGridViewDetail.ColumnCount; i++)
                {
                    if (i == 0) File.AppendAllText(Help.path, "param K_i:=" + Environment.NewLine);
                    if (i == 1) File.AppendAllText(Help.path, "param c_i:=" + Environment.NewLine);
                    if (i == 2) File.AppendAllText(Help.path, "param n_i:=" + Environment.NewLine);

                    for (int j = 0; j < DataGridViewDetail.RowCount; j++)
                    {
                        if (DataGridViewDetail[i, j].Value == null)
                        {
                            File.AppendAllText(Help.path, @"""" + DataGridViewDetail.Rows[j].HeaderCell.Value
                            + @"""" + " 0" + Environment.NewLine);
                        }
                        else
                        {
                            File.AppendAllText(Help.path, @"""" + DataGridViewDetail.Rows[j].HeaderCell.Value
                                + @"""" + " " + DataGridViewDetail[i, j].Value.ToString().Replace(',', '.') + Environment.NewLine);
                        }
                    }
                    File.AppendAllText(Help.path, ";" + Environment.NewLine);
                }

                // Убираем видимость формы
                Hide();

                // Появление новой формы
                DifficultForm detailSeb = new DifficultForm();
                detailSeb.Show();

            }
        }

        private void Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
