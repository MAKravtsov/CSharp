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
using System.Diagnostics;
using System.Threading;

namespace Diploma
{
    public partial class LastForm : Form
    {
        public LastForm()
        {
            InitializeComponent();

            Thread.Sleep(2000);

            StreamReader sr = new StreamReader(Help.Gusek + Help.Result);
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(Help.Gusek + Help.Result).ToList();
                
            // Для нахождения потраченной денежной суммы
            string tx = "Сколько мы потратили? ";
            textBoxMoney.Text = lines.Where(y => y.Contains(tx)).First().ToString().Substring(tx.Length);

            // Нваходим пустую строку, чтобы удалить все после нее
            var t = File.ReadAllLines(Help.Gusek + Help.Result).ToList().IndexOf("");

            // Удаляем оттуда ненужное
            for (int i = t; i < lines.Count;)
            {
                lines.RemoveAt(i);
            }

            // Создаем новый список, вида Out
            List<Out> str = new List<Out>();
            var copy = new Out();
            for (int i = 0; i < lines.Count; i++)
            {
                str.Add(copy.Addition(lines[i].Split(';').ToList()));
            }

            // Для маршрутов деталей
            List<string> MarshDet = (from txt in str select txt.Detail + ';' + txt.Route).Distinct().ToList();

            // Внешний вид таблицы маршрутов
            Help.LookLike(dataGridViewRoute, 100, 25);
            dataGridViewRoute.RowCount = MarshDet.Count();
            dataGridViewRoute.ColumnCount = 2;
            dataGridViewRoute.Columns[0].HeaderCell.Value = "Номер маршрута";
            dataGridViewRoute.Columns[1].HeaderCell.Value = "Маршрут";




            for (int i = 0; i < MarshDet.Count(); i++)
            {
                dataGridViewRoute.Rows[i].HeaderCell.Value = MarshDet[i].Split(';').ToList()[0];

                // Находим в файле выбранный маршрут деталей
                if (DifficultForm.table1.Any(l => l.StartsWith(MarshDet[i])))
                {
                    // Находим строку в массиве из DifficultForm
                    var st = DifficultForm.table1.Where(m => m.Contains(MarshDet[i])).First().Split(';').ToList();

                    // Массив в порядке обработки деталей
                    List<string> dop = (from txt in st where txt.Contains("/") && txt.Split('/').Length == 3 orderby txt.Split('/').ToList()[1] select txt).ToList();

                    // Заисываем данные dataGridViewRoute в столбец с номером выбранного маршрута
                    dataGridViewRoute[0, i].Value = MarshDet[i].Split(';').ToList()[1];

                    // Записываем данные в файл для Димы
                    string result = st[0] + ':';
                    for (int h = 2; h < st.Count - 1; h++)
                    {
                        result += st[h] + ';';
                    }
                    File.AppendAllText(Help.Gusek + Help.Dima, result + Environment.NewLine);

                    // Записываем данные в последний столбец таблицы dataGridViewRoute
                    for (int j = 0; j < dop.Count - 1; j++)
                    {
                        dataGridViewRoute[1, i].Value += dop[j].Split('/').ToList()[0] + Environment.NewLine;
                    }
                    dataGridViewRoute[1, i].Value += dop[dop.Count - 1].Split('/').ToList()[0];
                }
            }

            var equipment = new List<TableEquipment>();
            foreach (var s in str)
            {
                int i = 1;
                TableEquipment eq = equipment.FirstOrDefault(y => y.Name == s.Equipment && y.Num == s.NumberEq);
                if (eq != null)
                    eq.DetailsAndPercent.Add(new Tuple<string, double>(s.Detail, s.Percent));
                else
                    equipment.Add(new TableEquipment(s.Equipment, s.NumberEq, s.Detail, s.Percent));
            }

            foreach (var eq in equipment.Select(y => y.Name).Distinct())
            {
                var oneEq = equipment.Where(y => y.Name == eq);
                int i = 1;
                foreach (var one in oneEq)
                {
                    one.Num = i;
                    i++;
                }
            }

            // Внешний вид таблицы количества станков
            Help.LookLike(dataGridViewNumberEq, 100, 25);
            dataGridViewNumberEq.RowCount = equipment.Count();
            dataGridViewNumberEq.ColumnCount = 2;
            dataGridViewNumberEq.Columns[0].HeaderCell.Value = "Номер станка";
            dataGridViewNumberEq.Columns[1].HeaderCell.Value = "Доля деталей, обрабатываемых на этом станке";

            for (int i = 0; i < equipment.Count(); i++)
            {
                dataGridViewNumberEq.Rows[i].HeaderCell.Value = equipment[i].Name;
                dataGridViewNumberEq[0, i].Value = equipment[i].Num;
                int s = 1;
                foreach(var d in equipment[i].DetailsAndPercent)
                {
                    dataGridViewNumberEq[1, i].Value += $"{d.Item1} - {d.Item2.ToString()}%";
                    if (s < equipment[i].DetailsAndPercent.Count())
                        dataGridViewNumberEq[1, i].Value += Environment.NewLine;
                    s++;
                }
            }    
        }

        /// <summary>
        /// Для закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(Help.Gusek + Help.Dima, string.Empty);
            DifficultForm.table1.RemoveAll(y => y != null);
        }

        /// <summary>
        /// Кнопка Finish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFinish_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }
    }

    /// <summary>
    /// Класс для записы данных из файла Out
    /// </summary>
    class Out
    {
        public string Equipment { get; set; }
        public string Detail { get; set; }
        public int Route { get; set; }
        public double Percent { get; set; }
        public int NumberEq { get; set; }

        /// <summary>
        /// Метод добавления жлементов
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Out Addition (List<string> list)
        {
            var t = new Out();
            t.Equipment = list[0];
            t.Detail = list[1];
            t.Route = int.Parse(list[2]);
            t.Percent = Math.Round(double.Parse(list[3].Replace('.', ',')) * 100,0);
            t.NumberEq = int.Parse(list[4]);
            return t;
        }
    }

    class TableEquipment
    {
        public string Name;
        public int Num;
        public List<Tuple<string, double>> DetailsAndPercent;

        public TableEquipment(string name, int num, string detail, double cnt)
        {
            Name = name;
            Num = num;
            DetailsAndPercent = new List<Tuple<string, double>>() { new Tuple<string, double>(detail, cnt) };
        }
    }
}









