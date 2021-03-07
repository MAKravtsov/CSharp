namespace Diploma
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelEquipment = new System.Windows.Forms.Label();
            this.textBoxEquipment = new System.Windows.Forms.TextBox();
            this.labelDetail = new System.Windows.Forms.Label();
            this.textBoxDetail = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxEquipment = new System.Windows.Forms.ListBox();
            this.listBoxDetail = new System.Windows.Forms.ListBox();
            this.buttonEquipmentAdd = new System.Windows.Forms.Button();
            this.buttonEquipmentSub = new System.Windows.Forms.Button();
            this.buttonDetailAdd = new System.Windows.Forms.Button();
            this.buttonDetailSub = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEquipment
            // 
            this.labelEquipment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEquipment.Location = new System.Drawing.Point(41, 0);
            this.labelEquipment.Name = "labelEquipment";
            this.labelEquipment.Size = new System.Drawing.Size(341, 37);
            this.labelEquipment.TabIndex = 0;
            this.labelEquipment.Text = "Множество станков";
            this.labelEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEquipment
            // 
            this.textBoxEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEquipment.Location = new System.Drawing.Point(41, 42);
            this.textBoxEquipment.Name = "textBoxEquipment";
            this.textBoxEquipment.Size = new System.Drawing.Size(341, 26);
            this.textBoxEquipment.TabIndex = 1;
            this.textBoxEquipment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxEquipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEquipment_KeyDown);
            // 
            // labelDetail
            // 
            this.labelDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDetail.Location = new System.Drawing.Point(388, 0);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(341, 37);
            this.labelDetail.TabIndex = 2;
            this.labelDetail.Text = "Множество деталей";
            this.labelDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDetail
            // 
            this.textBoxDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDetail.Location = new System.Drawing.Point(388, 42);
            this.textBoxDetail.Name = "textBoxDetail";
            this.textBoxDetail.Size = new System.Drawing.Size(341, 26);
            this.textBoxDetail.TabIndex = 3;
            this.textBoxDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDetail_KeyDown);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.Location = new System.Drawing.Point(688, 401);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 37);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(15, 401);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 37);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxEquipment
            // 
            this.listBoxEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxEquipment.FormattingEnabled = true;
            this.listBoxEquipment.ItemHeight = 20;
            this.listBoxEquipment.Location = new System.Drawing.Point(41, 77);
            this.listBoxEquipment.Name = "listBoxEquipment";
            this.listBoxEquipment.Size = new System.Drawing.Size(341, 290);
            this.listBoxEquipment.TabIndex = 6;
            // 
            // listBoxDetail
            // 
            this.listBoxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxDetail.FormattingEnabled = true;
            this.listBoxDetail.ItemHeight = 20;
            this.listBoxDetail.Location = new System.Drawing.Point(388, 77);
            this.listBoxDetail.Name = "listBoxDetail";
            this.listBoxDetail.Size = new System.Drawing.Size(341, 290);
            this.listBoxDetail.TabIndex = 7;
            // 
            // buttonEquipmentAdd
            // 
            this.buttonEquipmentAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEquipmentAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEquipmentAdd.Location = new System.Drawing.Point(3, 40);
            this.buttonEquipmentAdd.Name = "buttonEquipmentAdd";
            this.buttonEquipmentAdd.Size = new System.Drawing.Size(32, 31);
            this.buttonEquipmentAdd.TabIndex = 8;
            this.buttonEquipmentAdd.Text = "+";
            this.buttonEquipmentAdd.UseVisualStyleBackColor = true;
            this.buttonEquipmentAdd.Click += new System.EventHandler(this.buttonEquipmentAdd_Click);
            // 
            // buttonEquipmentSub
            // 
            this.buttonEquipmentSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEquipmentSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEquipmentSub.Location = new System.Drawing.Point(3, 202);
            this.buttonEquipmentSub.Name = "buttonEquipmentSub";
            this.buttonEquipmentSub.Size = new System.Drawing.Size(32, 39);
            this.buttonEquipmentSub.TabIndex = 9;
            this.buttonEquipmentSub.Text = "-";
            this.buttonEquipmentSub.UseVisualStyleBackColor = true;
            this.buttonEquipmentSub.Click += new System.EventHandler(this.buttonEquipmentSub_Click);
            // 
            // buttonDetailAdd
            // 
            this.buttonDetailAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDetailAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDetailAdd.Location = new System.Drawing.Point(735, 40);
            this.buttonDetailAdd.Name = "buttonDetailAdd";
            this.buttonDetailAdd.Size = new System.Drawing.Size(35, 31);
            this.buttonDetailAdd.TabIndex = 10;
            this.buttonDetailAdd.Text = "+";
            this.buttonDetailAdd.UseVisualStyleBackColor = true;
            this.buttonDetailAdd.Click += new System.EventHandler(this.buttonDetailAdd_Click);
            // 
            // buttonDetailSub
            // 
            this.buttonDetailSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDetailSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDetailSub.Location = new System.Drawing.Point(735, 201);
            this.buttonDetailSub.Name = "buttonDetailSub";
            this.buttonDetailSub.Size = new System.Drawing.Size(35, 41);
            this.buttonDetailSub.TabIndex = 11;
            this.buttonDetailSub.Text = "-";
            this.buttonDetailSub.UseVisualStyleBackColor = true;
            this.buttonDetailSub.Click += new System.EventHandler(this.buttonDetailSub_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(569, 401);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 37);
            this.buttonBack.TabIndex = 12;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInfo.Location = new System.Drawing.Point(137, 401);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(100, 37);
            this.buttonInfo.TabIndex = 13;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxDetail, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonDetailSub, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxEquipment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEquipmentSub, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEquipmentAdd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDetail, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxEquipment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelEquipment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDetail, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDetailAdd, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 370);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonNext);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оборудование и детали";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelEquipment;
        private System.Windows.Forms.Label labelDetail;
        private System.Windows.Forms.TextBox textBoxDetail;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxEquipment;
        private System.Windows.Forms.Button buttonEquipmentAdd;
        private System.Windows.Forms.Button buttonEquipmentSub;
        private System.Windows.Forms.Button buttonDetailAdd;
        private System.Windows.Forms.Button buttonDetailSub;
        public System.Windows.Forms.ListBox listBoxEquipment;
        public System.Windows.Forms.ListBox listBoxDetail;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

