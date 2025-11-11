using System;
using System.IO;

namespace SegaRallyRevoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            String path = "";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);



        }
    }
}
