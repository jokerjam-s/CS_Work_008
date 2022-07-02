/**
* * Задача 58
*   Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
*
*/

/// Максимальное генерируемое значение для элементов массива.
const int maxValue = 10;

/// Получение целочисленного значения от пользователя с консоли
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

/// Генерация матрицы.
///     rowCount - количество строк в массиве
///     colCount - количество колонок
int[,] GenerateMatrix(int rowCount, int colCount)
{
    int[,] array = new int[rowCount, colCount];
    Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(maxValue);
        }
    }

    return array;
}

/// Вывод матрицы на экран.
///     message - сообщение для пользователя
///     array - массив для печати 
void PrintMatrix(string message, int[,] matrix)
{
    Console.WriteLine(message);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3} ", matrix[i, j]));
        }
        Console.WriteLine();
    }
}

/// Умножение матриц, возвращает массив - результат операции умножения
/// Умножать можно прямоугольные матрицы, в которых число столбцов первой матрицы
/// равно числу строк во второй (согласованные матрицы),
/// если матрицы перемножить нельзя возвращает null.
///     firstMatrix - первая матрица
///     secondMatrix - вторая матрица
int[,] MultiplicateMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
    {
        return null;
    }

    int[,] newMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

    for (int i = 0; i < newMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < newMatrix.GetLength(1); j++)
        {
            newMatrix[i, j] = 0;
            for (int k = 0; k < newMatrix.GetLength(0); k++)
            {
                newMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }

    return newMatrix;
}

/// Main body
Console.Clear();

int firstRowsCount = InputNum("Input count rows for 1st matrix: ");
int firstColsCount = InputNum("Input count columns for 1st matrix: ");
int secondRowsCount = InputNum("Input count rows for 2st matrix: ");
int secondColsCount = InputNum("Input count columns for 2nd matrix: ");

int[,] firstMatrix = GenerateMatrix(firstRowsCount, firstColsCount);
int[,] secondMatrix = GenerateMatrix(secondRowsCount, secondColsCount);


/// Тестовые массивы для проверки, сответствие в README.MD.
/// int[,] firstMatrix = { { 1, 4, 3 }, { 2, 1, 5 }, { 3, 2, 1 } };
/// int[,] secondMatrix = { { 5, 2, 1 }, { 4, 3, 2 }, { 2, 1, 5 } };

PrintMatrix("First matrix: ", firstMatrix);
PrintMatrix("Second matrix: ", secondMatrix);

int[,] resultMatrix = MultiplicateMatrix(firstMatrix, secondMatrix);

if (resultMatrix == null)
{
    Console.WriteLine("Matrixes is not multiplicable!");
}
else
{
    PrintMatrix("Result: ", resultMatrix);
}