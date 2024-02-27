// Класс для босса
public class Boss
{
    public int Health { get; set; } // Здоровье босса
    public int Damage { get; set; } // Урон, наносимый боссом

    // Конструктор для инициализации здоровья и урона босса
    public Boss(int health, int damage)
    {
        Health = health;
        Damage = damage;
    }

    // Метод для атаки игрока боссом
    public void Attack(Player player)
    {
        player.Health -= Damage; // Уменьшаем здоровье игрока на урон босса
    }
}

// Класс для игрока
public class Player
{
    public int Health { get; set; } // Здоровье игрока
    public int Energy { get; set; } // Энергия игрока

    // Конструктор для инициализации здоровья и энергии игрока
    public Player(int health, int energy)
    {
        Health = health;
        Energy = energy;
    }

    // Метод для применения заклинания игроком
    public void CastSpell(Spell spell, Boss boss)
    {
        spell.Cast(this, boss); // Вызов метода Cast заклинания с текущим игроком и боссом в качестве параметров
    }
}

// Абстрактный класс для заклинаний
public abstract class Spell
{
    public string Name { get; set; } // Имя заклинания
    public int EnergyCost { get; set; } // Стоимость энергии за использование заклинания
    public bool CanCast { get; set; } // Флаг, указывающий, может ли заклинание быть использовано

    // Конструктор для инициализации имени и стоимости энергии заклинания
    public Spell(string name, int energyCost)
    {
        Name = name;
        EnergyCost = energyCost;
        CanCast = true; // По умолчанию заклинание может быть использовано
    }

    // Абстрактный метод для применения заклинания
    public abstract void Cast(Player player, Boss boss);
}

// Класс заклинания "Рашамон"
public class ShadowSpirit : Spell
{
    public ShadowSpirit() : base("Рашамон", 50) { } // Конструктор с базовыми параметрами

    // Переопределение метода Cast для "Рашамон"
    public override void Cast(Player player, Boss boss)
    {
        if (player.Energy >= EnergyCost) // Проверяем, достаточно ли энергии у игрока
        {
            player.Energy -= EnergyCost; // Уменьшаем энергию игрока
            boss.Health -= 100; // Уменьшаем здоровье босса
            player.Health -= 100; // Уменьшаем здоровье игрока
            CanCast = false; // Заклинание "Рашамон" может быть использовано только один раз
        }
    }
}

// Класс заклинания "Хуганзакура"
public class Hugenzakura : Spell
{
    public Hugenzakura() : base("Хуганзакура", 100) { } // Конструктор с базовыми параметрами

    // Переопределение метода Cast для "Хуганзакура"
    public override void Cast(Player player, Boss boss)
    {
        if (player.Energy >= EnergyCost && CanCast) // Проверяем, достаточно ли энергии у игрока и может ли заклинание быть использовано
        {
            player.Energy -= EnergyCost; // Уменьшаем энергию игрока
            boss.Health -= 100; // Уменьшаем здоровье босса
        }
    }
}

// Класс заклинания "Межпространственный разлом"
public class InterdimensionalRift : Spell
{
    public InterdimensionalRift() : base("Межпространственный разлом", 200) { } // Конструктор с базовыми параметрами

    // Переопределение метода Cast для "Межпространственный разлом"
    public override void Cast(Player player, Boss boss)
    {
        if (player.Energy >= EnergyCost) // Проверяем, достаточно ли энергии у игрока
        {
            player.Energy -= EnergyCost; // Уменьшаем энергию игрока
            player.Health += 250; // Восстанавливаем здоровье игрока
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Boss boss = new Boss(500, 100); // Создание босса с начальным здоровьем и уроном
        Player player = new Player(200, 300); // Создание игрока с начальным здоровьем и энергией

        ShadowSpirit shadowSpirit = new ShadowSpirit(); // Создание заклинания "Рашамон"
        Hugenzakura hugenzakura = new Hugenzakura(); // Создание заклинания "Хуганзакура"
        InterdimensionalRift interdimensionalRift = new InterdimensionalRift(); // Создание заклинания "Межпространственный разлом"

        while (player.Health > 0 && boss.Health > 0) // Цикл игры продолжается, пока здоровье игрока и босса больше нуля
        {
            // Вывод текущего состояния игрока и босса
            Console.WriteLine($"Ваше здоровье: {player.Health}, Здоровье босса: {boss.Health}");
            Console.WriteLine("Выберите заклинание:");
            Console.WriteLine("1. Рашамон");
            Console.WriteLine("2. Хуганзакура");
            Console.WriteLine("3. Межпространственный разлом");
            int choice = Convert.ToInt32(Console.ReadLine()); // Получение выбора игрока

            switch (choice) // Обработка выбора игрока
            {
                case 1:
                    if (shadowSpirit.CanCast)
                    {
                        player.CastSpell(shadowSpirit, boss); // Применение заклинания "Рашамон"
                        Console.WriteLine("Вы атаковали босса заклинанием Рашамон!");
                    }
                    else
                    {
                        Console.WriteLine("Заклинание Рашамон уже было использовано!");
                    }
                    break;
                case 2:
                    if (hugenzakura.CanCast)
                    {
                        player.CastSpell(hugenzakura, boss); // Применение заклинания "Хуганзакура"
                        Console.WriteLine("Вы атаковали босса заклинанием Хуганзакура!");
                    }
                    else
                    {
                        Console.WriteLine("Заклинание Хуганзакура может быть использовано только после Рашамон!");
                    }
                    break;
                case 3:
                    if (interdimensionalRift.CanCast)
                    {
                        player.CastSpell(interdimensionalRift, boss); // Применение заклинания "Межпространственный разлом"
                        Console.WriteLine("Вы использовали заклинание Межпространственный разлом!");
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно маны для использования этого заклинания!");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор заклинания!");
                    break;
            }

            if (boss.Health > 0) // Если здоровье босса больше нуля, босс атакует игрока
            {
                boss.Attack(player);
            }
        }

        if (player.Health <= 0) // Проверка условий победы или поражения
        {
            Console.WriteLine("Вы погибли!");
        }
        else
        {
            Console.WriteLine("Босс был побежден!");
        }
    }
}
