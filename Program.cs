// Base functions:

void InitRandomIntMatrix(int[,] matrix, int min = 0, int max = 100)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
            matrix[i, j] = new Random().Next(min, max);
    }
}
void PrintArray(double[] arr)
{
    foreach (double i in arr)
        Console.Write(i + " ");
    Console.WriteLine();
}

void PrintMatrix(double[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
            Console.Write(matrix[i, j] + " ");
        Console.WriteLine();
    }
}

void PrintIntMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
            Console.Write(matrix[i, j] + " ");
        Console.WriteLine();
    }
}

//Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

void SortRows(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int tmp;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
            for (int k = 0; k < cols - 1; k++)
                if (matrix[i, k] < matrix[i, k+1])
                {
                    tmp = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = tmp;
                }
    }
}

int[,] newArr = new int[3, 4];
InitRandomIntMatrix(newArr);
PrintIntMatrix(newArr);
SortRows(newArr);
Console.WriteLine();
PrintIntMatrix(newArr);


