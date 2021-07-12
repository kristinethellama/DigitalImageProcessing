/*
 * Kristine Monsada  
 * 2001381858
 * CS 469 Digital Image Processing
 * Description: Create waves through a wav file
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace CS469HW6V2
{
	public partial class Form1 : Form
	{
		// windows audio
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string command, StringBuilder restring, int Returnlength, IntPtr callback);
		public Form1()
		{
			// we're gonna be making audio so init this
			InitializeComponent();
			mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
			button1.Click += new EventHandler(this.button1click);
		}

		private void button1click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			string cmd = "set recsound time format ms";
			// record the voice in 2 bytes per sec
			cmd += " bitspersample 16";
			cmd += " channels 1";
			cmd += " samplespersec 16000";
			cmd += " bytespersec 265000";
			cmd += " alignment 2";
			mciSendString("record recsound", null, 0, IntPtr.Zero);
			button2.Click += new EventHandler(this.button2click);
		}

		// ignore
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// saves audio recording to folder test/subfolder/record.wav and stops
		// will create a folder for the audio if not created already
		private void button2click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			// THE AUDIO NEEDS TO BE SAVED IN A FOLDER CALLED "test"
			string folderName = @"c:\test";
			// adding a subfolder
			string pathString = System.IO.Path.Combine(folderName, "SubFolder");

			string pathString2 = @"c:\test\SubFolder2";

			// creates the folder in c drive
			System.IO.Directory.CreateDirectory(pathString);

			// the audiofile we are specifying
			string fileName = "record.wav";

			// now to combine it so it is all in one path and doesn't get lost
			pathString = System.IO.Path.Combine(pathString, fileName);

			Console.WriteLine("Path to my file: {0}\n", pathString);

			// the file doesn't exist, create it and write to audio wav file
			if (!System.IO.File.Exists(pathString))
			{
				// writes into the audio file and saves
				Console.WriteLine("Creating \"{0}\".", fileName);
				mciSendString("save recsound c:\\test\\SubFolder\\record.wav", null, 0, IntPtr.Zero);
				mciSendString("close recsound", null, 0, IntPtr.Zero);
			}
			else
			{
				// either way we are overwriting into the audiofile
				mciSendString("save recsound c:\\test\\SubFolder\\record.wav", null, 0, IntPtr.Zero);
				Console.WriteLine("File \"{0}\" already exists.", fileName);
				mciSendString("close recsound", null, 0, IntPtr.Zero);
				return;
			}
			//button4.Click += new EventHandler(this.button4click);
		}

		// play audio recording
		private void button4click(object sender, EventArgs e)
		{
			// reopen our last saved file, play, and close it
			mciSendString("open c:\\test\\SubFolder\\record.wav alias playFile", null, 0, IntPtr.Zero);
			mciSendString("play playFile wait", null, 0, IntPtr.Zero);
			mciSendString("close playFile", null, 0, IntPtr.Zero);
		}

		// ignore
		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// so it plays the new overwritten file :)
		private void button4_Click(object sender, EventArgs e)
		{
			button4.Click += new EventHandler(this.button4click);
		}

		static bool readWav(out float[] L, out float[] R)
		{
			L = R = null;
			String location = "c:\\test\\SubFolder\\record.wav";

			try
			{
				using (FileStream fs = File.Open(location, FileMode.Open))
				{
					BinaryReader waveReader = new BinaryReader(fs);

					// parse through every piece of wav file
					int chunkID = waveReader.ReadInt32();
					int fileSize = waveReader.ReadInt32();
					int riffType = waveReader.ReadInt32();
					int fmtID = waveReader.ReadInt32();
					int fmtSize = waveReader.ReadInt32();
					int fmtCode = waveReader.ReadInt16();
					int channels = waveReader.ReadInt16();
					int sampleRate = waveReader.ReadInt32();
					int byteRate = waveReader.ReadInt32();
					int fmtBlockAlign = waveReader.ReadInt16();
					int bitDepth = waveReader.ReadInt16();

					// if formatSize is size of 18
					if (fmtSize == 18)
					{
						// Read any extra values
						int fmtExtraSize = waveReader.ReadInt16();
						waveReader.ReadBytes(fmtExtraSize);
					}

					int dataID = waveReader.ReadInt32();
					int bytes = waveReader.ReadInt32();

					// read data in byte array
					byte[] byteArray = waveReader.ReadBytes(bytes);

					int bytesForSamp = bitDepth / 8;
					int nValues = bytes / bytesForSamp;

					float[] asFloat = null;

					// 16 bits bc altered!
					Int16[] asInt16 = new Int16[nValues];
					Buffer.BlockCopy(byteArray, 0, asInt16, 0, bytes);
					asFloat = Array.ConvertAll(asInt16, e => e / (float)(Int16.MaxValue + 1));

					switch (channels)
					{
						case 1:
							L = asFloat;
							R = null;
							return true;
						case 2:
							// de-interleave
							int nSamps = nValues / 2;
							L = new float[nSamps];
							R = new float[nSamps];
							for (int s = 0, v = 0; s < nSamps; s++)
							{
								L[s] = asFloat[v++];
								R[s] = asFloat[v++];
							}
							return true;
						default:
							return false;
					}
				}
			}
			catch
			{
				MessageBox.Show("...Failed to load: " + location);
				throw new NotImplementedException();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Making waves...");

			soundWaves.Series.Clear();
			String location = "c:\\test\\SubFolder\\record.wav";
			Byte[] waveData = File.ReadAllBytes(location);
			int sample = ((waveData[43] << 24) | (waveData[42] << 16) | (waveData[41] << 8) | waveData[40]) / 2;
			sample /= 2;

			float[] leftChannel = new float[sample];
			float[] rightChannel = new float[sample];

			// function to read the wav file
			readWav(out leftChannel, out rightChannel);

			var plottime = new Series("Series 1");

			// plot time hehe
			for (int i = 0; i < sample; i++)
			{
				plottime.Points.AddXY(i, leftChannel[i]);
			}

			// set line type
			plottime.ChartType = SeriesChartType.Line;

			soundWaves.Series.Add(plottime);

			MessageBox.Show("Your audio is now created as a wave");

		}
		
	}
}


