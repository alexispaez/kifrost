using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KLaunch
{
    class KConnectionReader
    {
        public static void LoadConnections(List<KConnection> connections, string connectionsFilePath, int retries = 5) {
            String line;
            // Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(connectionsFilePath);

            connections.Clear();

            // Read the file header, split it and check its length
            line = sr.ReadLine();
            string[] parts = line.Split(';');
            int length = parts.Length;
            if (length != 11)
            {
                MessageBox.Show("The connections file header does not have 11 fields, please check it and try again afterwards.");
            }
            else
            {
                // Continue to read until you reach end of file
                while ((line = sr.ReadLine()) != null)
                {
                    // Parse the line
                    parts = line.Split(';');
                    length = parts.Length;
                    if (length != 11)
                    {
                        MessageBox.Show("The connections file has at least one record that does not have 11 fields per line, please check it and try again afterwards.");
                        break;
                    }
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
                        parts[10]));
                }
            }

            // Close the file
            sr.Close();
        }
    }
}
