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
    public partial class MainWindow : Form
    {
        int CountInfo = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (CountInfo == 0)
            {
                MessageBox.Show("Посмотрите Info!!!");
            }
            else
            {
                if (listBoxEquipment.Items.Count != 0 && listBoxDetail.Items.Count != 0)
                {
                    // Listbox оборудования
                    Help.Equipment = new string[listBoxEquipment.Items.Count];

                    for (int i = 0; i < Help.Equipment.Length; i++)
                    {
                        Help.Equipment[i] = listBoxEquipment.Items[i].ToString();
                    }

                    // Listbox деталей
                    Help.Detail = new string[listBoxDetail.Items.Count];

                    for (int i = 0; i < Help.Detail.Length; i++)
                    {
                        Help.Detail[i] = listBoxDetail.Items[i].ToString();
                    }

                    //Создание файла и запись в него списка оборудования и деталей

                    using (StreamWriter sw = File.CreateText(Help.path))
                    {
                        sw.WriteLine("#Множество станков и деталей");
                        sw.Write("set J:= ");
                        for (int i = 0; i < Help.Equipment.Length; i++)
                        {
                            sw.Write(@"""" + Help.Equipment[i] + @"""" + " ");
                        }
                        sw.WriteLine(";");
                        sw.Write("set I:= ");
                        for (int i = 0; i < Help.Detail.Length; i++)
                        {
                            sw.Write(@"""" + Help.Detail[i] + @"""" + " ");
                        }
                        sw.WriteLine(";");
                        sw.Close();
                    }

                    // Убираем видимость фомы
                    Hide();

                    // Видимость новой формы
                    var form2 = new Equipment();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Вы не ввели данные");
                }
            }
        }

        /// <summary>
        /// Enter для добавления новых элементов в ListboxEquipment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonEquipmentAdd_Click(sender, e);
                textBoxEquipment.Clear();
            }
        }

        /// <summary>
        /// Enter для добавления новых элементов в ListboxDetail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDetailAdd_Click(sender, e);
                textBoxDetail.Clear();
            }
        }

        /// <summary>
        /// Кнопка Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }

        /// <summary>
        /// Добавление эдементов в ListboxEqyipment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEquipmentAdd_Click(object sender, EventArgs e)
        {
            if (textBoxEquipment.Text != "")
            listBoxEquipment.Items.Add(textBoxEquipment.Text);
            textBoxEquipment.Clear();
        }

        /// <summary>
        /// Удаление элементов из ListboxEquipment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEquipmentSub_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxEquipment.Items.RemoveAt(listBoxEquipment.SelectedIndex);
            }
            catch
            {
            }
        }

        /// <summary>
        /// обавление эдементов в ListboxDetail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDetailAdd_Click(object sender, EventArgs e)
        {
            if (textBoxDetail.Text != "")
                listBoxDetail.Items.Add(textBoxDetail.Text);
            textBoxDetail.Clear();
        }

        /// <summary>
        /// Удаление элементов из ListboxEquipment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDetailSub_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxDetail.Items.RemoveAt(listBoxDetail.SelectedIndex);
            }
            catch
            {
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            CountInfo++;
            MessageBox.Show("Вещественные числа вводятся через ЗАПЯТУЮ");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Hide();

            NullForm nullForm = new NullForm();
            nullForm.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
