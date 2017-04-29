using System;

namespace LogAndNotification
{
    public class LogAnalyzer
    {
        public bool WasLastNameValid { get; set; }
        public bool IsLogFileNameValid (string fileName)
        {
            WasLastNameValid = false; // Change the state of the system
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("File has to have a name!");

            if (!fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
                return false;

            WasLastNameValid = true; // Change the state of the system
            return true;
        }
    }
}
