using System;
using System.Collections.Generic;
using System.IO;

namespace DevCompress
{
    public delegate void MakeDevProgressHandler(string filename,int index, int lengt);

    public class DevCompressFileMake
    {

        public event MakeDevProgressHandler MakeProgress;

        public DevFileInfoRead FileRead { get; private set; }

        private string SavePath { get; set; }

        public List<WDevFile> WFileList { get; private set; }     
     

        public  DevCompressFileMake(string path)
        {
            WFileList = new List<WDevFile>();
            SavePath = path;
        }

        public void AddDirectory(string path)
        {
            List<string> files = new List<string>();

            var dirinfo = new DirectoryInfo(path);

            if (!dirinfo.Exists)
                throw new FileNotFoundException("File Not Find:" + path);

            GetFile(dirinfo, files);



            foreach (var item in files)
            {
                FileInfo file = new FileInfo(item);

                string pathx = file.DirectoryName.Substring(dirinfo.Parent.FullName.Length, file.DirectoryName.Length - dirinfo.Parent.FullName.Length);

                if (pathx[0] != '/' || pathx[0] != '\\')
                    pathx = "/" + pathx;

                if (pathx[pathx.Length-1] != '/' || pathx[pathx.Length - 1] != '\\')
                    pathx = pathx+"/";

                if (string.IsNullOrEmpty(pathx))
                    pathx = "/";

                string PathByPack = pathx.Replace("\\", "/");

                PathByPack = PathByPack.Replace("//", "/");


                WDevFile tmp = new WDevFile(file.Name, PathByPack, file.FullName);

                if (WFileList.Find(p => p.FileName == file.Name && p.Path == PathByPack) == null)
                {
                    WFileList.Add(tmp);
                }
            }
           
        }

        private void GetFile(DirectoryInfo dirinfo,List<string> files)
        {
            var filesystemfils= dirinfo.GetFileSystemInfos();

            foreach (var item in filesystemfils)
            {
                if (item is FileInfo)
                {
                    files.Add(item.FullName);
                }
                else if (item is DirectoryInfo)
                {
                    GetFile(item as DirectoryInfo, files);
                }

            }
        }


        public void AddFile(string fullFileName,string PathByPack)
        {
            if (string.IsNullOrEmpty(PathByPack))
                PathByPack = "/";

            PathByPack = PathByPack.Replace("\\", "/");

            FileInfo file = new FileInfo(fullFileName);

            if(!file.Exists)
            {
                throw new FileNotFoundException("File not find:" + fullFileName);
            }

            WDevFile tmp = new WDevFile(file.Name, PathByPack, file.FullName);

            if(WFileList.Find(p=>p.FileName==file.Name&&p.Path==PathByPack)==null)
            {
                WFileList.Add(tmp);
            }
        }

        public void Clecr()
        {
            WFileList.Clear();
        }

        public void Make()
        {

            DevTableMake devtable = new DevTableMake();

            string dvdfile = SavePath + ".dev";           
            using (var dvdfileStream = File.Create(dvdfile))
            {
                using (var wr = new BinaryWriter(dvdfileStream))
                {
                    int i = 1;
                    int max = WFileList.Count;

                    wr.Write((int)0xFFEEEE);
                    wr.Write((long)0);

                    devtable.AddItem((int)0xFFEEDD);
                    devtable.AddItem((long)0);
                    devtable.AddItem((int)max);

                    foreach (var file in WFileList)
                    {
                        if (MakeProgress != null)
                            MakeProgress(file.FileName, i, max);


                        long complengt;
                        bool isCompuress;
                        long index = InsertFileData(dvdfileStream, file, out complengt, out isCompuress);

                        if (index != -1)
                        {
                            devtable.AddItem(file.FileName);
                            devtable.AddItem(file.Path);
                            devtable.AddItem(isCompuress);
                            devtable.AddItem(complengt);
                            devtable.AddItem(file.Size);
                            devtable.AddItem(index);
                        }

                        i++;

                    }

                    devtable.SetPostion(4);
                    devtable.AddItem(devtable.GetLength());
                    var data = devtable.Finish();


                    long postion = dvdfileStream.Position;
                    dvdfileStream.Write(data, 0, data.Length);
                    dvdfileStream.Position = 4;
                    wr.Write(postion);

                    dvdfileStream.Close();
                    dvdfileStream.Dispose();
                }
            }
        }

        private long InsertFileData(FileStream dvdfileStream, WDevFile file,out long length,out bool isCompuress)
        {
            var read = file.fileInfo.OpenRead();

            byte[] data = new byte[read.Length];

            long postion = dvdfileStream.Position;

            length = 0;

            if (read.Read(data, 0, data.Length) == read.Length)
            {

                data = DevFile.Compress(data, out isCompuress);

                dvdfileStream.Write(data, 0, data.Length);

                length = data.Length;

                return postion;
            }
            else
            {
                isCompuress = false;
                return -1;
            }
        }

      

    }
}
