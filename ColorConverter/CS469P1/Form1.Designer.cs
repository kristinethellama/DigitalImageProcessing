
namespace CS469P1
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
			this.Gray_Scale = new System.Windows.Forms.Button();
			this.Load_Image = new System.Windows.Forms.Button();
			this.Red_Scale = new System.Windows.Forms.Button();
			this.Green_Scale = new System.Windows.Forms.Button();
			this.Blue_Scale = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.OpenImageDisplay = new System.Windows.Forms.PictureBox();
			this.Y_Luma_Scale = new System.Windows.Forms.Button();
			this.I_Band_Scale = new System.Windows.Forms.Button();
			this.Q_Band_Scale = new System.Windows.Forms.Button();
			this.Cyan_Scale = new System.Windows.Forms.Button();
			this.Yellow_Scale = new System.Windows.Forms.Button();
			this.Magenta_Scale = new System.Windows.Forms.Button();
			this.Key = new System.Windows.Forms.Button();
			this.Cr_Scale = new System.Windows.Forms.Button();
			this.Cb_Scale = new System.Windows.Forms.Button();
			this.U_Scale = new System.Windows.Forms.Button();
			this.V_Scale = new System.Windows.Forms.Button();
			this.cmyk = new System.Windows.Forms.Label();
			this.YCrCbYUV = new System.Windows.Forms.Label();
			this.YIQ = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.note = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// Gray_Scale
			// 
			this.Gray_Scale.Location = new System.Drawing.Point(140, 12);
			this.Gray_Scale.Name = "Gray_Scale";
			this.Gray_Scale.Size = new System.Drawing.Size(125, 39);
			this.Gray_Scale.TabIndex = 1;
			this.Gray_Scale.Text = "Gray Scale";
			this.Gray_Scale.UseVisualStyleBackColor = true;
			this.Gray_Scale.Click += new System.EventHandler(this.Gray_Scale_Click);
			// 
			// Load_Image
			// 
			this.Load_Image.Location = new System.Drawing.Point(12, 12);
			this.Load_Image.Name = "Load_Image";
			this.Load_Image.Size = new System.Drawing.Size(122, 39);
			this.Load_Image.TabIndex = 2;
			this.Load_Image.Text = "Load Image";
			this.Load_Image.UseVisualStyleBackColor = true;
			this.Load_Image.Click += new System.EventHandler(this.Load_Image_Click);
			// 
			// Red_Scale
			// 
			this.Red_Scale.Location = new System.Drawing.Point(271, 12);
			this.Red_Scale.Name = "Red_Scale";
			this.Red_Scale.Size = new System.Drawing.Size(122, 39);
			this.Red_Scale.TabIndex = 3;
			this.Red_Scale.Text = "Red Scale";
			this.Red_Scale.UseVisualStyleBackColor = true;
			this.Red_Scale.Click += new System.EventHandler(this.Red_Scale_Click);
			// 
			// Green_Scale
			// 
			this.Green_Scale.Location = new System.Drawing.Point(399, 12);
			this.Green_Scale.Name = "Green_Scale";
			this.Green_Scale.Size = new System.Drawing.Size(128, 39);
			this.Green_Scale.TabIndex = 4;
			this.Green_Scale.Text = "Green Scale";
			this.Green_Scale.UseVisualStyleBackColor = true;
			this.Green_Scale.Click += new System.EventHandler(this.Green_Scale_Click);
			// 
			// Blue_Scale
			// 
			this.Blue_Scale.Location = new System.Drawing.Point(533, 12);
			this.Blue_Scale.Name = "Blue_Scale";
			this.Blue_Scale.Size = new System.Drawing.Size(111, 39);
			this.Blue_Scale.TabIndex = 5;
			this.Blue_Scale.Text = "Blue Scale";
			this.Blue_Scale.UseVisualStyleBackColor = true;
			this.Blue_Scale.Click += new System.EventHandler(this.Blue_Scale_Click);
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(732, 12);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(115, 39);
			this.Exit.TabIndex = 6;
			this.Exit.Text = "Exit";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// OpenImageDisplay
			// 
			this.OpenImageDisplay.Location = new System.Drawing.Point(21, 208);
			this.OpenImageDisplay.Name = "OpenImageDisplay";
			this.OpenImageDisplay.Size = new System.Drawing.Size(806, 471);
			this.OpenImageDisplay.TabIndex = 7;
			this.OpenImageDisplay.TabStop = false;
			// 
			// Y_Luma_Scale
			// 
			this.Y_Luma_Scale.Location = new System.Drawing.Point(140, 145);
			this.Y_Luma_Scale.Name = "Y_Luma_Scale";
			this.Y_Luma_Scale.Size = new System.Drawing.Size(125, 37);
			this.Y_Luma_Scale.TabIndex = 8;
			this.Y_Luma_Scale.Text = "Y (Luma) Scale";
			this.Y_Luma_Scale.UseVisualStyleBackColor = true;
			this.Y_Luma_Scale.Click += new System.EventHandler(this.Y_Luma_Scale_Click);
			// 
			// I_Band_Scale
			// 
			this.I_Band_Scale.Location = new System.Drawing.Point(271, 145);
			this.I_Band_Scale.Name = "I_Band_Scale";
			this.I_Band_Scale.Size = new System.Drawing.Size(122, 37);
			this.I_Band_Scale.TabIndex = 9;
			this.I_Band_Scale.Text = "I Band";
			this.I_Band_Scale.UseVisualStyleBackColor = true;
			this.I_Band_Scale.Click += new System.EventHandler(this.I_Band_Scale_Click);
			// 
			// Q_Band_Scale
			// 
			this.Q_Band_Scale.Location = new System.Drawing.Point(399, 145);
			this.Q_Band_Scale.Name = "Q_Band_Scale";
			this.Q_Band_Scale.Size = new System.Drawing.Size(127, 37);
			this.Q_Band_Scale.TabIndex = 10;
			this.Q_Band_Scale.Text = "Q Band";
			this.Q_Band_Scale.UseVisualStyleBackColor = true;
			this.Q_Band_Scale.Click += new System.EventHandler(this.Q_Band_Scale_Click);
			// 
			// Cyan_Scale
			// 
			this.Cyan_Scale.Location = new System.Drawing.Point(140, 57);
			this.Cyan_Scale.Name = "Cyan_Scale";
			this.Cyan_Scale.Size = new System.Drawing.Size(125, 41);
			this.Cyan_Scale.TabIndex = 11;
			this.Cyan_Scale.Text = "Cyan Scale";
			this.Cyan_Scale.UseVisualStyleBackColor = true;
			this.Cyan_Scale.Click += new System.EventHandler(this.Cyan_Scale_Click);
			// 
			// Yellow_Scale
			// 
			this.Yellow_Scale.Location = new System.Drawing.Point(271, 57);
			this.Yellow_Scale.Name = "Yellow_Scale";
			this.Yellow_Scale.Size = new System.Drawing.Size(122, 41);
			this.Yellow_Scale.TabIndex = 12;
			this.Yellow_Scale.Text = "Yellow Scale";
			this.Yellow_Scale.UseVisualStyleBackColor = true;
			this.Yellow_Scale.Click += new System.EventHandler(this.Yellow_Scale_Click);
			// 
			// Magenta_Scale
			// 
			this.Magenta_Scale.Location = new System.Drawing.Point(399, 58);
			this.Magenta_Scale.Name = "Magenta_Scale";
			this.Magenta_Scale.Size = new System.Drawing.Size(127, 40);
			this.Magenta_Scale.TabIndex = 13;
			this.Magenta_Scale.Text = "Magenta Scale";
			this.Magenta_Scale.UseVisualStyleBackColor = true;
			this.Magenta_Scale.Click += new System.EventHandler(this.Magenta_Scale_Click);
			// 
			// Key
			// 
			this.Key.Location = new System.Drawing.Point(533, 58);
			this.Key.Name = "Key";
			this.Key.Size = new System.Drawing.Size(111, 40);
			this.Key.TabIndex = 14;
			this.Key.Text = "Key";
			this.Key.UseVisualStyleBackColor = true;
			this.Key.Click += new System.EventHandler(this.Key_Click);
			// 
			// Cr_Scale
			// 
			this.Cr_Scale.Location = new System.Drawing.Point(141, 104);
			this.Cr_Scale.Name = "Cr_Scale";
			this.Cr_Scale.Size = new System.Drawing.Size(124, 35);
			this.Cr_Scale.TabIndex = 15;
			this.Cr_Scale.Text = "Cr Scale";
			this.Cr_Scale.UseVisualStyleBackColor = true;
			this.Cr_Scale.Click += new System.EventHandler(this.Cr_Scale_Click);
			// 
			// Cb_Scale
			// 
			this.Cb_Scale.Location = new System.Drawing.Point(271, 104);
			this.Cb_Scale.Name = "Cb_Scale";
			this.Cb_Scale.Size = new System.Drawing.Size(122, 35);
			this.Cb_Scale.TabIndex = 16;
			this.Cb_Scale.Text = "Cb Scale";
			this.Cb_Scale.UseVisualStyleBackColor = true;
			this.Cb_Scale.Click += new System.EventHandler(this.Cb_Scale_Click);
			// 
			// U_Scale
			// 
			this.U_Scale.Location = new System.Drawing.Point(399, 104);
			this.U_Scale.Name = "U_Scale";
			this.U_Scale.Size = new System.Drawing.Size(128, 35);
			this.U_Scale.TabIndex = 17;
			this.U_Scale.Text = "U Scale";
			this.U_Scale.UseVisualStyleBackColor = true;
			this.U_Scale.Click += new System.EventHandler(this.U_Scale_Click);
			// 
			// V_Scale
			// 
			this.V_Scale.Location = new System.Drawing.Point(533, 104);
			this.V_Scale.Name = "V_Scale";
			this.V_Scale.Size = new System.Drawing.Size(111, 35);
			this.V_Scale.TabIndex = 18;
			this.V_Scale.Text = "V Scale";
			this.V_Scale.UseVisualStyleBackColor = true;
			this.V_Scale.Click += new System.EventHandler(this.V_Scale_Click);
			// 
			// cmyk
			// 
			this.cmyk.AutoSize = true;
			this.cmyk.Location = new System.Drawing.Point(31, 70);
			this.cmyk.Name = "cmyk";
			this.cmyk.Size = new System.Drawing.Size(87, 17);
			this.cmyk.TabIndex = 19;
			this.cmyk.Text = "CMY / CMYK";
			this.cmyk.Click += new System.EventHandler(this.cmyk_Click);
			// 
			// YCrCbYUV
			// 
			this.YCrCbYUV.AutoSize = true;
			this.YCrCbYUV.Location = new System.Drawing.Point(30, 113);
			this.YCrCbYUV.Name = "YCrCbYUV";
			this.YCrCbYUV.Size = new System.Drawing.Size(88, 17);
			this.YCrCbYUV.TabIndex = 20;
			this.YCrCbYUV.Text = "YCrCb / YUV";
			this.YCrCbYUV.Click += new System.EventHandler(this.YCrCbYUV_Click);
			// 
			// YIQ
			// 
			this.YIQ.AutoSize = true;
			this.YIQ.Location = new System.Drawing.Point(52, 155);
			this.YIQ.Name = "YIQ";
			this.YIQ.Size = new System.Drawing.Size(31, 17);
			this.YIQ.TabIndex = 21;
			this.YIQ.Text = "YIQ";
			this.YIQ.Click += new System.EventHandler(this.YIQ_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(681, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 17);
			this.label1.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 17);
			this.label2.TabIndex = 23;
			// 
			// note
			// 
			this.note.AutoSize = true;
			this.note.Location = new System.Drawing.Point(548, 155);
			this.note.Name = "note";
			this.note.Size = new System.Drawing.Size(299, 17);
			this.note.TabIndex = 24;
			this.note.Text = "NOTE: please use \"Y\" on YIQ for other scales!";
			this.note.Click += new System.EventHandler(this.note_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(864, 691);
			this.Controls.Add(this.note);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.YIQ);
			this.Controls.Add(this.YCrCbYUV);
			this.Controls.Add(this.cmyk);
			this.Controls.Add(this.V_Scale);
			this.Controls.Add(this.U_Scale);
			this.Controls.Add(this.Cb_Scale);
			this.Controls.Add(this.Cr_Scale);
			this.Controls.Add(this.Key);
			this.Controls.Add(this.Magenta_Scale);
			this.Controls.Add(this.Yellow_Scale);
			this.Controls.Add(this.Cyan_Scale);
			this.Controls.Add(this.Q_Band_Scale);
			this.Controls.Add(this.I_Band_Scale);
			this.Controls.Add(this.Y_Luma_Scale);
			this.Controls.Add(this.OpenImageDisplay);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.Blue_Scale);
			this.Controls.Add(this.Green_Scale);
			this.Controls.Add(this.Red_Scale);
			this.Controls.Add(this.Load_Image);
			this.Controls.Add(this.Gray_Scale);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.OpenImageDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button Gray_Scale;
		private System.Windows.Forms.Button Load_Image;
		private System.Windows.Forms.Button Red_Scale;
		private System.Windows.Forms.Button Green_Scale;
		private System.Windows.Forms.Button Blue_Scale;
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.PictureBox OpenImageDisplay;
		private System.Windows.Forms.Button Y_Luma_Scale;
		private System.Windows.Forms.Button I_Band_Scale;
		private System.Windows.Forms.Button Q_Band_Scale;
		private System.Windows.Forms.Button Cyan_Scale;
		private System.Windows.Forms.Button Yellow_Scale;
		private System.Windows.Forms.Button Magenta_Scale;
		private System.Windows.Forms.Button Key;
		private System.Windows.Forms.Button Cr_Scale;
		private System.Windows.Forms.Button Cb_Scale;
		private System.Windows.Forms.Button U_Scale;
		private System.Windows.Forms.Button V_Scale;
		private System.Windows.Forms.Label cmyk;
		private System.Windows.Forms.Label YCrCbYUV;
		private System.Windows.Forms.Label YIQ;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label note;
	}
}

