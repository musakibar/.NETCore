namespace WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string mesage)
        {
            Console.WriteLine("[DbLogger] - " + mesage);
        }

    }

}