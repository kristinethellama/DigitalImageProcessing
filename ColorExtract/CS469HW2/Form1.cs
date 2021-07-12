/*
 * Kristine Monsada, 2001381858
 * HW 2
 * CS 469 Digital Image Processing
 * Dr. Yfantis
 * Description: C# program to find the location of the pixel clicked
 *				and display individual RBG values on a 9x9 plane
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS469HW2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Load_Image_Click(object sender, EventArgs e)
		{
			OpenFileDialog imagefileopen = new OpenFileDialog();
			//imagefileopen.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif; *.bmp; *.png)";
			imagefileopen.Filter = "Image Files(*.jpg;*.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg; *.gif; *.bmp; *.png)";
			if (imagefileopen.ShowDialog() == DialogResult.OK)
			{
				OpenImageDisplay.Image = new Bitmap(imagefileopen.FileName);
				OpenImageDisplay.Size = OpenImageDisplay.Image.Size;

			}
		}


		// when clicked, should display the location of pixel and the 9x9 rgb
		private void OpenImageDisplay_Click(object sender, EventArgs e)
		{
			// mouse triggered control event
			var mouseArgs = (MouseEventArgs)e;
			// store x and y
			int x = mouseArgs.X;
			int y = mouseArgs.Y;
			// handle click event -- displays the x and y coordinates of clicked pixel
			MessageBox.Show("pixel location of (x,y): (" + x.ToString() + ", " + y.ToString() + ")");

			// 9x9 arrays to store each rgb value
			int[,] redDisplay = new int[9, 9];
			int[,] greenDisplay = new int[9, 9];
			int[,] blueDisplay = new int[9, 9];

			// create a bitmap to extract pixel
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			// because we are given the center
			// standard 9x9 center is at (4,4) so we need to subtract 4 to get origin
			int xOrigin = x - 4;
			int yOrigin = y - 4;

			// Get the color of a pixel from bitmap
			Color pixelColor;

			// iterating though a 9x9 grid
			for (int i = 0; i < 9; i++) {
				//TextBox redText = new TextBox();
				for (int j = 0; j < 9; j++) {
					// get pixel of bitmap at location (0,0) from our center
					pixelColor  = imageInstance.GetPixel(xOrigin, yOrigin);

					// get red value & save onto arr
					int red = pixelColor.R;
					redDisplay[i,j] = red;

					// get green value & save onto arr
					int green = pixelColor.G;
					greenDisplay[i,j] = green;

					// get blue value & save onto arr
					int blue = pixelColor.B;
					blueDisplay[i, j] = blue;

					// iterate though x axis
					xOrigin++;
				}
				// iterate through y axis
				// reset x back
				xOrigin = x - 4;
				yOrigin++;
			}
			/*
			//printing out matrix
			Console.Write("RED");
			Console.WriteLine();
			for (int i = 0; i < redDisplay.GetLength(0); i++)
			{
				for (int j = 0; j < redDisplay.GetLength(1); j++)
				{
					Console.Write(redDisplay[i, j] + "\t");
				}
				Console.WriteLine();
			}


			Console.Write("GREEN");
			Console.WriteLine();
			for (int i = 0; i < greenDisplay.GetLength(0); i++)
			{
				for (int j = 0; j < greenDisplay.GetLength(1); j++)
				{
					Console.Write(greenDisplay[i, j] + "\t");
				}
				Console.WriteLine();
			}

			Console.Write("BLUE");
			Console.WriteLine();
			for (int i = 0; i < blueDisplay.GetLength(0); i++)
			{
				for (int j = 0; j < blueDisplay.GetLength(1); j++)
				{
					Console.Write(blueDisplay[i, j] + "\t");
				}
				Console.WriteLine();
			}
			*/

			// red form -- display all values of 9x9
			Form form1 = new Red_Form();
			RichTextBox redText = new RichTextBox();
			Label locationPic = new Label();
			Label redLabel = new Label();
			redLabel.Location = new Point(300, 450);
			// adding properties for labels and textbox
			redLabel.Text = "RED VALUES";
			redLabel.AutoSize = true;
			redLabel.Location = new Point(20, 300);
			redLabel.ForeColor = System.Drawing.Color.Red;
			redText.Location = new Point(20, 30);
			locationPic.Location = new Point(600, 10);
			locationPic.AutoSize = true;
			// location of the bit
			locationPic.Text = "pixel location of (x,y): (" + x.ToString() + ", " + y.ToString() + ")";
			for (int i = 0; i < 9; i++) {

				for (int j = 0; j < 9; j++) {
					
					// output red value of bit
					redText.Text += redDisplay[i, j].ToString();

					// allow spacing until the last number of the array
					if (j != 9)
					{
						redText.Text += "\t";
					}
				}
				// new line
				string newLine = Environment.NewLine;
				redText.Text += newLine;
			}
			redText.MinimumSize = new Size(420, 260);
			redText.AutoSize = true;
			// add labs and textbox to form
			form1.Controls.Add(locationPic);
			form1.Controls.Add(redText);
			form1.Controls.Add(redLabel);
			// show red form
			form1.Show();

			// green form -- display all values of 9x9
			Form form2 = new Green_Form();
			RichTextBox greenText = new RichTextBox();
			Label locationPic1 = new Label();
			Label greenLabel = new Label();
			// setting properties of labels & textbox
			greenLabel.Text = "GREEN VALUES";
			greenLabel.AutoSize = true;
			greenLabel.Location = new Point(20, 300);
			greenLabel.ForeColor = System.Drawing.Color.ForestGreen;
			greenText.Location = new Point(20, 30);
			locationPic1.Location = new Point(600, 10);
			locationPic1.AutoSize = true;
			// display location
			locationPic1.Text = "pixel location of (x,y): (" + x.ToString() + ", " + y.ToString() + ")";
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					// display green value
					greenText.Text += greenDisplay[i, j].ToString();

					if (j != 9)
					{
						// tab as long as its not the last number of arr (9)
						greenText.Text += "\t";
					}
				}
				// new line
				string newLine = Environment.NewLine;
				greenText.Text += newLine;
			}
			greenText.MinimumSize = new Size(420, 260);
			greenText.AutoSize = true;
			// add onto form
			form2.Controls.Add(locationPic1);
			form2.Controls.Add(greenText);
			form2.Controls.Add(greenLabel);
			// show form
			form2.Show();

			// blue form -- display all values of 9x9
			Form form3 = new Blue_Form();
			// set up textbox and labels on form
			RichTextBox blueText = new RichTextBox();
			Label locationPic2 = new Label();
			Label blueLabel = new Label();
			// adjusting properties
			blueLabel.Text = "BLUE VALUES";
			blueLabel.AutoSize = true;
			blueLabel.Location = new Point(20, 300);
			blueLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
			blueText.Location = new Point(20, 30);
			locationPic2.Location = new Point(600, 10);
			locationPic2.AutoSize = true;
			// display location
			locationPic2.Text = "pixel location of (x,y): (" + x.ToString() + ", " + y.ToString() + ")";
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					// output the blue value
					blueText.Text += blueDisplay[i, j].ToString();

					if (j != 9)
					{	
						// tab for every num before 9
						blueText.Text += "\t";
					}
				}
				// new line
				string newLine = Environment.NewLine;
				blueText.Text += newLine;
			}
			// add onto form
			blueText.MinimumSize = new Size(420, 260);
			blueText.AutoSize = true;
			form3.Controls.Add(locationPic2);
			form3.Controls.Add(blueText);
			form3.Controls.Add(blueLabel);
			// show form
			form3.Show();

		}

		// exit out of prog
		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
