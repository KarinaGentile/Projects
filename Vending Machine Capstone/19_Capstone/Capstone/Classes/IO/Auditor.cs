using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone;

namespace Capstone
{
    public static class Auditor
    {
        public static void Audit(string message)
        {
            using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + "\\Log.txt"))
            {
                sw.WriteLine($"{DateTime.Now.ToString("G")} {message}");
            }
        }
    }
}