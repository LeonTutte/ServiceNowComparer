using LiteDB;

namespace ServiceNowComparerLibrary.Storage.Models
{
    public class User
    {
        [BsonId]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Password { get; set; }

        public User(string nowUserId, string password, ServiceNowInstance nowInstance)
        {
            Label = nowUserId;
            Password = password; // TODO: needs to be encrypted
        }
    }
}