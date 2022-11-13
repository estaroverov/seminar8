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
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    tmp = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = tmp;
                }
    }
}

int[,] newArr = new int[4, 3];
InitRandomIntMatrix(newArr);
PrintIntMatrix(newArr);
SortRows(newArr);
Console.WriteLine();
PrintIntMatrix(newArr);

// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
int MinRowSum(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int sum;
    int minSum = 0;
    int minSumRow = 0;
    for (int i = 0; i < rows; i++)
    {
        sum = 0;
        for (int j = 0; j < cols; j++)
            sum += matrix[i, j];

        if (i == 0)
            minSum = sum;
        if (sum < minSum)
        {
            minSum = sum;
            minSumRow = i;
        }
    }
    return minSumRow+1;
}
int[,] newArr2 = new int[4, 3];
InitRandomIntMatrix(newArr2);
Console.WriteLine();
PrintIntMatrix(newArr2);

Console.WriteLine(MinRowSum(newArr2) + " строка");