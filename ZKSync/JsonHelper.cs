using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading;
using Newtonsoft.Json;

namespace ZKSync
{
    public class JsonHelper
    {
        public static List<Profile> profiles = new List<Profile>();

        public static string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");

        public static void WriteJson()
        {
            string jsonString = JsonConvert.SerializeObject(profiles);
            File.WriteAllText(jsonPath, jsonString);
        }

        public static void ReadJson()
        {
            string jsonString = File.ReadAllText(jsonPath);
            profiles = JsonConvert.DeserializeObject<List<Profile>>(jsonString);
        }

        public static void WriteJsonToChromeProfile(string chromePath, Profile profile)
        {
            string jsonString = JsonConvert.SerializeObject(profile);
            File.WriteAllText(chromePath, jsonString);
        }

        // Change profile state in list
        public static void ChangeProfilesState(int[] selectedProfiles, string state)
        {
            foreach (int profileN in selectedProfiles)
            {
                Profile tempProfile = profiles[profileN];
                tempProfile.CurrentState = state;
                profiles[profileN] = tempProfile;
            }
        }
    }
}