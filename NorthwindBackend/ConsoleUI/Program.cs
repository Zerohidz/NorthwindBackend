using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

internal class Program
{
    private static void Main()
    {
        ProductTest();
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var category in categoryManager.GetAll().Data)
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

        var result = productManager.GetProductDetails();

        if (result.Success == true)
        {
            foreach (var productDetails in result.Data)
            {
                Console.WriteLine(productDetails.ProductName + " / " + productDetails.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}