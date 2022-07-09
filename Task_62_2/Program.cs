using System.Diagnostics;
/**
* * Задача 62
*   Заполните спирально массив 4 на 4. Вариант решения 2
*/

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
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

/// Main body.
int rowCount = InputNum("Input count of rows: ");
int colCount = InputNum("Input count of columns: ");

int[,] array = new int[rowCount, colCount];

PrintMatrix("Empty array: ", array);

int fillValue = 1;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();

int rowTop = 0;
int rowBottom = array.GetLength(0) - 1;
int colLeft = 0;
int colRight = array.GetLength(1) - 1;


while (fillValue <= array.Length)
{
    for (int i = colLeft; i <= colRight; i++)
    {
        array[rowTop, i] = fillValue++;
    }

    rowTop++;
    for (int i = rowTop; i <= rowBottom; i++)
    {
        array[i, colRight] = fillValue++;
    }

    colRight--;
    for (int i = colRight; i >= colLeft && fillValue <= array.Length; i--)
    {
        array[rowBottom, i] = fillValue++;
    }

    rowBottom--;
    for (int i = rowBottom; i >= rowTop; i--)
    {
        array[i, colLeft] = fillValue++;
    }
    colLeft++;
}

stopwatch.Stop();

PrintMatrix("Fill array: ", array);

Console.WriteLine("Time: " + stopwatch.Elapsed);