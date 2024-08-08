using System;
using System.IO;

namespace DedalusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // For local testing, prompt for directory if no arguments or environment variables are provided
            string directory = args.Length > 0 ? args[0] : Environment.GetEnvironmentVariable("DIRECTORY_PATH") ?? GetDirectoryFromUser();

            Console.WriteLine($"Checking directory: {directory}");

            // Validate if the input is not null or empty and is a valid directory
            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                Console.WriteLine($"{directory} is not a valid directory");
                Environment.Exit(1);
            }

            // Find and print the subdirectory with the longest name
            var (longestName, longestPath) = FindLongestSubdirectory(directory);
            Console.WriteLine($"The subdirectory with the longest name is: {longestName}");
            Console.WriteLine($"In location {longestPath}");
        }

        static string GetDirectoryFromUser()
        {
            Console.Write("Enter the directory you want to check: ");
            return Console.ReadLine();
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
