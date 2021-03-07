using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using StudentBillsv2;

namespace StudentsBillsv2
{
    public class Student
    {
        public string FIO;
        public string NumberStudentCard;
        public string StudentsType;
        public bool IsGraduateDate;
        public string room;

        public List<Error> errors = new List<Error>();

        public void Method(Student el, string path, DateTime startDate, DateTime DateB, DateTime DateNorm, double Price, string target, Bills bills)
        {
            DateTime endDate = el.IsGraduateDate ? DateB : DateNorm;

            var excel = new ExcelFile();
            excel.Connect(path, "квитанция");

            excel.FillCell(18, "G", el.FIO);
            excel.FillCell(16, "M", target == "электричество" ? "Э" + el.NumberStudentCard : el.NumberStudentCard);
            excel.FillCell(25, "S", startDate);
            excel.FillCell(25, "U", endDate);
            excel.FillCell(21, "S", Price * FindDiffMonths(startDate, endDate));

            excel.RunMacros("Лист1.QRCodeGenerate");

            excel.Save();

            if (bills.PDFCheckBox.Checked)
                excel.ExportToPDF($"{bills.PDFTextBox.Text}\\{el.FIO}_{target}");
            if (bills.PrintCheckBox.Checked)
                excel.Print();

            excel.DisConnect();
        }

        public enum Error
        {
            [Description("Не существует имени в базе")]
            NoNameInBase,
            [Description("Неправильно заполнен столбец <Дата подписания>")]
            BadDateOfContract,
            [Description("Неправильно заполнен столбец <Форма заселения>")]
            BadForm,
            [Description("Неправильно заполнен столбец <Конец проживания>")]
            BadDateOfEnd,
            [Description("Нет студенческого билета")]
            EmptyStudentCard,
            [Description("Нет группы")]
            EmptyGroup,
            [Description("Нет комнаты")]
            EmptyRoom,
            [Description("Нет страны")]
            EmptyCountry
        }

        /// <summary>
        /// Найти количнство месяцев между 2мя датами
        /// </summary>
        /// <param name="start">Начальная дата</param>
        /// <param name="end">Конечная дата</param>
        /// <returns></returns>
        private int FindDiffMonths(DateTime start, DateTime end)
        {
            int countMonth = 0;
            for (DateTime dt = start; dt < end; dt = dt.AddMonths(1))
            {
                countMonth++;
            }

            return countMonth;
        }
    }
}
