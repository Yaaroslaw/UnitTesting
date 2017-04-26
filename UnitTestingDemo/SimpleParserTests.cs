using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo
{
    public class SimpleParserTests
    {
        public static void Test1()
        {
            SimpleParser parser = new SimpleParser();
            int result = parser.ParseAndSum(string.Empty);
            if (result != 0)
                throw new Exception("ParseAndSum should return 0, when passed empty string");
        }
    }
}
