/* 
 * Kristine Monsada
 * CS 469 Dr. Yfantis
 * HW 5
 * Description: double and quadruple the image size using sinc interpolation
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS469HW5
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void LoadImage_Click(object sender, EventArgs e)
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

		private Bitmap DoubleInSize(Bitmap original) {

			try {
				Bitmap og = original;
				int width = og.Width;
				int height = og.Height;
				// create a new bitmap double in original bitmaps size
				Bitmap doubledWidth = new Bitmap(width * 2, height * 2);
				Bitmap doubledHeight = new Bitmap(width, height * 2);
				int[,] originalPixelsRed = new int[width, height];
				int[,] originalPixelsGreen = new int[width, height];
				int[,] originalPixelsBlue = new int[width, height];

				int[,] doubledHeightMatrixR = new int[width, height * 2];
				int[,] doubledHeightMatrixG = new int[width, height * 2];
				int[,] doubledHeightMatrixB = new int[width, height * 2];

				// extract the colors out of the pixel
				for (int x = 0; x < width; x++)
				{
					for (int y = 0; y < height; y++)
					{
						// get pixel color
						Color ogColor = og.GetPixel(x, y);

						// indiv rgb channels
						originalPixelsRed[x, y] = ogColor.R;
						originalPixelsGreen[x, y] = ogColor.G;
						originalPixelsBlue[x, y] = ogColor.B;
					}
				}
			
				int kRed = 0;
				int kR = 0, kG = 0, kB = 0;
				int kGreen = 0;
				int kBlue = 0;
				int kPos = 0;

				// get doubled height
				for (int i = 0; i < width; i++) {
					for (int j = 3; j < (height -4) * 2; j++) {

						// if height modded height == 0, copy straight over
						if (j % 2 == 0) {
							kR = originalPixelsRed[i, j / 2];
							kG = originalPixelsGreen[i, j / 2];
							kB = originalPixelsBlue[i, j / 2];

							Color copiedColor = Color.FromArgb(kR, kG, kB);
							doubledHeight.SetPixel(i, j, copiedColor);
						}
						// interpolated pixel
						// use sinc function
						else if (j % 2 == 1) {

							kPos = j/2;
							if ((kPos - 3 < 0) && (kPos - 2 < 0) && (kPos - 1 < 0)) {
								kRed = (-10 * (originalPixelsRed[i, (kPos)])) + (14 * (originalPixelsRed[i, (kPos)])) + (-23 * (originalPixelsRed[i, (kPos)])) + (69 * (originalPixelsRed[i, kPos])) + (69 * (originalPixelsRed[i, (kPos) + 1])) + (-23 * (originalPixelsRed[i, (kPos) + 2])) + (14 * (originalPixelsRed[i, (kPos) + 3])) + (-10 * (originalPixelsRed[i, (kPos) + 4])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (originalPixelsGreen[i, (kPos)])) + (14 * (originalPixelsGreen[i, (kPos)])) + (-23 * (originalPixelsGreen[i, (kPos)])) + (69 * (originalPixelsGreen[i, kPos])) + (69 * (originalPixelsGreen[i, (kPos) + 1])) + (-23 * (originalPixelsGreen[i, (kPos) + 2])) + (14 * (originalPixelsGreen[i, (kPos) + 3])) + (-10 * (originalPixelsGreen[i, (kPos) + 4])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (originalPixelsBlue[i, (kPos)])) + (14 * (originalPixelsBlue[i, (kPos)])) + (-23 * (originalPixelsBlue[i, (kPos)])) + (69 * (originalPixelsBlue[i, (kPos)])) + (69 * (originalPixelsBlue[i, (kPos) + 1])) + (-23 * (originalPixelsBlue[i, (kPos) + 2])) + (14 * (originalPixelsBlue[i, (kPos) + 3])) + (-10 * (originalPixelsBlue[i, (kPos) + 4])) + 50;
								kBlue = kBlue / 100;
							}
							else if ((kPos - 3 < 0) && (kPos - 2 < 0))
							{
								kRed = (-10 * (originalPixelsRed[i, (kPos)])) + (14 * (originalPixelsRed[i, (kPos) - 1])) + (-23 * (originalPixelsRed[i, (kPos) - 1])) + (69 * (originalPixelsRed[i, kPos])) + (69 * (originalPixelsRed[i, (kPos) + 1])) + (-23 * (originalPixelsRed[i, (kPos) + 2])) + (14 * (originalPixelsRed[i, (kPos) + 3])) + (-10 * (originalPixelsRed[i, (kPos) + 4])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (originalPixelsGreen[i, (kPos)])) + (14 * (originalPixelsGreen[i, (kPos) - 1])) + (-23 * (originalPixelsGreen[i, (kPos) - 1])) + (69 * (originalPixelsGreen[i, kPos])) + (69 * (originalPixelsGreen[i, (kPos) + 1])) + (-23 * (originalPixelsGreen[i, (kPos) + 2])) + (14 * (originalPixelsGreen[i, (kPos) + 3])) + (-10 * (originalPixelsGreen[i, (kPos) + 4])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (originalPixelsBlue[i, (kPos)])) + (14 * (originalPixelsBlue[i, (kPos) - 1])) + (-23 * (originalPixelsBlue[i, (kPos) - 1])) + (69 * (originalPixelsBlue[i, (kPos)])) + (69 * (originalPixelsBlue[i, (kPos) + 1])) + (-23 * (originalPixelsBlue[i, (kPos) + 2])) + (14 * (originalPixelsBlue[i, (kPos) + 3])) + (-10 * (originalPixelsBlue[i, (kPos) + 4])) + 50;
								kBlue = kBlue / 100;
							}
							else if ((kPos - 3 < 0))
							{
								kRed = (-10 * (originalPixelsRed[i, (kPos) - 2])) + (14 * (originalPixelsRed[i, (kPos) - 2])) + (-23 * (originalPixelsRed[i, (kPos) - 1])) + (69 * (originalPixelsRed[i, kPos])) + (69 * (originalPixelsRed[i, (kPos) + 1])) + (-23 * (originalPixelsRed[i, (kPos) + 2])) + (14 * (originalPixelsRed[i, (kPos) + 3])) + (-10 * (originalPixelsRed[i, (kPos) + 4])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (originalPixelsGreen[i, (kPos) - 2])) + (14 * (originalPixelsGreen[i, (kPos) - 2])) + (-23 * (originalPixelsGreen[i, (kPos) - 1])) + (69 * (originalPixelsGreen[i, kPos])) + (69 * (originalPixelsGreen[i, (kPos) + 1])) + (-23 * (originalPixelsGreen[i, (kPos) + 2])) + (14 * (originalPixelsGreen[i, (kPos) + 3])) + (-10 * (originalPixelsGreen[i, (kPos) + 4])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (originalPixelsBlue[i, (kPos) - 2])) + (14 * (originalPixelsBlue[i, (kPos) - 2])) + (-23 * (originalPixelsBlue[i, (kPos) - 1])) + (69 * (originalPixelsBlue[i, (kPos)])) + (69 * (originalPixelsBlue[i, (kPos) + 1])) + (-23 * (originalPixelsBlue[i, (kPos) + 2])) + (14 * (originalPixelsBlue[i, (kPos) + 3])) + (-10 * (originalPixelsBlue[i, (kPos) + 4])) + 50;
								kBlue = kBlue / 100;
							}
							else
							{
								kRed = (-10 * (originalPixelsRed[i, (kPos) - 3])) + (14 * (originalPixelsRed[i, (kPos) - 2])) + (-23 * (originalPixelsRed[i, (kPos) - 1])) + (69 * (originalPixelsRed[i, kPos])) + (69 * (originalPixelsRed[i, (kPos) + 1])) + (-23 * (originalPixelsRed[i, (kPos) + 2])) + (14 * (originalPixelsRed[i, (kPos) + 3])) + (-10 * (originalPixelsRed[i, (kPos) + 4])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (originalPixelsGreen[i, (kPos) - 3])) + (14 * (originalPixelsGreen[i, (kPos) - 2])) + (-23 * (originalPixelsGreen[i, (kPos) - 1])) + (69 * (originalPixelsGreen[i, kPos])) + (69 * (originalPixelsGreen[i, (kPos) + 1])) + (-23 * (originalPixelsGreen[i, (kPos) + 2])) + (14 * (originalPixelsGreen[i, (kPos) + 3])) + (-10 * (originalPixelsGreen[i, (kPos) + 4])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (originalPixelsBlue[i, (kPos) - 3])) + (14 * (originalPixelsBlue[i, (kPos) - 2])) + (-23 * (originalPixelsBlue[i, (kPos) - 1])) + (69 * (originalPixelsBlue[i, (kPos)])) + (69 * (originalPixelsBlue[i, (kPos) + 1])) + (-23 * (originalPixelsBlue[i, (kPos) + 2])) + (14 * (originalPixelsBlue[i, (kPos) + 3])) + (-10 * (originalPixelsBlue[i, (kPos) + 4])) + 50;
								kBlue = kBlue / 100;

							}

							// keep in range of 0-255
							if (kRed > 255)
							{
								kRed = 255;
							}
							else if (kRed < 0) {
								kRed = 0;
							}
							if (kGreen > 255)
							{
								kGreen = 255;
							}
							else if (kGreen < 0) {
								kGreen = 0;
							}
							if (kBlue > 255)
							{
								kBlue = 255;
							}
							else if (kBlue < 0) {
								kBlue = 0;
							}

							Color setColor = Color.FromArgb(kRed, kGreen, kBlue);
							doubledHeight.SetPixel(i, j, setColor);
						}
					}
				}

				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height * 2; j++)
					{
						Color getColor = doubledHeight.GetPixel(i, j);

						doubledHeightMatrixR[i, j] = getColor.R;
						doubledHeightMatrixG[i, j] = getColor.G;
						doubledHeightMatrixB[i, j] = getColor.B;

					}
				}

				kRed = 0;
				kR = 0;
				kG = 0;
				kB = 0;
				kGreen = 0;
				kBlue = 0;
				kPos = 0;

				// calc width next
				for (int i = 3; i < (width - 4) * 2; i++)
				{
					for (int j = 3; j < (height - 4) * 2; j++)
					{
						// move original pixel
						if (i % 2 == 0)
						{
							kR = doubledHeightMatrixR[i / 2, j];
							kG = doubledHeightMatrixG[i / 2, j];
							kB = doubledHeightMatrixB[i / 2, j];

							Color copiedColor = Color.FromArgb(kR, kG, kB);
							doubledWidth.SetPixel(i, j, copiedColor);
						}
						// interpolated
						else if (i % 2 == 1)
						{

							kPos = i / 2;

							// handle out of bounds cases
							if ((kPos - 3 < 0) && (kPos - 2 < 0) && (kPos - 1 < 0)) {
								kRed = (-10 * (doubledHeightMatrixR[kPos, j])) + (14 * (doubledHeightMatrixR[kPos, j])) + (-23 * (doubledHeightMatrixR[kPos, j])) + (69 * (doubledHeightMatrixR[kPos, j])) + (69 * (doubledHeightMatrixR[kPos + 1, j])) + (-23 * (doubledHeightMatrixR[kPos + 2, j])) + (14 * (doubledHeightMatrixR[kPos + 3, j])) + (-10 * (doubledHeightMatrixR[kPos + 4, j])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (doubledHeightMatrixG[kPos, j])) + (14 * (doubledHeightMatrixG[kPos, j])) + (-23 * (doubledHeightMatrixG[kPos, j])) + (69 * (doubledHeightMatrixG[kPos, j])) + (69 * (doubledHeightMatrixG[kPos + 1, j])) + (-23 * (doubledHeightMatrixG[kPos + 2, j])) + (14 * (doubledHeightMatrixG[kPos + 3, j])) + (-10 * (doubledHeightMatrixG[kPos + 4, j])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (doubledHeightMatrixB[kPos, j])) + (14 * (doubledHeightMatrixB[kPos, j])) + (-23 * (doubledHeightMatrixB[kPos, j])) + (69 * (doubledHeightMatrixB[kPos, j])) + (69 * (doubledHeightMatrixB[kPos + 1, j])) + (-23 * (doubledHeightMatrixB[kPos + 2, j])) + (14 * (doubledHeightMatrixB[kPos + 3, j])) + (-10 * (doubledHeightMatrixB[kPos + 4, j])) + 50;
								kBlue = kBlue / 100;
							}
							else if ((kPos - 3 < 0) && (kPos - 2 < 0))
							{

								kRed = (-10 * (doubledHeightMatrixR[kPos, j])) + (14 * (doubledHeightMatrixR[kPos - 1, j])) + (-23 * (doubledHeightMatrixR[kPos - 1, j])) + (69 * (doubledHeightMatrixR[kPos, j])) + (69 * (doubledHeightMatrixR[kPos + 1, j])) + (-23 * (doubledHeightMatrixR[kPos + 2, j])) + (14 * (doubledHeightMatrixR[kPos + 3, j])) + (-10 * (doubledHeightMatrixR[kPos + 4, j])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (doubledHeightMatrixG[kPos, j])) + (14 * (doubledHeightMatrixG[kPos - 1, j])) + (-23 * (doubledHeightMatrixG[kPos - 1, j])) + (69 * (doubledHeightMatrixG[kPos, j])) + (69 * (doubledHeightMatrixG[kPos + 1, j])) + (-23 * (doubledHeightMatrixG[kPos + 2, j])) + (14 * (doubledHeightMatrixG[kPos + 3, j])) + (-10 * (doubledHeightMatrixG[kPos + 4, j])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (doubledHeightMatrixB[kPos, j])) + (14 * (doubledHeightMatrixB[kPos - 1, j])) + (-23 * (doubledHeightMatrixB[kPos - 1, j])) + (69 * (doubledHeightMatrixB[kPos, j])) + (69 * (doubledHeightMatrixB[kPos + 1, j])) + (-23 * (doubledHeightMatrixB[kPos + 2, j])) + (14 * (doubledHeightMatrixB[kPos + 3, j])) + (-10 * (doubledHeightMatrixB[kPos + 4, j])) + 50;
								kBlue = kBlue / 100;
								

							}
							else if ((kPos - 3) < 0)
							{
								kRed = (-10 * (doubledHeightMatrixR[kPos - 2, j])) + (14 * (doubledHeightMatrixR[kPos - 2, j])) + (-23 * (doubledHeightMatrixR[kPos - 1, j])) + (69 * (doubledHeightMatrixR[kPos, j])) + (69 * (doubledHeightMatrixR[kPos + 1, j])) + (-23 * (doubledHeightMatrixR[kPos + 2, j])) + (14 * (doubledHeightMatrixR[kPos + 3, j])) + (-10 * (doubledHeightMatrixR[kPos + 4, j])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (doubledHeightMatrixG[kPos - 2, j])) + (14 * (doubledHeightMatrixG[kPos - 2, j])) + (-23 * (doubledHeightMatrixG[kPos - 1, j])) + (69 * (doubledHeightMatrixG[kPos, j])) + (69 * (doubledHeightMatrixG[kPos + 1, j])) + (-23 * (doubledHeightMatrixG[kPos + 2, j])) + (14 * (doubledHeightMatrixG[kPos + 3, j])) + (-10 * (doubledHeightMatrixG[kPos + 4, j])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (doubledHeightMatrixB[kPos - 2, j])) + (14 * (doubledHeightMatrixB[kPos - 2, j])) + (-23 * (doubledHeightMatrixB[kPos - 1, j])) + (69 * (doubledHeightMatrixB[kPos, j])) + (69 * (doubledHeightMatrixB[kPos + 1, j])) + (-23 * (doubledHeightMatrixB[kPos + 2, j])) + (14 * (doubledHeightMatrixB[kPos + 2, j])) + (-10 * (doubledHeightMatrixB[kPos + 4, j])) + 50;
								kBlue = kBlue / 100;
							}
							else
							{
								kRed = (-10 * (doubledHeightMatrixR[kPos - 3, j])) + (14 * (doubledHeightMatrixR[kPos - 2, j])) + (-23 * (doubledHeightMatrixR[kPos - 1, j])) + (69 * (doubledHeightMatrixR[kPos, j])) + (69 * (doubledHeightMatrixR[kPos + 1, j])) + (-23 * (doubledHeightMatrixR[kPos + 2, j])) + (14 * (doubledHeightMatrixR[kPos + 3, j])) + (-10 * (doubledHeightMatrixR[kPos + 4, j])) + 50;
								kRed = kRed / 100;
								kGreen = (-10 * (doubledHeightMatrixG[kPos - 3, j])) + (14 * (doubledHeightMatrixG[kPos - 2, j])) + (-23 * (doubledHeightMatrixG[kPos - 1, j])) + (69 * (doubledHeightMatrixG[kPos, j])) + (69 * (doubledHeightMatrixG[kPos + 1, j])) + (-23 * (doubledHeightMatrixG[kPos + 2, j])) + (14 * (doubledHeightMatrixG[kPos + 3, j])) + (-10 * (doubledHeightMatrixG[kPos + 4, j])) + 50;
								kGreen = kGreen / 100;
								kBlue = (-10 * (doubledHeightMatrixB[kPos - 3, j])) + (14 * (doubledHeightMatrixB[kPos - 2, j])) + (-23 * (doubledHeightMatrixB[kPos - 1, j])) + (69 * (doubledHeightMatrixB[kPos, j])) + (69 * (doubledHeightMatrixB[kPos + 1, j])) + (-23 * (doubledHeightMatrixB[kPos + 2, j])) + (14 * (doubledHeightMatrixB[kPos + 3, j])) + (-10 * (doubledHeightMatrixB[kPos + 4, j])) + 50;
								kBlue = kBlue / 100;
							}

							// get the range 0 - 255
							if (kRed > 255)
							{
								kRed = 255;
							}
							else if (kRed < 0)
							{
								kRed = 0;
							}
							if (kGreen > 255)
							{
								kGreen = 255;
							}
							else if (kGreen < 0)
							{
								kGreen = 0;
							}
							if (kBlue > 255)
							{
								kBlue = 255;
							}
							else if (kBlue < 0)
							{
								kBlue = 0;
							}

							Color setColor = Color.FromArgb(kRed, kGreen, kBlue);
							doubledWidth.SetPixel(i, j, setColor);
						}
						
					}
				}
				
				return doubledWidth;

			} catch {

				throw new NotImplementedException();
			}
		}

		private Bitmap QuadInSize(Bitmap original) {

			try {
				Bitmap og = original;
				int width = og.Width;
				int height = og.Height;
				// create a new bitmap quadruple in original bitmaps size
				Bitmap doubled = new Bitmap(width * 2, height * 2);
				Bitmap quad = new Bitmap(width * 4, height * 4);
			
				// call the doubled twice bc it makes it quad
				doubled = DoubleInSize(og);

				quad = DoubleInSize(doubled);

				return quad;
			} catch {
				throw new NotImplementedException();
			}
		}
		
		private void Double_Click(object sender, EventArgs e)
		{
			Form form2 = new Doubled();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = DoubleInSize(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form2.Controls.Add(tempPict);
				form2.AutoSize = true;
				tempPict.Image = imageInstance1;
				form2.Show();
			}
		}

		private void Quadruple_Click(object sender, EventArgs e)
		{
			Form form3 = new Quad();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = QuadInSize(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form3.Controls.Add(tempPict);
				form3.AutoSize = true;
				tempPict.Image = imageInstance1;
				form3.Show();
			}
		}

		// exit out of prog
		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
