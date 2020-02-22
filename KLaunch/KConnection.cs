using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLaunch
{
    public class KConnection
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Host { get; set; }
        public string Service { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Home { get; set; }
        public bool CvsSystem { get; set; }
        public string Notes { get; set; }
        public string IconR { get; set; } //Nacho

        public KConnection(string country, string name, string path, string host, string service, string port, string user, string password, string home, bool cvsSystem, string notes, string IconR)
            // Nacho added Icon
        {
            this.Country = country;
            this.Name = name;
            this.Path = path;
            this.Host = host;
            this.Service = service;
            this.Port = port;
            this.User = user;
            this.Password = password;
            this.Home = home;
            this.CvsSystem = cvsSystem;
            this.Notes = notes;
            this.IconR = IconR;
        }

        public string GetNotes()
        {
            return Notes;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}   ({2}:{3})", Country, Name, Host, Port);
        }
    }
}
