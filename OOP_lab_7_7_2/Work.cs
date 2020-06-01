using System;
using System.IO;

namespace OOP_lab_7_7_2
{
    class Work : IWork
    {
        public void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

        RetryDate:
            Console.Write("Дата: ");

            try
            {
                file.WriteLine(DateTime.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Неправильно вказана дата!");

                goto RetryDate;
            }

            Console.Write("Мiсто: ");

            file.WriteLine(Console.ReadLine());

        RetryPressure:
            Console.Write("Атмосферний тиск: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Атмосферний тиск має бути вказаний лише числом!");

                goto RetryPressure;
            }

        RetryTemperature:
            Console.Write("Температура: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Температура має бути вказана лише числом!");

                goto RetryTemperature;
            }

        RetryWindSpeed:
            Console.Write("Швидкiсть вiтру: ");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Швидкiсть вiтру має бути вказана лише числом!");

                goto RetryWindSpeed;
            }

            file.Close();

            new Input().ReadBase();
        }

        public void Remove()
        {
            Console.WriteLine();

            new Output().Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.weather.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.weather[i].Date.ToShortDateString());
                    file.WriteLine(Program.weather[i].City);
                    file.WriteLine(Program.weather[i].Perssure);
                    file.WriteLine(Program.weather[i].Temperature);
                    file.WriteLine(Program.weather[i].WindSpeed);
                }
            }

            Console.Write("Видалено.\n");

            file.Close();

            new Input().ReadBase();
        }

        public void Edit()
        {
            Console.WriteLine();

            new Output().Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.weather.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не iснує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("\nВведiть новi данi");

                RetryDate:
                    Console.Write("Дата: ");

                    try
                    {
                        file.WriteLine(DateTime.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Неправильно вказана дата!");

                        goto RetryDate;
                    }

                    Console.Write("Мiсто: ");

                    file.WriteLine(Console.ReadLine());

                RetryPressure:
                    Console.Write("Атмосферний тиск: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Атмосферний тиск має бути вказаний лише числом!");

                        goto RetryPressure;
                    }

                RetryTemperature:
                    Console.Write("Температура: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Температура має бути вказана лише числом!");

                        goto RetryTemperature;
                    }

                RetryWindSpeed:
                    Console.Write("Швидкiсть вiтру: ");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Швидкiсть вiтру має бути вказана лише числом!");

                        goto RetryWindSpeed;
                    }
                }
                else
                {
                    file.WriteLine(Program.weather[i].Date.ToShortDateString());
                    file.WriteLine(Program.weather[i].City);
                    file.WriteLine(Program.weather[i].Perssure);
                    file.WriteLine(Program.weather[i].Temperature);
                    file.WriteLine(Program.weather[i].WindSpeed);
                }
            }

            Console.Write("Змiни внесено.\n");

            file.Close();

            new Input().ReadBase();
        }

        public void InitialiseBase(int n)
        {
            Program.weather = new Weather[n];
        }

        public void SortByDate()
        {
            Console.WriteLine();

            Array.Sort(Program.weather);

            new Output().Write();
        }

        public void SortByTemperature()
        {
            Console.WriteLine();

            Array.Sort(Program.weather, new Weather.SortByTemperature());

            new Output().Write();
        }

        public void SortByWindSpeed()
        {
            Console.WriteLine();

            Array.Sort(Program.weather, new Weather.SortByWindSpeed());

            new Output().Write();
        }
    }
}
