namespace LazySingletonExample
{
    public interface IConfigProvider
    {
        Config? Provide(string path);
    }
}
