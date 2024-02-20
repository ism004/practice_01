using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты коня x1y1 и координаты фигуры x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены   ровно две пары координат
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }

        // Преобразуем координаты коня и фигуры в верхний регистр для удобства сравнения
        string knightCoordinates = coordinates[0].ToUpper();
        string pieceCoordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие   номер столбца и   номер строки для коня
        char knightRow = knightCoordinates[1];
        char knightColumn = knightCoordinates[0];
        // Извлекаем символы, представляющие   номер столбца и   номер строки для фигуры
        char pieceRow = pieceCoordinates[1];
        char pieceColumn = pieceCoordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H' и от '1' до '8'
        if (knightColumn >= 'A' && knightColumn <= 'H' && knightRow >= '1' && knightRow <= '8' &&
            pieceColumn >= 'A' && pieceColumn <= 'H' && pieceRow >= '1' && pieceRow <= '8')
        {
            // Если есть разница между номерами столбцов и строк, которая равна   2, конь может побить фигуру
            if (Math.Abs(knightRow - pieceRow) == 2 && Math.Abs(knightColumn - pieceColumn) == 1 ||
                Math.Abs(knightRow - pieceRow) == 1 && Math.Abs(knightColumn - pieceColumn) == 2)
            {
                Console.WriteLine("Конь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Конь не сможет побить фигуру");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
