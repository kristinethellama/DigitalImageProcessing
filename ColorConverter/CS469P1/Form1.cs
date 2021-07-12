/*
 * Kristine Monsada  
 * NSHE: 2001381858
 * CS 469 - Dr. Yfantis
 * Assignment 1
 * Description: convert rgb to yiq, cmy/cmyk, YCrCb, and yuv scales
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

namespace CS469P1
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

		private Bitmap MakeGrayscale(Bitmap original)
		{
			try
			{
				Bitmap newBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						// get the pixels from OG image
						Color originalColor = original.GetPixel(i, j);
						// create the gray scale version of each px
						int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
						Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
						newBitmap.SetPixel(i, j, newColor);

					}
				}
				return newBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Gray_Scale_Click(object sender, EventArgs e)
		{
			Form form2 = new Gray_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeGrayscale(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form2.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form2.Show();
			}

		}

		private Bitmap MakeRed(Bitmap orginal)
		{
			try
			{
				Bitmap redBitmap = new Bitmap(orginal.Width, orginal.Height);
				for (int i = 0; i < orginal.Width; i++)
				{
					for (int j = 0; j < orginal.Height; j++)
					{
						// get the pixels from OG image
						Color originalColor = orginal.GetPixel(i, j);
						// create the red scale version of each pixel
						Color redColor = Color.FromArgb(originalColor.R, originalColor.R, originalColor.R);
						redBitmap.SetPixel(i, j, redColor);
					}
				}
				return redBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Red_Scale_Click(object sender, EventArgs e)
		{
			Form form3 = new Red_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeRed(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form3.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form3.Show();
			}
		}

		private Bitmap MakeGreen(Bitmap original)
		{
			try
			{
				Bitmap greenBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Width; j++)
					{
						// get pixels from OG images
						Color originalColor = original.GetPixel(i, j);
						// create green scale version of each pixel
						Color greenColor = Color.FromArgb(originalColor.G, originalColor.G, originalColor.G);
						greenBitmap.SetPixel(i, j, greenColor);
					}
				}
				return greenBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Green_Scale_Click(object sender, EventArgs e)
		{
			Form form2 = new Green_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeGreen(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form2.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form2.Show();
			}
		}

		private Bitmap MakeBlue(Bitmap original)
		{
			try
			{
				Bitmap blueBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// create blue scale version of each pixel
						Color blueColor = Color.FromArgb(originalColor.B, originalColor.B, originalColor.B);
						blueBitmap.SetPixel(i, j, blueColor);
					}
				}
				return blueBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Blue_Scale_Click(object sender, EventArgs e)
		{
			Form form5 = new Blue_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeBlue(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form5.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form5.Show();
			}

		}

		private Bitmap MakeY(Bitmap original)
		{
			try
			{
				Bitmap yBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{	
						double rColor, gColor, bColor;

						// NOTE -- Y KINDA THE SAME AS GREYSCALE
						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);

						// divide out 255 which is the max of each rgb value to get in [0,255] range
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// go back to rbg
						rColor = rColor * 255;
						gColor = gColor * 255;
						bColor = bColor * 255;

						// multiply Y vector to corresp RGB color
						int getY = (int)((0.299900 * rColor) + (0.587000 * gColor) + (0.114000 * bColor));

						// create Y scale version of each pixel
						Color yScaledColor = Color.FromArgb(getY, getY, getY);
						yBitmap.SetPixel(i, j, yScaledColor);
					}
				}
				return yBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Y_Luma_Scale_Click(object sender, EventArgs e)
		{
			Form form6 = new Y_Luma_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeY(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form6.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form6.Show();
			}
		}

		private Bitmap MakeI(Bitmap original)
		{
			try
			{
				Bitmap iBitmap = new Bitmap(original.Width, original.Height);
				int geti = 0;
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						//double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						//rColor = (double)originalColor.R / 255;
						//gColor = (double)originalColor.G / 255;
						//bColor = (double)originalColor.B / 255;


						// I = [0.5959, -0.2746, -0.3213]
						// case if it goes out of range
						if (geti > -1 && geti < 256)
						{
							// if not, perform matrix scale on given rgb values
							geti = (int)((0.596 * originalColor.R) + (-0.275 * originalColor.G) + (-0.321 * originalColor.B) + 127);
						}
						else
						{
							// otherwise set to 0 so it doesnt bug out
							geti = 0;
						}

						
						// normalize / scale down to fit i range
						//geti = (double)(geti + 0.5959);
						//geti = (double)(geti / 1.1918);
						
						// get back to rbg
						//int iScale = (int)(geti * 255);

						// create i scale version of each pixel
						Color iScaledColor = Color.FromArgb(geti, geti, geti);
						iBitmap.SetPixel(i, j, iScaledColor);
					}
				}
				return iBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void I_Band_Scale_Click(object sender, EventArgs e)
		{
			Form form7 = new I_Band_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeI(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form7.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form7.Show();
			}
		}

		private Bitmap MakeQ(Bitmap original)
		{
			try
			{
				Bitmap qBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// Q = [0.212, -0.523, -0.311]
						// transition with provided matrix
						double getq = ((0.212 * rColor) + (-0.523 * gColor) + (0.311 * bColor));

						// add the max of the matrix to get min/max
						// divide by our highest number (0.523+0.523) to get the correct scale
						getq = getq + 0.523;
						getq = getq / 1.046;

						// put it back into rgb format
						int qScale = (int)(getq * 255);

						// create q scale version of each pixel
						Color qScaledColor = Color.FromArgb(qScale, qScale, qScale);
						qBitmap.SetPixel(i, j, qScaledColor);
					}
				}
				return qBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Q_Band_Scale_Click(object sender, EventArgs e)
		{
			Form form8 = new Q_Band_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeQ(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form8.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form8.Show();
			}
		}

		private Bitmap MakeCyan(Bitmap original)
		{
			try
			{
				Bitmap cyanBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						Color originalColor = original.GetPixel(i, j);

						// subtract the red from max
						int getCyan = (int)(255 - originalColor.R);

						// create cyan scale version of each pixel
						Color cyanScaledColor = Color.FromArgb(getCyan, getCyan, getCyan);
						cyanBitmap.SetPixel(i, j, cyanScaledColor);
					}
				}
				return cyanBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Cyan_Scale_Click(object sender, EventArgs e)
		{
			Form form9 = new Cyan_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeCyan(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form9.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form9.Show();
			}
		}

		private Bitmap MakeYellow(Bitmap original)
		{
			try
			{
				Bitmap yellowBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						Color originalColor = original.GetPixel(i, j);

						// subtract the blue from max
						int getYellow = (int)(255 - originalColor.B);

						// create yellow scale version of each pixel
						Color yellowScaledColor = Color.FromArgb(getYellow, getYellow, getYellow);
						yellowBitmap.SetPixel(i, j, yellowScaledColor);
					}
				}
				return yellowBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Yellow_Scale_Click(object sender, EventArgs e)
		{
			Form form10 = new Yellow_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeYellow(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form10.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form10.Show();
			}
		}

		private Bitmap MakeMagenta(Bitmap original)
		{
			try
			{
				Bitmap magentaBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						Color originalColor = original.GetPixel(i, j);

						// subtract the green from max
						int getMagenta = (int)(255 - originalColor.G);

						// create magenta scale version of each pixel
						Color magentaScaledColor = Color.FromArgb(getMagenta, getMagenta, getMagenta);
						magentaBitmap.SetPixel(i, j, magentaScaledColor);
					}
				}
				return magentaBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private Bitmap MakeKey(Bitmap original)
		{
			try
			{
				Bitmap keyBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						Color originalColor = original.GetPixel(i, j);

						// CMY - dont need but here for reference
						int getCyan = (int)(255 - originalColor.R);
						int getMagenta = (int)(255 - originalColor.G);
						int getYellow = (int)(255 - originalColor.B);

						// put rbg in an array
						int[] rbgColors = { originalColor.R, originalColor.G, originalColor.B };

						// find the max of those
						int maxrbg = rbgColors.Max();

						// subtract from 255 range to get k (black)
						int key = 255 - maxrbg;

						// create k scale version of each pixel
						Color keyScaledColor = Color.FromArgb(key, key, key);
						keyBitmap.SetPixel(i, j, keyScaledColor);
					}
				}
				return keyBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Magenta_Scale_Click(object sender, EventArgs e)
		{

			Form form11 = new Magenta_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeMagenta(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form11.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form11.Show();
			}
		}

		private void Key_Click(object sender, EventArgs e)
		{
			Form form12 = new Key_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeKey(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form12.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form12.Show();
			}
		}

		private Bitmap MakeCr(Bitmap original)
		{
			try
			{
				Bitmap crBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// Cr = [0.500, -0.419, -0.081]
						double getcr = ((0.500 * rColor) + (-0.419 * gColor) + (-0.081 * bColor));

						// normalize it / scale down to fit Cr range
						getcr = getcr + 0.500;
						getcr = getcr / 1.000;

						// get it back to rbg format
						int crScale = (int)(getcr * 255);

						// create cr scale version of each pixel
						Color crScaledColor = Color.FromArgb(crScale, crScale, crScale);
						crBitmap.SetPixel(i, j, crScaledColor);
					}
				}
				return crBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Cr_Scale_Click(object sender, EventArgs e)
		{
			Form form13 = new Cr_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeCr(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form13.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form13.Show();
			}
		}


		private Bitmap MakeCb(Bitmap original)
		{
			try
			{
				Bitmap cbBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// Cb = [-0.169, -0.331, 0.500]
						double getcb = ((-0.169 * rColor) + (-0.331 * gColor) + (0.500 * bColor));

						// normalize it / scale down to fit Cb range
						getcb = getcb + 0.500;
						getcb = getcb / 1.000;

						// get back to rbg
						int cbScale = (int)(getcb * 255);

						// create cb scale version of each pixel
						Color cbScaledColor = Color.FromArgb(cbScale, cbScale, cbScale);
						cbBitmap.SetPixel(i, j, cbScaledColor);
					}
				}
				return cbBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void Cb_Scale_Click(object sender, EventArgs e)
		{
			Form form14 = new Cb_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeCb(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form14.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form14.Show();
			}
		}

		private Bitmap MakeU(Bitmap original)
		{
			try
			{
				Bitmap uBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// u = [-0.147, -0.289, 0.437]
						double getu = ((-0.147 * rColor) + (-0.289 * gColor) + (0.437 * bColor));

						// normalize it / scale down to fit u range
						getu = getu + 0.437;
						getu = getu / 0.874;

						// get back to rbg 
						int uScale = (int)(getu * 255);

						// create u scale version of each pixel
						Color uScaledColor = Color.FromArgb(uScale, uScale, uScale);
						uBitmap.SetPixel(i, j, uScaledColor);
					}
				}
				return uBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void U_Scale_Click(object sender, EventArgs e)
		{
			Form form15 = new U_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeU(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form15.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form15.Show();
			}
		}

		private Bitmap MakeV(Bitmap original)
		{
			try
			{
				Bitmap vBitmap = new Bitmap(original.Width, original.Height);
				for (int i = 0; i < original.Width; i++)
				{
					for (int j = 0; j < original.Height; j++)
					{
						double rColor, gColor, bColor;

						// get the pixel from OG
						Color originalColor = original.GetPixel(i, j);
						// divide out 255 which is the max of each rgb value to get to scale [0,1]
						rColor = (double)originalColor.R / 255;
						gColor = (double)originalColor.G / 255;
						bColor = (double)originalColor.B / 255;

						// v = [0.615, -0.515, -0.100]
						double getv = ((0.615 * rColor) + (-0.515 * gColor) + (-0.100 * bColor));

						// normalize it / scale down to fit v range
						getv = getv + 0.615;
						getv = getv / 1.23;

						// get back to rbg
						int vScale = (int)(getv * 255);

						// create v scale version of each pixel
						Color vScaledColor = Color.FromArgb(vScale, vScale, vScale);
						vBitmap.SetPixel(i, j, vScaledColor);
					}
				}
				return vBitmap;
			}
			catch
			{
				throw new NotImplementedException();
			}
		}

		private void V_Scale_Click(object sender, EventArgs e)
		{
			Form form16 = new V_Scale_Form();
			Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
			Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
			if (imageInstance != null)
			{
				imageInstance1 = MakeV(imageInstance);
				PictureBox tempPict = new PictureBox();
				tempPict.Size = imageInstance1.Size;
				form16.Controls.Add(tempPict);
				tempPict.Image = imageInstance1;
				form16.Show();
			}
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		// labels -- these don't do anything but exist
		private void cmyk_Click(object sender, EventArgs e)
		{

		}

		private void YCrCbYUV_Click(object sender, EventArgs e)
		{

		}

		private void YIQ_Click(object sender, EventArgs e)
		{

		}

		private void note_Click(object sender, EventArgs e)
		{

		}

	}
}
