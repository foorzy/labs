namespace АЛГОРИТМЫ_______
{
    partial class Diagram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartSort = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSort = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.chartSeacrh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeacrh)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSort
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSort.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSort.Legends.Add(legend3);
            this.chartSort.Location = new System.Drawing.Point(14, 14);
            this.chartSort.Margin = new System.Windows.Forms.Padding(5);
            this.chartSort.Name = "chartSort";
            this.chartSort.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartSort.Size = new System.Drawing.Size(421, 324);
            this.chartSort.TabIndex = 0;
            this.chartSort.Text = "chart1";
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSort.Location = new System.Drawing.Point(9, 370);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(396, 25);
            this.labelSort.TabIndex = 2;
            this.labelSort.Text = "Cтатистика для алгоритмов сортировки";
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSearch.Location = new System.Drawing.Point(502, 370);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(349, 25);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Статистика для алгоритмов поиска";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(668, 426);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(151, 42);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // chartSeacrh
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSeacrh.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSeacrh.Legends.Add(legend4);
            this.chartSeacrh.Location = new System.Drawing.Point(445, 14);
            this.chartSeacrh.Margin = new System.Windows.Forms.Padding(5);
            this.chartSeacrh.Name = "chartSeacrh";
            this.chartSeacrh.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartSeacrh.Size = new System.Drawing.Size(406, 324);
            this.chartSeacrh.TabIndex = 5;
            this.chartSeacrh.Text = "chart1";
            // 
            // Diagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 500);
            this.Controls.Add(this.chartSeacrh);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.chartSort);
            this.Name = "Diagram";
            this.Text = "Diagram";
            ((System.ComponentModel.ISupportInitialize)(this.chartSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeacrh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.Label labelSearch;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartSort;
        private System.Windows.Forms.Button buttonBack;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartSeacrh;
    }
}