using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DaySeven
{
    internal class NoSpaceLeftOnDevice : BaseAdventSolver<Dictionary<string, FileDirectory>, int>
    {
        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetFileSystem;
        }

        protected override int SolvePartOne(Dictionary<string, FileDirectory> processedInput)
        {
            int result = 0;
            foreach (var item in processedInput)
            {
                int directorySize = RecusivelyCountFileSize(item.Value);
                if (directorySize <= CommonConstant.DaySeven.MaximumDirectorySize)
                {
                    result += directorySize;
                }

            }
            return result;
        }

        protected override int SolvePartTwo(Dictionary<string, FileDirectory> processedInput)
        {
            int result = 0;
            int totalUsedSpace = RecusivelyCountFileSize(processedInput[CommonConstant.DaySeven.RootDirectory]);
            int requiredSpace = CommonConstant.DaySeven.RequiredUnusedSize - (CommonConstant.DaySeven.MaximumFileSystemSize - totalUsedSpace);
            result = processedInput.Select(item => item.Value)
                                   .Select(item => RecusivelyCountFileSize(item))
                                   .Where(item => item > requiredSpace)
                                   .Min();

            return result;
        }

        private int RecusivelyCountFileSize(FileDirectory directory)
        {
            int size = 0;
            if (directory.SubDirectories != null
               && directory.SubDirectories.Count > 0)
            {
                foreach (var subDirectory in directory.SubDirectories)
                {
                    size += RecusivelyCountFileSize(subDirectory);
                }
            }
            if (directory.FileDescriptions != null
               && directory.FileDescriptions.Count > 0)
            {
                size += directory.FileDescriptions.Select(item => item.FileSize).Sum();
            }
            return size;
        }
    }
}
