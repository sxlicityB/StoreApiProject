using StoreApiProject.Domain.Models;

namespace StoreApiProject.DAL.Interfaces
{
    public interface IDataRepository
    {
        public Task GenerateOrderAsync();
        public Task GenerateBuyerAsync();
        public Task GenerateProductAsync();
        public Task GenerateDataAsync();
        public Task GenerateAppUserAsync();
        public Task ResetDatabaseAsync();
    }
}
