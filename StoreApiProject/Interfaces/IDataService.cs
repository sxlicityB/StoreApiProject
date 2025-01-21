namespace StoreApiProject.Interfaces
{
    public interface IDataService
    {
        public Task GenerateOrder();
        public void GenerateBuyer();
        public void GenerateProduct();
        public void GenerateData();
        public void ResetDatabase();
    }
}
