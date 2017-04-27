using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAndNotification
{
    public class LogAnalyzer
    {
        public bool IsLogFileNameValid (string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("File has to have a name!");

            else if (!fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
                return false;
            return true;
        }
    }
}
