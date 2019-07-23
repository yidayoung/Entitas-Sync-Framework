using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;


namespace NetStack.Serialization
{
    public class BitBuffer
    {
        private byte[] _bytes = new byte[0];
        private int _position;

        public BitBuffer(int size = 512)
        {
            Source = new byte[size];
        }

        public void Reset()
        {
            _position = 0;
        }

        public byte[] Source
        {
            get => _bytes;
            private set
            {
                _bytes = value;
                Reset();
            }
        }

        public int Length => _position;

        public BitBuffer AddInt(int value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public int ReadInt32()
        {
            return BitConverter.ToInt32(Get(4), 0);
        }

        public BitBuffer AddUInt(uint value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(Get(4), 0);
        }

        public BitBuffer AddShort(short value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public short ReadShort()
        {
            return BitConverter.ToInt16(Get(2), 0);
        }

        public BitBuffer AddUShort(ushort value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(Get(2), 0);
        }

        public BitBuffer AddString(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);
            AddInt(data.Length);
            Copy(data);
            return this;
        }

        public string ReadString()
        {
            return Encoding.UTF8.GetString(Get(ReadInt32()));
        }

        public BitBuffer AddBytes(byte[] value)
        {
            AddInt(value.Length);
            Copy(value);
            return this;
        }

        public byte[] ReadBytes()
        {
            return Get(ReadInt32());
        }


        public BitBuffer AddByte(byte value)
        {
            Copy(new byte[] {value});
            return this;
        }

        public byte ReadByte()
        {
            return Get(1)[0];
        }

        public BitBuffer AddBool(bool value)
        {
            AddByte(Convert.ToByte(value));
            return this;
        }

        public bool ReadBool()
        {
            return Convert.ToBoolean(ReadByte());
        }

        public BitBuffer AddLong(long value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public long ReadLong()
        {
            return BitConverter.ToInt64(Get(8), 0);
        }

        public BitBuffer AddULong(ulong value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public ulong ReadULong()
        {
            return BitConverter.ToUInt64(Get(8), 0);
        }

        public BitBuffer AddFloat(float value)
        {
            Copy(BitConverter.GetBytes(value));
            return this;
        }

        public float ReadFloat()
        {
            return BitConverter.ToSingle(Get(4), 0);
        }

        private void Copy(byte[] value)
        {
            var newSize = _position + value.Length;
            if (_bytes.Length >= newSize)
            {
                Buffer.BlockCopy(value, 0, _bytes, _position, value.Length);
            }
            else
            {
                var temps = new byte[newSize];
                Buffer.BlockCopy(_bytes, 0, temps, 0, _position);
                Buffer.BlockCopy(value, 0, temps, _position, value.Length);
                _bytes = temps;
            }
            _position += value.Length;
        }

        private byte[] Get(int length)
        {
            byte[] data = new byte[length];
            Buffer.BlockCopy(_bytes, _position, data, 0, length);
            _position += length;
            return data;
        }

        public void Dispose()
        {
            _position = 0;
            _bytes = null;
        }

        //压缩字节
        //1.创建压缩的数据流 
        //2.设定compressStream为存放被压缩的文件流,并设定为压缩模式
        //3.将需要压缩的字节写到被压缩的文件流
        public static byte[] CompressBytes(byte[] bytes)
        {
            using (MemoryStream compressStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(compressStream, CompressionMode.Compress))
                    zipStream.Write(bytes, 0, bytes.Length);
                return compressStream.ToArray();
            }
        }

        //解压缩字节
        //1.创建被压缩的数据流
        //2.创建zipStream对象，并传入解压的文件流
        //3.创建目标流
        //4.zipStream拷贝到目标流
        //5.返回目标流输出字节
        public static byte[] Decompress(byte[] bytes)
        {
            using (var compressStream = new MemoryStream(bytes))
            {
                using (var zipStream = new GZipStream(compressStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        zipStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }

        public void Clear()
        {
            Array.Clear(_bytes, 0, _bytes.Length);
            Reset();
        }

        public void ToArray(byte[] data, int offset)
        {
            if (_bytes.Length > data.Length + offset)
            {
                Buffer.BlockCopy(_bytes, 0, data, offset, data.Length);
            }
            else
            {
                Buffer.BlockCopy(_bytes, 0, data, offset, _bytes.Length);
            }
        }


        public void FromSpan(ref ReadOnlySpan<byte> data, int length)
        {
            _bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                _bytes[i] = data[i];
            }
        }

        public override bool Equals(object obj)
        {
            var bufferB = (BitBuffer) obj;
            return bufferB != null && _bytes.SequenceEqual(bufferB._bytes);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}