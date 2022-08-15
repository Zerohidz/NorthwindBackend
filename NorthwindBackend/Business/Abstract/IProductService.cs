using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);

        IDataResult<List<Product>> GetAll();

        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        IDataResult<Product> GetById(int productId);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}