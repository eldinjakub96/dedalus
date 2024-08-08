using System;
using System.IO;

namespace DedalusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the first command-line argument or environment variable, or default to "/data"
            string directory = args.Length > 0 ? args[0] : Environment.GetEnvironmentVariable("DIRECTORY_PATH") ?? "/data";

            // Validate if the input is not null or empty and is a valid directory
            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                Console.WriteLine($"{directory} is not a valid directory");
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

           
