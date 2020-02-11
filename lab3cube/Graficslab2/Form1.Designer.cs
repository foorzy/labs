namespace Graficslab2
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ЗагрузитьТочки = new System.Windows.Forms.Button();
            this.ЗагрузитьМатрицу = new System.Windows.Forms.Button();
            this.Draw = new System.Windows.Forms.Button();
            this.Povor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Увеличить = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Перенести = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PovorotOY = new System.Windows.Forms.Button();
            this.PovorotOZ = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.ПоКривой = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(697, 456);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ЗагрузитьТочки
            // 
            this.ЗагрузитьТочки.Location = new System.Drawing.Point(722, 3);
            this.ЗагрузитьТочки.Name = "ЗагрузитьТочки";
            this.ЗагрузитьТочки.Size = new System.Drawing.Size(107, 22);
            this.ЗагрузитьТочки.TabIndex = 1;
            this.ЗагрузитьТочки.Text = "Загрузить точки";
            this.ЗагрузитьТочки.UseVisualStyleBackColor = true;
            this.ЗагрузитьТочки.Click += new System.EventHandler(this.ЗагрузитьТочки_Click);
            // 
            // ЗагрузитьМатрицу
            // 
            this.ЗагрузитьМатрицу.Location = new System.Drawing.Point(835, 3);
            this.ЗагрузитьМатрицу.Name = "ЗагрузитьМатрицу";
            this.ЗагрузитьМатрицу.Size = new System.Drawing.Size(121, 22);
            this.ЗагрузитьМатрицу.TabIndex = 2;
            this.ЗагрузитьМатрицу.Text = "Загрузить матрицу ";
            this.ЗагрузитьМатрицу.UseVisualStyleBackColor = true;
            this.ЗагрузитьМатрицу.Click += new System.EventHandler(this.ЗагрузитьМатрицу_Click);
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(203, 474);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(268, 44);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "Нарисовать букву";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Povor
            // 
            this.Povor.Enabled = false;
            this.Povor.Location = new System.Drawing.Point(814, 191);
            this.Povor.Name = "Povor";
            this.Povor.Size = new System.Drawing.Size(61, 23);
            this.Povor.TabIndex = 4;
            this.Povor.Text = "GO!";
            this.Povor.UseVisualStyleBackColor = true;
            this.Povor.Click += new System.EventHandler(this.Povor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Масштабирование";
            // 
            // Увеличить
            // 
            this.Увеличить.Enabled = false;
            this.Увеличить.Location = new System.Drawing.Point(1040, 44);
            this.Увеличить.Name = "Увеличить";
            this.Увеличить.Size = new System.Drawing.Size(102, 23);
            this.Увеличить.TabIndex = 9;
            this.Увеличить.Text = "Увеличить";
            this.Увеличить.UseVisualStyleBackColor = true;
            this.Увеличить.Click += new System.EventHandler(this.Увеличить_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Перенос";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(905, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(967, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Z";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(826, 117);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(48, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(887, 117);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(48, 20);
            this.textBox4.TabIndex = 15;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(950, 117);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(48, 20);
            this.textBox5.TabIndex = 16;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // Перенести
            // 
            this.Перенести.Enabled = false;
            this.Перенести.Location = new System.Drawing.Point(826, 143);
            this.Перенести.Name = "Перенести";
            this.Перенести.Size = new System.Drawing.Size(172, 23);
            this.Перенести.TabIndex = 17;
            this.Перенести.Text = "Перенести";
            this.Перенести.UseVisualStyleBackColor = true;
            this.Перенести.Click += new System.EventHandler(this.Перенести_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(715, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Движение по OX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(715, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Движение по OY";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(715, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Движение по OZ";
            // 
            // PovorotOY
            // 
            this.PovorotOY.Enabled = false;
            this.PovorotOY.Location = new System.Drawing.Point(814, 220);
            this.PovorotOY.Name = "PovorotOY";
            this.PovorotOY.Size = new System.Drawing.Size(61, 23);
            this.PovorotOY.TabIndex = 23;
            this.PovorotOY.Text = "GO!";
            this.PovorotOY.UseVisualStyleBackColor = true;
            this.PovorotOY.Click += new System.EventHandler(this.PovorotOY_Click);
            // 
            // PovorotOZ
            // 
            this.PovorotOZ.Enabled = false;
            this.PovorotOZ.Location = new System.Drawing.Point(814, 249);
            this.PovorotOZ.Name = "PovorotOZ";
            this.PovorotOZ.Size = new System.Drawing.Size(61, 23);
            this.PovorotOZ.TabIndex = 24;
            this.PovorotOZ.Text = "GO!";
            this.PovorotOZ.UseVisualStyleBackColor = true;
            this.PovorotOZ.Click += new System.EventHandler(this.PovorotOZ_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 60;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(880, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "STOP!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(880, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "STOP!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(881, 249);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "STOP!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(721, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Отображение по XOY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(721, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Отображение по XOZ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(721, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Отображение по YOZ";
            // 
            // timer4
            // 
            this.timer4.Interval = 70;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // ПоКривой
            // 
            this.ПоКривой.Enabled = false;
            this.ПоКривой.Location = new System.Drawing.Point(887, 416);
            this.ПоКривой.Name = "ПоКривой";
            this.ПоКривой.Size = new System.Drawing.Size(64, 23);
            this.ПоКривой.TabIndex = 36;
            this.ПоКривой.Text = "GO!";
            this.ПоКривой.UseVisualStyleBackColor = true;
            this.ПоКривой.Click += new System.EventHandler(this.ПоКривой_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(887, 445);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 37;
            this.button4.Text = "GO!";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer5
            // 
            this.timer5.Interval = 80;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(947, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Поворот по OX";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(947, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Поворот по OY";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(948, 254);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Поворот по OZ";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(1048, 191);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 23);
            this.button5.TabIndex = 45;
            this.button5.Text = "GO!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(1048, 220);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 23);
            this.button6.TabIndex = 46;
            this.button6.Text = "GO!";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(1048, 249);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 23);
            this.button7.TabIndex = 47;
            this.button7.Text = "GO!";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(719, 420);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "Движение по кривой влево";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(719, 445);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(153, 13);
            this.label18.TabIndex = 49;
            this.label18.Text = "Движение по кривой вправо";
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(957, 416);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(61, 23);
            this.button8.TabIndex = 50;
            this.button8.Text = "STOP!";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(958, 445);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(61, 23);
            this.button9.TabIndex = 51;
            this.button9.Text = "STOP!";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(857, 298);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 52;
            this.button10.Text = "GO!";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(857, 358);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 53;
            this.button11.Text = "GO!";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Location = new System.Drawing.Point(857, 328);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 54;
            this.button12.Text = "GO!";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(1040, 63);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(102, 23);
            this.button13.TabIndex = 56;
            this.button13.Text = "Уменьшить";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(826, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 57;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(887, 60);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(48, 20);
            this.textBox8.TabIndex = 58;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(950, 60);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(48, 20);
            this.textBox9.TabIndex = 59;
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(826, 31);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(32, 23);
            this.button14.TabIndex = 60;
            this.button14.Text = "GO!";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(887, 31);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(32, 23);
            this.button15.TabIndex = 61;
            this.button15.Text = "GO!";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Enabled = false;
            this.button16.Location = new System.Drawing.Point(957, 31);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(32, 23);
            this.button16.TabIndex = 62;
            this.button16.Text = "GO!";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Enabled = false;
            this.button17.Location = new System.Drawing.Point(1020, 353);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 63;
            this.button17.Text = "GO! ";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1004, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Возврат на начало";
            // 
            // button18
            // 
            this.button18.Enabled = false;
            this.button18.Location = new System.Drawing.Point(580, 485);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(129, 23);
            this.button18.TabIndex = 65;
            this.button18.Text = "Включить функционал";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 530);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ПоКривой);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PovorotOZ);
            this.Controls.Add(this.PovorotOY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Перенести);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Увеличить);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Povor);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.ЗагрузитьМатрицу);
            this.Controls.Add(this.ЗагрузитьТочки);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ЗагрузитьТочки;
        private System.Windows.Forms.Button ЗагрузитьМатрицу;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Povor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Увеличить;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button Перенести;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button PovorotOY;
        private System.Windows.Forms.Button PovorotOZ;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button ПоКривой;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button18;
    }
}

