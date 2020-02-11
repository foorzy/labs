namespace NfaDfaBondarenko
{
    partial class Form1
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
            this.transformaciyaNfaDfa = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StringInputMin = new System.Windows.Forms.TextBox();
            this.PokazSostoyaniyaMin = new System.Windows.Forms.Label();
            this.VsyaStrokaSrazuMin = new System.Windows.Forms.Button();
            this.VvodTextaMin = new System.Windows.Forms.Button();
            this.NextSostoyaniyeMin = new System.Windows.Forms.Button();
            this.NomerSostoyaniyaMin = new System.Windows.Forms.Label();
            this.MinimizaciyaAvtomata = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StringInput = new System.Windows.Forms.TextBox();
            this.Podskazka2 = new System.Windows.Forms.Label();
            this.VsyaStrokaSrazu = new System.Windows.Forms.Button();
            this.NextSostoyaniye = new System.Windows.Forms.Button();
            this.PokazSostoyaniya = new System.Windows.Forms.Label();
            this.VvodTexta = new System.Windows.Forms.Button();
            this.NomerSostoyaniya = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.Podskazka1 = new System.Windows.Forms.Label();
            this.VvodAlfavita = new System.Windows.Forms.Button();
            this.ChtoVNem = new System.Windows.Forms.Label();
            this.Schitka = new System.Windows.Forms.Button();
            this.Alfavit = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transformaciyaNfaDfa
            // 
            this.transformaciyaNfaDfa.Enabled = false;
            this.transformaciyaNfaDfa.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.transformaciyaNfaDfa.Location = new System.Drawing.Point(332, 8);
            this.transformaciyaNfaDfa.Name = "transformaciyaNfaDfa";
            this.transformaciyaNfaDfa.Size = new System.Drawing.Size(162, 231);
            this.transformaciyaNfaDfa.TabIndex = 48;
            this.transformaciyaNfaDfa.Text = "Преобразование NFA в DFA";
            this.transformaciyaNfaDfa.UseVisualStyleBackColor = true;
            this.transformaciyaNfaDfa.Click += new System.EventHandler(this.TransformaciyaNfaDfa_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.StringInputMin);
            this.groupBox3.Controls.Add(this.PokazSostoyaniyaMin);
            this.groupBox3.Controls.Add(this.VsyaStrokaSrazuMin);
            this.groupBox3.Controls.Add(this.VvodTextaMin);
            this.groupBox3.Controls.Add(this.NextSostoyaniyeMin);
            this.groupBox3.Controls.Add(this.NomerSostoyaniyaMin);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(984, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 236);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа с минимизированным";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 21);
            this.label1.TabIndex = 40;
            this.label1.Text = "Введите строку для обработки";
            // 
            // StringInputMin
            // 
            this.StringInputMin.Location = new System.Drawing.Point(29, 52);
            this.StringInputMin.Name = "StringInputMin";
            this.StringInputMin.Size = new System.Drawing.Size(254, 20);
            this.StringInputMin.TabIndex = 40;
            // 
            // PokazSostoyaniyaMin
            // 
            this.PokazSostoyaniyaMin.AutoSize = true;
            this.PokazSostoyaniyaMin.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.PokazSostoyaniyaMin.Location = new System.Drawing.Point(25, 129);
            this.PokazSostoyaniyaMin.Name = "PokazSostoyaniyaMin";
            this.PokazSostoyaniyaMin.Size = new System.Drawing.Size(165, 21);
            this.PokazSostoyaniyaMin.TabIndex = 34;
            this.PokazSostoyaniyaMin.Text = "Текущее состояние";
            // 
            // VsyaStrokaSrazuMin
            // 
            this.VsyaStrokaSrazuMin.Enabled = false;
            this.VsyaStrokaSrazuMin.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.VsyaStrokaSrazuMin.Location = new System.Drawing.Point(162, 153);
            this.VsyaStrokaSrazuMin.Name = "VsyaStrokaSrazuMin";
            this.VsyaStrokaSrazuMin.Size = new System.Drawing.Size(121, 72);
            this.VsyaStrokaSrazuMin.TabIndex = 32;
            this.VsyaStrokaSrazuMin.Text = "Вся строка";
            this.VsyaStrokaSrazuMin.UseVisualStyleBackColor = true;
            this.VsyaStrokaSrazuMin.Click += new System.EventHandler(this.VsyaStrokaSrazuMin_Click);
            // 
            // VvodTextaMin
            // 
            this.VvodTextaMin.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.VvodTextaMin.Location = new System.Drawing.Point(29, 78);
            this.VvodTextaMin.Name = "VvodTextaMin";
            this.VvodTextaMin.Size = new System.Drawing.Size(254, 46);
            this.VvodTextaMin.TabIndex = 33;
            this.VvodTextaMin.Text = "Принять";
            this.VvodTextaMin.UseVisualStyleBackColor = true;
            this.VvodTextaMin.Click += new System.EventHandler(this.VvodTextaMin_Click);
            // 
            // NextSostoyaniyeMin
            // 
            this.NextSostoyaniyeMin.Enabled = false;
            this.NextSostoyaniyeMin.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NextSostoyaniyeMin.Location = new System.Drawing.Point(29, 153);
            this.NextSostoyaniyeMin.Name = "NextSostoyaniyeMin";
            this.NextSostoyaniyeMin.Size = new System.Drawing.Size(121, 72);
            this.NextSostoyaniyeMin.TabIndex = 31;
            this.NextSostoyaniyeMin.Text = "Следующий символ (позиция)";
            this.NextSostoyaniyeMin.UseVisualStyleBackColor = true;
            this.NextSostoyaniyeMin.Click += new System.EventHandler(this.NextSostoyaniyeMin_Click);
            // 
            // NomerSostoyaniyaMin
            // 
            this.NomerSostoyaniyaMin.AutoSize = true;
            this.NomerSostoyaniyaMin.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomerSostoyaniyaMin.Location = new System.Drawing.Point(230, 129);
            this.NomerSostoyaniyaMin.Name = "NomerSostoyaniyaMin";
            this.NomerSostoyaniyaMin.Size = new System.Drawing.Size(53, 21);
            this.NomerSostoyaniyaMin.TabIndex = 35;
            this.NomerSostoyaniyaMin.Text = "ЖДУ";
            // 
            // MinimizaciyaAvtomata
            // 
            this.MinimizaciyaAvtomata.Enabled = false;
            this.MinimizaciyaAvtomata.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.MinimizaciyaAvtomata.Location = new System.Drawing.Point(816, 8);
            this.MinimizaciyaAvtomata.Name = "MinimizaciyaAvtomata";
            this.MinimizaciyaAvtomata.Size = new System.Drawing.Size(162, 231);
            this.MinimizaciyaAvtomata.TabIndex = 44;
            this.MinimizaciyaAvtomata.Text = "МАГИЯ";
            this.MinimizaciyaAvtomata.UseVisualStyleBackColor = true;
            this.MinimizaciyaAvtomata.Click += new System.EventHandler(this.MinimizaciyaAvtomata_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StringInput);
            this.groupBox2.Controls.Add(this.Podskazka2);
            this.groupBox2.Controls.Add(this.VsyaStrokaSrazu);
            this.groupBox2.Controls.Add(this.NextSostoyaniye);
            this.groupBox2.Controls.Add(this.PokazSostoyaniya);
            this.groupBox2.Controls.Add(this.VvodTexta);
            this.groupBox2.Controls.Add(this.NomerSostoyaniya);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(502, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 236);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа";
            // 
            // StringInput
            // 
            this.StringInput.Location = new System.Drawing.Point(29, 52);
            this.StringInput.Name = "StringInput";
            this.StringInput.Size = new System.Drawing.Size(254, 20);
            this.StringInput.TabIndex = 39;
            // 
            // Podskazka2
            // 
            this.Podskazka2.AutoSize = true;
            this.Podskazka2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Podskazka2.Location = new System.Drawing.Point(26, 16);
            this.Podskazka2.Name = "Podskazka2";
            this.Podskazka2.Size = new System.Drawing.Size(258, 21);
            this.Podskazka2.TabIndex = 37;
            this.Podskazka2.Text = "Введите строку для обработки";
            // 
            // VsyaStrokaSrazu
            // 
            this.VsyaStrokaSrazu.Enabled = false;
            this.VsyaStrokaSrazu.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.VsyaStrokaSrazu.Location = new System.Drawing.Point(162, 153);
            this.VsyaStrokaSrazu.Name = "VsyaStrokaSrazu";
            this.VsyaStrokaSrazu.Size = new System.Drawing.Size(121, 72);
            this.VsyaStrokaSrazu.TabIndex = 27;
            this.VsyaStrokaSrazu.Text = "Вся строка";
            this.VsyaStrokaSrazu.UseVisualStyleBackColor = true;
            this.VsyaStrokaSrazu.Click += new System.EventHandler(this.VsyaStrokaSrazu_Click);
            // 
            // NextSostoyaniye
            // 
            this.NextSostoyaniye.Enabled = false;
            this.NextSostoyaniye.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NextSostoyaniye.Location = new System.Drawing.Point(29, 153);
            this.NextSostoyaniye.Name = "NextSostoyaniye";
            this.NextSostoyaniye.Size = new System.Drawing.Size(121, 72);
            this.NextSostoyaniye.TabIndex = 22;
            this.NextSostoyaniye.Text = "Следующий символ (позиция)";
            this.NextSostoyaniye.UseVisualStyleBackColor = true;
            this.NextSostoyaniye.Click += new System.EventHandler(this.NextSostoyaniye_Click);
            // 
            // PokazSostoyaniya
            // 
            this.PokazSostoyaniya.AutoSize = true;
            this.PokazSostoyaniya.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.PokazSostoyaniya.Location = new System.Drawing.Point(25, 129);
            this.PokazSostoyaniya.Name = "PokazSostoyaniya";
            this.PokazSostoyaniya.Size = new System.Drawing.Size(177, 21);
            this.PokazSostoyaniya.TabIndex = 23;
            this.PokazSostoyaniya.Text = "Состояние автомата:";
            // 
            // VvodTexta
            // 
            this.VvodTexta.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.VvodTexta.Location = new System.Drawing.Point(29, 78);
            this.VvodTexta.Name = "VvodTexta";
            this.VvodTexta.Size = new System.Drawing.Size(254, 46);
            this.VvodTexta.TabIndex = 21;
            this.VvodTexta.Text = "Принять";
            this.VvodTexta.UseVisualStyleBackColor = true;
            this.VvodTexta.Click += new System.EventHandler(this.VvodTexta_Click);
            // 
            // NomerSostoyaniya
            // 
            this.NomerSostoyaniya.AutoSize = true;
            this.NomerSostoyaniya.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomerSostoyaniya.Location = new System.Drawing.Point(230, 129);
            this.NomerSostoyaniya.Name = "NomerSostoyaniya";
            this.NomerSostoyaniya.Size = new System.Drawing.Size(53, 21);
            this.NomerSostoyaniya.TabIndex = 25;
            this.NomerSostoyaniya.Text = "ЖДУ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InputBox);
            this.groupBox1.Controls.Add(this.Podskazka1);
            this.groupBox1.Controls.Add(this.VvodAlfavita);
            this.groupBox1.Controls.Add(this.ChtoVNem);
            this.groupBox1.Controls.Add(this.Schitka);
            this.groupBox1.Controls.Add(this.Alfavit);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 236);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введение";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(20, 52);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(284, 20);
            this.InputBox.TabIndex = 37;
            // 
            // Podskazka1
            // 
            this.Podskazka1.AutoSize = true;
            this.Podskazka1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Podskazka1.Location = new System.Drawing.Point(26, 16);
            this.Podskazka1.Name = "Podskazka1";
            this.Podskazka1.Size = new System.Drawing.Size(269, 21);
            this.Podskazka1.TabIndex = 36;
            this.Podskazka1.Text = "Введите буквы алфавита через *";
            // 
            // VvodAlfavita
            // 
            this.VvodAlfavita.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.VvodAlfavita.Location = new System.Drawing.Point(20, 78);
            this.VvodAlfavita.Name = "VvodAlfavita";
            this.VvodAlfavita.Size = new System.Drawing.Size(284, 46);
            this.VvodAlfavita.TabIndex = 16;
            this.VvodAlfavita.Text = "Принять";
            this.VvodAlfavita.UseVisualStyleBackColor = true;
            this.VvodAlfavita.Click += new System.EventHandler(this.VvodAlfavita_Click);
            // 
            // ChtoVNem
            // 
            this.ChtoVNem.AutoSize = true;
            this.ChtoVNem.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ChtoVNem.Location = new System.Drawing.Point(170, 129);
            this.ChtoVNem.Name = "ChtoVNem";
            this.ChtoVNem.Size = new System.Drawing.Size(53, 21);
            this.ChtoVNem.TabIndex = 26;
            this.ChtoVNem.Text = "ЖДУ";
            // 
            // Schitka
            // 
            this.Schitka.Enabled = false;
            this.Schitka.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Schitka.Location = new System.Drawing.Point(20, 153);
            this.Schitka.Name = "Schitka";
            this.Schitka.Size = new System.Drawing.Size(284, 72);
            this.Schitka.TabIndex = 15;
            this.Schitka.Text = "Подгрузить файл с тестом";
            this.Schitka.UseVisualStyleBackColor = true;
            this.Schitka.Click += new System.EventHandler(this.Schitka_Click);
            // 
            // Alfavit
            // 
            this.Alfavit.AutoSize = true;
            this.Alfavit.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.Alfavit.Location = new System.Drawing.Point(70, 129);
            this.Alfavit.Name = "Alfavit";
            this.Alfavit.Size = new System.Drawing.Size(83, 21);
            this.Alfavit.TabIndex = 24;
            this.Alfavit.Text = "Алфавит:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1294, 241);
            this.Controls.Add(this.transformaciyaNfaDfa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MinimizaciyaAvtomata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button transformaciyaNfaDfa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StringInputMin;
        private System.Windows.Forms.Label PokazSostoyaniyaMin;
        private System.Windows.Forms.Button VsyaStrokaSrazuMin;
        private System.Windows.Forms.Button VvodTextaMin;
        private System.Windows.Forms.Button NextSostoyaniyeMin;
        private System.Windows.Forms.Label NomerSostoyaniyaMin;
        private System.Windows.Forms.Button MinimizaciyaAvtomata;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox StringInput;
        private System.Windows.Forms.Label Podskazka2;
        private System.Windows.Forms.Button VsyaStrokaSrazu;
        private System.Windows.Forms.Button NextSostoyaniye;
        private System.Windows.Forms.Label PokazSostoyaniya;
        private System.Windows.Forms.Button VvodTexta;
        private System.Windows.Forms.Label NomerSostoyaniya;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label Podskazka1;
        private System.Windows.Forms.Button VvodAlfavita;
        private System.Windows.Forms.Label ChtoVNem;
        private System.Windows.Forms.Button Schitka;
        private System.Windows.Forms.Label Alfavit;
    }
}

