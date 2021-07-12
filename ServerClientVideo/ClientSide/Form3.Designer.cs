
namespace ClientSide
{
	partial class Form3
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
			this.ClientButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.recievejunk = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.closeClient = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ClientButton
			// 
			this.ClientButton.Location = new System.Drawing.Point(25, 296);
			this.ClientButton.Name = "ClientButton";
			this.ClientButton.Size = new System.Drawing.Size(160, 39);
			this.ClientButton.TabIndex = 2;
			this.ClientButton.Text = "&Start Client";
			this.ClientButton.UseVisualStyleBackColor = true;
			this.ClientButton.Click += new System.EventHandler(this.ClientButton_Click);
			// 
			// ExitButton
			// 
			this.ExitButton.Location = new System.Drawing.Point(25, 504);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(160, 32);
			this.ExitButton.TabIndex = 4;
			this.ExitButton.Text = "&Exit";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// recievejunk
			// 
			this.recievejunk.Location = new System.Drawing.Point(25, 341);
			this.recievejunk.Name = "recievejunk";
			this.recievejunk.Size = new System.Drawing.Size(160, 36);
			this.recievejunk.TabIndex = 6;
			this.recievejunk.Text = "&Recieve";
			this.recievejunk.UseVisualStyleBackColor = true;
			this.recievejunk.Click += new System.EventHandler(this.recievejunk_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 383);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 36);
			this.button1.TabIndex = 8;
			this.button1.Text = "&Display Video";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// closeClient
			// 
			this.closeClient.Location = new System.Drawing.Point(25, 425);
			this.closeClient.Name = "closeClient";
			this.closeClient.Size = new System.Drawing.Size(160, 36);
			this.closeClient.TabIndex = 9;
			this.closeClient.Text = "&Close Client";
			this.closeClient.UseVisualStyleBackColor = true;
			this.closeClient.Click += new System.EventHandler(this.closeClient_Click);
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 577);
			this.Controls.Add(this.closeClient);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.recievejunk);
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.ClientButton);
			this.Name = "Form3";
			this.Text = "Client";
			this.Load += new System.EventHandler(this.Form3_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ClientButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Button recievejunk;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button closeClient;
	}
}

