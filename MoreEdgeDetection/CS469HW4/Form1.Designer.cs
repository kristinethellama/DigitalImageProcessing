
namespace CS469HW4
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
			this.LoadImage = new System.Windows.Forms.Button();
			this.OpenImageDisplay = new System.Windows.Forms.PictureBox();
			this.Exit = new System.Windows.Forms.Button();
			this.OptionSelect = new System.Windows.Forms.ComboBox();
			this.Confirm = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// LoadImage
			// 
			this.LoadImage.Location = new System.Drawing.Point(16, 16);
			this.LoadImage.Name = "LoadImage";
			this.LoadImage.Size = new System.Drawing.Size(134, 31);
			this.LoadImage.TabIndex = 0;
			this.LoadImage.Text = "Load Image";
			this.LoadImage.UseVisualStyleBackColor = true;
			this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
			// 
			// OpenImageDisplay
			// 
			this.OpenImageDisplay.Location = new System.Drawing.Point(173, 19);
			this.OpenImageDisplay.Name = "OpenImageDisplay";
			this.OpenImageDisplay.Size = new System.Drawing.Size(755, 547);
			this.OpenImageDisplay.TabIndex = 1;
			this.OpenImageDisplay.TabStop = false;
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(16, 538);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(134, 28);
			this.Exit.TabIndex = 2;
			this.Exit.Text = "Exit";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// OptionSelect
			// 
			this.OptionSelect.FormattingEnabled = true;
			this.OptionSelect.Items.AddRange(new object[] {
            "Grayscale",
            "Fit Image",
            "Smoothed",
            "Canny Edge Detection"});
			this.OptionSelect.Location = new System.Drawing.Point(19, 65);
			this.OptionSelect.Name = "OptionSelect";
			this.OptionSelect.Size = new System.Drawing.Size(130, 24);
			this.OptionSelect.TabIndex = 3;
			// 
			// Confirm
			// 
			this.Confirm.Location = new System.Drawing.Point(19, 109);
			this.Confirm.Name = "Confirm";
			this.Confirm.Size = new System.Drawing.Size(129, 27);
			this.Confirm.TabIndex = 4;
			this.Confirm.Text = "Confirm";
			this.Confirm.UseVisualStyleBackColor = true;
			this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 585);
			this.Controls.Add(this.Confirm);
			this.Controls.Add(this.OptionSelect);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.OpenImageDisplay);
			this.Controls.Add(this.LoadImage);
			this.Name = "Form1";
			this.Text = "Canny Edge Detection";
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button LoadImage;
		private System.Windows.Forms.PictureBox OpenImageDisplay;
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.ComboBox OptionSelect;
		private System.Windows.Forms.Button Confirm;
	}
}

