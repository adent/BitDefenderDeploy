using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace BitDefenderDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("C:\\bddeploy");
            
            WebClient webClient = new WebClient();
            webClient.DownloadFile(args[0], @"C:\\bddeploy\\bd.exe");
            string pattern = @".*?/(setupdownloader.*?)$";
            string input = args[0];
            Match m = Regex.Match(input, pattern);
            string filename = m.Groups[1].Value;
            File.Copy("C:\\bddeploy\\bd.exe", $"C:\\bddeploy\\{filename}");
            File.Delete("C:\\bddeploy\\bd.exe");            

            ProcessStartInfo processInfo = new ProcessStartInfo();
            
            processInfo.FileName = $"C:\\bddeploy\\{filename}";
            processInfo.Arguments = "/bdparams /silent silent";
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = false;
            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();
            process.WaitForInputIdle();

            File.Delete($"C:\\bddeploy\\{filename}");
            Directory.Delete("C:\\bddeploy");
        }
    }
}
