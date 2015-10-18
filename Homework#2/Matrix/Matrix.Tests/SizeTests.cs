using NUnit.Framework;

namespace Matrix.Tests
{
    public class SizeTests
    {
        [Test]
        public void WidthProperty_Always_ReturnsWidth()
        {
            var size = new Size(1, 2);

            Assert.AreEqual(1, size.Width);
        }

        [Test]
        public void HeightProperty_Always_ReturnsHeight()
        {
            var size = new Size(1, 2);

            Assert.AreEqual(2, size.Height);
        }

        [Test]
        public void IsSquare_WhenHeightIsTheSameAsWidth_ReturnsTrue()
        {
            var size = new Size(1, 1);

            Assert.IsTrue(size.IsSquare);
        }

        [Test]
        public void IsSquare_WhenHeightAndWidthAreDifferent_ReturnsFalse()
        {
            var size = new Size(1, 2);

            Assert.IsFalse(size.IsSquare);
        }

        [Test]
        public void EqualsOperator_WhenHeightIsTheSameAsWidth_ReturnsTrue()
        {
            var sizeA = new Size(1, 1);
            var sizeB = new Size(1, 1);

            Assert.IsTrue(sizeA == sizeB);
        }

        [Test]
        public void EqualsOperator_WhenHeightAndWidthAreDifferent_ReturnsFalse()
        {
            var sizeA = new Size(1, 1);
            var sizeB = new Size(1, 2);
            var sizeC = new Size(2, 1);

            Assert.IsFalse(sizeA == sizeB);
            Assert.IsFalse(sizeA == sizeC);
            Assert.IsFalse(sizeB == sizeC);
        }

        [Test]
        public void EqualsOperator_ForTheSameObject_ReturnsTrue()
        {
            var size = new Size(1, 2);

            Assert.IsTrue(size == size);
        }

        [Test]
        public void EqualsOperator_ForNull_ReturnsFalse()
        {
            var size = new Size(1, 2);

            Assert.IsFalse(size == null);
        }

        [Test]
        public void GetHashCode_ForEqualObjects_IsTheSame()
        {
            var size1 = new Size(1, 1);
            var size2 = new Size(1, 1);

            Assert.AreEqual(size1, size2);
            Assert.AreEqual(size1.GetHashCode(), size2.GetHashCode());
        }
    }
}