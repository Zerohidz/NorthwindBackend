using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator(ICategoryService categoryService)
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.CategoryId).Must(id =>
            {
                var dataResult = categoryService.GetAll();
                if (dataResult.Success == false)
                    return false;

                return dataResult.Data.Any(c => c.CategoryId == id);
            }).WithMessage(Messages.CategoryDoesNotExists);
        }
    }
}