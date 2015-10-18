using System.Security.Cryptography;

namespace Matrix
{
    public class Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
        public bool IsSquare => Width == Height;

        protected bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Size) obj);
        }

        public override int GetHashCode()
        {
            return Width ^ Height;
        }

        public static bool operator ==(Size size1, Size size2)
        {
            return Equals(size1, size2);
        }

        public static bool operator !=(Size size1, Size size2)
        {
            return !Equals(size1, size2);
        }
    }
}