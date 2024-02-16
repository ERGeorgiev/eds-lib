using System.Text.Json;

namespace EdsLibrary.Utility
{
    public abstract class JsonSerializable<T>
    {
        public static JsonSerializerOptions SharedJsonSerializerOptions = new() { WriteIndented = true };

        public void Save(string filePath)
        {
            Save(this, filePath);
        }

        public string ToJson() => ToJson(this);

        public static void Save(object obj, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, ToJson(obj));
        }

        public static T? Load(string filePath)
        {
            T? obj = FromJson(File.ReadAllText(filePath));
            return obj;
        }

        public static string ToJson(object obj) => JsonSerializer.Serialize(obj, SharedJsonSerializerOptions);

        public static T? FromJson(string json) => JsonSerializer.Deserialize<T>(json, SharedJsonSerializerOptions);
    }
}
