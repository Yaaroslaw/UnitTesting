using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAndNotification
{
    public class MemCalculator
    {
        private int sum = 0;
        public int Add(int number)
        {
            return sum += number;
        }

        public int Sum()
        {
            int temp = sum;
            sum = 0;
            return temp;
        }
    }
}
