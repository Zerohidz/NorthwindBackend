using Business.Abstract;
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

        public List<Category> GetAll()
        {
            // Business codes

            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            // Business codes

            return _categoryDal.Get(c => c.CategoryId == id);
        }
    }
}