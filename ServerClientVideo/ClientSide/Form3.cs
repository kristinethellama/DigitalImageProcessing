using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace ClientSide
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		private OpenFileDialog openFileDialog1;

		public const string ServerFunctionsDLL = @"..\..\..\Debug\ServerFunctions.dll";
		[DllImport(ServerFunctionsDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int startClient();

		public static class ImportTest
		{
			[DllImport(ServerFunctionsDLL, EntryPoint = "testString2", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.LPStr)]
			public static extern void testString2();
		}

		[DllImport(ServerFunctionsDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int stopClient();


		private void Form3_Load(object sender, EventArgs e)
		{

		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// open video from server
		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void ClientButton_Click(object sender, EventArgs e)
		{
			startClient();
		}

		private void recievejunk_Click(object sender, EventArgs e)
		{
			// automatically delete the recording if it exists already so it doesn't bug out
			if (File.Exists(@"c:\\temp\\result.avi"))
			{
				File.Delete(@"c:\\temp\\result.avi");
			}

			ImportTest.testString2();	
		}

		// this is to display :P
		private void button1_Click_1(object sender, EventArgs e)
		{
			openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
		
			openFileDialog1.ShowDialog();

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//this.pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
				string filePath = openFileDialog1.FileName;
				MessageBox.Show("Path of video: " + filePath);
				Process.Start(filePath);
			}
		}

		private void closeClient_Click(object sender, EventArgs e)
		{
			stopClient();
		}

	}
}
