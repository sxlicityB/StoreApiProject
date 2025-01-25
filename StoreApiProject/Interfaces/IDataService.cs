namespace StoreApiProject.Interfaces
{
    public interface IDataService
    {
        public Task GenerateOrder();
        public Task GenerateBuyer();
        public Task GenerateProduct();
        public Task GenerateData();
        public Task ResetDatabase();
    }
}
