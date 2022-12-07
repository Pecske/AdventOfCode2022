using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DaySeven
{
    internal class FileDescription
    {
        public int FileSize { get; private set; }
        public string FileName { get; private set; }

        public FileDescription(int fileSize, string fileName)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
        }
    }
}
