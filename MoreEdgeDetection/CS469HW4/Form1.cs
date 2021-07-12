/*
 * Kristine Monsada
 * CS 469 HW 4
 * Dr. Yfantis
 * Description: Compute canny edge detection algorithm
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CS469HW4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
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

        private static Bitmap ConvolutionFilter(Bitmap sourceBitmap, double[,] filterMatrix, double factor = 1,int bias = 0, bool grayscale = false)
        {
            try {
                BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                byte[] extractPix = new byte[sourceData.Stride * sourceData.Height];
                byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

                Marshal.Copy(sourceData.Scan0, extractPix, 0, extractPix.Length);

                sourceBitmap.UnlockBits(sourceData);
                Bitmap smoothenedImage = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
                int length = extractPix.Length;

                // convert each byte of the bitmap into grayscale
                if (grayscale == true)
                {
                    float convertToGray = 0;
                    for (int k = 0; k < length; k += 4)
                    {
                        convertToGray = extractPix[k] * 0.11f;
                        convertToGray += extractPix[k + 1] * 0.59f;
                        convertToGray += extractPix[k + 2] * 0.3f;


                        extractPix[k] = (byte)convertToGray;
                        extractPix[k + 1] = extractPix[k];
                        extractPix[k + 2] = extractPix[k];
                        extractPix[k + 3] = 255;
                    }
                }


                double blue = 0.0, green = 0.0, red = 0.0;

                // 5x5 guassian filter mask
                int filterWidth = filterMatrix.GetLength(1);
                int filterHeight = filterMatrix.GetLength(0);

                int filterOffset = (filterWidth - 1) / 2;
                int calcOffset = 0, byteOffset = 0;

                // iterate thru image
                for (int i = filterOffset; i < sourceBitmap.Height - filterOffset; i++)
                {
                    for (int j = filterOffset; j < sourceBitmap.Width - filterOffset; j++)
                    {
                        blue = 0;
                        green = 0;
                        red = 0;

                        byteOffset = i * sourceData.Stride + j * 4;

                        // from the 5x5 start multiplying for those rgb values
                        for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                            {

                                calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                                blue += (double)(extractPix[calcOffset]) * filterMatrix[filterY + filterOffset, filterX + filterOffset];


                                green += (double)(extractPix[calcOffset + 1]) * filterMatrix[filterY + filterOffset, filterX + filterOffset];


                                red += (double)(extractPix[calcOffset + 2]) * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                            }
                        }

                        // divide it all by 273 to get correct values for rbg smoothening
                        blue = (factor * blue + bias) / 273;
                        green = (factor * green + bias) / 273;
                        red = (factor * red + bias) / 273;

                        // rgb ranges of intensity
                        // if value goes over 255, set to 225
                        // if value is under 0, set to 0
                        if (blue > 255)
                        { blue = 255; }
                        else if (blue < 0)
                        { blue = 0; }

                        if (green > 255)
                        { green = 255; }
                        else if (green < 0)
                        { green = 0; }


                        if (red > 255)
                        { red = 255; }
                        else if (red < 0)
                        { red = 0; }

                        // add color into the result byte matrix
                        resultBuffer[byteOffset] = (byte)(blue);
                        resultBuffer[byteOffset + 1] = (byte)(green);
                        resultBuffer[byteOffset + 2] = (byte)(red);
                        resultBuffer[byteOffset + 3] = 255;
                    }
                }

                // newly made bitmap attribute data
                // used to construct the image
                BitmapData resultData = smoothenedImage.LockBits(new Rectangle(0, 0, smoothenedImage.Width, smoothenedImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
                smoothenedImage.UnlockBits(resultData);

                return smoothenedImage;

            } catch {
                // otherwise shoot error
                throw new NotImplementedException();
            }
        }

        public Bitmap smootheningMask(Bitmap sourceBitmap)
        {
            double[,] gaussianFilter = new double[,]  {
                 { 1, 4, 7, 4, 1 },
                 { 4, 16, 26, 16, 4 },
                 { 7, 26, 41, 26, 7 },
                 { 4, 16, 26, 16, 4 },
                 { 1, 4, 7, 4, 1 },
                };
            bool grayscale = true;

            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap, gaussianFilter, 1.0, 0, grayscale);

            
            return resultBitmap;
        }

        private Bitmap MakeCanny(Bitmap original)
        {
            try
            {

                Bitmap og = original;
                Bitmap maskedImage = original;
                Bitmap transformedCanny = new Bitmap(og.Width, og.Height);

                // apply the smoothening filter
                maskedImage = smootheningMask(og);
                int width = maskedImage.Width;
                int height = maskedImage.Height;

                // get new bitmap to all black first
                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        transformedCanny.SetPixel(i, j, Color.Black);
                    }
                }

                // to get every pixel of smoothend image
                int[,] smoothedx = new int[width, height];
                int[,] smoothedy = new int[width, height];
                int[,] smoothedmanhattan = new int[width, height];

                // iter thru image first to get everything
                for (int x = 1; x < width - 1; x++) {
                    for (int y = 1; y < height - 1; y++) {
                        Color beforeColorx = maskedImage.GetPixel(x - 1, y);
                        Color afterColorx = maskedImage.GetPixel(x + 1, y);
                        Color beforeColory = maskedImage.GetPixel(x, y - 1);
                        Color afterColory = maskedImage.GetPixel(x, y + 1);

                        // cuz all grayscale just get one
                        smoothedx[x,y] = Math.Abs((beforeColorx.B - afterColorx.B) / 2);
                        smoothedy[x,y] = Math.Abs((beforeColory.B - afterColory.B) / 2);

                        smoothedmanhattan[x, y] = (Math.Abs((beforeColorx.B - afterColorx.B) / 2)) + (Math.Abs((beforeColory.B - afterColory.B) / 2));
                    }
                }

                // using the circle, find phase angle from conditions using dy and dx part
                // use manhattan distance when determining if edge or not
                for (int i = 1; i < width - 1; i++) {
                    for (int j = 1; j < height - 1; j++) {

                        // 0 degrees
                        if ((smoothedx[i, j] > smoothedy[i, j]) && (smoothedx[i, j] > 0) && (smoothedy[i, j] > 0)) {
                            // u/d
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i-1, j]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i+1, j]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }


                        }
                        // 45 degrees
                        if ((smoothedy[i, j] > smoothedx[i, j]) && (smoothedx[i, j] > 0) && (smoothedy[i, j] > 0))
                        {
                            // diag
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i-1, j - 1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i+1, j + 1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }

                        }
                        // 90 degrees
                        if ((smoothedy[i, j] > smoothedx[i, j]) && (smoothedx[i, j] < 0) && (smoothedy[i, j] > 0))
                        {
                            // u/d
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i, j+1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i, j-1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }

                        }
                        // 135 degrees
                        if ((smoothedx[i, j] > smoothedy[i, j]) && (smoothedx[i, j] < 0) && (smoothedy[i, j] > 0))
                        {
                            // diag
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i +1, j-1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i - 1, j+1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }

                     

                        }
                        // 180 degrees
                        if ((smoothedx[i, j] > smoothedy[i, j]) && (smoothedx[i, j] < 0) && (smoothedy[i, j] < 0))
                        {
                            // l/r
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i+1, j]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i-1, j]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }


                        }
                        // 225 degrees
                        if ((smoothedy[i, j] > smoothedx[i, j]) && (smoothedx[i, j] < 0) && (smoothedy[i, j] < 0))
                        {
                            // diag
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i + 1, j + 1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i -1, j - 1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }


                        }
                        // 270 degrees
                        if ((smoothedy[i, j] > smoothedx[i, j]) && (smoothedx[i, j] > 0) && (smoothedy[i, j] < 0))
                        {
                            // u/d
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i, j+1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i, j-1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }


                        }
                        // 315 degrees
                        if ((smoothedx[i, j] > smoothedy[i, j]) && (smoothedx[i, j] > 0) && (smoothedy[i, j] < 0))
                        {
                            // diag
                            if ((smoothedmanhattan[i, j] > smoothedmanhattan[i + 1, j - 1]) && (smoothedmanhattan[i, j] > smoothedmanhattan[i - 1, j + 1]))
                            {
                                transformedCanny.SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                transformedCanny.SetPixel(i, j, Color.Black);
                            }


                        }

                        // get rid of extra noise -- hysteresis
                        // double thresholding
                        if (smoothedmanhattan[i, j] < 15)
                        {
                            transformedCanny.SetPixel(i, j, Color.Black);
                        }
                        else if (smoothedmanhattan[i, j] > 35)
                        {
                            transformedCanny.SetPixel(i, j, Color.White);
                        }

                    }
                }
                return transformedCanny;

            }
            catch
            {
                // otherwise shoot error
                throw new NotImplementedException();
            }

        }

        private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        private void Confirm_Click(object sender, EventArgs e)
		{
            switch (OptionSelect.SelectedItem.ToString()) {
                case "Grayscale":
                    Form form3 = new ImageDisplayForm();
                    Bitmap imageInstancegray = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancegray1 = new Bitmap(imageInstancegray.Width, imageInstancegray.Height);
                    if (imageInstancegray != null)
                    {
                        imageInstancegray1 = MakeGrayscale(imageInstancegray);
                        PictureBox tempPict = new PictureBox();
                        tempPict.Size = imageInstancegray1.Size;
                        form3.AutoSize = true;
                        form3.Controls.Add(tempPict);
                        tempPict.Image = imageInstancegray1;
                        form3.Show();
                    }
                    break;
                case "Fit Image":
                    Form form4 = new ImageDisplayForm();
                    Bitmap imageInstancefit = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancefit1 = new Bitmap(imageInstancefit.Width, imageInstancefit.Height);
                    if (imageInstancefit != null)
                    {
                        imageInstancefit1 = imageInstancefit;
                        PictureBox tempPict = new PictureBox();
                        tempPict.SizeMode = PictureBoxSizeMode.AutoSize;
                        tempPict.Size = imageInstancefit1.Size;
                        form4.AutoSize = true;
                        form4.Controls.Add(tempPict);
                        tempPict.Image = imageInstancefit1;
                        form4.Show();
                    }
                    break;
                case "Smoothed":
                    Form form5 = new ImageDisplayForm();
                    Bitmap imageInstancesmooth = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancesmooth1 = new Bitmap(imageInstancesmooth.Width, imageInstancesmooth.Height);
                    if (imageInstancesmooth != null)
                    {
                        imageInstancesmooth1 = smootheningMask(imageInstancesmooth);
                        PictureBox tempPict = new PictureBox();
                        tempPict.SizeMode = PictureBoxSizeMode.AutoSize;
                        tempPict.Size = imageInstancesmooth1.Size;
                        form5.AutoSize = true;
                        form5.Controls.Add(tempPict);
                        tempPict.Image = imageInstancesmooth1;
                        form5.Show();
                    }
                    break;
                case "Canny Edge Detection":
                    Form form6 = new ImageDisplayForm();
                    Bitmap imageInstancecanny = (Bitmap)OpenImageDisplay.Image;
                    Bitmap imageInstancecanny1 = new Bitmap(imageInstancecanny.Width, imageInstancecanny.Height);
                    if (imageInstancecanny != null)
                    {
                        imageInstancecanny1 = MakeCanny(imageInstancecanny);
                        PictureBox tempPict = new PictureBox();
                        tempPict.SizeMode = PictureBoxSizeMode.AutoSize;
                        tempPict.Size = imageInstancecanny1.Size;
                        form6.AutoSize = true;
                        form6.Controls.Add(tempPict);
                        tempPict.Image = imageInstancecanny1;
                        form6.Show();
                    }
                    break;
            }

        }
	}
}
