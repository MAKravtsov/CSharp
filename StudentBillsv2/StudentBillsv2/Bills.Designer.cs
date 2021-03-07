namespace StudentsBillsv2
{
    partial class Bills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OrderLabel = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.PDFlabel = new System.Windows.Forms.Label();
            this.PDFButton = new System.Windows.Forms.Button();
            this.PDFTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePickerEndGraduate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.Performbutton = new System.Windows.Forms.Button();
            this.StudentsButton = new System.Windows.Forms.Button();
            this.StudentsLabel = new System.Windows.Forms.Label();
            this.StudentsTextBox = new System.Windows.Forms.TextBox();
            this.OverviewButtonBase = new System.Windows.Forms.Button();
            this.BaseLabel = new System.Windows.Forms.Label();
            this.BaseTextBox = new System.Windows.Forms.TextBox();
            this.PrintCheckBox = new System.Windows.Forms.CheckBox();
            this.PDFCheckBox = new System.Windows.Forms.CheckBox();
            this.PriceElectrLabel = new System.Windows.Forms.Label();
            this.PriceElectrTextBox = new System.Windows.Forms.TextBox();
            this.PriceCommBudgLabel = new System.Windows.Forms.Label();
            this.PriceCommBudgTextBox = new System.Windows.Forms.TextBox();
            this.PriceCommPlatnLabel = new System.Windows.Forms.Label();
            this.PriceCommPlatnTextBox = new System.Windows.Forms.TextBox();
            this.PriceEmployeeLabel = new System.Windows.Forms.Label();
            this.PriceEmployeeTextBox = new System.Windows.Forms.TextBox();
            this.EndGraduate = new System.Windows.Forms.Label();
            this.End = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Label();
            this.openFileDialogBase = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogStudents = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogPDF = new System.Windows.Forms.FolderBrowserDialog();
            this.status = new System.Windows.Forms.StatusStrip();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxTemplates = new System.Windows.Forms.TextBox();
            this.buttonTemplates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialogTemplates = new System.Windows.Forms.FolderBrowserDialog();
            this.checkedListBoxDopDate = new System.Windows.Forms.CheckedListBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderLabel
            // 
            this.OrderLabel.AutoSize = true;
            this.OrderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderLabel.Location = new System.Drawing.Point(45, 422);
            this.OrderLabel.Name = "OrderLabel";
            this.OrderLabel.Size = new System.Drawing.Size(58, 13);
            this.OrderLabel.TabIndex = 60;
            this.OrderLabel.Text = "Порядок";
            // 
            // checkedListBox
            // 
            this.checkedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "По комнатам",
            "По алфавиту"});
            this.checkedListBox.Location = new System.Drawing.Point(27, 438);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(120, 30);
            this.checkedListBox.TabIndex = 59;
            this.checkedListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_SelectedIndexChanged);
            // 
            // PDFlabel
            // 
            this.PDFlabel.AutoSize = true;
            this.PDFlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PDFlabel.Location = new System.Drawing.Point(83, 355);
            this.PDFlabel.Name = "PDFlabel";
            this.PDFlabel.Size = new System.Drawing.Size(211, 13);
            this.PDFlabel.TabIndex = 58;
            this.PDFlabel.Text = "Выберите папку, куда класть PDF";
            this.PDFlabel.Visible = false;
            // 
            // PDFButton
            // 
            this.PDFButton.Location = new System.Drawing.Point(748, 350);
            this.PDFButton.Name = "PDFButton";
            this.PDFButton.Size = new System.Drawing.Size(75, 23);
            this.PDFButton.TabIndex = 57;
            this.PDFButton.Text = "Обзор";
            this.PDFButton.UseVisualStyleBackColor = true;
            this.PDFButton.Visible = false;
            this.PDFButton.Click += new System.EventHandler(this.PDFButton_Click);
            // 
            // PDFTextBox
            // 
            this.PDFTextBox.Location = new System.Drawing.Point(305, 352);
            this.PDFTextBox.Multiline = true;
            this.PDFTextBox.Name = "PDFTextBox";
            this.PDFTextBox.Size = new System.Drawing.Size(403, 20);
            this.PDFTextBox.TabIndex = 56;
            this.PDFTextBox.Visible = false;
            // 
            // dateTimePickerEndGraduate
            // 
            this.dateTimePickerEndGraduate.Location = new System.Drawing.Point(309, 222);
            this.dateTimePickerEndGraduate.Name = "dateTimePickerEndGraduate";
            this.dateTimePickerEndGraduate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndGraduate.TabIndex = 55;
            this.dateTimePickerEndGraduate.ValueChanged += new System.EventHandler(this.dateTimePickerEndGraduate_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(19, 266);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 54;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(19, 191);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 53;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // Performbutton
            // 
            this.Performbutton.BackColor = System.Drawing.Color.Green;
            this.Performbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Performbutton.Location = new System.Drawing.Point(805, 425);
            this.Performbutton.Name = "Performbutton";
            this.Performbutton.Size = new System.Drawing.Size(166, 58);
            this.Performbutton.TabIndex = 52;
            this.Performbutton.Text = "Выполнить";
            this.Performbutton.UseVisualStyleBackColor = false;
            this.Performbutton.Click += new System.EventHandler(this.PerformButton_Click);
            // 
            // StudentsButton
            // 
            this.StudentsButton.Location = new System.Drawing.Point(748, 99);
            this.StudentsButton.Name = "StudentsButton";
            this.StudentsButton.Size = new System.Drawing.Size(75, 23);
            this.StudentsButton.TabIndex = 51;
            this.StudentsButton.Text = "Обзор";
            this.StudentsButton.UseVisualStyleBackColor = true;
            this.StudentsButton.Click += new System.EventHandler(this.StudentsButton_Click);
            // 
            // StudentsLabel
            // 
            this.StudentsLabel.AutoSize = true;
            this.StudentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StudentsLabel.Location = new System.Drawing.Point(45, 104);
            this.StudentsLabel.Name = "StudentsLabel";
            this.StudentsLabel.Size = new System.Drawing.Size(231, 13);
            this.StudentsLabel.TabIndex = 50;
            this.StudentsLabel.Text = "Выберите excel с именами студентов";
            // 
            // StudentsTextBox
            // 
            this.StudentsTextBox.Location = new System.Drawing.Point(305, 101);
            this.StudentsTextBox.Name = "StudentsTextBox";
            this.StudentsTextBox.Size = new System.Drawing.Size(403, 20);
            this.StudentsTextBox.TabIndex = 49;
            // 
            // OverviewButtonBase
            // 
            this.OverviewButtonBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OverviewButtonBase.Location = new System.Drawing.Point(748, 29);
            this.OverviewButtonBase.Name = "OverviewButtonBase";
            this.OverviewButtonBase.Size = new System.Drawing.Size(75, 23);
            this.OverviewButtonBase.TabIndex = 48;
            this.OverviewButtonBase.Text = "Обзор";
            this.OverviewButtonBase.UseVisualStyleBackColor = true;
            this.OverviewButtonBase.Click += new System.EventHandler(this.OverviewButtonBase_Click);
            // 
            // BaseLabel
            // 
            this.BaseLabel.AutoSize = true;
            this.BaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaseLabel.Location = new System.Drawing.Point(77, 34);
            this.BaseLabel.Name = "BaseLabel";
            this.BaseLabel.Size = new System.Drawing.Size(145, 13);
            this.BaseLabel.TabIndex = 47;
            this.BaseLabel.Text = "Выберите Базу Боевую";
            // 
            // BaseTextBox
            // 
            this.BaseTextBox.Location = new System.Drawing.Point(305, 31);
            this.BaseTextBox.Name = "BaseTextBox";
            this.BaseTextBox.Size = new System.Drawing.Size(403, 20);
            this.BaseTextBox.TabIndex = 46;
            // 
            // PrintCheckBox
            // 
            this.PrintCheckBox.AutoSize = true;
            this.PrintCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrintCheckBox.Location = new System.Drawing.Point(27, 377);
            this.PrintCheckBox.Name = "PrintCheckBox";
            this.PrintCheckBox.Size = new System.Drawing.Size(68, 17);
            this.PrintCheckBox.TabIndex = 45;
            this.PrintCheckBox.Text = "Печать";
            this.PrintCheckBox.UseVisualStyleBackColor = true;
            this.PrintCheckBox.CheckedChanged += new System.EventHandler(this.PrintCheckBox_CheckedChanged);
            // 
            // PDFCheckBox
            // 
            this.PDFCheckBox.AutoSize = true;
            this.PDFCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PDFCheckBox.Location = new System.Drawing.Point(27, 354);
            this.PDFCheckBox.Name = "PDFCheckBox";
            this.PDFCheckBox.Size = new System.Drawing.Size(50, 17);
            this.PDFCheckBox.TabIndex = 44;
            this.PDFCheckBox.Text = "PDF";
            this.PDFCheckBox.UseVisualStyleBackColor = true;
            this.PDFCheckBox.CheckedChanged += new System.EventHandler(this.PDFCheckBox_CheckedChanged);
            // 
            // PriceElectrLabel
            // 
            this.PriceElectrLabel.AutoSize = true;
            this.PriceElectrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceElectrLabel.Location = new System.Drawing.Point(621, 298);
            this.PriceElectrLabel.Name = "PriceElectrLabel";
            this.PriceElectrLabel.Size = new System.Drawing.Size(199, 13);
            this.PriceElectrLabel.TabIndex = 43;
            this.PriceElectrLabel.Text = "Цена за месяц, элекстричество";
            // 
            // PriceElectrTextBox
            // 
            this.PriceElectrTextBox.Location = new System.Drawing.Point(870, 295);
            this.PriceElectrTextBox.Name = "PriceElectrTextBox";
            this.PriceElectrTextBox.Size = new System.Drawing.Size(100, 20);
            this.PriceElectrTextBox.TabIndex = 42;
            this.PriceElectrTextBox.TextChanged += new System.EventHandler(this.PriceElectrTextBox_TextChanged);
            // 
            // PriceCommBudgLabel
            // 
            this.PriceCommBudgLabel.AutoSize = true;
            this.PriceCommBudgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceCommBudgLabel.Location = new System.Drawing.Point(610, 252);
            this.PriceCommBudgLabel.Name = "PriceCommBudgLabel";
            this.PriceCommBudgLabel.Size = new System.Drawing.Size(230, 13);
            this.PriceCommBudgLabel.TabIndex = 41;
            this.PriceCommBudgLabel.Text = "Цена за месяц, коммуналка, бюджет";
            // 
            // PriceCommBudgTextBox
            // 
            this.PriceCommBudgTextBox.Location = new System.Drawing.Point(870, 249);
            this.PriceCommBudgTextBox.Name = "PriceCommBudgTextBox";
            this.PriceCommBudgTextBox.Size = new System.Drawing.Size(100, 20);
            this.PriceCommBudgTextBox.TabIndex = 40;
            this.PriceCommBudgTextBox.TextChanged += new System.EventHandler(this.PriceCommBudgTextBox_TextChanged);
            // 
            // PriceCommPlatnLabel
            // 
            this.PriceCommPlatnLabel.AutoSize = true;
            this.PriceCommPlatnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceCommPlatnLabel.Location = new System.Drawing.Point(610, 207);
            this.PriceCommPlatnLabel.Name = "PriceCommPlatnLabel";
            this.PriceCommPlatnLabel.Size = new System.Drawing.Size(240, 13);
            this.PriceCommPlatnLabel.TabIndex = 39;
            this.PriceCommPlatnLabel.Text = "Цена за месяц, коммуналка, платники";
            // 
            // PriceCommPlatnTextBox
            // 
            this.PriceCommPlatnTextBox.Location = new System.Drawing.Point(870, 204);
            this.PriceCommPlatnTextBox.Name = "PriceCommPlatnTextBox";
            this.PriceCommPlatnTextBox.Size = new System.Drawing.Size(100, 20);
            this.PriceCommPlatnTextBox.TabIndex = 38;
            this.PriceCommPlatnTextBox.TextChanged += new System.EventHandler(this.PriceCommPlatnTextBox_TextChanged);
            // 
            // PriceEmployeeLabel
            // 
            this.PriceEmployeeLabel.AutoSize = true;
            this.PriceEmployeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceEmployeeLabel.Location = new System.Drawing.Point(641, 163);
            this.PriceEmployeeLabel.Name = "PriceEmployeeLabel";
            this.PriceEmployeeLabel.Size = new System.Drawing.Size(134, 13);
            this.PriceEmployeeLabel.TabIndex = 37;
            this.PriceEmployeeLabel.Text = "Цена за месяц, найм";
            // 
            // PriceEmployeeTextBox
            // 
            this.PriceEmployeeTextBox.Location = new System.Drawing.Point(870, 160);
            this.PriceEmployeeTextBox.Name = "PriceEmployeeTextBox";
            this.PriceEmployeeTextBox.Size = new System.Drawing.Size(100, 20);
            this.PriceEmployeeTextBox.TabIndex = 36;
            this.PriceEmployeeTextBox.TextChanged += new System.EventHandler(this.PriceEmployeeTextBox_TextChanged);
            // 
            // EndGraduate
            // 
            this.EndGraduate.AutoSize = true;
            this.EndGraduate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndGraduate.Location = new System.Drawing.Point(288, 191);
            this.EndGraduate.Name = "EndGraduate";
            this.EndGraduate.Size = new System.Drawing.Size(250, 13);
            this.EndGraduate.TabIndex = 35;
            this.EndGraduate.Text = "Отдельная дата для выпускников и 15Ф";
            // 
            // End
            // 
            this.End.AutoSize = true;
            this.End.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.End.Location = new System.Drawing.Point(90, 245);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(43, 13);
            this.End.TabIndex = 34;
            this.End.Text = "Конец";
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(83, 163);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(50, 13);
            this.Start.TabIndex = 33;
            this.Start.Text = "Начало";
            // 
            // openFileDialogBase
            // 
            this.openFileDialogBase.FileName = "openFileDialog1";
            // 
            // openFileDialogStudents
            // 
            this.openFileDialogStudents.FileName = "openFileDialog1";
            // 
            // folderBrowserDialogPDF
            // 
            this.folderBrowserDialogPDF.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progress,
            this.toolStripStatusLabelPercent,
            this.toolStripStatusLabel});
            this.status.Location = new System.Drawing.Point(0, 526);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(993, 22);
            this.status.TabIndex = 61;
            this.status.Text = "statusStrip1";
            this.status.Visible = false;
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(600, 16);
            // 
            // toolStripStatusLabelPercent
            // 
            this.toolStripStatusLabelPercent.Name = "toolStripStatusLabelPercent";
            this.toolStripStatusLabelPercent.Size = new System.Drawing.Size(23, 17);
            this.toolStripStatusLabelPercent.Text = "0%";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel.Text = "Статус";
            // 
            // textBoxTemplates
            // 
            this.textBoxTemplates.Location = new System.Drawing.Point(305, 67);
            this.textBoxTemplates.Name = "textBoxTemplates";
            this.textBoxTemplates.Size = new System.Drawing.Size(403, 20);
            this.textBoxTemplates.TabIndex = 62;
            // 
            // buttonTemplates
            // 
            this.buttonTemplates.Location = new System.Drawing.Point(748, 65);
            this.buttonTemplates.Name = "buttonTemplates";
            this.buttonTemplates.Size = new System.Drawing.Size(75, 23);
            this.buttonTemplates.TabIndex = 63;
            this.buttonTemplates.Text = "Обзор";
            this.buttonTemplates.UseVisualStyleBackColor = true;
            this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(77, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Выберите файл Templates";
            // 
            // checkedListBoxDopDate
            // 
            this.checkedListBoxDopDate.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxDopDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxDopDate.FormattingEnabled = true;
            this.checkedListBoxDopDate.Items.AddRange(new object[] {
            "Бакалавры",
            "Магистры",
            "Специалисты",
            "15 форма"});
            this.checkedListBoxDopDate.Location = new System.Drawing.Point(362, 252);
            this.checkedListBoxDopDate.Name = "checkedListBoxDopDate";
            this.checkedListBoxDopDate.Size = new System.Drawing.Size(96, 60);
            this.checkedListBoxDopDate.TabIndex = 65;
            // 
            // Bills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 548);
            this.Controls.Add(this.checkedListBoxDopDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTemplates);
            this.Controls.Add(this.textBoxTemplates);
            this.Controls.Add(this.status);
            this.Controls.Add(this.OrderLabel);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.PDFlabel);
            this.Controls.Add(this.PDFButton);
            this.Controls.Add(this.PDFTextBox);
            this.Controls.Add(this.dateTimePickerEndGraduate);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.Performbutton);
            this.Controls.Add(this.StudentsButton);
            this.Controls.Add(this.StudentsLabel);
            this.Controls.Add(this.StudentsTextBox);
            this.Controls.Add(this.OverviewButtonBase);
            this.Controls.Add(this.BaseLabel);
            this.Controls.Add(this.BaseTextBox);
            this.Controls.Add(this.PrintCheckBox);
            this.Controls.Add(this.PDFCheckBox);
            this.Controls.Add(this.PriceElectrLabel);
            this.Controls.Add(this.PriceElectrTextBox);
            this.Controls.Add(this.PriceCommBudgLabel);
            this.Controls.Add(this.PriceCommBudgTextBox);
            this.Controls.Add(this.PriceCommPlatnLabel);
            this.Controls.Add(this.PriceCommPlatnTextBox);
            this.Controls.Add(this.PriceEmployeeLabel);
            this.Controls.Add(this.PriceEmployeeTextBox);
            this.Controls.Add(this.EndGraduate);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Start);
            this.Name = "Bills";
            this.Text = "Bills";
            this.Load += new System.EventHandler(this.Bills_Load_1);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label OrderLabel;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Label PDFlabel;
        private System.Windows.Forms.Button PDFButton;
        public System.Windows.Forms.TextBox PDFTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndGraduate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button Performbutton;
        private System.Windows.Forms.Button StudentsButton;
        private System.Windows.Forms.Label StudentsLabel;
        private System.Windows.Forms.TextBox StudentsTextBox;
        private System.Windows.Forms.Button OverviewButtonBase;
        private System.Windows.Forms.Label BaseLabel;
        private System.Windows.Forms.TextBox BaseTextBox;
        public System.Windows.Forms.CheckBox PrintCheckBox;
        public System.Windows.Forms.CheckBox PDFCheckBox;
        private System.Windows.Forms.Label PriceElectrLabel;
        private System.Windows.Forms.TextBox PriceElectrTextBox;
        private System.Windows.Forms.Label PriceCommBudgLabel;
        private System.Windows.Forms.TextBox PriceCommBudgTextBox;
        private System.Windows.Forms.Label PriceCommPlatnLabel;
        private System.Windows.Forms.TextBox PriceCommPlatnTextBox;
        private System.Windows.Forms.Label PriceEmployeeLabel;
        private System.Windows.Forms.TextBox PriceEmployeeTextBox;
        private System.Windows.Forms.Label EndGraduate;
        private System.Windows.Forms.Label End;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.OpenFileDialog openFileDialogBase;
        private System.Windows.Forms.OpenFileDialog openFileDialogStudents;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPDF;
        private System.Windows.Forms.StatusStrip status;
        public System.Windows.Forms.ToolStripProgressBar progress;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPercent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox textBoxTemplates;
        private System.Windows.Forms.Button buttonTemplates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogTemplates;
        private System.Windows.Forms.CheckedListBox checkedListBoxDopDate;
    }
}

