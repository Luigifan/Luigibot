﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luigibot2
{
    public class Settings
    {

        public SettingsObject settings = new SettingsObject();

        public Settings()
        {
            
        }

        public void LoadSettings()
        {
			if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "settings.json"))
            {
                JsonSerializer js = new JsonSerializer();
                js.Formatting = Formatting.Indented;
				using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "settings.json"))
                {
                    using (JsonReader jsr = new JsonTextReader(sr))
                    {
                        this.settings = js.Deserialize<SettingsObject>(jsr);
                    }
                }
            }
            else
            {
                Console.WriteLine("No settings, loading defaults");
                settings.EightballEnabled = true;
                settings.SlapEnabled = true;
                settings.WelcomeUserEnabled = true;
				settings.SeenEnabled = true;
                settings.NickServPass = "";
                settings.UsersAllowedToDisable = new List<string> { "luigifan2010", "ghosthawk", "aeromatter", "joey" };
                settings.LastJoinedChannel = "#luigibot";
                settings.LastJoinedServer = "irc.swiftirc.net";
                settings.LastUsedNick = "Luigibot";
            }
        }

        public void WriteSettings()
        {
            JsonSerializer js = new JsonSerializer();
            js.Formatting = Formatting.Indented;

			using(StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "settings.json"))
            {
                using(JsonWriter jsw = new JsonTextWriter(sw))
                {
                    js.Serialize(jsw, this.settings);
                }
            }
        }

    }
}
