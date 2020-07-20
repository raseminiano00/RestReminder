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
        private Dictionary<string, string> settingsValue;
        private List<string> sections;
        public Settings(string[] iniValue)
        {
            this.settingsValue = new Dictionary<string, string>();
            this.sections = new List<string>();
            parseIniFile(iniValue);
        }
        public static void initializeSettings(string[] iniValue)
        {
            localSetting = new Settings(iniValue);
        }
        private void parseIniFile(string[] path)
        {
            string currentSection = "";
            string[] lines = path;
            string key;
            foreach (string line in lines)
            {
                if (IsSection(line))
                {
                    if (sections.Contains(removeBrackets(line)))
                        throw new Exception("Detected duplicate section name '" + currentSection + "'");

                    if (currentSection != line)
                    {
                        currentSection = removeBrackets(line);
                        sections.Add(currentSection);
                        continue;
                    }
                }
                else
                {
                    key = getKey(line);
                    if (IsSectionKeyExists(currentSection + key) == true)
                        throw new Exception("Detected duplicate key at section '"+ currentSection + "'");
                    else
                        settingsValue.Add(currentSection + key, getValue(line));
                }
            }
        }
        private bool IsSection(string line)
        {
            return (line[0] == '[' || line[line.Length - 1] == ']');
        }
        private string getKey(string value)
        {
            return value.Remove(value.LastIndexOf('='), (value.Length ) - value.LastIndexOf('='));
        }
        private string getValue(string value)
        {
            return value.Substring(value.LastIndexOf('=')+1);
        }
        private string removeBrackets(string section)
        {
            return section.Remove(section.Length - 1,1).Remove(0,1);
        }
        public static Settings getSetting()
        {
            IsInitialized();

            return localSetting;
        }
        public string getSettings(string section,string key,string defaultValue)
        {
            if (localSetting == null)
                throw new NullReferenceException("Settings not initialized yet");

            if (IsSectionKeyExists(section+key) == false)
                return defaultValue;

            return settingsValue[section + key];
        }
        private bool IsSectionKeyExists(string sectionKey)
        {
            return settingsValue.ContainsKey(sectionKey);
        }

        private static bool IsInitialized()
        {
            if (localSetting == null)
                throw new NullReferenceException("Settings not initialized yet");

            return true;
        }
    }
}
