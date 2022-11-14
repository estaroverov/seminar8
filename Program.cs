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

void PrintStrMatrix(string [,] matrix)
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
Console.WriteLine("Задача 54.");
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
    return minSumRow + 1;
}
int[,] newArr2 = new int[4, 3];
InitRandomIntMatrix(newArr2);
Console.WriteLine("Задача 56.");
PrintIntMatrix(newArr2);

Console.WriteLine(MinRowSum(newArr2) + " строка");


// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
int[,] MultMatrix(int[,] matrix1, int[,] matrix2)
{

    int rows = matrix1.GetLength(0);
    int cols = matrix1.GetLength(1);
    int cols2 = matrix2.GetLength(1);
    int[,] multMatrix = new int[rows, cols2];
    int[] sum = new int[cols2];
    if (cols == matrix2.GetLength(0))
        for (int i = 0; i < rows; i++)
        {
            for (int k = 0; k < sum.Length; k++)
            {
                for (int j = 0; j < cols; j++)
                    sum[k] += matrix1[i, j] * matrix2[j, k];
                multMatrix[i, k] = sum[k];
                sum[k] = 0;
            }
        }
    return multMatrix;
}

int[,] newArr3 = new int[2, 2];
int[,] newArr4 = new int[2, 2];
Console.WriteLine("Задача 58.");
InitRandomIntMatrix(newArr3, 1, 10);
InitRandomIntMatrix(newArr4, 1, 10);
Console.WriteLine();
PrintIntMatrix(newArr3);
Console.WriteLine();
PrintIntMatrix(newArr4);

Console.WriteLine();
PrintIntMatrix(MultMatrix(newArr3, newArr4));


// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
int[,,] array = new int[2, 2, 2];
void Init3dArray(int[,,] array, int min = 0, int max = 100)
{
    int size = array.GetLength(0) * array.GetLength(1) * array.GetLength(2);
    int tempVal;
    int counter = 0;
    int[] tempArr = new int[size];
    for (int i = 0; i < size; i++)
    {
        tempVal = new Random().Next(min, max);
        while (tempArr.Contains(tempVal))
        {
            tempVal = new Random().Next(min, max);
        }
        tempArr[i] = tempVal;
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = tempArr[counter];
                counter++;
            }
        }
    }

}
void Print3dArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(array[i, j, k] + $"({i},{j},{k})");
            }
            Console.WriteLine();
        }
    }
}
Console.WriteLine("Задача 60.");
Init3dArray(array);
Print3dArray(array);

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

string[,] SpiralArray(int rows = 4, int cols = 4)
{
    string[,] spiralArr = new string[rows, cols];
    int size = rows * cols;
    int counter = 0;
    int nStep = 0;
    while (counter < size)
    {
        for (int j = nStep; j < cols - nStep; j++)
            spiralArr[nStep, j] = counter < 9 ? "0" + ++counter : "" + ++counter;

        for (int j = nStep + 1; j < rows - nStep; j++)
            spiralArr[j, cols - nStep - 1] = counter < 9 ? "0" + ++counter : "" + ++counter;

        for (int i = cols - nStep - 2; i >= nStep; i--)
            spiralArr[rows - nStep - 1, i] = counter < 9 ? "0" + ++counter : "" + ++counter;

        for (int i = rows - nStep - 2; i >= nStep + 1; i--)
            spiralArr[i, nStep] = counter < 9 ? "0" + ++counter : "" + ++counter;

        nStep++;
    }
    return spiralArr;
}
Console.WriteLine("Задача 62.");
PrintStrMatrix(SpiralArray());