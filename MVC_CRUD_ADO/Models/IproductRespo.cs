namespace MVC_CRUD_ADO.Models
{
    public interface IproductRespo
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        Product GetProductById(int id);
        void DeleteProductById(int id);
    }
}
