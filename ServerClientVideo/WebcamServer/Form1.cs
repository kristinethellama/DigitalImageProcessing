using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using Accord.Video.VFW;

namespace WebcamServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public const string ServerFunctionsDLL = @"..\..\..\Debug\ServerFunctions.dll";

		[DllImport(ServerFunctionsDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int startServer();

		[DllImport(ServerFunctionsDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int closeServer();

		public static class ImportTest
		{
			[DllImport(ServerFunctionsDLL, EntryPoint = "testString2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.LPStr)]
			public static extern void testString2();
		}

		[DllImport(ServerFunctionsDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void sendingStuff();
		

		private FilterInfoCollection filterInfoCollection;
		private VideoCaptureDevice finalVideo = null;
		private VideoCaptureDeviceForm captureDevice;
		private Bitmap vid;
		private VideoFileWriter FileWriter = new VideoFileWriter();
		private SaveFileDialog saveAvi;

		private void exitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (FilterInfo filterInfo in filterInfoCollection)
				cboCamera.Items.Add(filterInfo.Name);
			cboCamera.SelectedIndex = 0;
			finalVideo = new VideoCaptureDevice();
			captureDevice = new VideoCaptureDeviceForm();
		}

		private void StartCam_Click(object sender, EventArgs e)
		{
			// make folder called temp
			string folderName = @"c:\temp";
			// If directory does not exist, create it. 
			if (!Directory.Exists(folderName))
			{
				// creates the folder in c drive
				System.IO.Directory.CreateDirectory(folderName);
			}

			if (captureDevice.ShowDialog(this) == DialogResult.OK) {
				finalVideo = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
				finalVideo = captureDevice.VideoDevice;
				finalVideo.NewFrame += VideoCaptureDevice_NewFrame;
				finalVideo.Start();
			}

		}

		private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			if (stopCam.Text == "Stop Record")
			{
				// copy each frame from the recordings into a bitmap
				vid = (Bitmap)eventArgs.Frame.Clone();
				// same goes for as image
				pic.Image = (Bitmap)eventArgs.Frame.Clone();
				// write to video bc all done
				FileWriter.WriteVideoFrame(vid);
			}
			else
			{
				// keep on coppying the frames
				vid = (Bitmap)eventArgs.Frame.Clone();
				pic.Image = (Bitmap)eventArgs.Frame.Clone();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (finalVideo == null)
			{ return; }
			if (finalVideo.IsRunning)
			{
				this.finalVideo.Stop();
				FileWriter.Close();
				//this.AVIwriter.Close();
			}
		}

		private void dllTest_Click(object sender, EventArgs e)
		{
			startServer();
			string ipaddy = GetLocalIPAddress();
			ipBox.Text = ipaddy;
		}

		private void stopCam_Click(object sender, EventArgs e)
		{
			if (stopCam.Text == "Stop Record")
			{
				stopCam.Text = "Stopping Recording.....";
				if (finalVideo == null)
				{ return; }
				if (finalVideo.IsRunning)
				{
					//this.FinalVideo.Stop();
					FileWriter.Close();
					//this.AVIwriter.Close();
					pic.Image = null;
				}
			}
			else
			{
				this.finalVideo.Stop();
				FileWriter.Close();
				//this.AVIwriter.Close();
				pic.Image = null;
			}
		}

		// now changed to close server hshgkjsghkj
		private void selectFilesButton_Click(object sender, EventArgs e)
		{
			closeServer();	
		}

		// actually changed to save video
		private void zippytime_Click(object sender, EventArgs e)
		{

			// the audiofile we are specifying
			var sourceFile = @"c:\\record.avi";
			var pathname = @"c:\\temp\\record.avi";

			// automatically delete the recording if it exists already so it doesn't bug out
			if (File.Exists(@"c:\\temp\\record.avi"))
			{
				File.Delete(@"c:\\temp\\record.avi");
			}

			string folderName = @"c:\test";
			
			// creates the folder in c drive
			System.IO.Directory.CreateDirectory(folderName);

			// the audiofile we are specifying
			string fileName = "record.avi";

			// now to combine it so it is all in one path and doesn't get lost
			folderName = System.IO.Path.Combine(folderName, fileName);

			Console.WriteLine("Path to my file: {0}\n", folderName);

			// the file doesn't exist, create it and write to audio wav file
			if (!System.IO.File.Exists(folderName))
			{
				//saveAvi = new SaveFileDialog();
				//saveAvi.Filter = "Avi Files (*.avi)|*.avi";
				//if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				//{
				int h = captureDevice.VideoDevice.VideoResolution.FrameSize.Height;
				int w = captureDevice.VideoDevice.VideoResolution.FrameSize.Width;
				//saveAvi.FileName = "record.avi";
				// replaced saveAvi.fileName --> fileName;
				FileWriter.Open(pathname, w, h, 25, VideoCodec.Default, 5000000);
				//System.IO.File.Copy(sourceFile, saveAvi.FileName);
				FileWriter.WriteVideoFrame(vid);

				//AVIwriter.Open(saveAvi.FileName, w, h);
				stopCam.Text = "Stop Record";
				//FinalVideo = captureDevice.VideoDevice;
				//FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
				//FinalVideo.Start();
				//}
			}
			else
			{
				System.IO.File.Copy(pathname, fileName);
			}
		}

		private void serverSend_Click(object sender, EventArgs e)
		{
			sendingStuff();
		}
	}
}
