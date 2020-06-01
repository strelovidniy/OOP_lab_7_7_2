using System;

namespace OOP_lab_7_7_2
{
    class Output : IOutput
    {
        public const string Format = "{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}";

        public void Write()
        {
            Console.WriteLine(Format, "Дата", "Мiсто", "Атмосферний тиск", "Температура повiтря", "Швидкiсть вiтру");

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                Console.WriteLine(Format, Program.weather[i].Date.ToShortDateString(), Program.weather[i].City, Program.weather[i].Perssure, Program.weather[i].Temperature, Program.weather[i].WindSpeed);
            }
        }
    }
}
