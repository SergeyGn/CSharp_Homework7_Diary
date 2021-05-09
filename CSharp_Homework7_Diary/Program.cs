using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.CreatePage;
using static CSharp_Homework7_Diary.ReadPage;

namespace CSharp_Homework7_Diary
{
    class Program
    {
        static string _pathInDiary = @"Diary\";
        static void Main(string[] args)
        {
            MainMenu();   
        }
        private static void MainMenu()
        {
            Console.WriteLine("Для создания задач нажмите 1");
            Console.WriteLine("Для просмотра задач нажмите 2");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                CreatePageDiary();
                    break;
                case ConsoleKey.D2:
                ReadPageDiary();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

       public static DateTime CheckTime()
        {
            DateTime time;
            string input;
            do
            {
                Console.WriteLine("Введите время в формате HH:MM");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "HH:mm", null, DateTimeStyles.None, out time));
            {
                return time;
            }
        }
        public static DateTime CheckDate()
        {
            DateTime date;
            string input;
            do
            {
                Console.WriteLine("Введите время в формате ДД.MM.ГГГГ");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));
            return date;
            
        }
        public static bool AskQuestion(string question)
        {
            Console.WriteLine(question);
            bool IsYes = false;
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.Y:
                    IsYes = true;
                    break;
                case ConsoleKey.N:
                    IsYes = false;
                    break;
                default:
                    Console.WriteLine("Неизвестный ввод");
                    AskQuestion(question);
                    break;
            }
            return IsYes;
        }
    }
}
