/**
* * Задача 60
*   Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
*   которая будет построчно выводить массив, добавляя индексы каждого элемента.
*
*   Исходя из условия массив может содержать числа от 10 до 99 всего 90 цифр
*   соответственно размерность (M x N x Z) <= 90
*/

int counter = 0;


/// Максимальное количество элементов в массиве.
const int maxFullSize = 90;

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

/// Метод вывода трехмерного массива на экран.
///     array - массив для отображения
void PrintArray3D(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(string.Format("{0,2}[{1,2},{2,2},{3,2}] ", array[i, j, k], i, j, k));
            }
        }
        Console.WriteLine();
    }
}

/// Возвращает трехмерный массив не более чем из maxFullSize элементов согласно переданных параметров.
/// Масив заполняется последовательно от 10 до 99. Если переданная размерность превышает допустимый 
/// предел, возвращает null.  
///     rowCount    - количество строк в массиве
///     colCount    - количество колонок в массиве
///     deepCount   - глубина массива
int[,,] CreateArray3D(int rowCount, int colCount, int deepCount)
{
    if (rowCount * colCount * deepCount > maxFullSize)
    {
        return null;
    }

    int[,,] array = new int[rowCount, colCount, deepCount];

    int startValue = 10;
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            for (int k = 0; k < deepCount; k++)
            {
                array[i, j, k] = startValue++;
            }
        }
    }

    return array;
}



/// Main body
Console.Clear();

int rowCount = InputNum("Rows count: ");
int colCount = InputNum("Columns count: ");
int deepCount = InputNum("Deep of array: ");

int[,,] array3D = CreateArray3D(rowCount, colCount, deepCount);

if (array3D == null)
{
    Console.WriteLine("Invalid size of array.");
}
else
{
    PrintArray3D(array3D);
}



