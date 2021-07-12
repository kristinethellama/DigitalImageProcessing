
namespace WebcamServer
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
			this.pic = new System.Windows.Forms.PictureBox();
			this.exitButton = new System.Windows.Forms.Button();
			this.cboCamera = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.StartCam = new System.Windows.Forms.Button();
			this.dllTest = new System.Windows.Forms.Button();
			this.stopCam = new System.Windows.Forms.Button();
			this.selectFilesButton = new System.Windows.Forms.Button();
			this.zippytime = new System.Windows.Forms.Button();
			this.serverSend = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.ipBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.SuspendLayout();
			// 
			// pic
			// 
			this.pic.Location = new System.Drawing.Point(224, 17);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(570, 524);
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(18, 502);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(176, 39);
			this.exitButton.TabIndex = 1;
			this.exitButton.Text = "&Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// cboCamera
			// 
			this.cboCamera.FormattingEnabled = true;
			this.cboCamera.Location = new System.Drawing.Point(18, 37);
			this.cboCamera.Name = "cboCamera";
			this.cboCamera.Size = new System.Drawing.Size(190, 24);
			this.cboCamera.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Camera:";
			// 
			// StartCam
			// 
			this.StartCam.Location = new System.Drawing.Point(18, 131);
			this.StartCam.Name = "StartCam";
			this.StartCam.Size = new System.Drawing.Size(176, 39);
			this.StartCam.TabIndex = 4;
			this.StartCam.Text = "&Start Camera";
			this.StartCam.UseVisualStyleBackColor = true;
			this.StartCam.Click += new System.EventHandler(this.StartCam_Click);
			// 
			// dllTest
			// 
			this.dllTest.Location = new System.Drawing.Point(18, 265);
			this.dllTest.Name = "dllTest";
			this.dllTest.Size = new System.Drawing.Size(176, 38);
			this.dllTest.TabIndex = 5;
			this.dllTest.Text = "&Start Server";
			this.dllTest.UseVisualStyleBackColor = true;
			this.dllTest.Click += new System.EventHandler(this.dllTest_Click);
			// 
			// stopCam
			// 
			this.stopCam.Location = new System.Drawing.Point(18, 221);
			this.stopCam.Name = "stopCam";
			this.stopCam.Size = new System.Drawing.Size(176, 38);
			this.stopCam.TabIndex = 6;
			this.stopCam.Text = "&Stop Camera";
			this.stopCam.UseVisualStyleBackColor = true;
			this.stopCam.Click += new System.EventHandler(this.stopCam_Click);
			// 
			// selectFilesButton
			// 
			this.selectFilesButton.Location = new System.Drawing.Point(18, 353);
			this.selectFilesButton.Name = "selectFilesButton";
			this.selectFilesButton.Size = new System.Drawing.Size(176, 38);
			this.selectFilesButton.TabIndex = 7;
			this.selectFilesButton.Text = "&Close Server";
			this.selectFilesButton.UseVisualStyleBackColor = true;
			this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
			// 
			// zippytime
			// 
			this.zippytime.Location = new System.Drawing.Point(18, 177);
			this.zippytime.Name = "zippytime";
			this.zippytime.Size = new System.Drawing.Size(176, 38);
			this.zippytime.TabIndex = 10;
			this.zippytime.Text = "&Save Video";
			this.zippytime.UseVisualStyleBackColor = true;
			this.zippytime.Click += new System.EventHandler(this.zippytime_Click);
			// 
			// serverSend
			// 
			this.serverSend.Location = new System.Drawing.Point(18, 309);
			this.serverSend.Name = "serverSend";
			this.serverSend.Size = new System.Drawing.Size(176, 38);
			this.serverSend.TabIndex = 12;
			this.serverSend.Text = "&Send To Client";
			this.serverSend.UseVisualStyleBackColor = true;
			this.serverSend.Click += new System.EventHandler(this.serverSend_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 17);
			this.label2.TabIndex = 13;
			this.label2.Text = "IP Address:";
			// 
			// ipBox
			// 
			this.ipBox.Location = new System.Drawing.Point(101, 70);
			this.ipBox.Name = "ipBox";
			this.ipBox.Size = new System.Drawing.Size(107, 22);
			this.ipBox.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 570);
			this.Controls.Add(this.ipBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.serverSend);
			this.Controls.Add(this.zippytime);
			this.Controls.Add(this.selectFilesButton);
			this.Controls.Add(this.stopCam);
			this.Controls.Add(this.dllTest);
			this.Controls.Add(this.StartCam);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboCamera);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.pic);
			this.Name = "Form1";
			this.Text = "Server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.ComboBox cboCamera;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button StartCam;
		private System.Windows.Forms.Button dllTest;
		private System.Windows.Forms.Button stopCam;
		private System.Windows.Forms.Button selectFilesButton;
		private System.Windows.Forms.Button zippytime;
		private System.Windows.Forms.Button serverSend;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ipBox;
	}
}

