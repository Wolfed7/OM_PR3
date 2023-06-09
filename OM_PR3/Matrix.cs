﻿namespace OM_PR3;

public class Matrix
{
   private readonly double[,] A;

   public double this[int i, int j]
   {
      get => A[i, j];
      set => A[i, j] = value;
   }

   public int Size { get; init; }

   public Matrix(int size)
   {
      A = new double[size, size];
      Size = size;
   }

   public void Clear()
   {
      for (int i = 0; i < Size; i++)
         for (int j = 0; j < Size; j++)
            A[i, j] = 0;
   }

   public static PointND operator *(Matrix matrix, PointND vector)
   {
      PointND result = new(matrix.Size);

      for (int i = 0; i < matrix.Size; i++)
         for (int j = 0; j < matrix.Size; j++)
            result[i] += matrix[i, j] * vector[j];

      return result;
   }

   public static Matrix operator /(Matrix matrix, double constant)
   {
      for (int i = 0; i < matrix.Size; i++)
         for (int j = 0; j < matrix.Size; j++)
            matrix[i, j] /= constant;

      return matrix;
   }

   public static Matrix operator +(Matrix fstMatrix, Matrix sndMatrix)
   {
      Matrix result = new(fstMatrix.Size);

      for (int i = 0; i < result.Size; i++)
         for (int j = 0; j < result.Size; j++)
            result[i, j] = fstMatrix[i, j] + sndMatrix[i, j];

      return result;
   }

   public static Matrix operator -(Matrix matrix)
   {
      Matrix newMatrix = new(matrix.Size);

      for (int i = 0; i < matrix.Size; i++)
         for (int j = 0; j < matrix.Size; j++)
            newMatrix[i, j] = -matrix[i, j];

      return newMatrix;
   }

   public override string ToString()
   {
      string result = "";

      for (int i = 0; i < Size; i++)
         for (int j = 0; j < Size; j++)
         {
            result += A[i, j];
            result += " ";
         }

      return result;
   }
}