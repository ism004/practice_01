using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты слона x1y1 и координаты фигуры x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены ровно две пары координат
        if (coordinates.Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }

        // Преобразуем координаты слона и фигуры в верхний регистр для удобства сравнения
        string elephantCoordinates = coordinates[0].ToUpper();
        string pieceCoordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие номер столбца и номер строки для слона
        char elephantRow = elephantCoordinates[1];
        char elephantColumn = elephantCoordinates[0];
        // Извлекаем символы, представляющие номер столбца и номер строки для фигуры
        char pieceRow = pieceCoordinates[1];
        char pieceColumn = pieceCoordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H' и от '1' до '8'
        if (elephantColumn >= 'A' && elephantColumn <= 'H' && elephantRow >= '1' && elephantRow <= '8' &&
            pieceColumn >= 'A' && pieceColumn <= 'H' && pieceRow >= '1' && pieceRow <= '8')
        {
            // Если разница между номерами столбцов и строк равна, слон может побить фигуру.
            if (Math.Abs(elephantRow - pieceRow) == Math.Abs(elephantColumn - pieceColumn))
            {
                Console.WriteLine("Слон сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Слон не сможет побить фигуру");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
