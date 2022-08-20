using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

// Ders notu: bir Manager sadece kendi Dal'ını enjekte alabilir

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductNameExists(product.ProductName),
                CheckIfCategoryExists(product.CategoryId),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId));

            if (result.Success == false)
                return result;

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ListedProducts);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.GetAll(p => p.ProductName == productName).Any())
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            return new SuccessResult();
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            if (_productDal.GetAll(p => p.CategoryId == categoryId).Count() >= 20)
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            return new SuccessResult();
        }

        private IResult CheckIfCategoryExists(int categoryId)
        {
            var dataResult = _categoryService.GetAll();
            if (dataResult.Success == false)
                return new ErrorResult(Messages.TechnicalErrorFirstPart + dataResult.Message);

            if (dataResult.Data.Select(c => c.CategoryId).Contains(categoryId) == false)
                return new ErrorResult(Messages.CategoryDoesNotExists);

            return new SuccessResult();
        }
    }
}