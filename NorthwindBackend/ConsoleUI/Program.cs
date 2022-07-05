using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

class Program
{
    private static void Main()
    {

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var productDetails in productManager.GetProductDetails())
        {
            Console.WriteLine(productDetails.ProductName + " / " + productDetails.CategoryName);
        }
    }
}