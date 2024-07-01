internal class Program
{
    private static void Main()
    {
        int game;
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Правила");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите 1 или 2");
            game = Convert.ToInt32(Console.ReadLine());
            switch (game)
            {
                case 1:
                    GameNew();
                    break;
                case 2:
                    Console.WriteLine("\nПравила: " + "\n1) Угадывается буква, а не само слово, из букв получится само слово\n"
    + "2) У вас есть 11 попыток \n" + "3) Каждая неправильно выбранная буква снимает попытку, при 0 значении - вы проиграли");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Некорректный ввод.Пожалуйста, выберите 1, 2");
                    break;
            }
        }
        while (game != 1);
    }

    private static void GameNew()
    {
        int attemps = 9;
        List<Char> wordLetters = new List<Char>();
        Console.WriteLine("Введите слово, которое нужно загадать: ");
        string? word = Convert.ToString(Console.ReadLine());
        char[] wordEncription = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            wordEncription[i] = '_';
        }
        while (attemps != 0 && wordEncription.Contains('_'))
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Загадано слово состоящее из " + word.Length + " букв\n");
            Console.WriteLine("Кол-во попыток " + attemps);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char f in wordEncription)
            {
                Console.Write(f + " ");
            }
            Console.WriteLine();
            Console.Write("Этих букв нет в слове: ");
            foreach (char c in wordLetters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введите букву: ");
            char letter = Console.ReadKey().KeyChar;
            bool question = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    question = true;
                    wordEncription[i] = letter;
                }
            }
            if (question == false)
            {
                wordLetters.Add(letter);
                attemps--;
            }
        }
        if (!wordEncription.Contains('_'))
        {
            Console.Write(" - последняя буква \n");
            Console.WriteLine("Вы выйграли \n");
            Main();

        }
        if (attemps <= 0)
        {
            Console.WriteLine();
            Console.WriteLine("Вы проиграли, начните игру заново \n");
            Main();
        }
    }
}