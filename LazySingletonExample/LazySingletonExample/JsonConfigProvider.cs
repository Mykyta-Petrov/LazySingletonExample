using System.Text.Json;

namespace LazySingletonExample
{
    public class JsonConfigProvider : IConfigProvider
    {
        public Config? Provide(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    return JsonSerializer.Deserialize<Config>(fs);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
