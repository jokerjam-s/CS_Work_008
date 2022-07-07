/**
* * Задача 62
*   Заполните спирально массив 4 на 4. Вариант решения 3
*   Сокращение кол-ва циклов
*/

/// Стартовые значения заполнения ячейки, строка, колонка
const int startFillValue = 1;

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

/// Спиральное заполнение матрицы.
///     array - матрица для заполнения
///     fillValue - начальное значение для заполнения
void FillMatrix(int[,] array, int fillValue)
{

    int rowTop = 0;
    int rowBottom = array.GetLength(0) - 1;
    int colLeft = 0;
    int colRight = array.GetLength(1) - 1;
    int revertValue = fillValue + (colRight - colLeft) + (rowBottom - rowTop);

    while (fillValue < array.Length)
    {
        for (int i = colLeft; i <= colRight && fillValue < array.Length; i++)
        {
            array[rowTop, i] = fillValue++;
            array[rowBottom, colRight - i + colLeft] = revertValue++;
        }

        rowTop++;
        rowBottom--;

        for (int i = rowTop; i <= rowBottom && fillValue < array.Length; i++)
        {
            array[i, colRight] = fillValue++;
            array[rowBottom - i + rowTop, colLeft] = revertValue++;
        }

        colRight--;
        colLeft++;

        fillValue = revertValue;
        revertValue = fillValue + (colRight - colLeft) + (rowBottom - rowTop);
    }
}


/// Main body.
int rowCount = InputNum("Input count of rows: ");
int colCount = InputNum("Input count of columns: ");

int[,] array = new int[rowCount, colCount];

PrintMatrix("Empty array: ", array);

FillMatrix(array, startFillValue);

PrintMatrix("Fill array: ", array);