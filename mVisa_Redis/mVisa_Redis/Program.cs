using System;
using System.Diagnostics;

namespace mVisa_Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://localhost:17000/");
            Process.Start("http://localhost:17000/");
            Console.ReadLine();
        }
    }
}
