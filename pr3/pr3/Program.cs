﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты ферзя x1y1 и координаты фигуры x2y2");
        string input = Console.ReadLine();
        // Разбиваем введенную строку на две части по пробелу
        string[] coordinates = input.Split(' ');

        // Проверяем, что введены ровно две пары координат
        if (coordinates.Length != 2 || coordinates[0].Length != 2 || coordinates[1].Length != 2)
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;  
        }

        // Преобразуем координаты ферзя и фигуры в верхний регистр для удобства сравнения
        string queenCoordinates = coordinates[0].ToUpper();
        string pieceCoordinates = coordinates[1].ToUpper();

        // Извлекаем символы, представляющие номер строки и номер столбца для ферзя
        char queenRow = queenCoordinates[1];
        char queenColumn = queenCoordinates[0];
        // Извлекаем символы, представляющие номер строки и номер столбца для фигуры
        char pieceRow = pieceCoordinates[1];
        char pieceColumn = pieceCoordinates[0];

        // Проверяем, что столбцы и строки введены в диапазоне от 'A' до 'H' и от '1' до '8'
        if (queenColumn >= 'A' && queenColumn <= 'H' && queenRow >= '1' && queenRow <= '8' &&
            pieceColumn >= 'A' && pieceColumn <= 'H' && pieceRow >= '1' && pieceRow <= '8')
        {
            // Если  номер строки или столбца ферзя совпадает с номером строки или столбца фигуры,
            // или есть разница между номерами строк и столбцов, которая равна, ферзь может побить фигуру
            if (queenRow == pieceRow || queenColumn == pieceColumn ||
                Math.Abs(queenRow - pieceRow) == Math.Abs(queenColumn - pieceColumn))
            {
                Console.WriteLine("Ферзь сможет побить фигуру");
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели некорректные координаты");
            return;
        }
    }
}
