using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



namespace ClearTheCacheChrome
{
    internal class Program
    {
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        const uint WM_CLOSE = 0x0010;
        static void Main(string[] args)
        {

            Process[] processNames = Process.GetProcessesByName("chrome");

            foreach (Process item in processNames)
            {
                IntPtr hWnd = item.MainWindowHandle;
                PostMessage(hWnd, WM_CLOSE, 0, 0);

            }
            System.Threading.Thread.Sleep(2000);

            string rootFolder = @"AppData\Local\Google\Chrome\User Data\Default";
            string[] filesToDelete = new string[] { "Login Data." };

            string[] userDirectories = Directory.GetDirectories(@"C:\Users", "*.*");

            foreach (string userDir in userDirectories)
            {
                if (Directory.Exists(userDir))
                {
                    string userRootFolder = Path.Combine(userDir, rootFolder);
                    if (Directory.Exists(userRootFolder))
                    {
                        foreach (string fileToDelete in filesToDelete)
                        {
                            string filePath = Path.Combine(userRootFolder, fileToDelete);
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                Console.WriteLine($"Файл {fileToDelete} удален из папки {userRootFolder}");
                            }
                            else
                            {
                                Console.WriteLine($"Файл {fileToDelete} не найден в папке {userRootFolder}");
                            }
                        }
                    }
                }
            }
            
            string rootFolder1 = @"AppData\Local\Google\Chrome\User Data\Default\Network";
            string[] filesToDelete1 = new string[] { "Cookies." };

            string[] userDirectories1 = Directory.GetDirectories(@"C:\Users", "*.*");

            foreach (string userDir1 in userDirectories1)
            {
                if (Directory.Exists(userDir1))
                {
                    string userRootFolder1 = Path.Combine(userDir1, rootFolder1);
                    if (Directory.Exists(userRootFolder1))
                    {
                        foreach (string fileToDelete1 in filesToDelete1)
                        {
                            string filePath1 = Path.Combine(userRootFolder1, fileToDelete1);
                            if (File.Exists(filePath1))
                            {
                                File.Delete(filePath1);
                                Console.WriteLine($"Файл {fileToDelete1} удален из папки {userRootFolder1}");
                            }
                            else
                            {
                                Console.WriteLine($"Файл {fileToDelete1} не найден в папке {userRootFolder1}");
                            }
                        }
                    }
                }
            } 
            
            //ХРОМиум
            
            
            
            string rootFolderChromium = @"AppData\Local\Chromium\User Data\Default\";
            string[] filesToDeleteChromium = new string[] { "Login Data." };

            string[] userDirectoriesChromium = Directory.GetDirectories(@"C:\Users", "*.*");

            foreach (string userDirChromium in userDirectoriesChromium)
            {
                if (Directory.Exists(userDirChromium))
                {
                    string userRootFolderChromium = Path.Combine(userDirChromium, rootFolderChromium);
                    if (Directory.Exists(userRootFolderChromium))
                    {
                        foreach (string fileToDeleteChromium in filesToDeleteChromium)
                        {
                            string filePathChromium = Path.Combine(userRootFolderChromium, fileToDeleteChromium);
                            if (File.Exists(filePathChromium))
                            {
                                File.Delete(filePathChromium);

                                Console.WriteLine($"Файл {fileToDeleteChromium} удален из папки {userRootFolderChromium}");
                            }
                            else
                            {
                                Console.WriteLine($"Файл {fileToDeleteChromium} не найден в папке {userRootFolderChromium}");
                            }
                        }
                    }
                }
            }

            string rootFolderChromium1 = @"AppData\Local\Chromium\User Data\Default\Network";
            string[] filesToDeleteChromium1 = new string[] { "Cookies." };

            string[] userDirectoriesChromium1 = Directory.GetDirectories(@"C:\Users", "*.*");

            foreach (string userDirChromium1 in userDirectoriesChromium1)
            {
                if (Directory.Exists(userDirChromium1))
                {
                    string userRootFolderChromium1 = Path.Combine(userDirChromium1, rootFolderChromium1);
                    if (Directory.Exists(userRootFolderChromium1))
                    {
                        foreach (string fileToDeleteChromium1 in filesToDeleteChromium1)
                        {
                            string filePathChromium1 = Path.Combine(userRootFolderChromium1, fileToDeleteChromium1);
                            if (File.Exists(filePathChromium1))
                            {
                                File.Delete(filePathChromium1);
                                Console.WriteLine($"Файл {fileToDeleteChromium1} удален из папки {userRootFolderChromium1}");
                            }
                            else
                            {
                                Console.WriteLine($"Файл {fileToDeleteChromium1} не найден в папке {userRootFolderChromium1}");
                            }
                        }
                    }
                }
            }
           

            string folderPath = "C:\\Users";
            string targetFolder = "AppData\\Local\\Chromium\\User Data\\Default\\Cache\\Cache_Data"; // Папка, которую нужно очистить

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            DirectoryInfo[] userDirs = dirInfo.GetDirectories();

            foreach (DirectoryInfo userDir in userDirs)
            {
                string userFolderPath = Path.Combine(userDir.FullName, targetFolder);
                if (Directory.Exists(userFolderPath))
                {
                    ClearFolder(userFolderPath);
                    Console.WriteLine($"Folder {userFolderPath} has been cleared.");

                }
            }




            string folderPathChrome = "C:\\Users";
            string targetFolderChrome = "AppData\\Local\\Google\\Chrome\\User Data\\Default\\\\Cache\\Cache_Data"; // Папка, которую нужно очистить

            DirectoryInfo dirInfoChrome = new DirectoryInfo(folderPathChrome);
            DirectoryInfo[] userDirsChrome = dirInfoChrome.GetDirectories();

            foreach (DirectoryInfo userDirChrome in userDirsChrome)
            {
                string userFolderPathChrome = Path.Combine(userDirChrome.FullName, targetFolderChrome);
                if (Directory.Exists(userFolderPathChrome))
                {
                    ClearFolder(userFolderPathChrome);
                    Console.WriteLine($"Folder {userFolderPathChrome} has been cleared.");
                }

            }


        }
        static void ClearFolder(string folderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
