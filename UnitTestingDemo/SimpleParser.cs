using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDemo
{
    public class SimpleParser
    {
        public int ParseAndSum(string numbers)
        {
            if (numbers.Length == 0)
                return 0;
            else if (!numbers.Contains(","))
                return int.Parse(numbers);
            else
                throw new NotImplementedException("Wright now can only parse zero or one number");
               
        }
    }
}
