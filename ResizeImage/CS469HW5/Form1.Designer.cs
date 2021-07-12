
namespace CS469HW5
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
			this.OpenImageDisplay = new System.Windows.Forms.PictureBox();
			this.LoadImage = new System.Windows.Forms.Button();
			this.Double = new System.Windows.Forms.Button();
			this.Quadruple = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// OpenImageDisplay
			// 
			this.OpenImageDisplay.Location = new System.Drawing.Point(138, 16);
			this.OpenImageDisplay.Name = "OpenImageDisplay";
			this.OpenImageDisplay.Size = new System.Drawing.Size(757, 538);
			this.OpenImageDisplay.TabIndex = 0;
			this.OpenImageDisplay.TabStop = false;
			// 
			// LoadImage
			// 
			this.LoadImage.Location = new System.Drawing.Point(12, 16);
			this.LoadImage.Name = "LoadImage";
			this.LoadImage.Size = new System.Drawing.Size(108, 25);
			this.LoadImage.TabIndex = 1;
			this.LoadImage.Text = "Load Image";
			this.LoadImage.UseVisualStyleBackColor = true;
			this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
			// 
			// Double
			// 
			this.Double.Location = new System.Drawing.Point(13, 56);
			this.Double.Name = "Double";
			this.Double.Size = new System.Drawing.Size(107, 25);
			this.Double.TabIndex = 2;
			this.Double.Text = "Double Size";
			this.Double.UseVisualStyleBackColor = true;
			this.Double.Click += new System.EventHandler(this.Double_Click);
			// 
			// Quadruple
			// 
			this.Quadruple.Location = new System.Drawing.Point(13, 97);
			this.Quadruple.Name = "Quadruple";
			this.Quadruple.Size = new System.Drawing.Size(106, 24);
			this.Quadruple.TabIndex = 3;
			this.Quadruple.Text = "Quad Size";
			this.Quadruple.UseVisualStyleBackColor = true;
			this.Quadruple.Click += new System.EventHandler(this.Quadruple_Click);
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(12, 528);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(107, 26);
			this.Exit.TabIndex = 4;
			this.Exit.Text = "Exit";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 570);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.Quadruple);
			this.Controls.Add(this.Double);
			this.Controls.Add(this.LoadImage);
			this.Controls.Add(this.OpenImageDisplay);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox OpenImageDisplay;
		private System.Windows.Forms.Button LoadImage;
		private System.Windows.Forms.Button Double;
		private System.Windows.Forms.Button Quadruple;
		private System.Windows.Forms.Button Exit;
	}
}

