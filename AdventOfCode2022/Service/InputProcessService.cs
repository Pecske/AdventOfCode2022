﻿using AdventOfCode2022.DailySolutions.DayFive;
using AdventOfCode2022.DailySolutions.DayFour;
using AdventOfCode2022.DailySolutions.DayOne;
using AdventOfCode2022.DailySolutions.DaySeven;
using AdventOfCode2022.DailySolutions.DayTwo;
using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Service
{
    internal class InputProcessService
    {
        private static InputProcessService instance;
        public static InputProcessService Instance { get { if (instance == null) { instance = new InputProcessService(); } return instance; } }

        public List<Elf> GetElves(List<string> inputs)
        {
            List<Elf> elves = new List<Elf>();
            int newElfCounter = 0;
            List<int> calories = new List<int>();
            for (int i = 0; i < inputs.Count; i++)
            {
                string calorieInput = inputs[i];
                if (!string.IsNullOrEmpty(calorieInput))
                {
                    int calorie;
                    if (int.TryParse(calorieInput, out calorie))
                    {
                        calories.Add(calorie);
                    }
                }
                if (string.IsNullOrEmpty(calorieInput) || i == inputs.Count - 1)
                {
                    Elf newElf = new Elf(newElfCounter, calories);
                    elves.Add(newElf);
                    calories = new List<int>();
                    newElfCounter++;
                }
            }
            return elves;
        }

        public List<RPS> GetRPSs(List<string> inputs)
        {
            List<RPS> rpsList = new List<RPS>();
            foreach (var item in inputs)
            {
                string[] hand = item.Split(" ");
                RPS rps = new RPS(hand[0], hand[1]);
                rpsList.Add(rps);
            }

            return rpsList;
        }
        public List<string> GetInputs(List<string> inputs)
        {
            return inputs;
        }
        public List<SectionCleanUp> GetSections(List<string> inputs)
        {
            List<SectionCleanUp> sections = new List<SectionCleanUp>();
            foreach (var item in inputs)
            {
                string[] sectionArray = item.Split(",");
                SectionCleanUp section = new SectionCleanUp(sectionArray[0], sectionArray[1]);
                sections.Add(section);
            }

            return sections;
        }
        public Crate GetSupplyCommands(List<string> inputs)
        {
            Dictionary<int, List<string>> crateContainer = new Dictionary<int, List<string>>();
            List<SupplyCommand> commands = new List<SupplyCommand>();
            bool cratesReady = false;
            foreach (var item in inputs)
            {
                string numbers = item.Replace(" ", string.Empty);
                if (numbers.All(item => CommonConstant.Numbers.Contains(item)))
                {
                    cratesReady = true;
                }
                for (int i = 0; i < item.Length && !cratesReady; i++)
                {
                    string currentItem = item[i].ToString();
                    if (CommonConstant.UpperABC.Contains(currentItem))
                    {
                        int containerNumber = i / 4 + 1;
                        try
                        {
                            List<string> tempList = crateContainer[containerNumber];
                        }
                        catch (Exception)
                        {
                            crateContainer.Add(containerNumber, new List<string>());
                        }
                        finally
                        {
                            crateContainer[containerNumber].Add(currentItem);
                        }
                    }
                }
                if (cratesReady && item.Contains(CommonConstant.DayFive.MoveCommand))
                {
                    int[] commandInputs = SplitSupplyCommandInput(item);
                    commands.Add(new SupplyCommand(commandInputs[0], commandInputs[1], commandInputs[2]));
                }
            }
            return new Crate(crateContainer, commands);
        }

        public Dictionary<string, FileDirectory> GetFileSystem(List<string> inputs)
        {
            Dictionary<string, FileDirectory> result = new Dictionary<string, FileDirectory>();

            Stack<string> directoryHistory = new Stack<string>();

            foreach (var item in inputs)
            {
                if (item.Contains(CommonConstant.DaySeven.ChangeDirectory)
                    && !item.Contains(CommonConstant.DaySeven.JumpOut))
                {
                    string newDirectory = item.Replace(CommonConstant.DaySeven.ChangeDirectory, String.Empty).Replace(" ", String.Empty);
                    directoryHistory.Push(newDirectory);
                    string dirPath = directoryHistory.Aggregate((prev, current) => prev + current);
                    try
                    {
                        FileDirectory fileDirectory = result[dirPath];
                    }
                    catch (Exception)
                    {
                        FileDirectory currentDirectory = new FileDirectory(newDirectory, new List<FileDirectory>(), new List<FileDescription>());
                        result.Add(dirPath, currentDirectory);
                    }
                }
                else if (item.Contains(CommonConstant.DaySeven.Directory))
                {
                    string dirName = item.Replace(CommonConstant.DaySeven.Directory, String.Empty).Replace(" ", String.Empty);
                    string currentDirPath = directoryHistory.Aggregate((prev, current) => prev + current);
                    string newDirPath = dirName + directoryHistory.Aggregate((prev, current) => prev + current);
                    FileDirectory subDirectory = new FileDirectory(currentDirPath, new List<FileDirectory>(), new List<FileDescription>());
                    try
                    {
                        FileDirectory fileDirectory = result[newDirPath];
                    }
                    catch (Exception)
                    {
                        result.Add(newDirPath, subDirectory);
                    }
                    finally
                    {
                        FileDirectory directory = result[currentDirPath];
                        directory.SubDirectories.Add(subDirectory);
                    }
                }
                else if (item.Contains(CommonConstant.DaySeven.JumpOut))
                {
                    directoryHistory.Pop();
                }
                else if (!item.Contains(CommonConstant.DaySeven.ChangeDirectory)
                    && !item.Contains(CommonConstant.DaySeven.Directory)
                    && !item.Contains(CommonConstant.DaySeven.ListDirectory))
                {
                    string[] fileInput = item.Split(" ");
                    FileDescription fileDescription = new FileDescription(int.Parse(fileInput[0]), fileInput[1]);
                    string dirPath = directoryHistory.Aggregate((prev, current) => prev + current);
                    FileDirectory directory = result[dirPath];
                    directory.FileDescriptions.Add(fileDescription);
                }
            }
            return result;
        }

        private int[] SplitSupplyCommandInput(string commandString)
        {
            string moveCommandSplit = commandString.Substring(CommonConstant.DayFive.MoveCommand.Length);
            string[] fromSplit = moveCommandSplit.Split(CommonConstant.DayFive.FromCommand);
            string[] toSplit = fromSplit[1].Split(CommonConstant.DayFive.ToCommand);
            int[] result = { int.Parse(fromSplit[0]), int.Parse(toSplit[0]), int.Parse(toSplit[1]) };
            return result;
        }
    }
}
