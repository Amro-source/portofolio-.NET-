using System;
using System.IO;
using System.Collections.Generic;

class FileOrganizer
{
    static void Main()
    {
        Console.Write("Enter folder path to organize: ");
        string path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Directory not found.");
            return;
        }

        Dictionary<string, string> extensions = new Dictionary<string, string>
        {
            { ".txt", "Documents" },
            { ".docx", "Documents" },
            { ".xlsx", "Documents" },
            { ".pdf", "Documents" },
            { ".jpg", "Images" },
            { ".png", "Images" },
            { ".gif", "Images" },
            { ".mp3", "Music" },
            { ".wav", "Music" },
            { ".mp4", "Videos" },
            { ".avi", "Videos" },
            { ".mkv", "Videos" },
            { ".exe", "Executables" },
            { ".zip", "Archives" },
            { ".rar", "Archives" }
        };

        foreach (string file in Directory.GetFiles(path))
        {
            string ext = Path.GetExtension(file).ToLower();
            if (extensions.TryGetValue(ext, out string folderName))
            {
                string destFolder = Path.Combine(path, folderName);
                string destFile = Path.Combine(destFolder, Path.GetFileName(file));

                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                File.Move(file, destFile);
                Console.WriteLine($"Moved: {file} -> {destFile}");
            }
        }

        Console.WriteLine("Organization complete.");
    }
}