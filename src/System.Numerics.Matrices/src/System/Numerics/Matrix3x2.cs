// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Runtime.InteropServices;

namespace System.Numerics.Matrices
{
    /// <summary>
    /// Represents a matrix of double precision floating-point values defined by its number of columns and rows
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x2: IEquatable<Matrix3x2>, IMatrix
    {
        public const int ColumnCount = 3;
        public const int RowCount = 2;

        static Matrix3x2()
        {
            Zero = new Matrix3x2(0);
        }

        /// <summary>
        /// Gets the smallest value used to determine equality
        /// </summary>
        public double Epsilon { get { return MatrixHelper.Epsilon; } }

        /// <summary>
        /// Constant Matrix3x2 with all values initialized to zero
        /// </summary>
        public static readonly Matrix3x2 Zero;

        /// <summary>
        /// Initializes a Matrix3x2 with all of it values specifically set
        /// </summary>
        /// <param name="m11">The column 1, row 1 value</param>
        /// <param name="m21">The column 2, row 1 value</param>
        /// <param name="m31">The column 3, row 1 value</param>
        /// <param name="m12">The column 1, row 2 value</param>
        /// <param name="m22">The column 2, row 2 value</param>
        /// <param name="m32">The column 3, row 2 value</param>
        public Matrix3x2(double m11, double m21, double m31, 
                         double m12, double m22, double m32)
        {
            M11 = m11; M21 = m21; M31 = m31; 
            M12 = m12; M22 = m22; M32 = m32; 
        }

        /// <summary>
        /// Initialized a Matrix3x2 with all values set to the same value
        /// </summary>
        /// <param name="value">The value to set all values to</param>
        public Matrix3x2(double value)
        {
            M11 = M21 = M31 = 
            M12 = M22 = M32 = value;
        }

        public double M11;
        public double M21;
        public double M31;
        public double M12;
        public double M22;
        public double M32;

        public unsafe double this[int col, int row]
        {
            get
            {
                if (col < 0 || col >= ColumnCount)
                    throw new ArgumentOutOfRangeException("col", String.Format("Expected greater than or equal to 0 and less than {0}, found {1}.", ColumnCount, col));
                if (row < 0 || row >= RowCount)
                    throw new ArgumentOutOfRangeException("row", String.Format("Expected greater than or equal to 0 and less than {0}, found {1}.", RowCount, row));

                fixed (Matrix3x2* p = &this)
                {
                    double* d = (double*)p;
                    return d[row * ColumnCount + col];
                }
            }
            set
            {
                if (col < 0 || col >= ColumnCount)
                    throw new ArgumentOutOfRangeException("col", String.Format("Expected greater than or equal to 0 and less than {0}, found {1}.", ColumnCount, col));
                if (row < 0 || row >= RowCount)
                    throw new ArgumentOutOfRangeException("row", String.Format("Expected greater than or equal to 0 and less than {0}, found {1}.", RowCount, row));

                fixed (Matrix3x2* p = &this)
                {
                    double* d = (double*)p;
                    d[row * ColumnCount + col] = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of columns in the matrix
        /// </summary>
        public int Columns { get { return ColumnCount; } }
        /// <summary>
        /// Get the number of rows in the matrix
        /// </summary>
        public int Rows { get { return RowCount; } }

        /// <summary>
        /// Gets a new Matrix1x2 containing the values of column 1
        /// </summary>
        public Matrix1x2 Column1 { get { return new Matrix1x2(M11, M12); } }
        /// <summary>
        /// Gets a new Matrix1x2 containing the values of column 2
        /// </summary>
        public Matrix1x2 Column2 { get { return new Matrix1x2(M21, M22); } }
        /// <summary>
        /// Gets a new Matrix1x2 containing the values of column 3
        /// </summary>
        public Matrix1x2 Column3 { get { return new Matrix1x2(M31, M32); } }
        /// <summary>
        /// Gets a new Matrix3x1 containing the values of column 1
        /// </summary>
        public Matrix3x1 Row1 { get { return new Matrix3x1(M11, M21, M31); } }
        /// <summary>
        /// Gets a new Matrix3x1 containing the values of column 2
        /// </summary>
        public Matrix3x1 Row2 { get { return new Matrix3x1(M12, M22, M32); } }

        public override bool Equals(object obj)
        {
            if (obj is Matrix3x2)
                return this == (Matrix3x2)obj;

            return false;
        }

        public bool Equals(Matrix3x2 other)
        {
            return this == other;
        }

        public unsafe override int GetHashCode()
        {
            fixed (Matrix3x2* p = &this)
            {
                int* x = (int*)p;
                unchecked
                {
                    return 0xFFE1
                         + 7 * ((((x[00] ^ x[01]) << 0) + ((x[02] ^ x[03]) << 1) + ((x[04] ^ x[05]) << 2)) << 0)
                         + 7 * ((((x[03] ^ x[04]) << 0) + ((x[05] ^ x[06]) << 1) + ((x[07] ^ x[08]) << 2)) << 1);
                }
            }
        }

        public override string ToString()
        {
            return "Matrix3x2: "
                 + String.Format("{{|{0:00}|{1:00}|{2:00}|}}", M11, M21, M31)
                 + String.Format("{{|{0:00}|{1:00}|{2:00}|}}", M12, M22, M32); 
        }

        /// <summary>
        /// Creates and returns a transposed matrix
        /// </summary>
        /// <returns>Matrix with transposed values</returns>
        public Matrix2x3 Transpose()
        {
            return new Matrix2x3(M11, M12, 
                                 M21, M22, 
                                 M31, M32);
        }

        public static bool operator ==(Matrix3x2 matrix1, Matrix3x2 matrix2)
        {
            return MatrixHelper.AreEqual(matrix1.M11, matrix2.M11)
                && MatrixHelper.AreEqual(matrix1.M21, matrix2.M21)
                && MatrixHelper.AreEqual(matrix1.M31, matrix2.M31)
                && MatrixHelper.AreEqual(matrix1.M12, matrix2.M12)
                && MatrixHelper.AreEqual(matrix1.M22, matrix2.M22)
                && MatrixHelper.AreEqual(matrix1.M32, matrix2.M32);
        }

        public static bool operator !=(Matrix3x2 matrix1, Matrix3x2 matrix2)
        {
            return MatrixHelper.NotEqual(matrix1.M11, matrix2.M11)
                || MatrixHelper.NotEqual(matrix1.M21, matrix2.M21)
                || MatrixHelper.NotEqual(matrix1.M31, matrix2.M31)
                || MatrixHelper.NotEqual(matrix1.M12, matrix2.M12)
                || MatrixHelper.NotEqual(matrix1.M22, matrix2.M22)
                || MatrixHelper.NotEqual(matrix1.M32, matrix2.M32);
        }

        public static Matrix3x2 operator +(Matrix3x2 matrix1, Matrix3x2 matrix2)
        {
            double m11 = matrix1.M11 + matrix2.M11;
            double m21 = matrix1.M21 + matrix2.M21;
            double m31 = matrix1.M31 + matrix2.M31;
            double m12 = matrix1.M12 + matrix2.M12;
            double m22 = matrix1.M22 + matrix2.M22;
            double m32 = matrix1.M32 + matrix2.M32;

            return new Matrix3x2(m11, m21, m31, 
                                 m12, m22, m32);
        }

        public static Matrix3x2 operator -(Matrix3x2 matrix1, Matrix3x2 matrix2)
        {
            double m11 = matrix1.M11 - matrix2.M11;
            double m21 = matrix1.M21 - matrix2.M21;
            double m31 = matrix1.M31 - matrix2.M31;
            double m12 = matrix1.M12 - matrix2.M12;
            double m22 = matrix1.M22 - matrix2.M22;
            double m32 = matrix1.M32 - matrix2.M32;

            return new Matrix3x2(m11, m21, m31, 
                                 m12, m22, m32);
        }

        public static Matrix3x2 operator *(Matrix3x2 matrix, double scalar)
        {
            double m11 = matrix.M11 * scalar;
            double m21 = matrix.M21 * scalar;
            double m31 = matrix.M31 * scalar;
            double m12 = matrix.M12 * scalar;
            double m22 = matrix.M22 * scalar;
            double m32 = matrix.M32 * scalar;

            return new Matrix3x2(m11, m21, m31, 
                                 m12, m22, m32);
        }

        public static Matrix3x2 operator *(double scalar, Matrix3x2 matrix)
        {
            double m11 = scalar * matrix.M11;
            double m21 = scalar * matrix.M21;
            double m31 = scalar * matrix.M31;
            double m12 = scalar * matrix.M12;
            double m22 = scalar * matrix.M22;
            double m32 = scalar * matrix.M32;

            return new Matrix3x2(m11, m21, m31, 
                                 m12, m22, m32);
        }

        public static Matrix1x2 operator *(Matrix3x2 matrix1, Matrix1x3 matrix2)
        {
            double m11 = matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12 + matrix1.M31 * matrix2.M13;
            double m12 = matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12 + matrix1.M32 * matrix2.M13;

            return new Matrix1x2(m11, 
                                 m12);
        }
        public static Matrix2x2 operator *(Matrix3x2 matrix1, Matrix2x3 matrix2)
        {
            double m11 = matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12 + matrix1.M31 * matrix2.M13;
            double m21 = matrix1.M11 * matrix2.M21 + matrix1.M21 * matrix2.M22 + matrix1.M31 * matrix2.M23;
            double m12 = matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12 + matrix1.M32 * matrix2.M13;
            double m22 = matrix1.M12 * matrix2.M21 + matrix1.M22 * matrix2.M22 + matrix1.M32 * matrix2.M23;

            return new Matrix2x2(m11, m21, 
                                 m12, m22);
        }
        public static Matrix3x2 operator *(Matrix3x2 matrix1, Matrix3x3 matrix2)
        {
            double m11 = matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12 + matrix1.M31 * matrix2.M13;
            double m21 = matrix1.M11 * matrix2.M21 + matrix1.M21 * matrix2.M22 + matrix1.M31 * matrix2.M23;
            double m31 = matrix1.M11 * matrix2.M31 + matrix1.M21 * matrix2.M32 + matrix1.M31 * matrix2.M33;
            double m12 = matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12 + matrix1.M32 * matrix2.M13;
            double m22 = matrix1.M12 * matrix2.M21 + matrix1.M22 * matrix2.M22 + matrix1.M32 * matrix2.M23;
            double m32 = matrix1.M12 * matrix2.M31 + matrix1.M22 * matrix2.M32 + matrix1.M32 * matrix2.M33;

            return new Matrix3x2(m11, m21, m31, 
                                 m12, m22, m32);
        }
        public static Matrix4x2 operator *(Matrix3x2 matrix1, Matrix4x3 matrix2)
        {
            double m11 = matrix1.M11 * matrix2.M11 + matrix1.M21 * matrix2.M12 + matrix1.M31 * matrix2.M13;
            double m21 = matrix1.M11 * matrix2.M21 + matrix1.M21 * matrix2.M22 + matrix1.M31 * matrix2.M23;
            double m31 = matrix1.M11 * matrix2.M31 + matrix1.M21 * matrix2.M32 + matrix1.M31 * matrix2.M33;
            double m41 = matrix1.M11 * matrix2.M41 + matrix1.M21 * matrix2.M42 + matrix1.M31 * matrix2.M43;
            double m12 = matrix1.M12 * matrix2.M11 + matrix1.M22 * matrix2.M12 + matrix1.M32 * matrix2.M13;
            double m22 = matrix1.M12 * matrix2.M21 + matrix1.M22 * matrix2.M22 + matrix1.M32 * matrix2.M23;
            double m32 = matrix1.M12 * matrix2.M31 + matrix1.M22 * matrix2.M32 + matrix1.M32 * matrix2.M33;
            double m42 = matrix1.M12 * matrix2.M41 + matrix1.M22 * matrix2.M42 + matrix1.M32 * matrix2.M43;

            return new Matrix4x2(m11, m21, m31, m41, 
                                 m12, m22, m32, m42);
        }
    }
}
