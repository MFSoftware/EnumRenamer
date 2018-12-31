using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace er
{
    class Program
    {
        public static string path;

        public static void GetHelp()
        {
            Console.WriteLine();
            Console.WriteLine("- Help -");
        }

        static void Main(string[] args)
        {
            bool isDirs = false;

            if (args.Count() == 0)
                GetHelp();
            else if (args.Count() == 1)
            {
                if (args[0] == "/h" || args[0] == "-h" || args[0] == "/help" || args[0] == "-help")
                    GetHelp();
                else
                {
                    if (args[0].StartsWith("'") && args[0].EndsWith("'"))
                        path = args[0].Replace("'", string.Empty);
                    else
                        path = args[0];

                    List<string> dirs = Directory.GetDirectories(path).ToList<string>();
                    for (int i = 0; i < dirs.Count; i++)
                    {
                        string[] arr = dirs.ToArray();
                        if (path.EndsWith(@"\") || path.EndsWith(@"/"))
                            path = path.Remove(path.Length - 1);
                        if (arr[i] != path + "\\" + (i + 1).ToString())
                            Directory.Move(arr[i], path + "\\" + (i + 1).ToString());
                    }

                    List<string> files = Directory.GetFiles(path).ToList<string>();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string[] arr = files.ToArray();
                        string ext = arr[i].Substring(arr[i].LastIndexOf('.'));
                        if (path.EndsWith(@"\") || path.EndsWith(@"/"))
                            path = path.Remove(path.Length - 1);

                        if (arr[i] != path + "\\" + (i + 1).ToString() + ext)
                            File.Move(arr[i], path + "\\" + (i + 1).ToString() + ext);
                    }
                }
            }
            else if (args.Count() == 2)
            {
                foreach (string item in args)
                {
                    if (item == "-f" || item == "-files" || item == "/f" || item == "/files")
                        isDirs = false;
                    else if (item == "-d" || item == "-dirs" || item == "/d" || item == "/dirs")
                        isDirs = true;
                    else
                    {
                        if (item.StartsWith("'") && item.EndsWith("'"))
                            path = item.Replace("'", string.Empty);
                        else
                            path = item;
                    }
                }

                if (isDirs)
                {
                    List<string> dirs = Directory.GetDirectories(path).ToList<string>();
                    for (int i = 0; i < dirs.Count; i++)
                    {
                        string[] arr = dirs.ToArray();
                        if (path.EndsWith(@"\") || path.EndsWith(@"/"))
                            path = path.Remove(path.Length - 1);
                        if (arr[i] != path + "\\" + (i + 1).ToString())
                            Directory.Move(arr[i], path + "\\" + (i + 1).ToString());
                    }
                }
                else
                {
                    List<string> files = Directory.GetFiles(path).ToList<string>();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string[] arr = files.ToArray();
                        string ext = arr[i].Substring(arr[i].LastIndexOf('.'));
                        if (path.EndsWith(@"\") || path.EndsWith(@"/"))
                            path = path.Remove(path.Length - 1);

                        if (arr[i] != path + "\\" + (i + 1).ToString() + ext)
                            File.Move(arr[i], path + "\\" + (i + 1).ToString() + ext);
                    }
                }
            }
        }
    }
}
