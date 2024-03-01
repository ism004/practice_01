using System;
using System.ComponentModel;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int performerX, performerY;
        char[,] map = ReadMap("level01", out performerX, out performerY);
        bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)];
        DrawMap(map);
        MovePerformer(map, ref performerX, ref performerY, visited);
    }

    static char[,] ReadMap(string mapName, out int performerX, out int performerY)
    {
        performerX = 0;
        performerY = 0;

        string[] newFile = File.ReadAllLines($"level01.txt");
        char[,] map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = newFile[i][j];

                if (map[i, j] == '■')
                {
                    performerX = i;
                    performerY = j;
                }
            }
        }
        return map;
    }

    static void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void MovePerformer(char[,] map, ref int performerX, ref int performerY, bool[,] visited)
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int newX = performerX;
            int newY = performerY;
            // Клавиши перемещения и выхода из программы
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    newX--;
                    break;
                case ConsoleKey.DownArrow:
                    newX++;
                    break;
                case ConsoleKey.LeftArrow:
                    newY--;
                    break;
                case ConsoleKey.RightArrow:
                    newY++;
                    break;
                case ConsoleKey.Escape:
                    return; // Выход из цикла при нажатии Escape
            }

            // Проверка нового положения на валидность
            if (newX >= 0 && newX < map.GetLength(0) && newY >= 0 && newY < map.GetLength(1) && map[newX, newY] != '║' && map[newX, newY] != '╬' && map[newX, newY] != '╠' && map[newX, newY] != '╩' && map[newX, newY] != '═' && map[newX, newY] != '╦' && !visited[newX, newY])
            {
                // Перемещение '■'
                performerX = newX;
                performerY = newY;
                map[performerX, performerY] = '■'; // Добавление '■' в новую позицию

                // Перемещение курсора на новую позицию '■'
                Console.SetCursorPosition(performerY, performerX);
                Console.Write('■');
            }
            else if (visited[newX, newY])
            {
                // Остановка программы, если '■' пытается вернуться на уже посещенную позицию
                Console.WriteLine("Нельзя возвращать на пройденный путь.");
                Environment.Exit(0); // Завершение программы
            }
        }
    }
}