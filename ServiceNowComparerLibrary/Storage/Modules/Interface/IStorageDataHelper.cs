namespace ServiceNowComparerLibrary.Storage.Modules.Interface;

public interface IStorageDataHelper<T>
{
    T GetRecordById(int id);
    IEnumerable<T> GetRecordsByLabel(string searchTerm);
    int InsertRecord(T record);
    bool UpdateRecord(T record);
    bool DeleteRecord(int id);
}