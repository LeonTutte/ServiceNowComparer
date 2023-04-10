using LiteDB;

namespace ServiceNowComparerLibrary.Storage.Models
{
    public class ServiceNowInstance
    {
        [BsonId]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        [BsonRef("users")]
        public User? User { get; set; }

        public ServiceNowInstance(string label, string url)
        {
            Label = label;
            Url = url;
        }
    }
}