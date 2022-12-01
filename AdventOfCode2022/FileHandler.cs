using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class FileHandler
    {
        private string path;


        public FileHandler(string dayPart)
        {
            string? path = ConfigurationManager.AppSettings.Get(dayPart);
            if (!String.IsNullOrEmpty(path))
            {
                this.path = path;
            }
        }

        public List<string> GetInput()
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
