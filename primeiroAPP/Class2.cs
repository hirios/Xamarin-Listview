using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace primeiroAPP
{
    public class PYTHON
    {
        private HttpClient _client = new HttpClient();

        public async Task<string> Requests(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return await Task.FromResult("Null");
            }

            return await response.Content.ReadAsStringAsync();
        }

        public void print(string text)
        {
            Console.Write(text);
        }

        public string input(string text)
        {
            print(text);
            string ouput = Console.ReadLine();
            return ouput;
        }

        public string popen(string Command)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + Command;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        public void open(string path)
        {
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
        }
    }
}
