using KLaunch.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLaunch
{
    // Actions can be either a shortcut to be added to the KConnectio n string
    // or a script that can be executed after launching the KClient
    public class Action
    {
        public string Name { get; }
        public string Shortcut { get; }
        public Script Script { get; }
        public bool CvsOnly { get; }

        public Action(string name, string shortcut = null, Script script = null, bool cvsOnly = false)
        {
            this.Name = name;
            this.Shortcut = shortcut;
            this.Script = script;
            this.CvsOnly = cvsOnly;
        }

        public override string ToString()
        {
            return Name + (Shortcut != null ? " (shortcut)" : "") + (Script != null ? " (script)" : "");
        }
    }
}
