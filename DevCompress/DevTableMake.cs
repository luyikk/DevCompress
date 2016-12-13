using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace DevCompress
{
    public class DevTableMake
    {
        protected MemoryStream stream;
        protected System.IO.BinaryWriter buffList;

        public DevTableMake()
        {
            stream = new MemoryStream();
            buffList = new BinaryWriter(stream);
        }

        public void SetPostion(long index)
        {
            stream.Position = index;
        }

        public long GetLength()
        {
            return stream.Length;
        }

        public virtual void AddItem(bool data)
        {          
            buffList.Write(data);
        }
        public virtual void AddItem(String data)
        {
            Byte[] bytes = Encoding.UTF8.GetBytes(data);
            buffList.Write(bytes.Length);
            buffList.Write(bytes);
        }

        public virtual void AddItem(Int32 data)
        {           
            buffList.Write(data);
        }

        /// <summary>
        /// 添加一个8字节的整数
        /// </summary>
        /// <param name="data"></param>
        public virtual void AddItem(Int64 data)
        {
            buffList.Write(data);
        }

        public virtual byte[] Finish()
        {
            byte[] data= stream.ToArray();
            stream.Close();
            stream.Dispose();
            return data;

        }
    }
}
