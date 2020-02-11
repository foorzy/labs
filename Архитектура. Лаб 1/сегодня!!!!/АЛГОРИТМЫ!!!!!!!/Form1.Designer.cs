namespace АЛГОРИТМЫ_______
{
    partial class Mainform
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.radioButtonHoar = new System.Windows.Forms.RadioButton();
            this.radioButtonShell = new System.Windows.Forms.RadioButton();
            this.radioButtonChoice = new System.Windows.Forms.RadioButton();
            this.radioButtonInsert = new System.Windows.Forms.RadioButton();
            this.radioButtonBuble = new System.Windows.Forms.RadioButton();
            this.buttonSort = new System.Windows.Forms.Button();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.radioButtonFast = new System.Windows.Forms.RadioButton();
            this.radioButtonInerpol = new System.Windows.Forms.RadioButton();
            this.radioButtonQSearch = new System.Windows.Forms.RadioButton();
            this.radioButtonBI = new System.Windows.Forms.RadioButton();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxDel = new System.Windows.Forms.TextBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.labelDel = new System.Windows.Forms.Label();
            this.buttonNewPerson = new System.Windows.Forms.Button();
            this.buttonDiagr1 = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxSort.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.Location = new System.Drawing.Point(12, 534);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(246, 88);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Открыть файл";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File,
            this.FIO});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(606, 488);
            this.dataGridView1.TabIndex = 1;
            // 
            // File
            // 
            this.File.HeaderText = "Рейтинг";
            this.File.Name = "File";
            this.File.ReadOnly = true;
            // 
            // FIO
            // 
            this.FIO.HeaderText = "ФИО";
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 950;
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Controls.Add(this.radioButtonHoar);
            this.groupBoxSort.Controls.Add(this.radioButtonShell);
            this.groupBoxSort.Controls.Add(this.radioButtonChoice);
            this.groupBoxSort.Controls.Add(this.radioButtonInsert);
            this.groupBoxSort.Controls.Add(this.radioButtonBuble);
            this.groupBoxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxSort.Location = new System.Drawing.Point(639, 24);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(432, 218);
            this.groupBoxSort.TabIndex = 2;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Выбери сортировку";
            // 
            // radioButtonHoar
            // 
            this.radioButtonHoar.AutoSize = true;
            this.radioButtonHoar.Location = new System.Drawing.Point(24, 182);
            this.radioButtonHoar.Name = "radioButtonHoar";
            this.radioButtonHoar.Size = new System.Drawing.Size(188, 24);
            this.radioButtonHoar.TabIndex = 7;
            this.radioButtonHoar.TabStop = true;
            this.radioButtonHoar.Text = "Сортировка Хоара";
            this.radioButtonHoar.UseVisualStyleBackColor = true;
            // 
            // radioButtonShell
            // 
            this.radioButtonShell.AutoSize = true;
            this.radioButtonShell.Location = new System.Drawing.Point(24, 142);
            this.radioButtonShell.Name = "radioButtonShell";
            this.radioButtonShell.Size = new System.Drawing.Size(190, 24);
            this.radioButtonShell.TabIndex = 6;
            this.radioButtonShell.TabStop = true;
            this.radioButtonShell.Text = "Сортировка Шелла";
            this.radioButtonShell.UseVisualStyleBackColor = true;
            // 
            // radioButtonChoice
            // 
            this.radioButtonChoice.AutoSize = true;
            this.radioButtonChoice.Location = new System.Drawing.Point(24, 106);
            this.radioButtonChoice.Name = "radioButtonChoice";
            this.radioButtonChoice.Size = new System.Drawing.Size(210, 24);
            this.radioButtonChoice.TabIndex = 5;
            this.radioButtonChoice.TabStop = true;
            this.radioButtonChoice.Text = "Сортировка выбором";
            this.radioButtonChoice.UseVisualStyleBackColor = true;
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Location = new System.Drawing.Point(24, 67);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(226, 24);
            this.radioButtonInsert.TabIndex = 4;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Сортировка вставками";
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            // 
            // radioButtonBuble
            // 
            this.radioButtonBuble.AutoSize = true;
            this.radioButtonBuble.Location = new System.Drawing.Point(24, 30);
            this.radioButtonBuble.Name = "radioButtonBuble";
            this.radioButtonBuble.Size = new System.Drawing.Size(226, 24);
            this.radioButtonBuble.TabIndex = 3;
            this.radioButtonBuble.TabStop = true;
            this.radioButtonBuble.Text = "Сортировка пузырьком";
            this.radioButtonBuble.UseVisualStyleBackColor = true;
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSort.Location = new System.Drawing.Point(1123, 33);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(179, 69);
            this.buttonSort.TabIndex = 3;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.radioButtonFast);
            this.groupBoxSearch.Controls.Add(this.radioButtonInerpol);
            this.groupBoxSearch.Controls.Add(this.radioButtonQSearch);
            this.groupBoxSearch.Controls.Add(this.radioButtonBI);
            this.groupBoxSearch.Controls.Add(this.radioButtonLinear);
            this.groupBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxSearch.Location = new System.Drawing.Point(639, 287);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(432, 267);
            this.groupBoxSearch.TabIndex = 4;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Выбери метод поиска";
            // 
            // radioButtonFast
            // 
            this.radioButtonFast.AutoSize = true;
            this.radioButtonFast.Location = new System.Drawing.Point(16, 91);
            this.radioButtonFast.Name = "radioButtonFast";
            this.radioButtonFast.Size = new System.Drawing.Size(206, 24);
            this.radioButtonFast.TabIndex = 7;
            this.radioButtonFast.TabStop = true;
            this.radioButtonFast.Text = "Сверхбыстрый поиск";
            this.radioButtonFast.UseVisualStyleBackColor = true;
            // 
            // radioButtonInerpol
            // 
            this.radioButtonInerpol.AutoSize = true;
            this.radioButtonInerpol.Location = new System.Drawing.Point(16, 228);
            this.radioButtonInerpol.Name = "radioButtonInerpol";
            this.radioButtonInerpol.Size = new System.Drawing.Size(246, 24);
            this.radioButtonInerpol.TabIndex = 7;
            this.radioButtonInerpol.TabStop = true;
            this.radioButtonInerpol.Text = "Интерполяционный поиск";
            this.radioButtonInerpol.UseVisualStyleBackColor = true;
            // 
            // radioButtonQSearch
            // 
            this.radioButtonQSearch.AutoSize = true;
            this.radioButtonQSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQSearch.Location = new System.Drawing.Point(16, 139);
            this.radioButtonQSearch.Name = "radioButtonQSearch";
            this.radioButtonQSearch.Size = new System.Drawing.Size(393, 21);
            this.radioButtonQSearch.TabIndex = 7;
            this.radioButtonQSearch.TabStop = true;
            this.radioButtonQSearch.Text = "Последовательный поиск в отсортированном массиве ";
            this.radioButtonQSearch.UseVisualStyleBackColor = true;
            // 
            // radioButtonBI
            // 
            this.radioButtonBI.AutoSize = true;
            this.radioButtonBI.Location = new System.Drawing.Point(16, 187);
            this.radioButtonBI.Name = "radioButtonBI";
            this.radioButtonBI.Size = new System.Drawing.Size(159, 24);
            this.radioButtonBI.TabIndex = 7;
            this.radioButtonBI.TabStop = true;
            this.radioButtonBI.Text = "Бинарній поиск";
            this.radioButtonBI.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(16, 52);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(167, 24);
            this.radioButtonLinear.TabIndex = 0;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Линейный поиск";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // textBoxNum
            // 
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNum.Location = new System.Drawing.Point(1123, 302);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(179, 61);
            this.textBoxNum.TabIndex = 5;
            this.textBoxNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNum_KeyPress);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(1123, 378);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(179, 56);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxDel
            // 
            this.textBoxDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDel.Location = new System.Drawing.Point(1180, 576);
            this.textBoxDel.Name = "textBoxDel";
            this.textBoxDel.Size = new System.Drawing.Size(179, 61);
            this.textBoxDel.TabIndex = 7;
            this.textBoxDel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDel_KeyPress);
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDel.Location = new System.Drawing.Point(1380, 579);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(103, 58);
            this.buttonDel.TabIndex = 8;
            this.buttonDel.Text = "Ок";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // labelDel
            // 
            this.labelDel.AutoSize = true;
            this.labelDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDel.Location = new System.Drawing.Point(918, 593);
            this.labelDel.Name = "labelDel";
            this.labelDel.Size = new System.Drawing.Size(242, 29);
            this.labelDel.TabIndex = 9;
            this.labelDel.Text = "Удалить элемент№";
            // 
            // buttonNewPerson
            // 
            this.buttonNewPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewPerson.Location = new System.Drawing.Point(302, 534);
            this.buttonNewPerson.Name = "buttonNewPerson";
            this.buttonNewPerson.Size = new System.Drawing.Size(244, 88);
            this.buttonNewPerson.TabIndex = 10;
            this.buttonNewPerson.Text = "Добавить новый элемент";
            this.buttonNewPerson.UseVisualStyleBackColor = true;
            this.buttonNewPerson.Click += new System.EventHandler(this.buttonNewPerson_Click);
            // 
            // buttonDiagr1
            // 
            this.buttonDiagr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDiagr1.Location = new System.Drawing.Point(1123, 130);
            this.buttonDiagr1.Name = "buttonDiagr1";
            this.buttonDiagr1.Size = new System.Drawing.Size(207, 60);
            this.buttonDiagr1.TabIndex = 11;
            this.buttonDiagr1.Text = "Статистика";
            this.buttonDiagr1.UseVisualStyleBackColor = true;
            this.buttonDiagr1.Click += new System.EventHandler(this.buttonDiagr1_Click);
            // 
            // btnStat
            // 
            this.btnStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStat.Location = new System.Drawing.Point(1123, 453);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(207, 60);
            this.btnStat.TabIndex = 12;
            this.btnStat.Text = "Статистика";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(573, 561);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 61);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 666);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.buttonDiagr1);
            this.Controls.Add(this.buttonNewPerson);
            this.Controls.Add(this.labelDel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.textBoxDel);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpen);
            this.Name = "Mainform";
            this.Text = "Лабораторная 1";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxSort.ResumeLayout(false);
            this.groupBoxSort.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.RadioButton radioButtonInsert;
        private System.Windows.Forms.RadioButton radioButtonBuble;
        private System.Windows.Forms.RadioButton radioButtonHoar;
        private System.Windows.Forms.RadioButton radioButtonShell;
        private System.Windows.Forms.RadioButton radioButtonChoice;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.RadioButton radioButtonBI;
        private System.Windows.Forms.RadioButton radioButtonQSearch;
        private System.Windows.Forms.RadioButton radioButtonInerpol;
        private System.Windows.Forms.RadioButton radioButtonFast;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.TextBox textBoxDel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Label labelDel;
        private System.Windows.Forms.Button buttonNewPerson;
        private System.Windows.Forms.Button buttonDiagr1;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.Button buttonSave;
    }
}

