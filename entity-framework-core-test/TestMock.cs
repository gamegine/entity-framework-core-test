using entity_framework_core_test.Data;
using entity_framework_core_test.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace entity_framework_core_test
{
    public class TestMock
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Mock()
        {
            // Create some test data
            var data = new List<A> { new A() { Id = 1, AData = "test 1" } }.AsQueryable();

            // Create a mock set
            var mockSet= new Mock<DbSet<A>>();
            mockSet.As<IQueryable<A>>().Setup(e => e.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<A>>().Setup(e => e.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<A>>().Setup(e => e.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<A>>().Setup(e => e.GetEnumerator()).Returns(data.GetEnumerator());

            // Create a mock context
            var mockContext = new Mock<TestBddContext>();
            // add DbSet A -> mockSet
            mockContext.Setup(c => c.A).Returns(mockSet.Object);

            var context = mockContext.Object;

            // Test init
            Assert.AreEqual(context.A.ToList().Count(), 1);
            Assert.AreEqual(context.A.First().Id, 1);
            Assert.AreEqual(context.A.First().AData, "test 1");


            // Test add el
            var add = new A() { Id = 2, AData = "test 2" };
            var q = context.A.Add(add);
            context.SaveChanges();

            mockSet.Verify(e => e.Add(add), Times.Once());
            mockContext.Verify(e => e.SaveChanges(), Times.Once());
        }
    }
}