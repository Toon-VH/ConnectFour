using ForOnARow.core;
using NUnit.Framework;

namespace ForOnARow.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(2));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(2));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(2));
            Assert.IsTrue(forOnARow.Validate(1));
        }

        [Test]
        public void Test2()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsTrue(forOnARow.Validate(4));
        }

        [Test]
        public void Test3()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
            Assert.IsFalse(forOnARow.Validate(7));
            Assert.IsFalse(forOnARow.Validate(6));
            Assert.IsFalse(forOnARow.Validate(7));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(7));
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsTrue(forOnARow.Validate(7));
        }

        [Test]
        public void Test4()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(2));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(3));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsTrue(forOnARow.Validate(4));
        }

        [Test]
        public void Test5()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsFalse(forOnARow.Validate(6));
            Assert.IsFalse(forOnARow.Validate(1));
            Assert.IsTrue(forOnARow.Validate(7));
        }
        
        [Test]
        public void Test6()
        {
            ForOnARowEngine forOnARow = new ForOnARowEngine();
           
            
            Assert.IsFalse(forOnARow.Validate(3));
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(4));
            Assert.IsFalse(forOnARow.Validate(3));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(5));
            Assert.IsFalse(forOnARow.Validate(6));
            Assert.IsFalse(forOnARow.Validate(6));
            Assert.IsFalse(forOnARow.Validate(6));
            Assert.IsTrue(forOnARow.Validate(6));
        }
    }
}