using LiteDB;

using ServiceNowComparerLibrary.Modules.Static;
using ServiceNowComparerLibrary.Storage.Models;
using ServiceNowComparerLibrary.Storage.Modules.Interface;

namespace ServiceNowComparerLibrary.Storage.Modules.Instance;

public class UserHelper : IStorageDataHelper<User>
{
    private readonly ILiteCollection<User> _collection;

    public UserHelper(LiteDatabase storage)
    {
        _collection = storage.GetCollection<User>("users");
    }
    
    public User GetRecordById(int id)
    {
        return _collection.FindById(id);
    }

    public IEnumerable<User> GetRecordsByLabel(string searchTerm)
    {
        return _collection.FindAll().Where(x => x.Label.Equals(searchTerm));
    }

    public int InsertRecord(User record)
    {
        _collection.Insert(record);
        return _collection.FindOne(x => x.Equals(record)).Id;
    }

    public bool UpdateRecord(User record)
    {
        try
        {
            _collection.Update(record);
            return true;
        }
        catch (Exception e)
        {
            LogModule.WriteError(e.Message);
            return false;
        }
    }

    public bool DeleteRecord(int id)
    {
        try
        {
            _collection.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            LogModule.WriteError(e.Message);
            return false;
        }
    }
}