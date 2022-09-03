using System.Diagnostics;

namespace Core.Log.Middlewares.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Debug.WriteLine("[DBLogger] -  " + message);
        }
    }
}