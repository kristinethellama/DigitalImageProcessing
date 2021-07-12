
namespace CS469HW3
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
			this.Load_Image = new System.Windows.Forms.Button();
			this.OpenImageDisplay = new System.Windows.Forms.PictureBox();
			this.Exit = new System.Windows.Forms.Button();
			this.EdgeDetectionOptions = new System.Windows.Forms.ComboBox();
			this.Confirm = new System.Windows.Forms.Button();
			this.edgelabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// Load_Image
			// 
			this.Load_Image.Location = new System.Drawing.Point(22, 18);
			this.Load_Image.Name = "Load_Image";
			this.Load_Image.Size = new System.Drawing.Size(118, 32);
			this.Load_Image.TabIndex = 0;
			this.Load_Image.Text = "Load Image";
			this.Load_Image.UseVisualStyleBackColor = true;
			this.Load_Image.Click += new System.EventHandler(this.Load_Image_Click);
			// 
			// OpenImageDisplay
			// 
			this.OpenImageDisplay.Location = new System.Drawing.Point(180, 19);
			this.OpenImageDisplay.Name = "OpenImageDisplay";
			this.OpenImageDisplay.Size = new System.Drawing.Size(723, 539);
			this.OpenImageDisplay.TabIndex = 1;
			this.OpenImageDisplay.TabStop = false;
			this.OpenImageDisplay.Click += new System.EventHandler(this.OpenImageDisplay_Click);
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(22, 526);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(118, 32);
			this.Exit.TabIndex = 2;
			this.Exit.Text = "Exit";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// EdgeDetectionOptions
			// 
			this.EdgeDetectionOptions.FormattingEnabled = true;
			this.EdgeDetectionOptions.Items.AddRange(new object[] {
            "Prewitt (H)",
            "Prewitt (V)",
            "Prewitt (D1)",
            "Prewitt (D2)",
            "Sobel (H)",
            "Sobel (V)",
            "Sobel (D1)",
            "Sobel (D2)",
            "Robert\'s (D1)",
            "Robert\'s (D2)",
            "Laplacian"});
			this.EdgeDetectionOptions.Location = new System.Drawing.Point(22, 122);
			this.EdgeDetectionOptions.Name = "EdgeDetectionOptions";
			this.EdgeDetectionOptions.Size = new System.Drawing.Size(118, 24);
			this.EdgeDetectionOptions.TabIndex = 7;
			this.EdgeDetectionOptions.SelectedIndexChanged += new System.EventHandler(this.EdgeDetectionOptions_SelectedIndexChanged);
			// 
			// Confirm
			// 
			this.Confirm.Location = new System.Drawing.Point(22, 167);
			this.Confirm.Name = "Confirm";
			this.Confirm.Size = new System.Drawing.Size(118, 28);
			this.Confirm.TabIndex = 8;
			this.Confirm.Text = "Select";
			this.Confirm.UseVisualStyleBackColor = true;
			this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
			// 
			// edgelabel
			// 
			this.edgelabel.AutoSize = true;
			this.edgelabel.Location = new System.Drawing.Point(19, 73);
			this.edgelabel.Name = "edgelabel";
			this.edgelabel.Size = new System.Drawing.Size(109, 34);
			this.edgelabel.TabIndex = 9;
			this.edgelabel.Text = "Edge Detection \r\nAlgorithms";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(924, 570);
			this.Controls.Add(this.edgelabel);
			this.Controls.Add(this.Confirm);
			this.Controls.Add(this.EdgeDetectionOptions);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.OpenImageDisplay);
			this.Controls.Add(this.Load_Image);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Load_Image;
		private System.Windows.Forms.PictureBox OpenImageDisplay;
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.ComboBox EdgeDetectionOptions;
		private System.Windows.Forms.Button Confirm;
		private System.Windows.Forms.Label edgelabel;
	}
}

