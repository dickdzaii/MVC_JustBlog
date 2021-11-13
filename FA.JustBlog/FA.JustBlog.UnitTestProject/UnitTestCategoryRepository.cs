using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System.Linq;

namespace FA.JustBlog.UnitTestProject
{
    [TestClass]
    public class UnitTestCategoryRepository
    {
        private readonly CategoryRepository categoryRepository;
        public UnitTestCategoryRepository()
        {
            categoryRepository = new CategoryRepository();
        }
        [TestMethod]
        public void TestGetAllCategory()
        {
            var listCategory = categoryRepository.GetAll();
            Assert.AreEqual(3, listCategory.ToList().Count);
        }
        [TestMethod]
        public void TestFind()
        {
            var found = categoryRepository.Find(1);
            var notFound = categoryRepository.Find(4);
            var invalid = categoryRepository.Find(int.Parse("cdc"));
            Assert.IsNotNull(found);
            Assert.IsNull(notFound);
            Assert.IsNull(invalid);
        }
        [TestMethod]
        public void TestCreate()
        {
            var numberofCategory = categoryRepository.GetAll().ToList().Count;
            var validCategory = new Category
            {
                CategoryName = "Star",
                Description = "description",
            };
            var specialCategory = new Category
            {
                CategoryName = "@#$%^&*()  (*&^%$#@",
                Description = "$%^&UJBVFTJK",
            };
            var maxLengthCategory = new Category
            {
                CategoryName = "12345678901234567890123456789012345678901234567890s",
                Description = "chdsc",
            };
            var invalidRequireCategory = new Category
            {
                Description = "dcdcd",
            };
            categoryRepository.Create(validCategory);
            numberofCategory++;
            Assert.AreEqual(numberofCategory, categoryRepository.GetAll().ToList().Count);
            categoryRepository.Create(specialCategory);
            Assert.AreEqual(numberofCategory, categoryRepository.GetAll().ToList().Count);
            categoryRepository.Create(maxLengthCategory);
            Assert.AreEqual(numberofCategory, categoryRepository.GetAll().ToList().Count);
            categoryRepository.Create(invalidRequireCategory);
            Assert.AreEqual(numberofCategory, categoryRepository.GetAll().ToList().Count);
        }
        [TestMethod]
        public void TestDelete()
        {
            var listCategory = categoryRepository.GetAll();
            categoryRepository.Delete(1);
            Assert.AreEqual(2, listCategory.ToList().Count);
            categoryRepository.Delete(4);
            Assert.AreEqual(2, listCategory.ToList().Count);
        }
    }
}
