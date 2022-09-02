using System.Diagnostics;

namespace Core.Log.Middlewares.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Debug.WriteLine("[ConsoleLogger] -  " + message);
        }
    }
}