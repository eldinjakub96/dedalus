using System;
using System.IO;

namespace DedalusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter the directory they want to check
            Console.WriteLine("Enter the directory you want to check:");

            string? directory = Console.ReadLine();

            // 1. Check if the input is null or empty
            // 2. Check if the provided directory path exists
            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                // If invalid, print an error message
                Console.WriteLine($"{directory ?? "null"} is not a valid directory");
                Environment.Exit(1);
            }

            (string longestName, string longestPath) = FindLongestSubdirectory(directory);

            // Print the result to the console, including the path and the name of the longest subdirectory
            Console.WriteLine($"The subdirectory with the longest name is: {longestName}");
            Console.WriteLine($"Location: {longestPath}");
        }

        // Method to find the subdirectory with the longest name
        static (string longestName, string longestPath) FindLongestSubdirectory(string directory)
        {
            string longestName = string.Empty;
            string longestPath = string.Empty;

            // Iterate through all subdirectories in the given directory and its subdirectories
            foreach (var dir in Directory.GetDirectories(directory, "*", SearchOption.AllDirectories))
            {
                // Extract the name of the current subdirectory from its full path
                string dirName = Path.GetFileName(dir);

                if (dirName.Length > longestName.Length)
                {
                    // If true, update 'longestName' and 'longestPath' to the current directory name and path
                    longestName = dirName;
                    longestPath = dir;
                }
            }

            // Return the longest directory name and its full path
            return (longestName, longestPath);
        }
    }
}
