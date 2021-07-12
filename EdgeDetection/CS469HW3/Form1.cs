/*
 * Kristine Monsada 2001381858
 * CS 469 HW
 * Description: Compute Sobel, Roberts, Prewitt, and Laplacian Edge detection
 * 
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

namespace CS469HW3
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

        // upload image
		private void OpenImageDisplay_Click(object sender, EventArgs e)
		{

		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        // convert image to greyscale
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

        private Bitmap SobelEdgeDetectHorizontal(Bitmap original)
        {
            try {
                Bitmap og = original;
                Bitmap sobelTransformedGray = original;

                // turn into grayscale
                sobelTransformedGray = MakeGrayscale(og);
                Bitmap sobelHBitmap = new Bitmap(sobelTransformedGray.Width, sobelTransformedGray.Height);

                int[,] sobelHoriz = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                int sobel1Red = 0;
                int sobel2Red = 0;
                int sobel3Red = 0;
                int sobel1Green = 0;
                int sobel2Green = 0;
                int sobel3Green = 0;
                int sobel1Blue = 0;
                int sobel2Blue = 0;
                int sobel3Blue = 0;

                for (int i = 0; i < og.Width -1; i++)
                {
                    for (int j = 0; j < og.Height-1; j++)
                    {
                        if ((i+2 < (og.Width-1) && j+2 < (og.Height-1)) || (i + 1 < (og.Width-1) && j + 1 < (og.Height-1))) {
                            sobel1Red = (-1 * sobelTransformedGray.GetPixel(i, j).R) + (-2 * sobelTransformedGray.GetPixel(i + 1, j).R) + (-1 * sobelTransformedGray.GetPixel(i + 2, j).R);
                            sobel1Green = (-1 * sobelTransformedGray.GetPixel(i, j).G) + (-2 * sobelTransformedGray.GetPixel(i + 1, j).G) + (-1 * sobelTransformedGray.GetPixel(i + 2, j).G);
                            sobel1Blue = (-1 * sobelTransformedGray.GetPixel(i, j).B) + (-2 * sobelTransformedGray.GetPixel(i + 1, j).B) + (-1 * sobelTransformedGray.GetPixel(i + 2, j).B);

                            sobel2Red = (0 * sobelTransformedGray.GetPixel(i, j + 1).R) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 1).R);
                            sobel2Green = (0 * sobelTransformedGray.GetPixel(i, j + 1).G) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 1).G);
                            sobel2Blue = (0 * sobelTransformedGray.GetPixel(i, j + 1).B) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 1).B);

                            sobel3Red = (1 * sobelTransformedGray.GetPixel(i, j + 2).R) + (2 * sobelTransformedGray.GetPixel(i + 1, j + 2).R) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).R);
                            sobel3Green = (1 * sobelTransformedGray.GetPixel(i, j + 2).G) + (2 * sobelTransformedGray.GetPixel(i + 1, j + 2).G) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).G);
                            sobel3Blue = (1 * sobelTransformedGray.GetPixel(i, j + 2).B) + (2 * sobelTransformedGray.GetPixel(i + 1, j + 2).B) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).B);
                        }
                        
                        // calc running sum
                        int sumRed = sobel1Red + sobel2Red + sobel3Red;
                        int sumGreen = sobel1Green + sobel2Green + sobel3Green;
                        int sumBlue = sobel1Blue + sobel2Blue + sobel3Blue;


                        // threshold
                        if (sumRed <= 35 || sumBlue <= 35 || sumGreen <= 35)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            sobelHBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            sobelHBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return sobelHBitmap;

            } catch {
                throw new NotImplementedException();

            }

        }

        private Bitmap SobelEdgeDetectD1(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap sobelTransformedGray = original;

                // turn into grayscale
                sobelTransformedGray = MakeGrayscale(og);
                Bitmap sobelD1Bitmap = new Bitmap(sobelTransformedGray.Width, sobelTransformedGray.Height);

                // right matrix
                int[,] sobelDiagRight = new int[,] { { -2, -1, 0 }, { -1, 0, 1}, { 0, 1, 2 } };
                int sobel1Red = 0;
                int sobel2Red = 0;
                int sobel3Red = 0;
                int sobel1Green = 0;
                int sobel2Green = 0;
                int sobel3Green = 0;
                int sobel1Blue = 0;
                int sobel2Blue = 0;
                int sobel3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {
                            
                            sobel1Red = (-2 * sobelTransformedGray.GetPixel(i, j).R) + (-1 * sobelTransformedGray.GetPixel(i+1, j).R) + (-1 * sobelTransformedGray.GetPixel(i, j+1).R);
                            sobel1Green = (-2 * sobelTransformedGray.GetPixel(i, j).G) + (-1 * sobelTransformedGray.GetPixel(i+1, j).G) + (-1 * sobelTransformedGray.GetPixel(i, j+1).G);
                            sobel1Blue = (-2 * sobelTransformedGray.GetPixel(i, j).B) + (-1 * sobelTransformedGray.GetPixel(i+1, j).B) + (-1 * sobelTransformedGray.GetPixel(i, j+1).B);

                            sobel2Red = (0 * sobelTransformedGray.GetPixel(i+2, j).R) + (0 * sobelTransformedGray.GetPixel(i + 1, j+1).R) + (0 * sobelTransformedGray.GetPixel(i, j + 2).R);
                            sobel2Green = (0 * sobelTransformedGray.GetPixel(i+2, j).G) + (0 * sobelTransformedGray.GetPixel(i + 1, j+1).G) + (0 * sobelTransformedGray.GetPixel(i, j + 2).G);
                            sobel2Blue = (0 * sobelTransformedGray.GetPixel(i+2, j).B) + (0 * sobelTransformedGray.GetPixel(i + 1, j+1).B) + (0 * sobelTransformedGray.GetPixel(i, j + 2).B);

                            sobel3Red = (1 * sobelTransformedGray.GetPixel(i+2, j+1).R) + (1 * sobelTransformedGray.GetPixel(i+1, j +2).R) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 2).R);
                            sobel3Green = (1 * sobelTransformedGray.GetPixel(i+2, j+1).G) + (1 * sobelTransformedGray.GetPixel(i+1, j + 2).G) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 2).G);
                            sobel3Blue = (1 * sobelTransformedGray.GetPixel(i+2, j+1).B) + (1 * sobelTransformedGray.GetPixel(i+1, j + 2).B) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 2).B);
                        
                            }

                        // calc running sum
                        int sumRed = sobel1Red + sobel2Red + sobel3Red;
                        int sumGreen = sobel1Green + sobel2Green + sobel3Green;
                        int sumBlue = sobel1Blue + sobel2Blue + sobel3Blue;


                        if (sumRed <= 25 || sumBlue <= 25 || sumGreen <= 25)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            sobelD1Bitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            sobelD1Bitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return sobelD1Bitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        private Bitmap SobelEdgeDetectD2(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap sobelTransformedGray = original;

                // turn into grayscale
                sobelTransformedGray = MakeGrayscale(og);
                Bitmap sobelD2Bitmap = new Bitmap(sobelTransformedGray.Width, sobelTransformedGray.Height);

                int[,] sobelDiagLeft = new int[,] { { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } };
                int sobel1Red = 0;
                int sobel2Red = 0;
                int sobel3Red = 0;
                int sobel1Green = 0;
                int sobel2Green = 0;
                int sobel3Green = 0;
                int sobel1Blue = 0;
                int sobel2Blue = 0;
                int sobel3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {

                            sobel1Red = (-1 * sobelTransformedGray.GetPixel(i+1, j).R) + (-2 * sobelTransformedGray.GetPixel(i+2, j).R) + (-1 * sobelTransformedGray.GetPixel(i+2, j + 1).R);
                            sobel1Green = (-1 * sobelTransformedGray.GetPixel(i+1, j).G) + (-2 * sobelTransformedGray.GetPixel(i+2, j).G) + (-1 * sobelTransformedGray.GetPixel(i+2, j +1).G);
                            sobel1Blue = (-1 * sobelTransformedGray.GetPixel(i+1, j).B) + (-2 * sobelTransformedGray.GetPixel(i+2, j).B) + (-1 * sobelTransformedGray.GetPixel(i+2, j + 1).B);

                            sobel2Red = (0 * sobelTransformedGray.GetPixel(i, j).R) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 2).R);
                            sobel2Green = (0 * sobelTransformedGray.GetPixel(i, j).G) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 2).G);
                            sobel2Blue = (0 * sobelTransformedGray.GetPixel(i, j).B) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * sobelTransformedGray.GetPixel(i + 2, j + 2).B);

                            sobel3Red = (1 * sobelTransformedGray.GetPixel(i, j+1).R) + (2 * sobelTransformedGray.GetPixel(i, j + 2).R) + (1 * sobelTransformedGray.GetPixel(i + 1, j + 2).R);
                            sobel3Green = (1 * sobelTransformedGray.GetPixel(i, j+1).G) + (2 * sobelTransformedGray.GetPixel(i, j + 2).G) + (1 * sobelTransformedGray.GetPixel(i + 1, j + 2).G);
                            sobel3Blue = (1 * sobelTransformedGray.GetPixel(i, j+1).B) + (2 * sobelTransformedGray.GetPixel(i, j + 2).B) + (1 * sobelTransformedGray.GetPixel(i + 1, j + 2).B);

                        }

                        // calc running sum
                        int sumRed = sobel1Red + sobel2Red + sobel3Red;
                        int sumGreen = sobel1Green + sobel2Green + sobel3Green;
                        int sumBlue = sobel1Blue + sobel2Blue + sobel3Blue;


                        if (sumRed <= 35 || sumBlue <= 35 || sumGreen <= 35)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            sobelD2Bitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            sobelD2Bitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return sobelD2Bitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }
        private Bitmap SobelEdgeDetectVertical(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap sobelTransformedGray = original;

                // turn into grayscale
                sobelTransformedGray = MakeGrayscale(og);
                Bitmap sobelVBitmap = new Bitmap(sobelTransformedGray.Width, sobelTransformedGray.Height);

                int[,] sobelVertical = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                int sobel1Red = 0;
                int sobel2Red = 0;
                int sobel3Red = 0;
                int sobel1Green = 0;
                int sobel2Green = 0;
                int sobel3Green = 0;
                int sobel1Blue = 0;
                int sobel2Blue = 0;
                int sobel3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {

                            sobel1Red = (-1 * sobelTransformedGray.GetPixel(i, j).R) + (-2 * sobelTransformedGray.GetPixel(i, j + 1).R) + (-1 * sobelTransformedGray.GetPixel(i, j + 2).R);
                            sobel1Green = (-1 * sobelTransformedGray.GetPixel(i, j).G) + (-2 * sobelTransformedGray.GetPixel(i, j + 1).G) + (-1 * sobelTransformedGray.GetPixel(i, j + 2).G);
                            sobel1Blue = (-1 * sobelTransformedGray.GetPixel(i, j).B) + (-2 * sobelTransformedGray.GetPixel(i, j + 1).B) + (-1 * sobelTransformedGray.GetPixel(i, j + 2).B);

                            sobel2Red = (0 * sobelTransformedGray.GetPixel(i + 1, j).R) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 2).R);
                            sobel2Green = (0 * sobelTransformedGray.GetPixel(i + 1, j).G) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * sobel(0TransformedGray.GetPixel(i + 1, j + 2).G);
                            sobel2Blue = (0 * sobelTransformedGray.GetPixel(i + 1, j).B) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * sobelTransformedGray.GetPixel(i + 1, j + 2).B);

                            sobel3Red = (1 * sobelTransformedGray.GetPixel(i + 2, j).R) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 1).R) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).R);
                            sobel3Green = (1 * sobelTransformedGray.GetPixel(i + 2, j).G) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 1).G) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).G);
                            sobel3Blue = (1 * sobelTransformedGray.GetPixel(i + 2, j).B) + (2 * sobelTransformedGray.GetPixel(i + 2, j + 1).B) + (1 * sobelTransformedGray.GetPixel(i + 2, j + 2).B);

                        }

                        // calc running sum
                        int sumRed = sobel1Red + sobel2Red + sobel3Red;
                        int sumGreen = sobel1Green + sobel2Green + sobel3Green;
                        int sumBlue = sobel1Blue + sobel2Blue + sobel3Blue;


                        if (sumRed <= 35 || sumBlue <= 35 || sumGreen <= 35)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            sobelVBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            sobelVBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return sobelVBitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        private Bitmap PrewittEdgeDetectHorizontal(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap prewittTransformedGray = original;

                // turn into grayscale
                prewittTransformedGray = MakeGrayscale(og);
                Bitmap prewittHBitmap = new Bitmap(prewittTransformedGray.Width, prewittTransformedGray.Height);

                int[,] prewittHoriz = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
                int prewitt1Red = 0;
                int prewitt2Red = 0;
                int prewitt3Red = 0;
                int prewitt1Green = 0;
                int prewitt2Green = 0;
                int prewitt3Green = 0;
                int prewitt1Blue = 0;
                int prewitt2Blue = 0;
                int prewitt3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {
                            prewitt1Red = (-1 * prewittTransformedGray.GetPixel(i, j).R) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).R) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).R);
                            prewitt1Green = (-1 * prewittTransformedGray.GetPixel(i, j).G) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).G) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).G);
                            prewitt1Blue = (-1 * prewittTransformedGray.GetPixel(i, j).B) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).B) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).B);

                            prewitt2Red = (0 * prewittTransformedGray.GetPixel(i, j+1).R) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 1).R);
                            prewitt2Green = (0 * prewittTransformedGray.GetPixel(i, j+1).G) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 1).G);
                            prewitt2Blue = (0 * prewittTransformedGray.GetPixel(i, j+1).B) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 1).B);

                            prewitt3Red = (1 * prewittTransformedGray.GetPixel(i, j + 2).R) + (1 * prewittTransformedGray.GetPixel(i +1, j + 2).R) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).R);
                            prewitt3Green = (1 * prewittTransformedGray.GetPixel(i, j + 2).G) + (1 * prewittTransformedGray.GetPixel(i+1, j + 2).G) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).G);
                            prewitt3Blue = (1 * prewittTransformedGray.GetPixel(i, j + 2).B) + (1 * prewittTransformedGray.GetPixel(i+1, j + 2).B) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).B);
                        }

                        // calc running sum
                        int sumRed = prewitt1Red + prewitt2Red + prewitt3Red;
                        int sumGreen = prewitt1Green + prewitt2Green + prewitt3Green;
                        int sumBlue = prewitt1Blue + prewitt2Blue + prewitt3Blue;


                        // threshold
                        if (sumRed <= 35 || sumBlue <= 35 || sumGreen <= 35)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            prewittHBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            prewittHBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return prewittHBitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        private Bitmap PrewittEdgeDetectVertical(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap prewittTransformedGray = original;

                // turn into grayscale
                prewittTransformedGray = MakeGrayscale(og);
                Bitmap prewittVBitmap = new Bitmap(prewittTransformedGray.Width, prewittTransformedGray.Height);

                int[,] prewittVert = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                int prewitt1Red = 0;
                int prewitt2Red = 0;
                int prewitt3Red = 0;
                int prewitt1Green = 0;
                int prewitt2Green = 0;
                int prewitt3Green = 0;
                int prewitt1Blue = 0;
                int prewitt2Blue = 0;
                int prewitt3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {
                            
                            prewitt1Red = (-1 * prewittTransformedGray.GetPixel(i, j).R) + (-1 * prewittTransformedGray.GetPixel(i, j+1).R) + (-1 * prewittTransformedGray.GetPixel(i, j+2).R);
                            prewitt1Green = (-1 * prewittTransformedGray.GetPixel(i, j).G) + (-1 * prewittTransformedGray.GetPixel(i, j+1).G) + (-1 * prewittTransformedGray.GetPixel(i, j+2).G);
                            prewitt1Blue = (-1 * prewittTransformedGray.GetPixel(i, j).B) + (-1 * prewittTransformedGray.GetPixel(i, j+1).B) + (-1 * prewittTransformedGray.GetPixel(i, j+2).B);

                            prewitt2Red = (0 * prewittTransformedGray.GetPixel(i+1, j).R) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 2).R);
                            prewitt2Green = (0 * prewittTransformedGray.GetPixel(i+1, j).G) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 2).G);
                            prewitt2Blue = (0 * prewittTransformedGray.GetPixel(i+1, j).B) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 2).B);

                            prewitt3Red = (1 * prewittTransformedGray.GetPixel(i+2, j).R) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).R) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).R);
                            prewitt3Green = (1 * prewittTransformedGray.GetPixel(i+2, j).G) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).G) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).G);
                            prewitt3Blue = (1 * prewittTransformedGray.GetPixel(i+2, j).B) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).B) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).B);
                        }

                        // calc running sum
                        int sumRed = prewitt1Red + prewitt2Red + prewitt3Red;
                        int sumGreen = prewitt1Green + prewitt2Green + prewitt3Green;
                        int sumBlue = prewitt1Blue + prewitt2Blue + prewitt3Blue;

                        // threshold
                        if (sumRed <= 30 || sumBlue <= 30 || sumGreen <= 30)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            prewittVBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            prewittVBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return prewittVBitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }


        private Bitmap PrewittEdgeDetectD1(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap prewittTransformedGray = original;

                // turn into grayscale
                prewittTransformedGray = MakeGrayscale(og);
                Bitmap prewittDiagLeftBitmap = new Bitmap(prewittTransformedGray.Width, prewittTransformedGray.Height);

                int[,] prewittDiagLeft = new int[,] { { -1, -1, 0}, { -1, 0, 1 }, { 0, 1, 1 } };
                int prewitt1Red = 0;
                int prewitt2Red = 0;
                int prewitt3Red = 0;
                int prewitt1Green = 0;
                int prewitt2Green = 0;
                int prewitt3Green = 0;
                int prewitt1Blue = 0;
                int prewitt2Blue = 0;
                int prewitt3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {
                            prewitt1Red = (-1 * prewittTransformedGray.GetPixel(i + 1, j).R) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).R) + (-1 * prewittTransformedGray.GetPixel(i + 2, j + 1).R);
                            prewitt1Green = (-1 * prewittTransformedGray.GetPixel(i + 1, j).G) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).G) + (-1 * prewittTransformedGray.GetPixel(i + 2, j + 1).G);
                            prewitt1Blue = (-1 * prewittTransformedGray.GetPixel(i + 1, j).B) + (-1 * prewittTransformedGray.GetPixel(i + 2, j).B) + (-1 * prewittTransformedGray.GetPixel(i + 2, j + 1).B);

                            prewitt2Red = (0 * prewittTransformedGray.GetPixel(i, j).R) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 2).R);
                            prewitt2Green = (0 * prewittTransformedGray.GetPixel(i, j).G) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 2).G);
                            prewitt2Blue = (0 * prewittTransformedGray.GetPixel(i, j).B) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * prewittTransformedGray.GetPixel(i + 2, j + 2).B);

                            prewitt3Red = (1 * prewittTransformedGray.GetPixel(i, j + 1).R) + (1 * prewittTransformedGray.GetPixel(i, j + 2).R) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).R);
                            prewitt3Green = (1 * prewittTransformedGray.GetPixel(i, j + 1).G) + (1 * prewittTransformedGray.GetPixel(i, j + 2).G) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).G);
                            prewitt3Blue = (1 * prewittTransformedGray.GetPixel(i, j + 1).B) + (1 * prewittTransformedGray.GetPixel(i, j + 2).B) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).B);
                        }

                        // calc running sum
                        int sumRed = prewitt1Red + prewitt2Red + prewitt3Red;
                        int sumGreen = prewitt1Green + prewitt2Green + prewitt3Green;
                        int sumBlue = prewitt1Blue + prewitt2Blue + prewitt3Blue;

                        // threshold
                        if (sumRed <= 30 || sumBlue <= 30 || sumGreen <= 30)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            prewittDiagLeftBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            prewittDiagLeftBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return prewittDiagLeftBitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        private Bitmap PrewittEdgeDetectD2(Bitmap original)
        {
            try
            {
                Bitmap og = original;
                Bitmap prewittTransformedGray = original;

                // turn into grayscale
                prewittTransformedGray = MakeGrayscale(og);
                Bitmap prewittDiagRightBitmap = new Bitmap(prewittTransformedGray.Width, prewittTransformedGray.Height);

                int[,] prewittDiagRight = new int[,] { { 0, 1, 1 }, { -1, 0, 1 }, { -1, -1, 0 } };
                int prewitt1Red = 0;
                int prewitt2Red = 0;
                int prewitt3Red = 0;
                int prewitt1Green = 0;
                int prewitt2Green = 0;
                int prewitt3Green = 0;
                int prewitt1Blue = 0;
                int prewitt2Blue = 0;
                int prewitt3Blue = 0;

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {
                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1)))
                        {

                            prewitt1Red = (-1 * prewittTransformedGray.GetPixel(i, j).R) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).R) + (-1 * prewittTransformedGray.GetPixel(i, j + 1).R);
                            prewitt1Green = (-1 * prewittTransformedGray.GetPixel(i, j).G) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).G) + (-1 * prewittTransformedGray.GetPixel(i, j + 1).G);
                            prewitt1Blue = (-1 * prewittTransformedGray.GetPixel(i, j).B) + (-1 * prewittTransformedGray.GetPixel(i + 1, j).B) + (-1 * prewittTransformedGray.GetPixel(i, j + 1).B);

                            prewitt2Red = (0 * prewittTransformedGray.GetPixel(i + 2, j).R) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).R) + (0 * prewittTransformedGray.GetPixel(i, j + 2).R);
                            prewitt2Green = (0 * prewittTransformedGray.GetPixel(i + 2, j).G) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).G) + (0 * prewittTransformedGray.GetPixel(i, j + 2).G);
                            prewitt2Blue = (0 * prewittTransformedGray.GetPixel(i + 2, j).B) + (0 * prewittTransformedGray.GetPixel(i + 1, j + 1).B) + (0 * prewittTransformedGray.GetPixel(i, j + 2).B);

                            prewitt3Red = (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).R) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).R) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).R);
                            prewitt3Green = (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).G) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).G) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).G);
                            prewitt3Blue = (1 * prewittTransformedGray.GetPixel(i + 2, j + 1).B) + (1 * prewittTransformedGray.GetPixel(i + 1, j + 2).B) + (1 * prewittTransformedGray.GetPixel(i + 2, j + 2).B);
                        }

                        // calc running sum
                        int sumRed = prewitt1Red + prewitt2Red + prewitt3Red;
                        int sumGreen = prewitt1Green + prewitt2Green + prewitt3Green;
                        int sumBlue = prewitt1Blue + prewitt2Blue + prewitt3Blue;

                        // threshold
                        if (sumRed <= 30 || sumBlue <= 30 || sumGreen <= 30)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            prewittDiagRightBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            prewittDiagRightBitmap.SetPixel(i, j, Color.White);
                        }


                    }
                }

                return prewittDiagRightBitmap;

            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        private Bitmap RobertsEdgeDetectD1(Bitmap original)
        {

            try {

                // preserve orginal image and make new bitmap where we will apply robert's edge detection
                Bitmap og = original;
                Bitmap robertTransformedGray = original;

                // turn into grayscale
                robertTransformedGray = MakeGrayscale(og);
                Bitmap robertBitmap = new Bitmap(robertTransformedGray.Width, robertTransformedGray.Height);

                int[,] gx = new int[,] { { 1, 0 }, { 0, -1 } };
                int[,] gy = new int[,] { { 0, 1 }, { -1, 0 } };

                for (int i = 0; i < og.Width - 1; i++) {
                    for (int j = 0; j < og.Height - 1; j++) {

                        // calc gx red
                        int GXRed = (1 * robertTransformedGray.GetPixel(i, j).R) + (-1 * robertTransformedGray.GetPixel(i + 1, j + 1).R);
                        // calc gx green
                        int GXGreen = (1 * robertTransformedGray.GetPixel(i, j).G) + (-1 * robertTransformedGray.GetPixel(i + 1, j + 1).G);
                        // calc gx blue
                        int GXBlue = (1 * robertTransformedGray.GetPixel(i, j).B) + (-1 * robertTransformedGray.GetPixel(i + 1, j + 1).B);


                        // calc gy red
                        int GYRed = (0 * robertTransformedGray.GetPixel(i, j + 1).R) + (0() * robertTransformedGray.GetPixel(i + 1, j).R);
                        // calc gy green
                        int GYGreen = (0 * robertTransformedGray.GetPixel(i, j + 1).G) + (0 * robertTransformedGray.GetPixel(i + 1, j).G);
                        // calc gy blue
                        int GYBlue = (0 * robertTransformedGray.GetPixel(i, j + 1).B) + (0 * robertTransformedGray.GetPixel(i + 1, j).B);

                        int sumRed = GXRed + GYRed;
                        int sumGreen = GXGreen + GYGreen;
                        int sumBlue = GXBlue + GYBlue;


                        if (sumRed <= 20 || sumBlue <= 20 || sumGreen <= 20)
                        {
                            sumRed = 0;
                            sumBlue = 0;
                            sumGreen = 0;
                            robertBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumBlue = 255;
                            sumGreen = 255;
                            robertBitmap.SetPixel(i, j, Color.White);
                        }

          
                    }
                }


                return robertBitmap;

            } catch {
                throw new NotImplementedException();
            }

        }

        private Bitmap RobertsEdgeDetectD2(Bitmap original)
        {

            try
            {

                // preserve orginal image and make new bitmap where we will apply robert's edge detection
                Bitmap og = original;
                Bitmap robertTransformedGray = original;

                // turn into grayscale
                robertTransformedGray = MakeGrayscale(og);
                Bitmap robertBitmap = new Bitmap(robertTransformedGray.Width, robertTransformedGray.Height);

                int[,] gx = new int[,] { { 1, 0 }, { 0, -1 } };
                int[,] gy = new int[,] { { 0, 1 }, { -1, 0 } };

                for (int i = 0; i < og.Width - 1; i++)
                {
                    for (int j = 0; j < og.Height - 1; j++)
                    {

                        // calc gx red
                        int GXRed = (0 * robertTransformedGray.GetPixel(i, j).R) + (0 * robertTransformedGray.GetPixel(i + 1, j + 1).R);
                        // calc gx green
                        int GXGreen = (0 * robertTransformedGray.GetPixel(i, j).G) + (0 * robertTransformedGray.GetPixel(i + 1, j + 1).G);
                        // calc gx blue
                        int GXBlue = (0 * robertTransformedGray.GetPixel(i, j).B) + (0 * robertTransformedGray.GetPixel(i + 1, j + 1).B);

                        
                        // calc gy red
                        int GYRed = (-1 *robertTransformedGray.GetPixel(i, j + 1).R) + (1 * robertTransformedGray.GetPixel(i + 1, j).R);
                        // calc gy green
                        int GYGreen = (-1 * robertTransformedGray.GetPixel(i, j + 1).G) + (1 * robertTransformedGray.GetPixel(i + 1, j).G);
                        // calc gy blue
                        int GYBlue = (-1 * robertTransformedGray.GetPixel(i, j + 1).B) +(1 * robertTransformedGray.GetPixel(i + 1, j).B);

                        int sumRed = GXRed + GYRed;
                        int sumGreen = GXGreen + GYGreen;
                        int sumBlue = GXBlue + GYBlue;

                        if (sumRed <= 20 || sumBlue <= 20 || sumGreen <= 20)
                        {
                            sumRed = 0;
                            sumGreen = 0;
                            sumBlue = 0;
                            robertBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            sumRed = 255;
                            sumGreen = 255;
                            sumBlue = 255;
                            robertBitmap.SetPixel(i, j, Color.White);
                        }
   
                    }
                }


                return robertBitmap;

            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        private Bitmap LaplacianEdgeDetect(Bitmap original)
        {

            try
            {
                Bitmap og = original;
                Bitmap laplacianTransformedGray = original;

                // turn into grey to work with
                laplacianTransformedGray = MakeGrayscale(og);
                // we will be adding edges onto new bitmap
                Bitmap laplacianBitmap = new Bitmap(laplacianTransformedGray.Width, laplacianTransformedGray.Height);
                int laplaceHRed1 = 0;
                int laplaceHRed2 = 0;
                int laplaceHRed3 = 0;
                int laplaceHGreen1 = 0;
                int laplaceHGreen2 = 0;
                int laplaceHGreen3 = 0;
                int laplaceHBlue1 = 0;
                int laplaceHBlue2 = 0;
                int laplaceHBlue3 = 0;

                int laplaceVRed1 = 0;
                int laplaceVRed2 = 0;
                int laplaceVRed3 = 0;
                int laplaceVGreen1 = 0;
                int laplaceVGreen2 = 0;
                int laplaceVGreen3 = 0;
                int laplaceVBlue1 = 0;
                int laplaceVBlue2 = 0;
                int laplaceVBlue3 = 0;

                for (int i = 0; i < og.Width - 1; i++) {
                    for (int j = 0; j < og.Height - 1; j++) {


                        if ((i + 2 < (og.Width - 1) && j + 2 < (og.Height - 1))) {
                            // horizontal
                            laplaceHRed1 = ((0 * laplacianTransformedGray.GetPixel(i, j).R) + (1 * laplacianTransformedGray.GetPixel(i + 1, j).R) + (0 * laplacianTransformedGray.GetPixel(i + 2, j).R));
                            laplaceHGreen1 = ((0 * laplacianTransformedGray.GetPixel(i, j).G) + (1 * laplacianTransformedGray.GetPixel(i + 1, j).G) + (0 * laplacianTransformedGray.GetPixel(i + 2, j).G));
                            laplaceHBlue1 = ((0 * laplacianTransformedGray.GetPixel(i, j).B) + (1 * laplacianTransformedGray.GetPixel(i + 1, j).B) + (0 * laplacianTransformedGray.GetPixel(i + 2, j).B));

                            laplaceHRed2 = ((1 * laplacianTransformedGray.GetPixel(i, j + 1).R) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).R) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).R));
                            laplaceHGreen2 = ((1 * laplacianTransformedGray.GetPixel(i, j + 1).G) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).G) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).G));
                            laplaceHBlue2 = ((1 * laplacianTransformedGray.GetPixel(i, j + 1).B) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).B) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).B));

                            laplaceHRed3 = ((0 * laplacianTransformedGray.GetPixel(i, j + 2).R) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).R) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).R));
                            laplaceHGreen3 = ((0 * laplacianTransformedGray.GetPixel(i, j + 2).G) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).G) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).G));
                            laplaceHBlue3 = ((0 * laplacianTransformedGray.GetPixel(i, j + 2).B) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).B) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).B));

                            // vertical
                            laplaceVRed1 = ((0 * laplacianTransformedGray.GetPixel(i, j).R) + (1 * laplacianTransformedGray.GetPixel(i, j+1).R) + (0 * laplacianTransformedGray.GetPixel(i, j+2).R));
                            laplaceVGreen1 = ((0 * laplacianTransformedGray.GetPixel(i, j).G) + (1 * laplacianTransformedGray.GetPixel(i, j+1).G) + (0 * laplacianTransformedGray.GetPixel(i, j+2).G));
                            laplaceVBlue1 = ((0 * laplacianTransformedGray.GetPixel(i, j).B) + (1 * laplacianTransformedGray.GetPixel(i, j+1).B) + (0 * laplacianTransformedGray.GetPixel(i, j+2).B));

                            laplaceVRed2 = ((1 * laplacianTransformedGray.GetPixel(i+1, j).R) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).R) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).R));
                            laplaceVGreen2 = ((1 * laplacianTransformedGray.GetPixel(i+1, j).G) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).G) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).G));
                            laplaceVBlue2 = ((1 * laplacianTransformedGray.GetPixel(i+1, j).B) + (-4 * laplacianTransformedGray.GetPixel(i + 1, j + 1).B) + (1 * laplacianTransformedGray.GetPixel(i + 1, j + 2).B));

                            laplaceVRed3 = ((0 * laplacianTransformedGray.GetPixel(i+2, j).R) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).R) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).R));
                            laplaceVGreen3 = ((0 * laplacianTransformedGray.GetPixel(i+2, j).G) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).G) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).G));
                            laplaceVBlue3 = ((0 * laplacianTransformedGray.GetPixel(i+2, j).B) + (1 * laplacianTransformedGray.GetPixel(i + 2, j + 1).B) + (0 * laplacianTransformedGray.GetPixel(i + 2, j + 2).B));
                        }

                        // calc running sum -- horizontal direction
                        int redHSum = laplaceHRed1 + laplaceHRed2 + laplaceHRed3;
                        int greenHSum = laplaceHGreen1 + laplaceHGreen2 + laplaceHGreen3;
                        int blueHSum = laplaceHBlue1 + laplaceHBlue2 + laplaceHBlue3;

                        // calc running sum -- vertical direction
                        int redVSum = laplaceVRed1 + laplaceVRed2 + laplaceVRed3;
                        int greenVSum = laplaceVGreen1 + laplaceVGreen2 + laplaceVGreen3;
                        int blueVSum = laplaceVBlue1 + laplaceVBlue2 + laplaceVBlue3;

                        // magnitude
                        int redTotal = redHSum + redVSum;
                        int greenTotal = greenHSum + greenVSum;
                        int blueTotal = blueVSum + blueHSum;

                        // threshold
                        if (redTotal <= 25 || blueTotal <= 25 || greenTotal <= 25)
                        {
                            redHSum = 0;
                            blueHSum = 0;
                            greenHSum = 0;
                            laplacianBitmap.SetPixel(i, j, Color.Black);

                        }
                        else
                        {
                            redHSum = 255;
                            blueHSum = 255;
                            greenHSum = 255;
                            laplacianBitmap.SetPixel(i, j, Color.White);
                        }

                    }
                }

                return laplacianBitmap;

            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        private void EdgeDetectionOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
        }

		private void Confirm_Click(object sender, EventArgs e)
		{
            switch (EdgeDetectionOptions.SelectedItem.ToString()) {
                case "Prewitt (H)":
                    MessageBox.Show("You have chosen Prewitt Horizontal");
                    Form form3 = new EdgeDisplayForm();
                    Bitmap imageInstancePH = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancePH1 = new Bitmap(imageInstancePH.Width, imageInstancePH.Height);
                    if (imageInstancePH != null)
                    {
                        imageInstancePH1 = PrewittEdgeDetectHorizontal(imageInstancePH);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstancePH1.Size;
                        form3.Controls.Add(tempPict);
                        tempPict.Image = imageInstancePH1;
                        form3.Show();
                    }
                    break;
                case "Prewitt (V)":
                    MessageBox.Show("You have chosen Prewitt Vertical");
                    Form form4 = new EdgeDisplayForm();
                    Bitmap imageInstancePV = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancePV1 = new Bitmap(imageInstancePV.Width, imageInstancePV.Height);
                    if (imageInstancePV != null)
                    {
                        imageInstancePV1 = PrewittEdgeDetectVertical(imageInstancePV);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstancePV1.Size;
                        form4.Controls.Add(tempPict);
                        tempPict.Image = imageInstancePV1;
                        form4.Show();
                    }
                    break;
                case "Prewitt (D1)":
                    MessageBox.Show("You have chosen Prewitt Diagonal (Left)");
                    Form form5 = new EdgeDisplayForm();
                    Bitmap imageInstanceDiagLeft = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceDiagLeft1 = new Bitmap(imageInstanceDiagLeft.Width, imageInstanceDiagLeft.Height);
                    if (imageInstanceDiagLeft != null)
                    {
                        imageInstanceDiagLeft1 = PrewittEdgeDetectD1(imageInstanceDiagLeft);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceDiagLeft1.Size;
                        form5.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceDiagLeft1;
                        form5.Show();
                    }
                    break;
                case "Prewitt (D2)":
                    MessageBox.Show("You have chosen Prewitt Diagonal (Right)");
                    Form form12 = new EdgeDisplayForm();
                    Bitmap imageInstanceDiagRight = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceDiagRight1 = new Bitmap(imageInstanceDiagRight.Width, imageInstanceDiagRight.Height);
                    if (imageInstanceDiagRight != null)
                    {
                        imageInstanceDiagRight1 = PrewittEdgeDetectD2(imageInstanceDiagRight);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceDiagRight1.Size;
                        form12.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceDiagRight1;
                        form12.Show();
                    }
                    break;
                case "Sobel (H)":
                    MessageBox.Show("You have chosen Sobel Horizontal");
                    Form form6 = new EdgeDisplayForm();
                    Bitmap imageInstanceSH = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceSH1 = new Bitmap(imageInstanceSH.Width, imageInstanceSH.Height);
                    if (imageInstanceSH != null)
                    {
                        imageInstanceSH1 = SobelEdgeDetectHorizontal(imageInstanceSH);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceSH1.Size;
                        form6.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceSH1;
                        form6.Show();
                    }
                    break;
                case "Sobel (V)":
                    MessageBox.Show("You have chosen Sobel Vertical");
                    Form form7 = new EdgeDisplayForm();
                    Bitmap imageInstanceSV = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceSV1 = new Bitmap(imageInstanceSV.Width, imageInstanceSV.Height);
                    if (imageInstanceSV != null)
                    {
                        imageInstanceSV1 = SobelEdgeDetectVertical(imageInstanceSV);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceSV1.Size;
                        form7.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceSV1;
                        form7.Show();
                    }
                    break;
                case "Sobel (D1)":
                    MessageBox.Show("You have chosen Sobel Diagonal (Right)");
                    Form form8 = new EdgeDisplayForm();
                    Bitmap imageInstanceDRight = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceDRight1 = new Bitmap(imageInstanceDRight.Width, imageInstanceDRight.Height);
                    if (imageInstanceDRight != null)
                    {
                        imageInstanceDRight1 = SobelEdgeDetectD1(imageInstanceDRight);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceDRight1.Size;
                        form8.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceDRight1;
                        form8.Show();
                    }
                    break;
                case "Sobel (D2)":
                    MessageBox.Show("You have chosen Sobel Diagonal (Left)");
                    Form form13 = new EdgeDisplayForm();
                    Bitmap imageInstanceDLeft = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstanceDLeft1 = new Bitmap(imageInstanceDLeft.Width, imageInstanceDLeft.Height);
                    if (imageInstanceDLeft != null)
                    {
                        imageInstanceDLeft1 = SobelEdgeDetectD2(imageInstanceDLeft);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstanceDLeft1.Size;
                        form13.Controls.Add(tempPict);
                        tempPict.Image = imageInstanceDLeft1;
                        form13.Show();
                    }
                    break;
                case "Robert's (D1)":
                    MessageBox.Show("You have chosen Robert's Edge Detection (Left)");
                    Form form9 = new EdgeDisplayForm();
                    Bitmap imageInstance = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstance1 = new Bitmap(imageInstance.Width, imageInstance.Height);
                    if (imageInstance != null)
                    {
                        imageInstance1 = RobertsEdgeDetectD1(imageInstance);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstance1.Size;
                        form9.Controls.Add(tempPict);
                        tempPict.Image = imageInstance1;
                        form9.Show();
                    }
                    break;
                case "Robert's (D2)":
                    MessageBox.Show("You have chosen Robert's Edge Detection (Right)");
                    Form form11 = new EdgeDisplayForm();
                    Bitmap rd2 = (Bitmap)OpenImageDisplay.Image;
                    Bitmap rd2new = new Bitmap(rd2.Width, rd2.Height);
                    if (rd2 != null)
                    {
                        rd2new = RobertsEdgeDetectD2(rd2);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = rd2new.Size;
                        form11.Controls.Add(tempPict);
                        tempPict.Image = rd2new;
                        form11.Show();
                    }
                    break;
                case "Laplacian":
                    MessageBox.Show("You have chosen Laplacian Edge Detection");
                    Form form10 = new EdgeDisplayForm();
                    Bitmap lap = (Bitmap)OpenImageDisplay.Image;
                    Bitmap lap1 = new Bitmap(lap.Width, lap.Height);
                    if (lap != null)
                    {
                        lap1 = LaplacianEdgeDetect(lap);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = lap1.Size;
                        form10.Controls.Add(tempPict);
                        tempPict.Image = lap1;
                        form10.Show();
                    }
                    break;

            }
		}
	}
}
