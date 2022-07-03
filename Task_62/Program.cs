/**
* * Задача 62
*   Заполните спирально массив 4 на 4.
*
*/

/// Константы направления обхода массива.
const int goToLeft = 1;
const int goToRight = 2;
const int goToDown = 3;
const int goToUp = 4;

/// Стартовые значения заполнения ячейки, строка, колонка
const int startFillValue = 1;
const int startRow = 0;
const int startCol = 0;


/// Рекурсивное заполнение массива последовательностью чисел от 1, .. , N по спирали 
/// движение влево, вниз, вправо, вверх. Смена направления производится 
/// при достижении границ массива, или попадании на уже пройденный элемент.
///     array - массив для обхода
///     fillValue - значение для заполнения ячейки
///     direction - направление движения
///     rowPosition - строка ячеки для проверки
///     colPosition - колонка ячейки для проверки
void fillArray(int[,] array, int fillValue, int direction, int rowPosition, int colPosition)
{
    if (array[rowPosition, colPosition] == 0)
    {
        array[rowPosition, colPosition] = fillValue;
        fillValue++;
    }

    bool canMoveRight = CheckRight(array, rowPosition, colPosition);
    bool canMoveLeft = CheckLeft(array, rowPosition, colPosition);
    bool canMoveDown = CheckDown(array, rowPosition, colPosition);
    bool canMoveUp = CheckUp(array, rowPosition, colPosition);

    if (!(canMoveDown || canMoveLeft || canMoveRight || canMoveUp))
    {
        return;
    }

    if (direction == goToRight)
    {
        if (canMoveRight)
        {
            colPosition++;
        }
        else
        {
            direction = goToDown;
        }
    }

    if (direction == goToDown)
    {
        if (canMoveDown)
        {
            rowPosition++;
        }
        else
        {
            direction = goToLeft;
        }
    }

    if (direction == goToLeft)
    {
        if (canMoveLeft)
        {
            colPosition--;
        }
        else
        {
            direction = goToUp;
        }
    }

    if (direction == goToUp)
    {
        if (canMoveUp)
        {
            rowPosition--;
        }
        else
        {
            direction = goToRight;
        }
    }

    fillArray(array, fillValue, direction, rowPosition, colPosition);
}


/// Проверка возможности движения вправо. 
///     array - массив для обхода
///     rowPosition - строка стартовой ячеки
///     colPosition - колонка стартовой ячейки
/// Возврат:
///     true - движениеи возможно
///     false - движение закрыто
bool CheckRight(int[,] array, int rowPosition, int colPosition)
{
    bool result = false;
    if (colPosition < array.GetLength(1) - 1)           // оптимизация в C# условных выражений  
    {                                                   // конструкция (с1 && с2) если с1 == false, 
        if (array[rowPosition, colPosition + 1] == 0)   // будет ли проверка c2 - ?
        {
            result = true;
        }
    }

    return result;
}

/// Проверка возможности движения вниз. 
///     array - массив для обхода
///     rowPosition - строка стартовой ячеки
///     colPosition - колонка стартовой ячейки
/// Возврат:
///     true - движениеи возможно
///     false - движение закрыто
bool CheckDown(int[,] array, int rowPosition, int colPosition)
{
    bool result = false;
    if (rowPosition < array.GetLength(0) - 1)           // оптимизация в C# условных выражений  
    {                                                   // конструкция (с1 && с2) если с1 == false, 
        if (array[rowPosition + 1, colPosition] == 0)   // будет ли проверка c2 - ?
        {
            result = true;
        }
    }

    return result;
}

/// Проверка возможности движения влево. 
///     array - массив для обхода
///     rowPosition - строка стартовой ячеки
///     colPosition - колонка стартовой ячейки
/// Возврат:
///     true - движениеи возможно
///     false - движение закрыто
bool CheckLeft(int[,] array, int rowPosition, int colPosition)
{
    bool result = false;
    if (colPosition > 0)
    {
        if (array[rowPosition, colPosition - 1] == 0)
        {
            result = true;
        }
    }

    return result;

}

/// Проверка возможности движения вверх. 
///     array - массив для обхода
///     rowPosition - строка стартовой ячеки
///     colPosition - колонка стартовой ячейки
/// Возврат:
///     true - движениеи возможно
///     false - движение закрыто
bool CheckUp(int[,] array, int rowPosition, int colPosition)
{
    bool result = false;
    if (rowPosition > 0)
    {
        if (array[rowPosition - 1, colPosition] == 0)
        {
            result = true;
        }
    }

    return result;

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

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
int InputNum(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

/// Main body
Console.Clear();

int sizeOfArray = InputNum("Input size of array: ");

int[,] array = new int[sizeOfArray, sizeOfArray];

PrintMatrix("Empty array: ", array);
fillArray(array, startFillValue, goToRight, startRow, startCol);
PrintMatrix("Fill array", array);
