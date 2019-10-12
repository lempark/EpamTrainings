using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileTasks;
using System.IO;



namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input n_" );
            int n = int.Parse(Console.ReadLine());
            //Console.WriteLine((Month)n);
            Directory.CreateDirectory("NewDirectory/dir1");
            Console.Read();
        }
    }
}
