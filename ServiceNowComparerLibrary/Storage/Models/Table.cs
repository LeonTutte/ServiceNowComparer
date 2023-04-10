using LiteDB;

namespace ServiceNowComparerLibrary.Storage.Models
{
    public class Table
    {
        [BsonId]
        public int Id { get; set; }
        public string Label { get; set; }
        [BsonRef("instances")]
        public ServiceNowInstance Instance { get; set; }
        public List<string>? Columns { get; set; }

        public Table(string label, ServiceNowInstance nowInstance)
        {
            Label = label;
            Instance = nowInstance;
        }
    }
}