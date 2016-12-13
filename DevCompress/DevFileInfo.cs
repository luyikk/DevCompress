using System;
using System.Collections.Generic;
using System.IO;
namespace DevCompress
{
    public class DevFileInfoRead
    {
        public FileInfo fileinfo { get; private set; } 
        public Stream filestream { get; private set; }

        private bool IsStream { get; set; }

        public DevFileInfoRead(string path)
        {
            fileinfo = new FileInfo(path);

            if(!fileinfo.Exists)
            {
                throw new FileNotFoundException("Not Find:" + path);
            }
        }

        public DevFileInfoRead(Stream stream)
        {
            IsStream = true;
            filestream = stream;
        }




        public byte[] Read(long index,long lengt)
        {
            if (!IsStream)
            {
                using (var fileread = fileinfo.OpenRead())
                {
                    byte[] data = new byte[lengt];
                    fileread.Position = index;
                    fileread.Read(data, 0, data.Length);
                    fileread.Close();
                    return data;
                }
            }
            else
            {
                lock (filestream)
                {
                    byte[] data = new byte[lengt];
                    filestream.Position = index;
                    filestream.Read(data, 0, data.Length);
                    return data;
                }
            }
        }

    }
}
