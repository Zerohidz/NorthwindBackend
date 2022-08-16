using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            // Business codes

            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.ListedCategories);
        }

        public IDataResult<Category> GetById(int id)
        {
            // Business codes

            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
        }
    }
}