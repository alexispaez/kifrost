using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KLaunch.Scripts
{
    public interface Script
    {
        void Run(int hWnd, KConnection connection, KConnection destination, Form parent);
        bool TakesDestination();
        string GetNotes();
    }
}
