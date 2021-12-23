using System.Collections;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
         Task<Product> Get(int id);
         Task<IEnumerable> GetAll();
         Task Add(Product product);
         Task Delete(int id);
         Task Update(Product product);
    }
}