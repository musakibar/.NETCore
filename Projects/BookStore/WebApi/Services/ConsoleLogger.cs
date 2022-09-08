namespace WebApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string mesage)
        {
            Console.WriteLine("[ConsoleLogger] - " + mesage);
        }

    }

}