using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты двух полей x1y1 и x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены ровно две пары координат
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }

        // Преобразуем координаты полей в верхний регистр для удобства сравнения
        string field1Coordinates = coordinates[0].ToUpper();
        string field2Coordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие   номер столбца и   номер строки для первого поля
        char field1Row = field1Coordinates[1];
        char field1Column = field1Coordinates[0];
        // Извлекаем символы, представляющие   номер столбца и   номер строки для второго поля
        char field2Row = field2Coordinates[1];
        char field2Column = field2Coordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H' и от '1' до '8'
        if (field1Column >= 'A' && field1Column <= 'H' && field1Row >= '1' && field1Row <= '8' &&
            field2Column >= 'A' && field2Column <= 'H' && field2Row >= '1' && field2Row <= '8')
        {
            // Если  номер строки для обоих полей четный или нечетный, поля одного цвета
            if ((field1Row - '0') % 2 == (field2Row - '0') % 2)
            {
                Console.WriteLine("Поля одного цвета");
            }
            else
            {
                Console.WriteLine("Поля разных цветов");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
