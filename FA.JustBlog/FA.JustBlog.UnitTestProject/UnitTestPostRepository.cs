using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System.Linq;

namespace FA.JustBlog.UnitTestProject
{
    [TestClass]
    public class UnitTestPostRepository
    {
        private readonly PostRepository postRepository;
        public UnitTestPostRepository()
        {
            postRepository = new PostRepository();
        }
        [TestMethod]
        public void TestFindPost()
        {
            var found = postRepository.Find(1);
            var notFound = postRepository.Find(32);
            Assert.IsNotNull(found);
            Assert.IsNull(notFound);
        }
        [TestMethod]
        public void TestGetPublishedPost()
        {
            var publishedPosts = postRepository.GetPublishedPost();
            Assert.AreEqual(2, publishedPosts);
        }
        [TestMethod]
        public void TestGetUnpublishedPost()
        {
            var unpublishedPosts = postRepository.GetUnpublishedPost();
            Assert.AreEqual(1, unpublishedPosts);
        }
        [TestMethod]
        public void TestCountPostsForTag()
        {
            var found = postRepository.CountPostsForTag("abc");
            var notFound = postRepository.CountPostsForTag("acscsc%^&*(*&bc");
            Assert.AreEqual(2, found);
            Assert.AreEqual(0, notFound);
        }
        [TestMethod]
        public void TestCreatePost()
        {
            var numberOfPosts = postRepository.GetAll().ToList().Count;
            var validPost = new Post
            {
                Title = "chsfsd sdcdsch sdcsdc dcsdc",
                ShortDescription = @"cdjcjdc sdcjsdc dsc dsc dscsd",
                CategoryID = 1,
                PostContent = @"sdhcdscdcbsddsc csdch cds",
                Published = false,

            };
            postRepository.Create(validPost);
            numberOfPosts++;
            Assert.AreEqual(numberOfPosts, postRepository.GetAll().ToList().Count);
        }
    }
}
