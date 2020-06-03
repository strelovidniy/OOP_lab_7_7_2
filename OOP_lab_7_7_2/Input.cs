using System;
using System.IO;

namespace OOP_lab_7_7_2
{
    class Input : IInput
    {
        public void Read()
        {
            ReadBase();
            ReadKey();
        }

        public void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            new Work().InitialiseBase(tempStr.Length / 5);

            for (int i = 0; i < tempStr.Length; i += 5)
            {
                Program.weather[i / 5] = new Weather(DateTime.Parse(tempStr[i]), tempStr[i + 1], int.Parse(tempStr[i + 2]), int.Parse(tempStr[i + 3]), int.Parse(tempStr[i + 4]));
            }

            file.Close();
        }

        public void ReadKey()
        {
            
        Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Сортування за датою: D");
            Console.WriteLine("Сортування за температурою повiтря та швидкiстю вiтру: S");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    new Work().Add();
                    goto Start;

                case ConsoleKey.E:
                    new Work().Edit();
                    goto Start;

                case ConsoleKey.D:
                    new Work().SortByDate();
                    goto Start;

                case ConsoleKey.S:
                    new Work().SortByTemperatureAndWindSpeed();
                    goto Start;

                case ConsoleKey.OemMinus:
                    new Work().Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    new Output().Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}
