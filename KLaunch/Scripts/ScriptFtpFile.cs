using KLaunch.Scripts;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace KLaunch
{
    class ScriptFtpFile : Script
    {
        public string GetNotes()
        {
            return "Get a file through FTP";
        }

        public static int Get16BitHash(string s)
        {
            int hashValue = s.GetHashCode();
            return s.GetHashCode();
        }

        public void Run(int hWnd, KConnection connection, KConnection destination, Form parent)
        {
            //int hash = Get16BitHash("26/10/18");

            StringBuilder result = new StringBuilder();

            // Get the object used to communicate with the server.
            FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create("ftp://172.31.49.13/");
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;

            // This example assumes the FTP site uses anonymous logon.
            requestDir.Credentials = new NetworkCredential("kccjapt", "kccjapt123");
            FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
             
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string line = reader.ReadLine();
            while (line != null)
            {
                result.Append(line);
                result.Append("\n");
                line = reader.ReadLine();
            }

            // Get the object used to communicate with the server.
            FtpWebRequest requestFile = (FtpWebRequest)WebRequest.Create("ftp://172.31.49.13/%2fuser1/RMD/R9304EHAC/work/ScriptFileName.txt");
            requestFile.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            requestFile.Credentials = new NetworkCredential("kccjapt", "kccjapt123");
            FtpWebResponse responseFile = (FtpWebResponse)requestFile.GetResponse();

            Stream responseStreamFile = responseFile.GetResponseStream();
            StreamReader readerFile = new StreamReader(responseStreamFile);

            line = readerFile.ReadLine();
            if (line != null)
            {
                string test = line.Substring(1);
                StringCollection result2 = new StringCollection();

                FtpWebRequest requestFile2 = (FtpWebRequest)WebRequest.Create("ftp://172.31.49.13/%2f" + line.Substring(1));
                requestFile2.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                requestFile2.Credentials = new NetworkCredential("kccjapt", "kccjapt123");
                FtpWebResponse responseFile2 = (FtpWebResponse)requestFile2.GetResponse();

                Stream responseStreamFile2 = responseFile2.GetResponseStream();
                StreamReader readerFile2 = new StreamReader(responseStreamFile2);

                line = readerFile2.ReadLine();
                while (line != null)
                {
                    result2.Add(line);
                    line = readerFile2.ReadLine();
                }

                readerFile2.Close();

                int firstIndex = result2.IndexOf("CLEAR P");
                int lastIndex = 0;

                foreach(string s in result2)
                {
                    if (s.Contains("SAVE <G>"))
                        lastIndex = result2.IndexOf(s);
                }

                for(int index = firstIndex; index <= lastIndex ; index++)
                {
                    string lineCommand = result2[index];
                }
            }
            
            readerFile.Close();
            reader.Close();
            response.Close();
        }

        public bool TakesDestination()
        {
            return false;
        }
    }
}
