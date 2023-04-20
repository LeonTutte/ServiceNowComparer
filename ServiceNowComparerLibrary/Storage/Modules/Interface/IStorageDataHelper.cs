namespace ServiceNowComparerLibrary.Storage.Modules.Interface;

public interface IStorageDataHelper<T>
{
    T GetRecordById(int id);
    int InsertRecord(T record);
    bool UpdateRecord(T record);
    bool DeleteRecord(int id);
}