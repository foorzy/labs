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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxSort.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.Location = new System.Drawing.Point(21, 446);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(184, 72);
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
            this.dataGridView1.Location = new System.Drawing.Point(9, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(454, 396);
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
            this.groupBoxSort.Location = new System.Drawing.Point(479, 20);
            this.groupBoxSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSort.Size = new System.Drawing.Size(324, 177);
            this.groupBoxSort.TabIndex = 2;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Выбери сортировку";
            // 
            // radioButtonHoar
            // 
            this.radioButtonHoar.AutoSize = true;
            this.radioButtonHoar.Location = new System.Drawing.Point(18, 148);
            this.radioButtonHoar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonHoar.Name = "radioButtonHoar";
            this.radioButtonHoar.Size = new System.Drawing.Size(149, 21);
            this.radioButtonHoar.TabIndex = 7;
            this.radioButtonHoar.TabStop = true;
            this.radioButtonHoar.Text = "Сортировка Хоара";
            this.radioButtonHoar.UseVisualStyleBackColor = true;
            // 
            // radioButtonShell
            // 
            this.radioButtonShell.AutoSize = true;
            this.radioButtonShell.Location = new System.Drawing.Point(18, 115);
            this.radioButtonShell.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonShell.Name = "radioButtonShell";
            this.radioButtonShell.Size = new System.Drawing.Size(151, 21);
            this.radioButtonShell.TabIndex = 6;
            this.radioButtonShell.TabStop = true;
            this.radioButtonShell.Text = "Сортировка Шелла";
            this.radioButtonShell.UseVisualStyleBackColor = true;
            // 
            // radioButtonChoice
            // 
            this.radioButtonChoice.AutoSize = true;
            this.radioButtonChoice.Location = new System.Drawing.Point(18, 86);
            this.radioButtonChoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonChoice.Name = "radioButtonChoice";
            this.radioButtonChoice.Size = new System.Drawing.Size(166, 21);
            this.radioButtonChoice.TabIndex = 5;
            this.radioButtonChoice.TabStop = true;
            this.radioButtonChoice.Text = "Сортировка выбором";
            this.radioButtonChoice.UseVisualStyleBackColor = true;
            // 
            // radioButtonInsert
            // 
            this.radioButtonInsert.AutoSize = true;
            this.radioButtonInsert.Location = new System.Drawing.Point(18, 54);
            this.radioButtonInsert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonInsert.Name = "radioButtonInsert";
            this.radioButtonInsert.Size = new System.Drawing.Size(176, 21);
            this.radioButtonInsert.TabIndex = 4;
            this.radioButtonInsert.TabStop = true;
            this.radioButtonInsert.Text = "Сортировка вставками";
            this.radioButtonInsert.UseVisualStyleBackColor = true;
            // 
            // radioButtonBuble
            // 
            this.radioButtonBuble.AutoSize = true;
            this.radioButtonBuble.Location = new System.Drawing.Point(18, 24);
            this.radioButtonBuble.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonBuble.Name = "radioButtonBuble";
            this.radioButtonBuble.Size = new System.Drawing.Size(179, 21);
            this.radioButtonBuble.TabIndex = 3;
            this.radioButtonBuble.TabStop = true;
            this.radioButtonBuble.Text = "Сортировка пузырьком";
            this.radioButtonBuble.UseVisualStyleBackColor = true;
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSort.Location = new System.Drawing.Point(842, 27);
            this.buttonSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(134, 56);
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
            this.groupBoxSearch.Location = new System.Drawing.Point(479, 233);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSearch.Size = new System.Drawing.Size(324, 217);
            this.groupBoxSearch.TabIndex = 4;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Выбери метод поиска";
            // 
            // radioButtonFast
            // 
            this.radioButtonFast.AutoSize = true;
            this.radioButtonFast.Location = new System.Drawing.Point(12, 74);
            this.radioButtonFast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonFast.Name = "radioButtonFast";
            this.radioButtonFast.Size = new System.Drawing.Size(163, 21);
            this.radioButtonFast.TabIndex = 7;
            this.radioButtonFast.TabStop = true;
            this.radioButtonFast.Text = "Сверхьыстрый поиск";
            this.radioButtonFast.UseVisualStyleBackColor = true;
            // 
            // radioButtonInerpol
            // 
            this.radioButtonInerpol.AutoSize = true;
            this.radioButtonInerpol.Location = new System.Drawing.Point(12, 185);
            this.radioButtonInerpol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonInerpol.Name = "radioButtonInerpol";
            this.radioButtonInerpol.Size = new System.Drawing.Size(199, 21);
            this.radioButtonInerpol.TabIndex = 7;
            this.radioButtonInerpol.TabStop = true;
            this.radioButtonInerpol.Text = "Интерполяционный поиск";
            this.radioButtonInerpol.UseVisualStyleBackColor = true;
            // 
            // radioButtonQSearch
            // 
            this.radioButtonQSearch.AutoSize = true;
            this.radioButtonQSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonQSearch.Location = new System.Drawing.Point(12, 113);
            this.radioButtonQSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonQSearch.Name = "radioButtonQSearch";
            this.radioButtonQSearch.Size = new System.Drawing.Size(309, 17);
            this.radioButtonQSearch.TabIndex = 7;
            this.radioButtonQSearch.TabStop = true;
            this.radioButtonQSearch.Text = "Последовательный поиск в отсортированном массиве ";
            this.radioButtonQSearch.UseVisualStyleBackColor = true;
            // 
            // radioButtonBI
            // 
            this.radioButtonBI.AutoSize = true;
            this.radioButtonBI.Location = new System.Drawing.Point(12, 152);
            this.radioButtonBI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonBI.Name = "radioButtonBI";
            this.radioButtonBI.Size = new System.Drawing.Size(128, 21);
            this.radioButtonBI.TabIndex = 7;
            this.radioButtonBI.TabStop = true;
            this.radioButtonBI.Text = "Бинарній поиск";
            this.radioButtonBI.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(12, 42);
            this.radioButtonLinear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(136, 21);
            this.radioButtonLinear.TabIndex = 0;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Линейный поиск";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // textBoxNum
            // 
            this.textBoxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNum.Location = new System.Drawing.Point(842, 245);
            this.textBoxNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(135, 50);
            this.textBoxNum.TabIndex = 5;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(842, 332);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(134, 46);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 541);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpen);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

