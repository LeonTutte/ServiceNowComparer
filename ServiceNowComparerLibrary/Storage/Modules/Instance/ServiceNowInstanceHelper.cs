using LiteDB;

using ServiceNowComparerLibrary.Storage.Models;
using ServiceNowComparerLibrary.Storage.Modules.Interface;

namespace ServiceNowComparerLibrary.Storage.Modules.Instance;

public class ServiceNowInstanceHelper :IStorageDataHelper<ServiceNowInstance>
{
    private readonly ILiteCollection<ServiceNowInstance> _collection;

    public ServiceNowInstanceHelper(LiteDatabase storage)
    {
        _collection = storage.GetCollection<ServiceNowInstance>("instances");
    }
    public ServiceNowInstance GetRecordById(int id)
    {
        return _collection.FindById(id);
    }

    public IEnumerable<ServiceNowInstance> GetRecordsByLabel(string searchTerm)
    {
        return _collection.FindAll().Where(x => x.Label.Equals(searchTerm));
    }

    public int InsertRecord(ServiceNowInstance record)
    {
        _collection.Insert(record);
        return _collection.FindOne(x => x.Equals(record)).Id;
    }

    public bool UpdateRecord(ServiceNowInstance record)
    {
        try
        {
            _collection.Update(record);
            return true;
        }
        catch (Exception e)
        {
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
            return false;
        }
    }
}