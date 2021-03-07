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
    public partial class NullForm : Form
    {

        public NullForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Help.Cancel();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Help.Gusek = textBoxPath.Text;

            if (File.Exists(Help.path) && Help.Gusek != "")
            {
                try
                {
                    File.WriteAllText(Help.path, string.Empty);
                    File.WriteAllText(Help.Gusek + Help.Result, string.Empty);
                    File.WriteAllText(Help.Gusek + Help.Dima, string.Empty);
                    File.WriteAllText(Help.Gusek + Help.Mistake, string.Empty);

                    Hide();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Некорректный адрес");
            }
        }
    }
}
