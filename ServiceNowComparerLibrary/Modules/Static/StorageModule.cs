using IniParser.Model;

using LiteDB;

namespace ServiceNowComparerLibrary.Modules.Static
{
    public static class StorageModule
    {
        /// <summary>
        /// Return the storage if password ist set and ini file is available
        /// </summary>
        /// <returns>LiteDatabase</returns>
        public static LiteDatabase GetStorage()
        {
            string connectionString = GetConnectionStringFromConfigurationFile();
            // TODO: do something with exception
            if (connectionString.Contains("000000")) throw new ArgumentException("Password is not set");
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            LogModule.WriteDebug($"Reading database from: {GetStoragePath()}");
            return new LiteDatabase(connectionString);
        }

        private static string GetConnectionStringFromConfigurationFile()
        {
            IniData data = ConfigurationModule.GetConfiguration();
            string filePath = Path.Combine(Environment.CurrentDirectory, data["Database"]["Filename"]);
            return $"Filename={filePath};Password={CryptoModule.StoragePassword}";
        }
        /// <summary>
        /// Returns the full paht to the storage file
        /// </summary>
        /// <returns>string</returns>
        public static string GetStoragePath()
        {
            IniData data = ConfigurationModule.GetConfiguration();
            return Path.Combine(Environment.CurrentDirectory, data["Database"]["Filename"]);
        }
    }
}