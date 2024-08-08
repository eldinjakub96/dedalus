using System;
using System.IO;

namespace DedalusTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use an environment variable or default path if no arguments are provided
            string directory = args.Length > 0 ? args[0] : Environment.GetEnvironmentVariable("DIRECTORY_PATH") ?? "/data";

            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                Console.WriteLine($"{directory} is not a valid directory");
                Environment.Exit(1);
            }

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
