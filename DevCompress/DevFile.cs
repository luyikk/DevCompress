using System;
using System.IO.Compression;
using System.IO;

namespace DevCompress
{
    public class DevFile
    {

        

        public DevFile(string fileName,string path,bool isCompress, long compressSize,long size,long index, DevFileInfoRead fileinfo)
        {
            this.FileName = fileName;
            this.Path = path;
            this.IsCompress = isCompress;
            this.CompressSize = compressSize;
            this.Size = size;
            this.Index = index;
            this.FileInfo = fileinfo;
        }

        public string FileName { get; private set; }
        public string Path { get; private set; }

        public string KEY
        {   get
            {
                return Path + FileName;
            }
        }

        public bool IsCompress { get; set; }

        public long CompressSize { get; private set; }  

        public long Size { get; private set; }
        public long Index { get; private set; }

        private DevFileInfoRead FileInfo { get; set; }

        
        public byte[] GetData()
        {
            byte[] data= FileInfo.Read(Index, CompressSize);

            if(IsCompress)
                data = Decompress(data);

            if (data.Length != Size)
                throw new Exception(Path + FileName + " files in the archive are corrupted");

            return data;

        }

        /// <summary>
        /// GZip压缩
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public  static byte[] Compress(byte[] rawData,out bool IsCompress)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true))
                    {
                        compressedzipStream.Write(rawData, 0, rawData.Length);
                        compressedzipStream.Close();
                        IsCompress = true;
                        return ms.ToArray();
                    }
                }
            }
            catch
            {
                IsCompress = false;
                return rawData;
            }

          
        }


        /// <summary>
        /// ZIP解压
        /// </summary>
        /// <param name="zippedData"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] bytes)
        {
            try
            {
                byte[] buffer2;
                using (MemoryStream stream = new MemoryStream(bytes, false))
                {
                    using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        using (MemoryStream stream3 = new MemoryStream())
                        {

                            int num;
                            byte[] buffer = new byte[bytes.Length];
                            while ((num = stream2.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                stream3.Write(buffer, 0, num);
                            }
                            stream3.Close();
                            buffer2 = stream3.ToArray();
                        }
                    }
                }

                if (buffer2.Length == 0)
                    return bytes;
                else
                    return buffer2;
            }
            catch
            {
                return bytes;
            }
        }

        public override string ToString()
        {
            return Path + FileName + "|" + Size + "";
        }


    }
}
