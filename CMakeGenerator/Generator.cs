using System.Text.RegularExpressions;

namespace CMakeGenerator;

public static class Generator
{
    
    public static void GenerateTemplate(string tempDir, string projName, string dest, string cmakever = "3.21", string cxxver = "20")
    {
        var destPath = Path.Combine(dest, projName);
        string cmakeListFile = Path.Combine(destPath, "CMakeLists.txt");

        Console.Write("Copying files");
        //Now Create all of the directories
        foreach (string dirPath in Directory.GetDirectories(tempDir, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(tempDir, destPath));
        }

        //Copy all the files & Replaces any files with the same name
        foreach (string newPath in Directory.GetFiles(tempDir, "*.*",SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(tempDir, destPath), true);
        }
        
        Console.Write("\rGenerating CMake Text...");
        var cmakeText = GetCmakeLists(projName, cmakeListFile, cmakever, cxxver);
        Console.Write("\rGenerating new CMake file...");
        UpdateCmakeLists(cmakeListFile, cmakeText);
        Console.WriteLine("\nDone.");
    }

    private static void UpdateCmakeLists(string cmakeListFile, string cmakeText)
    {
        using var sw = File.CreateText(cmakeListFile);
        sw.WriteLine(cmakeText);
    }

    private static string GetCmakeLists(string projName, string path, string cmakever, string cxxver)
    {
        using var fs = File.Open(path, FileMode.Open);
        using var sr = new StreamReader(fs);
        var text = sr.ReadToEnd();
        text = Regex.Replace(text, "<PROJECT_NAME>", projName);
        text = Regex.Replace(text, "<CMAKE_VERSION_NUM>", cmakever);
        text = Regex.Replace(text, "<CXX_VERSION_NUM>", cxxver);
        return text;
    }
}