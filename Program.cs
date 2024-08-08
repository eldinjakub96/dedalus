using System;
using System.IO;

namespace DedalusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user for input
            Console.WriteLine("Enter the directory you want to check:");

            // Get the directory input from the user
            string? directory = Console.ReadLine();

            // Validate if the input is not null or empty and is a valid directory
            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                Console.WriteLine($"{directory ?? "null"} is not a valid directory");
                Environment.Exit(1);
            }

            // Find and print the subdirectory with the longest name
            var (longestName, longestPath) = FindLongestSubdirectory(directory);
            Console.WriteLine($"The subdirectory with the longest name is: {longestName} in location {longestPath}");
        }

        static (string longestName, string longestPath) FindLongestSubdirectory(string directory)
        {
            string longestName = string.Empty;
            string longestPath = string.Empty;

            foreach (var dir in Directory.GetDirectories(directory, "*", SearchOption.AllDirectories))
            {
                string dirName = Path.GetFileName(dir);
                if (dirName.Length > longestName.Length)
                {
                    longestName = dirName;
                    longestPath = dir;
                }
            }

            return (longestName, longestPath);
        }
    }
}
