namespace АЛГОРИТМЫ_______
{
    partial class Famous_people
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
            this.pictureBoxHuman = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuman)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHuman
            // 
            this.pictureBoxHuman.Location = new System.Drawing.Point(145, 36);
            this.pictureBoxHuman.Name = "pictureBoxHuman";
            this.pictureBoxHuman.Size = new System.Drawing.Size(465, 417);
            this.pictureBoxHuman.TabIndex = 0;
            this.pictureBoxHuman.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(673, 508);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(101, 38);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(290, 508);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 32);
            this.labelName.TabIndex = 2;
            // 
            // Famous_people
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 582);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBoxHuman);
            this.Name = "Famous_people";
            this.Text = "Famous_people";
            this.Load += new System.EventHandler(this.Famous_people_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHuman;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelName;
    }
}