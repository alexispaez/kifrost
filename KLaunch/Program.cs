/*
 * Created by SharpDevelop.
 * User: paezj
 * Date: 15/07/2018
 * Time: 19:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace KLaunch
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			bool createdNew = true;
			using (Mutex mutex = new Mutex(true, "KiFrost", out createdNew))
			{
				if (createdNew)
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new MainForm());
				}
				else
				{
					Process current = Process.GetCurrentProcess();
					foreach (Process process in Process.GetProcessesByName(current.ProcessName))
					{
						if (process.Id != current.Id)
						{
							WinApi.SetForegroundWindow((int)process.MainWindowHandle);
							WinApi.ShowWindow((int)process.MainWindowHandle, WinApi.SW_SHOW);
							break;
						}
					}
				}
			}
		}
		
	}
}
