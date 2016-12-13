using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace DevCompress
{
    public class DevCompressFileRead:IEnumerable<DevFile>,IDisposable
    {
        public string FileNamet { get; private set; }
        public string FileNamev { get; private set; }

        public DevFileInfoRead fileInfoRead { get; private set; }

        private Dictionary<string,DevFile> FileList { get;  set; }

        private Stream stream { get; set; }


        public DevCompressFileRead(Stream stream)
        {
            this.stream = stream;

            RDevFile read = new RDevFile(stream);

            int tag = read.ReadInt32();

            if (tag == 0xFFEEEE)
            {
                long postion = read.ReadInt64();

                read.Postion = postion;

                tag = read.ReadInt32();

                if (tag == 0xFFEEDD)
                {

                    long length = read.ReadInt64();

                    fileInfoRead = new DevFileInfoRead(stream);

                    long Size = read.ReadInt32();

                    FileList = new Dictionary<string, DevFile>();

                    for (int i = 0; i < Size; i++)
                    {
                        string filename = read.ReadString();
                        string path = read.ReadString();
                        bool isCompuress = read.ReadBoolean();
                        long complengt = read.ReadInt64();
                        long fileSize = read.ReadInt64();
                        long index = read.ReadInt64();

                        DevFile file = new DevFile(filename, path, isCompuress, complengt, fileSize, index, fileInfoRead);
                        FileList.Add(path + filename, file);
                    }
                }                

            }
            else
                throw new Exception("ERROR FILE");

        }

        public DevCompressFileRead(string fileName)
        {
            if (!File.Exists(fileName))
            {
                if(File.Exists(fileName+".det"))
                {
                    fileName = fileName + ".det";
                }
                else
                {
                    throw new FileNotFoundException("File NOT FIND:" + fileName);
                }
            }
                

            FileInfo file = new FileInfo(fileName);

            string basefile= file.FullName.Substring(0, file.FullName.Length - file.Extension.Length);

            if(File.Exists(basefile+".dev"))
            {
                FileNamev = basefile + ".dev";
            }
            else if(File.Exists(file.FullName + ".dev"))
            {
                FileNamev = file.FullName + ".dev";
            }
            else
            {
                throw new FileNotFoundException("DEV File NOT FIND:"+fileName);
            }



            FileNamet = file.FullName;
            Init();
        }

        private void Init()
        {
            RDevFile read = new RDevFile(FileNamet);

            int tag= read.ReadInt32();

            if (tag == 0xFFEEEE)
            {
                long postion = read.ReadInt64();

                read.Postion = postion;

                tag = read.ReadInt32();

                if (tag == 0xFFEEDD)
                {

                    long length = read.ReadInt64();

                    fileInfoRead = new DevFileInfoRead(FileNamev);

                    long Size = read.ReadInt32();

                    FileList = new Dictionary<string, DevFile>();

                    for (int i = 0; i < Size; i++)
                    {
                        string filename = read.ReadString();
                        string path = read.ReadString();
                        bool isCompuress = read.ReadBoolean();
                        long complengt = read.ReadInt64();
                        long fileSize = read.ReadInt64();
                        long index = read.ReadInt64();

                        DevFile file = new DevFile(filename, path, isCompuress, complengt, fileSize, index, fileInfoRead);
                        FileList.Add(path + filename, file);
                    }
                }

                read.Close();

            }
            else
                throw new Exception("ERROR FILE");
        }

        public bool IsHaveCheck(string file)
        {
            return FileList.ContainsKey(file);
        }

       

        public byte[] Read(string file)
        {
            if(FileList.ContainsKey(file))
            {
                byte[] data= FileList[file].GetData();

                return data;
               
            }
            return null;
        }

        IEnumerator<DevFile> IEnumerable<DevFile>.GetEnumerator()
        {
            return FileList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return FileList.Values.GetEnumerator();
        }

        public void Dispose()
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
        }
    }
}
