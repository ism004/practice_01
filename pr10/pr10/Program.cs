using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите название фигуры (ладья, слон, король, ферзь):");
        string figureName = Console.ReadLine();

        // Генерация случайных координат для начальной позиции фигуры
        Random random = new Random();
        string x1 = ((char)('a' + random.Next(0, 8))).ToString();
        int y1 = random.Next(1, 9);

        string x2, y2;

        // Генерация координат для x2 и y2
        do
        {
            x2 = ((char)('a' + random.Next(0, 8))).ToString();
            y2 = random.Next(1, 9).ToString(); // Преобразование int в string
        }
        while (IsThreatened(figureName, x1, y1.ToString(), x2, y2)); // Преобразование int в string

        Console.WriteLine($"Координаты фигуры для первого поля: {x1}{y1}");
        Console.WriteLine($"Координаты фигуры для второго поля: {x2}{y2}");
    }

    static bool IsThreatened(string figureName, string x1, string y1, string x2, string y2)
    {
        // Преобразование координат в числовой формат для упрощения логики
        int x1Num = x1[0] - 'a' + 1;
        int x2Num = x2[0] - 'a' + 1;
        int y1Num = int.Parse(y1);
        int y2Num = int.Parse(y2);

        // Проверка, угрожает ли фигура полю (x2, y2)
        switch (figureName.ToLower())
        {
            case "ладья":
                return x1 == x2 || y1Num == y2Num; // Ладья угрожает полям на одной линии
            case "слон":
                return Math.Abs(x1Num - x2Num) == Math.Abs(y1Num - y2Num); // Слон угрожает полям на одной диагонали
            case "король":
                return Math.Abs(x1Num - x2Num) <= 1 && Math.Abs(y1Num - y2Num) <= 1; // Король угрожает полям в пределах одной клетки
            case "ферзь":
                return Math.Abs(x1Num - x2Num) == Math.Abs(y1Num - y2Num) || x1Num == x2Num || y1Num == y2Num; // Ферзь угрожает полям на одной линии, диагонали или горизонтально/вертикально
            default:
                return true; // Если фигура неизвестна, считаем, что она угрожает
        }
    }
}
