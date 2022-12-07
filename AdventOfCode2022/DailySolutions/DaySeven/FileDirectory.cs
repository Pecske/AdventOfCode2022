using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DaySeven
{
    internal class FileDirectory
    {
        public string DirectoryName { get; private set; }
        public List<FileDirectory> SubDirectories { get; private set; }
        public List<FileDescription> FileDescriptions { get; private set; }

        public FileDirectory() { }
        public FileDirectory(string directoryName, List<FileDirectory> subDirectories, List<FileDescription> fileDescriptions)
        {
            DirectoryName = directoryName;
            SubDirectories = subDirectories;
            FileDescriptions = fileDescriptions;
        }
    }
}
