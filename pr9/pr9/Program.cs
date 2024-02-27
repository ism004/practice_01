using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите исходные данные: " +
            "название белой фигуры, пробел, координаты белой фигуры, " +
            "пробел, название черной фигуры, пробел, координаты черной фигуры, пробел, " +
            "координаты конечной точки");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');

        if (parts.Length > 7)
        {
            Console.WriteLine("Некорректный ввод данных.");
            return;
        }

        string whiteFigure = parts[0];
        string whitePosition = parts[1];
        string blackFigure = parts[2];
        string blackPosition = parts[3];
        string endPosition = parts[4];

        // Преобразуем координаты в числовые значения для сравнения
        int whiteRow = Convert.ToInt32(whitePosition[1].ToString());
        int whiteColumn = whitePosition[0] - 'a' + 1;
        int blackRow = Convert.ToInt32(blackPosition[1].ToString());
        int blackColumn = blackPosition[0] - 'a' + 1;
        int endRow = Convert.ToInt32(endPosition[1].ToString());
        int endColumn = endPosition[0] - 'a' + 1;

        bool canMove = false;

        // Проверяем, может ли белая фигура дойти до конечной точки, не попав под удар черной фигуры
        switch (whiteFigure.ToLower())
        {
            case "ферзь":
                // Ферзь может двигаться по вертикали, горизонтали и диагонали
                canMove = true;
                break;
            case "ладья":
                // Ладья может двигаться только по вертикали или горизонтали
                canMove = (whiteColumn == endColumn) || (whiteRow == endRow);
                break;
            case "слон":
                // Слон может двигаться по диагонали
                canMove = Math.Abs(whiteRow - endRow) == Math.Abs(whiteColumn - endColumn);
                break;
            case "конь":
                // Конь может двигаться по L-образной траектории
                canMove = Math.Abs(whiteRow - endRow) == 2 && Math.Abs(whiteColumn - endColumn) == 1
                    || Math.Abs(whiteRow - endRow) == 1 && Math.Abs(whiteColumn - endColumn) == 2;
                break;
            case "король":
                // Король может двигаться на одну клетку в любом направлении
                canMove = Math.Abs(whiteRow - endRow) <= 1 && Math.Abs(whiteColumn - endColumn) <= 1;
                break;
            default:
                Console.WriteLine("Неизвестная фигура.");
                return;
        }

        if (!canMove)
        {
            Console.WriteLine("Белая фигура не может дойти до конечной точки.");
        }
        else
        {
            Console.WriteLine($"{whiteFigure} дойдет до {endPosition}");
        }
    }
}
