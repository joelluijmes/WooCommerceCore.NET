using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace WooCommerceCore.NET
{
    internal sealed class LogManager
    {
        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory();

        public static ILogger GetCurrentClassLogger([CallerFilePath] string path = "") =>
            _loggerFactory.CreateLogger(Path.GetFileNameWithoutExtension(path));
    }
}
