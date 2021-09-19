using System;
using System.IO;

namespace abLogger
{
    public class abFileLoggerConfiguration
    {   
        /// <summary>
        /// The folder or path where the lof file will be stored, defaults to application root
        /// </summary>
        public string filePath { get; set; } = @".\";

        /// <summary>
        /// The log file prefix between the date_{prefix}_log.txt  defaults to the AppDomain.CurrentDomain.FriendlyName
        /// </summary>
        public string filePrefix { get; set; } = AppDomain.CurrentDomain.FriendlyName;

        internal string fullLogName 
        { 
            get
            {
                return Path.Combine(filePath,
                        $"{DateTime.Now.ToString("yyyy-MM-dd")}_{filePrefix}_log.txt");
            }
        }
    }
}
