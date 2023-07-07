using System.IO;
using System;

public static class DirectoryHelper
{
    /// <summary>
    /// This method will Set the CurrentDirectory for this application.
    /// In situation the application is running in Visual Studio IDE or VSCode Editor
    /// </summary>
    public static void SetDirectory()
    {
        var currentDirectory = Environment.CurrentDirectory;
        var separator = Path.DirectorySeparatorChar;
        var directoryList = currentDirectory.Split(separator);

        //Checking if the currentDirectory is in Bin Directory or not
        bool inBinDirectory = false;
        foreach (var directory in directoryList)
        {
            if (directory.Equals("bin"))
            {
                inBinDirectory = true;
                break;
            }
        }
        if (inBinDirectory) Environment.CurrentDirectory = Path.Combine(currentDirectory, "..", "..", "..");
    }
}
