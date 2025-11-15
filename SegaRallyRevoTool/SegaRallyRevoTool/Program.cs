using System;
using System.IO;
using System.IO.Compression;

namespace SegaRallyRevoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            String srcPath = @"D:\Hack\SEGAPC\SegaRallyRevo\git\sample\livery\livery36_data.sbf";
            string destPath = $@"{Path.GetDirectoryName(srcPath)}\{Path.GetFileNameWithoutExtension(srcPath)}_{Path.GetExtension(srcPath)}";
            using (FileStream srcFileStream = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
            using (FileStream destFileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            using (ZLibStream decompStream = new ZLibStream(srcFileStream, CompressionMode.Decompress))
            {
                byte[] bytes = new byte[4];
                srcFileStream.ReadExactly(bytes);
                uint magic = BitConverter.ToUInt32(bytes, 0x00);
                if (magic != 0x315A4253)
                {
                    return;
                }
                srcFileStream.ReadExactly(bytes);
                int decompressSize = BitConverter.ToInt32(bytes, 0x00);

                // decompress
                byte[] decompedData = new byte[decompressSize];
                decompStream.ReadExactly(decompedData, 0x00, decompressSize);
                destFileStream.Write(decompedData);
            }

            return;
        }
    }
}
