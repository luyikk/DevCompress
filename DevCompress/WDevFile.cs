using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DevCompress
{
   

    public class WDevFile
    {
        public WDevFile(string fileName, string parentPath, string fullFileName)
        {

            FileName = fileName;
            Path = parentPath;

            this.fileInfo = new FileInfo(fullFileName);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File NOT FIND:" + fullFileName);
            }

            Size = fileInfo.Length;


        }



        public string FileName { get; private set; }
        public string Path { get; private set; }     
        public long Size { get; private set; }

        public FileInfo fileInfo { get; private set; }

        public override string ToString()
        {
            return Path + "/" + FileName + "|" + Size + "|" + fileInfo.FullName;
        }

    }
}
