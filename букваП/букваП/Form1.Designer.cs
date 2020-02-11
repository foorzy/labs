namespace букваП
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.labelRot = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.RotX = new System.Windows.Forms.TextBox();
            this.textBoxRotZ = new System.Windows.Forms.TextBox();
            this.textBoxRotY = new System.Windows.Forms.TextBox();
            this.buttonOKX = new System.Windows.Forms.Button();
            this.buttonOKY = new System.Windows.Forms.Button();
            this.buttonOKZ = new System.Windows.Forms.Button();
            this.buttoDecrOK = new System.Windows.Forms.Button();
            this.lblMastab = new System.Windows.Forms.Label();
            this.buttonIncrOk = new System.Windows.Forms.Button();
            this.buttonZRot = new System.Windows.Forms.Button();
            this.buttonYRot = new System.Windows.Forms.Button();
            this.buttonXRot = new System.Windows.Forms.Button();
            this.timerRotx = new System.Windows.Forms.Timer(this.components);
            this.labelScaleZ = new System.Windows.Forms.Label();
            this.labelScaleY = new System.Windows.Forms.Label();
            this.labelScaleX = new System.Windows.Forms.Label();
            this.buttonScZ = new System.Windows.Forms.Button();
            this.buttonScY = new System.Windows.Forms.Button();
            this.buttonScX = new System.Windows.Forms.Button();
            this.textBoxScaleY = new System.Windows.Forms.TextBox();
            this.textBoxScaleZ = new System.Windows.Forms.TextBox();
            this.textBoxScaleX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPerX = new System.Windows.Forms.Button();
            this.textBoxPerY = new System.Windows.Forms.TextBox();
            this.textBoxPerZ = new System.Windows.Forms.TextBox();
            this.textBoxPerX = new System.Windows.Forms.TextBox();
            this.labelPerZ = new System.Windows.Forms.Label();
            this.labelPerY = new System.Windows.Forms.Label();
            this.labelPerX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOtrX = new System.Windows.Forms.Button();
            this.buttonOtrY = new System.Windows.Forms.Button();
            this.buttonOtrZ = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonAgain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1084, 665);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 711);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(139, 44);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Открыть файл";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // labelRot
            // 
            this.labelRot.AutoSize = true;
            this.labelRot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRot.Location = new System.Drawing.Point(1135, 21);
            this.labelRot.Name = "labelRot";
            this.labelRot.Size = new System.Drawing.Size(98, 25);
            this.labelRot.TabIndex = 11;
            this.labelRot.Text = "Поворот:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(1110, 58);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(91, 24);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "По оси х:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.Location = new System.Drawing.Point(1110, 86);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(90, 24);
            this.labelY.TabIndex = 13;
            this.labelY.Text = "По оси у:";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZ.Location = new System.Drawing.Point(1110, 118);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(90, 24);
            this.labelZ.TabIndex = 14;
            this.labelZ.Text = "По оси z:";
            // 
            // RotX
            // 
            this.RotX.Location = new System.Drawing.Point(1207, 58);
            this.RotX.Name = "RotX";
            this.RotX.Size = new System.Drawing.Size(100, 22);
            this.RotX.TabIndex = 15;
            this.RotX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotX_KeyPress);
            // 
            // textBoxRotZ
            // 
            this.textBoxRotZ.Location = new System.Drawing.Point(1207, 120);
            this.textBoxRotZ.Name = "textBoxRotZ";
            this.textBoxRotZ.Size = new System.Drawing.Size(100, 22);
            this.textBoxRotZ.TabIndex = 16;
            this.textBoxRotZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRotZ_KeyPress);
            // 
            // textBoxRotY
            // 
            this.textBoxRotY.Location = new System.Drawing.Point(1207, 86);
            this.textBoxRotY.Name = "textBoxRotY";
            this.textBoxRotY.Size = new System.Drawing.Size(100, 22);
            this.textBoxRotY.TabIndex = 17;
            this.textBoxRotY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRotY_KeyPress);
            // 
            // buttonOKX
            // 
            this.buttonOKX.Location = new System.Drawing.Point(1394, 57);
            this.buttonOKX.Name = "buttonOKX";
            this.buttonOKX.Size = new System.Drawing.Size(142, 23);
            this.buttonOKX.TabIndex = 18;
            this.buttonOKX.Text = "Автоматически";
            this.buttonOKX.UseVisualStyleBackColor = true;
            this.buttonOKX.Click += new System.EventHandler(this.buttonOKX_Click);
            // 
            // buttonOKY
            // 
            this.buttonOKY.Location = new System.Drawing.Point(1394, 89);
            this.buttonOKY.Name = "buttonOKY";
            this.buttonOKY.Size = new System.Drawing.Size(142, 23);
            this.buttonOKY.TabIndex = 19;
            this.buttonOKY.Text = "Автоматически";
            this.buttonOKY.UseVisualStyleBackColor = true;
            this.buttonOKY.Click += new System.EventHandler(this.buttonOKY_Click);
            // 
            // buttonOKZ
            // 
            this.buttonOKZ.Location = new System.Drawing.Point(1394, 118);
            this.buttonOKZ.Name = "buttonOKZ";
            this.buttonOKZ.Size = new System.Drawing.Size(142, 23);
            this.buttonOKZ.TabIndex = 20;
            this.buttonOKZ.Text = "Автоматически";
            this.buttonOKZ.UseVisualStyleBackColor = true;
            this.buttonOKZ.Click += new System.EventHandler(this.buttonOKZ_Click);
            // 
            // buttoDecrOK
            // 
            this.buttoDecrOK.Location = new System.Drawing.Point(1394, 195);
            this.buttoDecrOK.Name = "buttoDecrOK";
            this.buttoDecrOK.Size = new System.Drawing.Size(221, 23);
            this.buttoDecrOK.TabIndex = 21;
            this.buttoDecrOK.Text = "Уменьшить по умолчанию";
            this.buttoDecrOK.UseVisualStyleBackColor = true;
            this.buttoDecrOK.Click += new System.EventHandler(this.buttoDecrOK_Click);
            // 
            // lblMastab
            // 
            this.lblMastab.AutoSize = true;
            this.lblMastab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMastab.Location = new System.Drawing.Point(1136, 154);
            this.lblMastab.Name = "lblMastab";
            this.lblMastab.Size = new System.Drawing.Size(189, 25);
            this.lblMastab.TabIndex = 22;
            this.lblMastab.Text = "Масштабирование:";
            // 
            // buttonIncrOk
            // 
            this.buttonIncrOk.Location = new System.Drawing.Point(1394, 224);
            this.buttonIncrOk.Name = "buttonIncrOk";
            this.buttonIncrOk.Size = new System.Drawing.Size(221, 23);
            this.buttonIncrOk.TabIndex = 24;
            this.buttonIncrOk.Text = "Увеличить по умолчанию";
            this.buttonIncrOk.UseVisualStyleBackColor = true;
            this.buttonIncrOk.Click += new System.EventHandler(this.buttonIncrOk_Click);
            // 
            // buttonZRot
            // 
            this.buttonZRot.Location = new System.Drawing.Point(1313, 118);
            this.buttonZRot.Name = "buttonZRot";
            this.buttonZRot.Size = new System.Drawing.Size(75, 23);
            this.buttonZRot.TabIndex = 29;
            this.buttonZRot.Text = "Ок";
            this.buttonZRot.UseVisualStyleBackColor = true;
            this.buttonZRot.Click += new System.EventHandler(this.buttonZRot_Click);
            // 
            // buttonYRot
            // 
            this.buttonYRot.Location = new System.Drawing.Point(1313, 89);
            this.buttonYRot.Name = "buttonYRot";
            this.buttonYRot.Size = new System.Drawing.Size(75, 23);
            this.buttonYRot.TabIndex = 28;
            this.buttonYRot.Text = "Ок";
            this.buttonYRot.UseVisualStyleBackColor = true;
            this.buttonYRot.Click += new System.EventHandler(this.buttonYRot_Click);
            // 
            // buttonXRot
            // 
            this.buttonXRot.Location = new System.Drawing.Point(1313, 60);
            this.buttonXRot.Name = "buttonXRot";
            this.buttonXRot.Size = new System.Drawing.Size(75, 23);
            this.buttonXRot.TabIndex = 27;
            this.buttonXRot.Text = "Ок";
            this.buttonXRot.UseVisualStyleBackColor = true;
            this.buttonXRot.Click += new System.EventHandler(this.buttonXRot_Click);
            // 
            // timerRotx
            // 
            this.timerRotx.Interval = 25;
            this.timerRotx.Tick += new System.EventHandler(this.timerRotx_Tick);
            // 
            // labelScaleZ
            // 
            this.labelScaleZ.AutoSize = true;
            this.labelScaleZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScaleZ.Location = new System.Drawing.Point(1111, 249);
            this.labelScaleZ.Name = "labelScaleZ";
            this.labelScaleZ.Size = new System.Drawing.Size(90, 24);
            this.labelScaleZ.TabIndex = 32;
            this.labelScaleZ.Text = "По оси z:";
            // 
            // labelScaleY
            // 
            this.labelScaleY.AutoSize = true;
            this.labelScaleY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScaleY.Location = new System.Drawing.Point(1111, 217);
            this.labelScaleY.Name = "labelScaleY";
            this.labelScaleY.Size = new System.Drawing.Size(90, 24);
            this.labelScaleY.TabIndex = 31;
            this.labelScaleY.Text = "По оси у:";
            // 
            // labelScaleX
            // 
            this.labelScaleX.AutoSize = true;
            this.labelScaleX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScaleX.Location = new System.Drawing.Point(1111, 189);
            this.labelScaleX.Name = "labelScaleX";
            this.labelScaleX.Size = new System.Drawing.Size(91, 24);
            this.labelScaleX.TabIndex = 30;
            this.labelScaleX.Text = "По оси х:";
            // 
            // buttonScZ
            // 
            this.buttonScZ.Location = new System.Drawing.Point(1313, 251);
            this.buttonScZ.Name = "buttonScZ";
            this.buttonScZ.Size = new System.Drawing.Size(75, 23);
            this.buttonScZ.TabIndex = 38;
            this.buttonScZ.Text = "Ок";
            this.buttonScZ.UseVisualStyleBackColor = true;
            this.buttonScZ.Click += new System.EventHandler(this.buttonScZ_Click);
            // 
            // buttonScY
            // 
            this.buttonScY.Location = new System.Drawing.Point(1313, 222);
            this.buttonScY.Name = "buttonScY";
            this.buttonScY.Size = new System.Drawing.Size(75, 23);
            this.buttonScY.TabIndex = 37;
            this.buttonScY.Text = "Ок";
            this.buttonScY.UseVisualStyleBackColor = true;
            this.buttonScY.Click += new System.EventHandler(this.buttonScY_Click);
            // 
            // buttonScX
            // 
            this.buttonScX.Location = new System.Drawing.Point(1313, 193);
            this.buttonScX.Name = "buttonScX";
            this.buttonScX.Size = new System.Drawing.Size(75, 23);
            this.buttonScX.TabIndex = 36;
            this.buttonScX.Text = "Ок";
            this.buttonScX.UseVisualStyleBackColor = true;
            this.buttonScX.Click += new System.EventHandler(this.buttonScX_Click);
            // 
            // textBoxScaleY
            // 
            this.textBoxScaleY.Location = new System.Drawing.Point(1207, 219);
            this.textBoxScaleY.Name = "textBoxScaleY";
            this.textBoxScaleY.Size = new System.Drawing.Size(100, 22);
            this.textBoxScaleY.TabIndex = 35;
            this.textBoxScaleY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxScaleY_KeyPress);
            // 
            // textBoxScaleZ
            // 
            this.textBoxScaleZ.Location = new System.Drawing.Point(1207, 253);
            this.textBoxScaleZ.Name = "textBoxScaleZ";
            this.textBoxScaleZ.Size = new System.Drawing.Size(100, 22);
            this.textBoxScaleZ.TabIndex = 34;
            this.textBoxScaleZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxScaleZ_KeyPress);
            // 
            // textBoxScaleX
            // 
            this.textBoxScaleX.Location = new System.Drawing.Point(1207, 191);
            this.textBoxScaleX.Name = "textBoxScaleX";
            this.textBoxScaleX.Size = new System.Drawing.Size(100, 22);
            this.textBoxScaleX.TabIndex = 33;
            this.textBoxScaleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxScaleX_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1140, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "Перенос в точку:";
            // 
            // buttonPerX
            // 
            this.buttonPerX.Location = new System.Drawing.Point(1334, 388);
            this.buttonPerX.Name = "buttonPerX";
            this.buttonPerX.Size = new System.Drawing.Size(75, 23);
            this.buttonPerX.TabIndex = 46;
            this.buttonPerX.Text = "Ок";
            this.buttonPerX.UseVisualStyleBackColor = true;
            this.buttonPerX.Click += new System.EventHandler(this.buttonPerX_Click);
            // 
            // textBoxPerY
            // 
            this.textBoxPerY.Location = new System.Drawing.Point(1207, 354);
            this.textBoxPerY.Name = "textBoxPerY";
            this.textBoxPerY.Size = new System.Drawing.Size(100, 22);
            this.textBoxPerY.TabIndex = 45;
            this.textBoxPerY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPerY_KeyPress);
            // 
            // textBoxPerZ
            // 
            this.textBoxPerZ.Location = new System.Drawing.Point(1207, 388);
            this.textBoxPerZ.Name = "textBoxPerZ";
            this.textBoxPerZ.Size = new System.Drawing.Size(100, 22);
            this.textBoxPerZ.TabIndex = 44;
            this.textBoxPerZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPerZ_KeyPress);
            // 
            // textBoxPerX
            // 
            this.textBoxPerX.Location = new System.Drawing.Point(1207, 326);
            this.textBoxPerX.Name = "textBoxPerX";
            this.textBoxPerX.Size = new System.Drawing.Size(100, 22);
            this.textBoxPerX.TabIndex = 43;
            this.textBoxPerX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPerX_KeyPress);
            // 
            // labelPerZ
            // 
            this.labelPerZ.AutoSize = true;
            this.labelPerZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPerZ.Location = new System.Drawing.Point(1111, 384);
            this.labelPerZ.Name = "labelPerZ";
            this.labelPerZ.Size = new System.Drawing.Size(90, 24);
            this.labelPerZ.TabIndex = 42;
            this.labelPerZ.Text = "По оси z:";
            // 
            // labelPerY
            // 
            this.labelPerY.AutoSize = true;
            this.labelPerY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPerY.Location = new System.Drawing.Point(1111, 352);
            this.labelPerY.Name = "labelPerY";
            this.labelPerY.Size = new System.Drawing.Size(90, 24);
            this.labelPerY.TabIndex = 41;
            this.labelPerY.Text = "По оси у:";
            // 
            // labelPerX
            // 
            this.labelPerX.AutoSize = true;
            this.labelPerX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPerX.Location = new System.Drawing.Point(1111, 324);
            this.labelPerX.Name = "labelPerX";
            this.labelPerX.Size = new System.Drawing.Size(91, 24);
            this.labelPerX.TabIndex = 40;
            this.labelPerX.Text = "По оси х:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1140, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Отражение по оси: ";
            // 
            // buttonOtrX
            // 
            this.buttonOtrX.Location = new System.Drawing.Point(1114, 455);
            this.buttonOtrX.Name = "buttonOtrX";
            this.buttonOtrX.Size = new System.Drawing.Size(75, 23);
            this.buttonOtrX.TabIndex = 50;
            this.buttonOtrX.Text = "Х";
            this.buttonOtrX.UseVisualStyleBackColor = true;
            this.buttonOtrX.Click += new System.EventHandler(this.buttonOtrX_Click);
            // 
            // buttonOtrY
            // 
            this.buttonOtrY.Location = new System.Drawing.Point(1195, 455);
            this.buttonOtrY.Name = "buttonOtrY";
            this.buttonOtrY.Size = new System.Drawing.Size(75, 23);
            this.buttonOtrY.TabIndex = 51;
            this.buttonOtrY.Text = "Y";
            this.buttonOtrY.UseVisualStyleBackColor = true;
            this.buttonOtrY.Click += new System.EventHandler(this.buttonOtrY_Click);
            // 
            // buttonOtrZ
            // 
            this.buttonOtrZ.Location = new System.Drawing.Point(1276, 455);
            this.buttonOtrZ.Name = "buttonOtrZ";
            this.buttonOtrZ.Size = new System.Drawing.Size(75, 23);
            this.buttonOtrZ.TabIndex = 52;
            this.buttonOtrZ.Text = "Z";
            this.buttonOtrZ.UseVisualStyleBackColor = true;
            this.buttonOtrZ.Click += new System.EventHandler(this.buttonOtrZ_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(1246, 541);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(79, 31);
            this.buttonRight.TabIndex = 53;
            this.buttonRight.Text = "Вправо";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1145, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 25);
            this.label3.TabIndex = 54;
            this.label3.Text = "Движение по кривой:";
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(1150, 541);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 31);
            this.buttonLeft.TabIndex = 55;
            this.buttonLeft.Text = "Влево";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonAgain
            // 
            this.buttonAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAgain.Location = new System.Drawing.Point(187, 711);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(139, 44);
            this.buttonAgain.TabIndex = 56;
            this.buttonAgain.Text = "Заново";
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Visible = false;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 816);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonOtrZ);
            this.Controls.Add(this.buttonOtrY);
            this.Controls.Add(this.buttonOtrX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPerX);
            this.Controls.Add(this.textBoxPerY);
            this.Controls.Add(this.textBoxPerZ);
            this.Controls.Add(this.textBoxPerX);
            this.Controls.Add(this.labelPerZ);
            this.Controls.Add(this.labelPerY);
            this.Controls.Add(this.labelPerX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonScZ);
            this.Controls.Add(this.buttonScY);
            this.Controls.Add(this.buttonScX);
            this.Controls.Add(this.textBoxScaleY);
            this.Controls.Add(this.textBoxScaleZ);
            this.Controls.Add(this.textBoxScaleX);
            this.Controls.Add(this.labelScaleZ);
            this.Controls.Add(this.labelScaleY);
            this.Controls.Add(this.labelScaleX);
            this.Controls.Add(this.buttonZRot);
            this.Controls.Add(this.buttonYRot);
            this.Controls.Add(this.buttonXRot);
            this.Controls.Add(this.buttonIncrOk);
            this.Controls.Add(this.lblMastab);
            this.Controls.Add(this.buttoDecrOK);
            this.Controls.Add(this.buttonOKZ);
            this.Controls.Add(this.buttonOKY);
            this.Controls.Add(this.buttonOKX);
            this.Controls.Add(this.textBoxRotY);
            this.Controls.Add(this.textBoxRotZ);
            this.Controls.Add(this.RotX);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelRot);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label labelRot;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox RotX;
        private System.Windows.Forms.TextBox textBoxRotZ;
        private System.Windows.Forms.TextBox textBoxRotY;
        private System.Windows.Forms.Button buttonOKX;
        private System.Windows.Forms.Button buttonOKY;
        private System.Windows.Forms.Button buttonOKZ;
        private System.Windows.Forms.Button buttoDecrOK;
        private System.Windows.Forms.Label lblMastab;
        private System.Windows.Forms.Button buttonIncrOk;
        private System.Windows.Forms.Button buttonZRot;
        private System.Windows.Forms.Button buttonYRot;
        private System.Windows.Forms.Button buttonXRot;
        public System.Windows.Forms.Timer timerRotx;
        private System.Windows.Forms.Label labelScaleZ;
        private System.Windows.Forms.Label labelScaleY;
        private System.Windows.Forms.Label labelScaleX;
        private System.Windows.Forms.Button buttonScZ;
        private System.Windows.Forms.Button buttonScY;
        private System.Windows.Forms.Button buttonScX;
        private System.Windows.Forms.TextBox textBoxScaleY;
        private System.Windows.Forms.TextBox textBoxScaleZ;
        private System.Windows.Forms.TextBox textBoxScaleX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPerX;
        private System.Windows.Forms.TextBox textBoxPerY;
        private System.Windows.Forms.TextBox textBoxPerZ;
        private System.Windows.Forms.TextBox textBoxPerX;
        private System.Windows.Forms.Label labelPerZ;
        private System.Windows.Forms.Label labelPerY;
        private System.Windows.Forms.Label labelPerX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOtrX;
        private System.Windows.Forms.Button buttonOtrY;
        private System.Windows.Forms.Button buttonOtrZ;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonAgain;
    }
}

