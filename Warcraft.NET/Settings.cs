namespace Warcraft.NET
{
    public static class Settings
    {
        /// <summary>
        /// Logging verbosity. Default is LogLevel.None;
        /// </summary>
        public static LogLevel logLevel = LogLevel.None;

        /// <summary>
        /// Whether or not to throw on unknown chunk. Default is true;
        /// </summary>
        public static bool throwOnMissingChunk = true;
    }

    public enum LogLevel
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Debug = 4
    }
}
