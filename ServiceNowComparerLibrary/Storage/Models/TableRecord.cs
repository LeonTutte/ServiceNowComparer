using LiteDB;

namespace ServiceNowComparerLibrary.Storage.Models
{
    public class TableRecord
    {
        [BsonId]
        public UInt64 Id { get; set; }
        [BsonRef("tables")]
        public Table Table { get; set; }
        public string RecordData { get; set; }

        public TableRecord(Table table, string recordData)
        {
            Table = table;
            RecordData = recordData;
        }
    }
}