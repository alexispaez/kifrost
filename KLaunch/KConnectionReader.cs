﻿using System;
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
        public static void LoadConnections(List<KConnection> connections, string connectionsFilePath, int retries = 5) {
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
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3],
                    parts[4],
                    parts[5],
                    parts[6],
                    parts[7],
                    parts[8],
                    (parts[9] == "Y" ? true : false),
                    parts[10],
                    parts[11], //Nacho, Icono
                    parts[12] )); //Nacho, TLS Encryption
            }

            //close the file
            sr.Close();
    }
 }
    class KConnectionSaver
    {
        // ToDo Save connection as CSV
    }
}
