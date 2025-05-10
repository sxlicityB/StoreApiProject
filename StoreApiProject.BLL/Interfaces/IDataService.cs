namespace StoreApiProject.BLL.Interfaces;

public interface IDataService
{
    public Task GenerateOrderAsync();
    public Task GenerateBuyerAsync();
    public Task GenerateProductAsync();
    public Task GenerateDataAsync();
    public Task ResetDatabaseAsync();
}
