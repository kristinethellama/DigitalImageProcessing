
namespace CS469HW6V2
{
	partial class Form1
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.soundWaves = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.soundWaves)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(23, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 41);
			this.button1.TabIndex = 0;
			this.button1.Text = "Record Audio";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(23, 78);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 46);
			this.button2.TabIndex = 1;
			this.button2.Text = "Save/Stop Audio";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(28, 392);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(145, 39);
			this.button3.TabIndex = 2;
			this.button3.Text = "Exit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(23, 146);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(149, 39);
			this.button4.TabIndex = 3;
			this.button4.Text = "Play Audio";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(23, 209);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(150, 40);
			this.button5.TabIndex = 4;
			this.button5.Text = "Create Wave";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// soundWaves
			// 
			chartArea1.Name = "ChartArea1";
			this.soundWaves.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.soundWaves.Legends.Add(legend1);
			this.soundWaves.Location = new System.Drawing.Point(207, 26);
			this.soundWaves.Name = "soundWaves";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.soundWaves.Series.Add(series1);
			this.soundWaves.Size = new System.Drawing.Size(570, 404);
			this.soundWaves.TabIndex = 5;
			this.soundWaves.Text = "Sound Waves";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.soundWaves);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.soundWaves)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.DataVisualization.Charting.Chart soundWaves;
	}
}

