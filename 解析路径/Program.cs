using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解析路径
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayPathParts("D:\\干活\\psr1\\20180602.csv");
        }

        ///<summary>
        /// 解析路径方法
        /// </summary>
        public static void DisplayPathParts(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            string root = Path.GetPathRoot(path);
            string dirName = Path.GetDirectoryName(path);
            string fullFileName = Path.GetFileName(path);
            string fileExt = Path.GetExtension(path);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(path);
            StringBuilder format = new StringBuilder();
            format.Append($"ParsePath of {root} breaks up into the following pieces:" + $"{Environment.NewLine}");
            format.Append($"\tRoot:{root}{Environment.NewLine}");
            format.Append($"\tDirectory Name: {dirName}{Environment.NewLine}");
            format.Append($"\tFull File Name: {fullFileName}{Environment.NewLine}");
            format.Append($"\tFile Extension: {fileExt}{Environment.NewLine}");
            format.Append($"\tFile Name Without Extension: {fileNameWithoutExt}{Environment.NewLine}");
            Console.WriteLine(format.ToString());
            Console.ReadLine();
        }
    }
}
