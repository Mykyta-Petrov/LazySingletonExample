namespace LazySingletonExample
{
    public sealed class Singleton
    {
        private static Singleton? _instance = null;

        private static readonly object _instanceLock = new object();

        public Config Config { get; init; }

        private Singleton(IConfigProvider configProvider)
        {
            Config? config = configProvider.Provide(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "config.json"));
            
            if (config == null)
            {
                config = configProvider.Provide(Path.Combine(Environment.CurrentDirectory, "config.json"));
            }

            if (config == null)
            {
                throw new FileNotFoundException("Config not found.");
            }

            Config = config;
        }

        public static Singleton Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton(new JsonConfigProvider());
                    }

                    return _instance;
                }
            }
        }
    }
}
