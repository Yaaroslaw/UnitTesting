using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleParserTests.Test1();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }       
        }
    }
}
