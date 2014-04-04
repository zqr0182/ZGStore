using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Application
{
    public interface IFileService
    {
        void CreateDirectory(string path);
        List<string> GetFileNames(string directory);
    }

    public class FileService : IFileService
    {
        public void CreateDirectory(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public List<string> GetFileNames(string directory)
        {
            var dirInfo = new DirectoryInfo(directory);
            var files = dirInfo.GetFiles();

            var fileNames = new List<string>();
            fileNames.AddRange(files.Select(f => f.Name));

            return fileNames;
        }
    }
}
