using System.ComponentModel;

namespace POS_System
{
    partial class Analytics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pOSUnlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBx1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.pOSUnlockToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1898, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // pOSUnlockToolStripMenuItem
            // 
            this.pOSUnlockToolStripMenuItem.Name = "pOSUnlockToolStripMenuItem";
            this.pOSUnlockToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.pOSUnlockToolStripMenuItem.Text = "POS Unlock";
            this.pOSUnlockToolStripMenuItem.Click += new System.EventHandler(this.pOSUnlockToolStripMenuItem_Click);
            // 
            // txtBx1
            // 
            this.txtBx1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx1.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtBx1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.txtBx1.Location = new System.Drawing.Point(12, 72);
            this.txtBx1.Name = "txtBx1";
            this.txtBx1.Size = new System.Drawing.Size(484, 33);
            this.txtBx1.TabIndex = 11;
            this.txtBx1.Text = "CURRENT INTROSPECTED PRODUCT";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.richTextBox1.Location = new System.Drawing.Point(12, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(494, 68);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(494, 238);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.SeaGreen;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.Color.White;
            this.richTextBox2.Location = new System.Drawing.Point(12, 479);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(494, 37);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(12, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "SOURCE COMPANY";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label2.Location = new System.Drawing.Point(12, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "PRODUCT SALES";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.SeaGreen;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.ForeColor = System.Drawing.Color.White;
            this.richTextBox3.Location = new System.Drawing.Point(12, 568);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(494, 98);
            this.richTextBox3.TabIndex = 15;
            this.richTextBox3.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 675);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "Total Sales";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 675);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 43);
            this.button2.TabIndex = 18;
            this.button2.Text = "Past Month";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(348, 675);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 43);
            this.button3.TabIndex = 19;
            this.button3.Text = "Past Two Months\r\n\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(561, 108);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1034, 610);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Location = new System.Drawing.Point(12, 729);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "COMPANY SALES";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.SeaGreen;
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox4.ForeColor = System.Drawing.Color.White;
            this.richTextBox4.Location = new System.Drawing.Point(12, 765);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(494, 98);
            this.richTextBox4.TabIndex = 21;
            this.richTextBox4.Text = "";
            // 
            // Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 893);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtBx1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Analytics";
            this.Text = "Analytics";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox4;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.RichTextBox richTextBox2;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label txtBx1;

        private System.Windows.Forms.Label itemSearch;
        private System.Windows.Forms.RichTextBox richTextBox1;

        private System.Windows.Forms.ToolStripMenuItem pOSUnlockToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}