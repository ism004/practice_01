using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты ладьи x1y1 и координаты фигуры x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены ровно две пары координат
        if (coordinates.Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }

        // Преобразуем координаты ладьи и фигуры в верхний регистр для удобства сравнения
        string rookCoordinates = coordinates[0].ToUpper();
        string pieceCoordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие номер столбца и номер строки для ладьи
        char rookRow = rookCoordinates[1];
        char rookColumn = rookCoordinates[0];
        // Извлекаем символы, представляющие номер столбца и номер строки для фигуры
        char pieceRow = pieceCoordinates[1];
        char pieceColumn = pieceCoordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H'
        if (rookColumn >= 'A' && rookColumn <= 'H' && pieceColumn >= 'A' && pieceColumn <= 'H') 
        {
            // Если столбцы или строки совпадают, ладья может побить фигуру
            if (rookRow == pieceRow || rookColumn == pieceColumn)
            {
                Console.WriteLine("Ладья сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ладья не сможет побить фигуру");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
