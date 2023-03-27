using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KLaunch
{
    class KConnectionReader
    {
        public static void LoadConnections(List<KConnection> connections, string connectionsFilePath, int retries = 5)
		{
            String line;
            bool Nothing;
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(connectionsFilePath);

            connections.Clear();

            // Read the file header
            sr.ReadLine();

            //Continue to read until you reach end of file
            while ((line = sr.ReadLine()) != null)
            {
                // Parse the line
                string[] parts = line.Split(';');
                connections.Add(new KConnection(
                    parts[0], // Country
                    parts[1], // Name
                    parts[2], // Path to Kclient
                    parts[3], // Host
                    parts[4], // (KCML) Service
                    parts[5], // Port
                    parts[6], // User
                    parts[7], // Password
                    parts[8], // Home
                    (parts[9] == "Y" ? true : false), // CVS system?
                    parts[10], // Notes
                    parts[11], // Icon
                    parts[12] )); // TLS Encryption
            }

            //close the file
            sr.Close();
		}
	}
    class KConnectionSaver
    {
		public static void SaveConnnections(List<KConnection> connections, string connectionsFilePath)
		{
			FileStream objWrite = null;
			objWrite = new FileStream(connectionsFilePath, FileMode.Append);

			string sTempString = "KConnection.Country + KConnection.Name + KConnection.Path + KConnection.Host + KConnection.Service + KConnection.Port";
			sTempString += "KConnection.User + KConnection.Password + KConnection.Home + ";
			// (KConnection.CvsSystem == true && "Y" || "N") + " " + KConnection.IconR + (KConnection.TLSBox == true && "Y" || "N")";
			using (StreamWriter src = new StreamWriter(objWrite))
			{
				src.WriteLine(sTempString);
			}
			//src.close()
			if (objWrite != null)
				objWrite.Dispose();
		}
    }
}
