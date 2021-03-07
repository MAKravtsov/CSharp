using StudentBillsv2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentsBillsv2
{
    public partial class Bills : Form
    {
        internal string Path = "C:\\StudentBills\\Data.txt";

        string costComBud = "# Цена коммуналка бюджет";
        string costComPl = "# Цена коммуналка платники";
        string costEl = "# Цена электричество";
        string costEmp = "# Цена найм";
        string pathStud = "# Путь к файлу со студентами";
        string pathTemp = "# Путь к файлу Templates";
        string pathPDF = "# Путь к файлу PDF";
        string pathBase = "# Путь к файлу База Боевая";
        string startDate = "# Дата начала";
        string endDate = "# Дата конца";
        string specEndDate = "# Отдельная дата конца";
        string isPDF = "# Создаем PDF";
        string isPrint = "# Печатаем";
        string order = "# Порядок";
        string specDateFor = "# Для кого отдельная дата";

        internal Dictionary<string, string> FromFile;

        internal List<Student> Students;
        internal StudentType checkedTypeStudents;

        private string OutBlankEmployee;
        private string OutBlankCommunalka;
        private string OutBlankElectricity;
        private string OutBlankPlatn;
        private string OutBlankEmployeeINO;
        private string OutBlankCommunalkaINO;
        private string OutBlankElectricityINO;

        DateTime starDate;
        DateTime endDateB;
        DateTime endDateNorm;
        double PriceEmployee;
        double PriceCommunalkaBudg;
        double PriceCommunalkaPlatn;
        double PriceElectricity;

        public Bills()
        {
            InitializeComponent();
        }


        private void Bills_Load_1(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Path, Encoding.UTF8);

            FromFile = new Dictionary<string, string>();

            string line;
            string lastPart = string.Empty;
            int cnt = 1;
            while ((line = sr.ReadLine()) != null)
            {
                if (cnt > 30)
                    break;

                if (line.StartsWith("#"))
                {
                    FromFile.Add(line, string.Empty);
                    lastPart = line;
                }
                else
                    FromFile[lastPart] = line;

                cnt++;
            }
            sr.Close();

            PriceEmployeeTextBox.Text = FromFile[costEmp];
            PriceCommBudgTextBox.Text = FromFile[costComBud];
            PriceCommPlatnTextBox.Text = FromFile[costComPl];
            PriceElectrTextBox.Text = FromFile[costEl];
            dateTimePickerStart.Value = DateTime.Parse(FromFile[startDate]);
            dateTimePickerEnd.Value = DateTime.Parse(FromFile[endDate]);
            dateTimePickerEndGraduate.Value = DateTime.Parse(FromFile[specEndDate]);
            BaseTextBox.Text = FromFile[pathBase];
            StudentsTextBox.Text = FromFile[pathStud];
            PDFTextBox.Text = FromFile[pathPDF];
            textBoxTemplates.Text = FromFile[pathTemp];
            if (bool.Parse(FromFile[isPDF]))
                PDFCheckBox.Checked = true;
            if (bool.Parse(FromFile[isPrint]))
                PrintCheckBox.Checked = true;

            int cn = checkedListBoxDopDate.Items.Count;
            var dopDate = FromFile[specDateFor].Split('|');
            for (int i = 0; i < cn; i++)
            {
                if (dopDate.Contains(checkedListBoxDopDate.Items[i].ToString()))
                    checkedListBoxDopDate.SetItemChecked(i, true);
            }

            int cnDop = checkedListBox.Items.Count;
            for (int i = 0; i < cnDop; i++)
            {
                if (checkedListBox.Items[i].ToString() == FromFile[order])
                    checkedListBox.SetItemChecked(i, true);
            }
        }

        private void OverviewButtonBase_Click(object sender, EventArgs e)
        {
            openFileDialogBase.ShowDialog();
            string namePathBase = openFileDialogBase.FileName;
            BaseTextBox.Text = namePathBase;
            WriteToFile(pathBase, namePathBase);
        }

        private void StudentsButton_Click(object sender, EventArgs e)
        {
            openFileDialogStudents.ShowDialog();
            string namePathStudents = openFileDialogStudents.FileName;
            StudentsTextBox.Text = namePathStudents;
            WriteToFile(pathStud, namePathStudents);
        }

        private void PDFButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialogPDF.ShowDialog();
            string nameFolderPDF = folderBrowserDialogPDF.SelectedPath;
            PDFTextBox.Text = nameFolderPDF;
            WriteToFile(pathPDF, nameFolderPDF);
        }
        private void buttonTemplates_Click(object sender, EventArgs e)
        {
            folderBrowserDialogTemplates.ShowDialog();
            string nameFolderTemplates = folderBrowserDialogTemplates.SelectedPath;
            textBoxTemplates.Text = nameFolderTemplates;
            WriteToFile(pathTemp, nameFolderTemplates);
        }
        private void PDFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PDFButton.Visible = true;
            PDFlabel.Visible = true;
            PDFTextBox.Visible = true;
            WriteToFile(isPDF, PDFCheckBox.Checked.ToString());
        }

        private void PrintCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WriteToFile(isPrint, PrintCheckBox.Checked.ToString());
        }

        private void PriceEmployeeTextBox_TextChanged(object sender, EventArgs e)
        {
            WriteToFile(costEmp, PriceEmployeeTextBox.Text);
        }

        private void PriceCommPlatnTextBox_TextChanged(object sender, EventArgs e)
        {
            WriteToFile(costComPl, PriceCommPlatnTextBox.Text);
        }

        private void PriceCommBudgTextBox_TextChanged(object sender, EventArgs e)
        {
            WriteToFile(costComBud, PriceCommBudgTextBox.Text);
        }

        private void PriceElectrTextBox_TextChanged(object sender, EventArgs e)
        {
            WriteToFile(costEl, PriceElectrTextBox.Text);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            WriteToFile(startDate, dateTimePickerStart.Value.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            WriteToFile(endDate, dateTimePickerEnd.Value.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        private void dateTimePickerEndGraduate_ValueChanged(object sender, EventArgs e)
        {
            WriteToFile(specEndDate, dateTimePickerEndGraduate.Value.ToString("dd.MM.yyyy HH:mm:ss"));
        }
        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.SelectedIndex != i)
                    checkedListBox.SetItemChecked(i, false);
            }
        }

        private async void PerformButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Заполняем txt файл 
                string checkItems = string.Empty;
                foreach (var checkItem in checkedListBox.CheckedItems)
                {
                    checkItems = checkItem.ToString();
                }
                WriteToFile(order, checkItems);

                List<string> dopDateCheckItems = new List<string>();
                foreach(var checkItem in checkedListBoxDopDate.CheckedItems)
                {
                    dopDateCheckItems.Add(checkItem.ToString());
                }
                WriteToFile(specDateFor, string.Join("|", dopDateCheckItems));

                // Основная работа
                progress.Value = 0;
                toolStripStatusLabelPercent.Text = progress.Value.ToString() + "%";

                status.Visible = true;
                toolStripStatusLabel.Text = "Поиск данных о студентах в Базе Боевой";
                Performbutton.BackColor = Color.Red;
                Performbutton.Enabled = false;

                checkedTypeStudents = new StudentType();
                int cn = checkedListBoxDopDate.Items.Count;
                for (int i = 0; i < cn; i++)
                {
                    if (checkedListBoxDopDate.GetItemChecked(i))
                    {
                        var name = checkedListBoxDopDate.Items[i].ToString().First().ToString();
                        if (name == "Б")
                            checkedTypeStudents.IsBak = true;
                        else if (name == "М")
                            checkedTypeStudents.IsMast = true;
                        else if (name == "1")
                            checkedTypeStudents.Is15F = true;
                        else
                            checkedTypeStudents.IsSpec = true;
                    }
                }

                bool isError = false;
                await Task.Run(() => DataFromBase());

                if (checkedListBox.SelectedItem != null)
                {
                    if (checkedListBox.SelectedItem.ToString() == "По комнатам")
                        Students = Students.OrderBy(y => y.room).ToList();
                    else if (checkedListBox.SelectedItem.ToString() == "По алфавиту")
                        Students = Students.OrderBy(y => y.FIO).ToList();
                }

                if (Students.Any(y => string.IsNullOrWhiteSpace(y.NumberStudentCard)))
                {
                    var msg = new StringBuilder();
                    int cnt = 1;
                    msg.AppendLine("Проблема со следующими студентами:");
                    foreach (var st in Students.Where(y => y.errors.Any()))
                    {
                        var descriptions = new List<string>();
                        foreach (var err in st.errors)
                            descriptions.Add(GetDescriptionFromEnum(err));
                        string errs = string.Join(",", descriptions);
                        msg.AppendLine($"{cnt}) {st.FIO} Ошибки: " + errs);
                        cnt++;
                    }
                    var errForm = new Errors();
                    errForm.Show();
                    errForm.textBox.Text = msg.ToString();
                    isError = true;
                }

                if (!isError)
                {
                    toolStripStatusLabel.Text = "Создание квитанций";
                    int cnt = 1;
                    foreach (var st in Students)
                    {
                        bool success = await Task.Run(() => ToDocument(st));
                        progress.Value = (100 * cnt) / Students.Count();
                        toolStripStatusLabelPercent.Text = progress.Value.ToString() + "%";
                        cnt++;
                    }
                    toolStripStatusLabel.Text = "Квитанции созданы";
                }
                else
                    toolStripStatusLabel.Text = "Ошибка в данных";

                Performbutton.BackColor = Color.Green;
                Performbutton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.InnerException?.Message} {ex.StackTrace}");
                toolStripStatusLabel.Text = "ОШИБКА, попробуйте еще раз";
                Performbutton.BackColor = Color.Green;
                Performbutton.Enabled = true;
            }
        }

        private void DataFromBase()
        {
            string Base = BaseTextBox.Text;
            string InputData = StudentsTextBox.Text;
            string folder = textBoxTemplates.Text;

            OutBlankEmployee = folder + @"\бюджет найм.xlsm"; //имя нашего Excel файла
            OutBlankCommunalka = folder + @"\комуналка.xlsm";
            OutBlankElectricity = folder + @"\электричество.xlsm";
            OutBlankPlatn = folder + @"\платники найм.xlsm";
            OutBlankEmployeeINO = folder + @"\ИНО найм.xlsm";
            OutBlankCommunalkaINO = folder + @"\комуналка ИНО.xlsm";
            OutBlankElectricityINO = folder + @"\электричество ИНО.xlsm";

            starDate = dateTimePickerStart.Value;
            endDateB = dateTimePickerEndGraduate.Value;
            endDateNorm = dateTimePickerEnd.Value;
            PriceEmployee = double.Parse(PriceEmployeeTextBox.Text);
            PriceCommunalkaBudg = double.Parse(PriceCommBudgTextBox.Text);
            PriceCommunalkaPlatn = double.Parse(PriceCommPlatnTextBox.Text);
            PriceElectricity = double.Parse(PriceElectrTextBox.Text);

            SelectFromInput(InputData);

            SelectFromBase(Base);
        }

        private bool ToDocument(Student elem)
        {
            var student = new Student();
            switch (elem.StudentsType) {
                case "дог":
                    student.Method(elem, OutBlankPlatn, starDate, endDateB, endDateNorm, PriceEmployee, "наем", this);
                    student.Method(elem, OutBlankCommunalka, starDate, endDateB, endDateNorm, PriceCommunalkaPlatn, "комуналка", this);
                    student.Method(elem, OutBlankElectricity, starDate, endDateB, endDateNorm, PriceElectricity, "электричество", this);
                    break;
                case "ИНО":
                    student.Method(elem, OutBlankEmployeeINO, starDate, endDateB, endDateNorm, PriceEmployee, "наем", this);
                    student.Method(elem, OutBlankCommunalkaINO, starDate, endDateB, endDateNorm, PriceCommunalkaBudg, "комуналка", this);
                    student.Method(elem, OutBlankElectricityINO, starDate, endDateB, endDateNorm, PriceElectricity, "электричество", this);
                    break;
                default:
                    student.Method(elem, OutBlankEmployee, starDate, endDateB, endDateNorm, PriceEmployee, "наем", this);
                    student.Method(elem, OutBlankCommunalka, starDate, endDateB, endDateNorm, PriceCommunalkaBudg, "комуналка", this);
                    student.Method(elem, OutBlankElectricity, starDate, endDateB, endDateNorm, PriceElectricity, "электричество", this);
                    break;
            }

            return true;
        }
        private void SelectFromInput(string path)
        {
            Students = new List<Student>();

            var excel = new ExcelFile();
            excel.Connect(path, "Лист1");

            foreach (Excel.Range row in excel.Rows)
            {
                var item = new Student();
                foreach (var cell in row.Cells.Cast<Excel.Range>().Where(cell => cell.Address.Contains("$A$")))
                {
                    item.FIO = cell.Value;
                }

                if (!string.IsNullOrEmpty(item.FIO) && !Students.Select(y => y.FIO).Contains(item.FIO))
                    Students.Add(item);
            }

            excel.Save();

            excel.DisConnect();
        }

        private void SelectFromBase(string path)
        {
            var excel = new ExcelFile();
            excel.Connect(path, "Base");

            List<BaseData> listStudents = new List<BaseData>();
            foreach (Excel.Range row in excel.Rows)
            {
                if (row.Row == 1 || row.Row == 2)
                    continue;

                var baseData = new BaseData();
                bool badBaseStr = false;
                foreach (Excel.Range cell in row.Cells)
                {
                    var columnName = cell.Address.Split('$')[1];

                    object obj = (object)cell.Value;
                    switch (columnName)
                    {
                        case "AB":
                            baseData.FIO = obj == null ? string.Empty : obj.ToString();
                            if (string.IsNullOrWhiteSpace(baseData.FIO))
                                badBaseStr = true;
                            break;
                        case "D":
                            baseData.numStudCard = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "O":
                            baseData.dateContract = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "Z":
                            baseData.ino = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "N":
                            baseData.liveForm = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "L":
                            baseData.liveEnd = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "M":
                            baseData.room = obj == null ? string.Empty : obj.ToString();
                            break;
                        case "W":
                            baseData.group = obj == null ? string.Empty : obj.ToString();
                            break;
                    }
                }
                if (!badBaseStr)
                    listStudents.Add(baseData);
            }

            foreach (BaseData student in listStudents)
            {
                var item = Students.FirstOrDefault(y => y.FIO == student.FIO);

                if (item == null)
                    continue;

                string numStudCard = student.numStudCard;
                string dateContract = student.dateContract.Split(' ')[0];
                string ino = student.ino;
                string liveForm = student.liveForm;
                string liveEnd = student.liveEnd.Split(' ')[0];
                string room = student.room;
                string group = student.group;

                int numYear = DateTime.Now.Year.ToString().Length;
                string yearContract = dateContract.Substring(dateContract.Length - numYear, numYear);
                string yearEnd = liveEnd.Substring(liveEnd.Length - numYear, numYear);

                if (!int.TryParse(yearContract, out int number1))
                    item.errors.Add(Student.Error.BadDateOfContract);
                if (liveForm != "дог" && liveForm != "15Ф" && liveForm != "")
                    item.errors.Add(Student.Error.BadForm);
                if (!int.TryParse(yearEnd, out int number2))
                    item.errors.Add(Student.Error.BadDateOfEnd);
                if (string.IsNullOrWhiteSpace(numStudCard))
                    item.errors.Add(Student.Error.EmptyStudentCard);
                if (string.IsNullOrWhiteSpace(group))
                    item.errors.Add(Student.Error.EmptyGroup);
                //if (string.IsNullOrWhiteSpace(room))
                //    item.errors.Add(Student.Error.EmptyRoom);
                if (string.IsNullOrWhiteSpace(ino))
                    item.errors.Add(Student.Error.EmptyCountry);

                if (item.errors.Any())
                    continue;

                var studenttype = new StudentType();
                var groupLast = group.Last().ToString();
                switch (groupLast)
                {
                    case "Б":
                        studenttype.IsBak = true;
                        break;
                    case "М":
                        studenttype.IsMast = true;
                        break;
                    default:
                        studenttype.IsSpec = true;
                        break;
                }

                item.NumberStudentCard = $"6-{numStudCard}/{yearContract}";
                if (ino != "РФ")
                    item.StudentsType = "ИНО";
                else if (liveForm == "дог")
                    item.StudentsType = liveForm;
                else
                    item.StudentsType = string.Empty;

                if ((liveForm == "15Ф" && checkedTypeStudents.Is15F) || (yearEnd == DateTime.Now.Year.ToString() && studenttype.IsEqual(checkedTypeStudents)))
                    item.IsGraduateDate = true;

                item.room = room;
            }

            foreach (var st in Students.Where(st => st.NumberStudentCard == null && !st.errors.Any()))
            {
                st.errors.Add(Student.Error.NoNameInBase);
            }

            excel.Save();

            excel.DisConnect();
        }

        private string GetDescriptionFromEnum(Enum st)
        {
            return ((DescriptionAttribute[])st.GetType().GetField(st.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
        }

        private void WriteToFile(string part, string value)
        {
            FromFile[part] = value;
            StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.UTF8);
            foreach(var p in FromFile)
            {
                sw.WriteLine(p.Key);
                sw.WriteLine(p.Value);
            }
            sw.Close();
        }
    }
}
