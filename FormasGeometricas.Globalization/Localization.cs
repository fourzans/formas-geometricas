using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FormasGeometricas.Globalization
{
    public class Localization : ILocalization
    {
        private string Culture { get; set; } = "en-US";
        private Dictionary<string, string> Translations { get; set; }

        public Localization()
        {
            Translations = new Dictionary<string, string>();
            LoadLocalizationFile();
        }

        public string LocalizeString(string key)
        {
            if(this.Translations.ContainsKey(key))
                return this.Translations[key];
        
            return key;
        }

        public void SetCurrentCulture(string culture)
        {
            this.Culture = culture;
            LoadLocalizationFile();
        }

        private void LoadLocalizationFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FormasGeometricas.Globalization." + this.Culture + ".json";
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Translations\" + this.Culture + ".json");

            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }
    }
}
