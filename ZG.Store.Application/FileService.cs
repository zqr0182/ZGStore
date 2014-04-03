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
    }
}
