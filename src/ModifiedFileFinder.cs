using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSyncApp
{
    //System.IO.File.GetLastWriteTime()
    //Get Files in a folder 

    //DirectoryInfo d = new DirectoryInfo(startingPath);
    //FileInfo[] Files = d.GetFiles(startingPath);
    public static class ModifiedFileFinder
    {
        public static List<String> FindAndCopyTo(String startingPath, String copiedTo, DateTime fromDate, DateTime endDate, Boolean onlyCreateDir = true)
        {
            var result = (from file in Directory.EnumerateFiles(startingPath, "*", SearchOption.AllDirectories)
                          where System.IO.File.GetLastWriteTime(file) >= fromDate
                          && System.IO.File.GetLastWriteTime(file) <= endDate
                          select file).ToList();

            foreach (var f in result)
            {
                var newPath = f.Replace(startingPath, copiedTo);
                var direcToCreate = f;
                if (IsDirectory(f) == false)
                {
                    direcToCreate = Path.GetDirectoryName(newPath);
                }
                if (!Directory.Exists(direcToCreate))
                {
                    Directory.CreateDirectory(direcToCreate);
                }
                if (onlyCreateDir == false)
                {
                    System.IO.File.Copy(f, newPath, true);
                }
            }

            return result.ToList();
        }

        public static Boolean IsDirectory(String path)
        {
            FileAttributes attr = File.GetAttributes(path);
            return attr.HasFlag(FileAttributes.Directory);
        }
    }
}
