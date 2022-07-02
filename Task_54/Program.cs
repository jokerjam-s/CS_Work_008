/**
* * Задача 54: 
*   Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
*
*/


/// Максимальное генерируемое значение для элементов массива.
const int maxValue = 10;

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

/// Генерация двумерного массива.
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
            array[i, j] = rnd.Next(maxValue);
        }
    }

    return array;
}

/// Вывод массива на экран.
///     message - сообщение для пользователя
///     array - массив для печати 
void PrintArray(string message, int[,] array)
{
    Console.WriteLine(message);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,2} ", array[i, j]));
        }
        Console.WriteLine();
    }
}

/// Сортировка строк двумерного массива по убыванию.
///     array - массив для сортировки
void SortRowsArrayDesc(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = array.GetLength(1) - 1; k > j; k--)
            {
                if (array[i, k - 1] < array[i, k])
                {
                    int tmp = array[i, k - 1];
                    array[i, k - 1] = array[i, k];
                    array[i, k] = tmp;
                }
            }
        }
    }
}


/// Main body.
Console.Clear();

int rowCount = InputNum("Input count rows in array: ");
int colCount = InputNum("Input count columns in array: ");

int[,] array = GenerateArray(rowCount, colCount);

PrintArray("Generated array:", array);
SortRowsArrayDesc(array);
PrintArray("Sorted array:", array);

