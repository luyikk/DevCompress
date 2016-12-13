
using System;
using System.Text;
using System.Threading;
using System.IO;


namespace DevCompress
{
   
    /// <summary>
    /// 数据包在读取前需要额外的处理回调方法。（例如解密，解压缩等）
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public delegate byte[] RDataExtraHandle(byte[] data);


    /// <summary>
    /// 数据包读取类
    /// （此类的功能是讲通讯数据包重新转换成.NET 数据类型）
    /// </summary>
    public class RDevFile
    {


        protected Stream fileStream { get; set; }
        protected BinaryReader fileReader { get; set; }

        public bool IsFile { get; private set; }

        protected int current;

        public byte[] Data { get; set; }

        protected int startIndex;
        protected int endlengt;

        /// <summary>
        /// 额外处理是否调用成功，可以判断是否解密成功
        /// </summary>
        public bool IsDataExtraSuccess { get; set; }

        /// <summary>
        /// 数据包长度
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// 当前其位置
        /// </summary>
        public long Postion
        {
            get
            {
                if(IsFile)
                {
                    return fileStream.Position;
                }else
                    return current;
            }

            set
            {
                if (IsFile)
                {
                    fileStream.Position = value;
                }
                else
                    Interlocked.Exchange(ref current,(int) value);
            }
        }

        public virtual void Reset()
        {
            current = 0;
        }


        public RDevFile(Stream filestream)
        {
            this.fileStream = filestream;
            fileReader = new BinaryReader(fileStream);
            this.Length = (int)fileStream.Length;
            IsFile = true;
        }

        public RDevFile(string fileName)
        {
            fileStream = File.OpenRead(fileName);
            fileReader = new BinaryReader(fileStream);
            this.Length = (int)fileStream.Length;
            IsFile = true;
        }

        public void Close()
        {
            fileStream.Close();
            fileStream.Dispose();
            fileReader.Close();
            
        }


        public RDevFile(Byte[] data)
        {
            Data = data;
            this.Length = Data.Length;
            current = 0;
            IsDataExtraSuccess = true;
        }


        #region return 整数
        /// <summary>
        /// 读取内存流中的头2位并转换成整型
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual short ReadInt16()
        {
            if (IsFile)
            {
                return fileReader.ReadInt16();
            }
            else
            {
                short values = BitConverter.ToInt16(Data, current);
                current = Interlocked.Add(ref current, 2);
                return values;
            }
        }

        /// <summary>
        /// 读取内存流中的头2位并转换成无符号整型
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual ushort ReadUint16()
        {
            if (IsFile)
            {
                return fileReader.ReadUInt16();
            }
            else
            {
                ushort values = BitConverter.ToUInt16(Data, current);
                current = Interlocked.Add(ref current, 2);
                return values;
            }
        }


        /// <summary>
        /// 读取内存流中的头4位并转换成整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual int ReadInt32()
        {
            if (IsFile)
            {
                return fileReader.ReadInt32();
            }
            else
            {
                int values = BitConverter.ToInt32(Data, current);
                current = Interlocked.Add(ref current, 4);
                return values;
            }

        }

        /// <summary>
        /// 读取内存流中的头4位并转换成无符号整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual uint ReadUInt32()
        {
            if (IsFile)
            {
                return fileReader.ReadUInt32();
            }
            else
            {
                uint values = BitConverter.ToUInt32(Data, current);
                current = Interlocked.Add(ref current, 4);
                return values;
            }

        }


        /// <summary>
        /// 读取内存流中的头8位并转换成长整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual long ReadInt64()
        {
            if (IsFile)
            {
                return fileReader.ReadInt64();
            }
            else
            {
                long values = BitConverter.ToInt64(Data, current);
                current = Interlocked.Add(ref current, 8);
                return values;
            }
        }


        /// <summary>
        /// 读取内存流中的头8位并转换成无符号长整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual ulong ReadUInt64()
        {
            if (IsFile)
            {
                return fileReader.ReadUInt64();
            }
            else
            {
                ulong values = BitConverter.ToUInt64(Data, current);
                current = Interlocked.Add(ref current, 8);
                return values;
            }

        }

        /// <summary>
        /// 读取内存流中的首位
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual byte ReadByte()
        {
            if (IsFile)
            {
                return fileReader.ReadByte();
            }
            else
            {
                byte values = (byte)Data[current];
                current = Interlocked.Increment(ref current);
                return values;
            }

        }

        #endregion

        #region 整数
        /// <summary>
        /// 读取内存流中的头2位并转换成整型
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadInt16(out short values)
        {

            try
            {
                values = BitConverter.ToInt16(Data, current);
                current = Interlocked.Add(ref current, 2);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }

        /// <summary>
        /// 读取内存流中的头2位并转换成无符号整型
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public virtual bool ReadUint16(out ushort values)
        {

            try
            {
                values = BitConverter.ToUInt16(Data, current);
                current = Interlocked.Add(ref current, 2);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }


        /// <summary>
        /// 读取内存流中的头4位并转换成整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual bool ReadInt32(out int values)
        {
            try
            {
                values = BitConverter.ToInt32(Data, current);
                current = Interlocked.Add(ref current, 4);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }

        /// <summary>
        /// 读取内存流中的头4位并转换成无符号整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual bool ReadUInt32(out uint values)
        {
            try
            {
                values = BitConverter.ToUInt32(Data, current);
                current = Interlocked.Add(ref current, 4);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }


        /// <summary>
        /// 读取内存流中的头8位并转换成长整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual bool ReadInt64(out long values)
        {
            try
            {
                values = BitConverter.ToInt64(Data, current);
                current = Interlocked.Add(ref current, 8);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }


        /// <summary>
        /// 读取内存流中的头8位并转换成无符号长整型
        /// </summary>
        /// <param name="ms">内存流</param>
        /// <returns></returns>
        public virtual bool ReadUInt64(out ulong values)
        {
            try
            {
                values = BitConverter.ToUInt64(Data, current);
                current = Interlocked.Add(ref current, 8);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }

        /// <summary>
        /// 读取内存流中的首位
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadByte(out byte values)
        {
            try
            {
                values = (byte)Data[current];
                current = Interlocked.Increment(ref current);
                return true;
            }
            catch
            {
                values = 0;
                return false;
            }
        }

        #endregion
        
        #region return 浮点数


        /// <summary>
        /// 读取内存流中的头4位并转换成单精度浮点数
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual float ReadFloat()
        {
            if (IsFile)
            {
                return fileReader.ReadSingle();
            }
            else
            {
                float values = BitConverter.ToSingle(Data, current);
                current = Interlocked.Add(ref current, 4);
                return values;
            }
        }


        /// <summary>
        /// 读取内存流中的头8位并转换成浮点数
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual double ReadDouble()
        {
            if (IsFile)
            {
                return fileReader.ReadDouble();
            }
            else
            {
                double values = BitConverter.ToDouble(Data, current);
                current = Interlocked.Add(ref current, 8);
                return values;
            }

        }


        #endregion

        #region 浮点数


        /// <summary>
        /// 读取内存流中的头4位并转换成单精度浮点数
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadFloat(out float values)
        {

            try
            {
                values = BitConverter.ToSingle(Data, current);
                current = Interlocked.Add(ref current, 4);
                return true;
            }
            catch
            {
                values = 0.0f;
                return false;
            }
        }


        /// <summary>
        /// 读取内存流中的头8位并转换成浮点数
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadDouble(out double values)
        {

            try
            {
                values = BitConverter.ToDouble(Data, current);
                current = Interlocked.Add(ref current, 8);
                return true;
            }
            catch
            {
                values = 0.0;
                return false;
            }
        }


        #endregion

        #region return 布尔值
        /// <summary>
        /// 读取内存流中的头1位并转换成布尔值
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadBoolean()
        {
            if (IsFile)
            {
                return fileReader.ReadBoolean();
            }
            else
            {

                bool values = BitConverter.ToBoolean(Data, current);
                current = Interlocked.Add(ref current, 1);
                return values;
            }

        }

        #endregion

        #region 布尔值
        /// <summary>
        /// 读取内存流中的头1位并转换成布尔值
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadBoolean(out bool values)
        {

            try
            {
                values = BitConverter.ToBoolean(Data, current);
                current = Interlocked.Add(ref current, 1);
                return true;
            }
            catch
            {
                values = false;
                return false;
            }
        }

        #endregion
        
        #region  return 字符串
        /// <summary>
        /// 读取内存流中一段字符串
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public string ReadString()
        {
            if (IsFile)
            {
                int lengt = fileReader.ReadInt32();

                var buf = fileReader.ReadBytes(lengt);
                string values = Encoding.UTF8.GetString(buf, 0, buf.Length);
                return values;

            }
            else
            {

                int lengt = ReadInt32();

                Byte[] buf = new Byte[lengt];

                Buffer.BlockCopy(Data, current, buf, 0, buf.Length);

                string values = Encoding.UTF8.GetString(buf, 0, buf.Length);

                current = Interlocked.Add(ref current, lengt);

                return values;
            }

        }
        #endregion

        #region 字符串
        /// <summary>
        /// 读取内存流中一段字符串
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadString(out string values)
        {
            int lengt;
            try
            {
                if (ReadInt32(out lengt))
                {

                    Byte[] buf = new Byte[lengt];

                    Buffer.BlockCopy(Data, current, buf, 0, buf.Length);
                   
                    values = Encoding.UTF8.GetString(buf, 0, buf.Length);

                    current = Interlocked.Add(ref current, lengt);

                    return true;

                }
                else
                {
                    values = "";
                    return false;
                }
            }
            catch
            {
                values = "";
                return false;
            }

        }
        #endregion


        #region return  数据

        public virtual byte[] ReadByteArray(int lengt)
        {
            if (IsFile)
            {               
                var buf = fileReader.ReadBytes(lengt);              
                return buf;
            }
            else
            {

                byte[] values = new Byte[lengt];
                Buffer.BlockCopy(Data, current, values, 0, values.Length);
                current = Interlocked.Add(ref current, lengt);
                return values;
            }

        }


        /// <summary>
        /// 读取内存流中一段数据
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual byte[] ReadByteArray()
        {
            if (IsFile)
            {
                int lengt = fileReader.ReadInt32();

                var buf = fileReader.ReadBytes(lengt);

                return buf;

            }
            else
            {
                int lengt = ReadInt32();
                byte[] values = new Byte[lengt];
                Buffer.BlockCopy(Data, current, values, 0, values.Length);
                current = Interlocked.Add(ref current, lengt);
                return values;
            }
        }
        #endregion

        #region 数据

        public virtual bool ReadByteArray(out byte[] values, int lengt)
        {

            try
            {

                values = new Byte[lengt];
                Buffer.BlockCopy(Data, current, values, 0, values.Length);
                current = Interlocked.Add(ref current, lengt);
                return true;


            }
            catch
            {
                values = null;
                return false;
            }

        }


        /// <summary>
        /// 读取内存流中一段数据
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public virtual bool ReadByteArray(out byte[] values)
        {
            int lengt;
            try
            {
                if (ReadInt32(out lengt))
                {
                    values = new Byte[lengt];
                    Buffer.BlockCopy(Data, current, values, 0, values.Length);
                    current = Interlocked.Add(ref current, lengt);
                    return true;

                }
                else
                {
                    values = null;
                    return false;
                }
            }
            catch
            {
                values = null;
                return false;
            }

        }
        #endregion

    }


}
