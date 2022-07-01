/**
*
* * Задача 56
*   Задайте прямоугольный двумерный массив.
*   Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/

/// Минимальное и максимальное генерируемое значение для элементов массива.
const int minValue = -10;
const int maxValue = 11;

/// получение целочисленного значения от пользователя с консоли
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

/// генерация двумерного массива.
///     rowCount - количество строк в массиве
///     colCount - количество колонок
int[,] GenerateArray(int rowCount, int colCount)
{
    int[,] array = new int[rowCount, colCount];
    Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(minValue, maxValue);
        }
    }

    return array;
}

/// вывод массива на экран
///     message - сообщение для пользователя
///     array - массив для печати 
void PrintArray(string message, int[,] array)
{
    Console.WriteLine(message);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3}\t", array[i, j]));
        }
        Console.WriteLine();
    }
}

/// поиск строки с минимальной суммой элементов в массиве
/// возвращает номер искомой строки
///     array - массив для поиска
int FindRowMinSum(int[,] array)
{
    int rowIndex = 0;
    int lastSum = int.MaxValue;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int nowSum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            nowSum += array[i, j];
        }

        if (nowSum < lastSum)
        {
            lastSum = nowSum;
            rowIndex = i;
        }
    }

    return rowIndex;
}


/// main body
Console.Clear();

int rowCount = InputNum("Imnput count rows: ");
int colCount = InputNum("Input count columns: ");
int[,] array = GenerateArray(rowCount, colCount);

PrintArray("Generated array: ", array);
Console.WriteLine($"Row with minimal sum: {FindRowMinSum(array)}");

