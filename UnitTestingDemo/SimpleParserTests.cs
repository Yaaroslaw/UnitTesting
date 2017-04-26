using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo
{
    public class SimpleParserTests
    {
        public static void ShowProblem(string test, string message)
        {
            var  msg = string.Format(@"
            ---{0}---
            {1}
            --------------------", test, message);
            Console.WriteLine(msg);
        }

        public static void TestReturnsZeroWhenEmptyString()
        {
            try
            {
                SimpleParser parser = new SimpleParser();
                int result = parser.ParseAndSum(string.Empty);
                if (result != 0)
                {
                    ShowProblem("TestReturnsZeroWhenEmptyString", "ParseAndSum should return 0, when passed empty string");
                    //throw new Exception("***TestReturnsZeroWhenEmptyString : ParseAndSum should return 0, when passed empty string");
                }               
            }
            catch(Exception e)
            {
                ShowProblem("TestReturnsZeroWhenEmptyString", e.ToString());
            }

        }
    }
}
