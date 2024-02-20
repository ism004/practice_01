using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты короля x1y1 и координаты фигуры x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены   ровно две пары координат
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }

        // Преобразуем координаты короля и фигуры в верхний регистр для удобства сравнения
        string kingCoordinates = coordinates[0].ToUpper();
        string pieceCoordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие   номер столбца и   номер строки для короля
        char kingRow = kingCoordinates[1];
        char kingColumn = kingCoordinates[0];
        // Извлекаем символы, представляющие   номер столбца и   номер строки для фигуры
        char pieceRow = pieceCoordinates[1];
        char pieceColumn = pieceCoordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H' и от '1' до '8
        if (kingColumn >= 'A' && kingColumn <= 'H' && kingRow >= '1' && kingRow <= '8' &&
            pieceColumn >= 'A' && pieceColumn <= 'H' && pieceRow >= '1' && pieceRow <= '8')
        {
            // Если   номер столбца или строки короля совпадает с  номером столбца или строки фигуры,
            // или есть разница между номерами столбцов и строк, которая равна  1, король может побить фигуру
            if (kingRow == pieceRow || kingColumn == pieceColumn ||
                Math.Abs(kingRow - pieceRow) == 1 || Math.Abs(kingColumn - pieceColumn) == 1)
            {
                Console.WriteLine("Король сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Король не сможет побить фигуру");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
