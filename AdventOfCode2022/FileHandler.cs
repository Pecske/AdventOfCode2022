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
        private static readonly string InputLocation = "InputLocation";
        private string path;


        public FileHandler()
        {
            string? path = ConfigurationManager.AppSettings.Get(InputLocation);
            if (!String.IsNullOrEmpty(path))
            {
                this.path = path;
            }
        }

        public List<string> GetInput(string day)
        {
            string path = this.path + day + CommonConstant.FileExtension;
            return File.ReadAllLines(path).ToList();
        }
    }
}
