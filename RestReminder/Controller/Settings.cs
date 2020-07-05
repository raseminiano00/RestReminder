using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestReminder.Controller
{
    public class Settings
    {
        private static Settings localSetting;
        private string path;
        private Dictionary<string, string> iniValue;
        public Settings(string path)
        {
            if (File.Exists(path) == false)
                throw new Exception("File does not exists.");

            parseIniFile(path);
            this.path = path;
        }
        public static void initializeSettings(string path)
        {
            localSetting = new Settings(path);
        }
        private void parseIniFile(string path)
        {
            string[] fileValue;
            string currentSection;
            using (StreamReader sr = new StreamReader(path))
            {
                fileValue = sr.ReadToEnd().Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.None);
            }   
            //string[] lines = File.ReadAllLines(path);

            //foreach (string line in lines)
            //{
            //    if (line[0] == '[' || line[line.Length-1] == ']')
            //        if(section)

            //}
        }
        private string removeBrackets(string section)
        {
            return section.Trim().Remove('[').Remove(']');
        }
        public static Settings getSetting()
        {
            if (localSetting == null)
                throw new NullReferenceException("Settings not initialized yet");

            return localSetting;
        }

        public string getPath()
        {
            return path;
        }
    }
}
