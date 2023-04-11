using IniParser;
using IniParser.Model;

namespace ServiceNowComparerLibrary.Modules.Static
{
    public class ConfigurationModule
    {
        public static IniData GetConfiguration()
    {
        var parser = new FileIniDataParser();
        IniData data = parser.ReadFile("settings.ini");
        return data;
    }
    }
}