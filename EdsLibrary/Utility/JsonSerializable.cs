using Newtonsoft.Json;
using System.IO;

namespace EdsLibrary.Utility
{
    public abstract class JsonSerializable<T>
    {
        public void Save(string filePath)
        {
            Save(this, filePath);
        }

        public string ToJson() => ToJson(this);

        public static void Save(object obj, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.Write(ToJson(obj));
            }
        }

        public static T Load(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                T obj = FromJson(json);
                return obj;
            }
        }

        public static string ToJson(object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
