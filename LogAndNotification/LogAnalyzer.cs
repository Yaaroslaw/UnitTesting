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
            if (!fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
                return false;
            return true;
        }
    }
}
