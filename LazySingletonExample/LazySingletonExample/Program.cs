namespace LazySingletonExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Singleton s = Singleton.Instance;
                Console.WriteLine(s.Config.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}