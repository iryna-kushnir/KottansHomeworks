using System;
using System.Text;

namespace Matrix
{
    public class CoolMatrix
    {
        private readonly int[,] _matrix;

        public CoolMatrix(int[,] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr), "Can't create matrix from null array");
            _matrix = arr;
            Size = new Size(arr.GetLength(0), arr.GetLength(1));
        }

        public Size Size { get; }

        public bool IsSquare => Size.IsSquare;

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size.Width)
                {
                    throw new IndexOutOfRangeException(nameof(i));
                }
                if (j < 0 || j >= Size.Height)
                {
                    throw new IndexOutOfRangeException(nameof(j));
                }
                return _matrix[i, j];
            }
        }

        public static implicit operator CoolMatrix(int[,] arr)
        {
            return new CoolMatrix(arr);
        }

        public override string ToString()
        {
            var matrixString = new StringBuilder();
            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    if (j == 0) matrixString.Append("[");
                    matrixString.Append(_matrix[i, j]);
                    if (j != Size.Height - 1) matrixString.Append(", ");
                    else
                    {
                        matrixString.Append("]");
                    }
                }
                if (i != Size.Width - 1) matrixString.AppendLine();
            }
            return matrixString.ToString();
        }

        protected bool Equals(CoolMatrix other)
        {
            if (Size != other.Size) return false;
            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    if (this[i, j] != other[i, j]) return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CoolMatrix) obj);
        }

        public override int GetHashCode()
        {
            int code = 0;
            for (var i = 0; i < Size.Width; i++)
            {
                for (var j = 0; j < Size.Height; j++)
                {
                    code = code ^ this[i, j];
                }
            }
            return code ^ Size.GetHashCode();
        }

        public static bool operator ==(CoolMatrix matrix1, CoolMatrix matrix2)
        {
            return Equals(matrix1, matrix2);
        }

        public static bool operator !=(CoolMatrix matrix1, CoolMatrix matrix2)
        {
            return !Equals(matrix1, matrix2);
        }

        public static CoolMatrix operator *(CoolMatrix matrix, int scalar)
        {
            var width = matrix.Size.Width;
            var heigh = matrix.Size.Height;
            var resulArr = new int[width, heigh];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < heigh; j++)
                {
                    resulArr[i, j] = matrix[i, j]*scalar;
                }
            }
            return new CoolMatrix(resulArr);
        }

        public static CoolMatrix operator +(CoolMatrix matrix1, CoolMatrix matrix2)
        {
            if (matrix1.Size != matrix2.Size) throw new ArgumentException("Can't add matrixes of different sizes");
            var width = matrix1.Size.Width;
            var heigh = matrix1.Size.Height;
            var resulArr = new int[width, heigh];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < heigh; j++)
                {
                    resulArr[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return new CoolMatrix(resulArr);
        }

        public CoolMatrix Transpose()
        {
            var width = Size.Width;
            var heigh = Size.Height;
            var resulArr = new int[heigh, width];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < heigh; j++)
                {
                    resulArr[j, i] = this[i, j];
                }
            }
            return new CoolMatrix(resulArr);
        }
    }
}