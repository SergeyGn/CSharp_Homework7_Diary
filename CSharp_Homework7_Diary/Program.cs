using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.CreatePage;
using static CSharp_Homework7_Diary.ReadPage;
using static CSharp_Homework7_Diary.EditPage;
using static CSharp_Homework7_Diary.SortList;

namespace CSharp_Homework7_Diary
{
    class Program
    {
       public static string PathInDiary = @"Diary.csv";
        static void Main(string[] args)
        {
            MainMenu();   
        }
        public static void MainMenu()
        {
            Console.WriteLine("Для создания задач нажмите 1");
            Console.WriteLine("Для просмотра задач нажмите 2");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    DateTime dataPageDiary = CheckDate();
                    CreatePageDiary(dataPageDiary);
                    break;
                case ConsoleKey.D2:
                    ReadPageDiary(GetListNote());
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
       public static void EndMenu(List<Note> ListNote, DateTime datePageDiary)
        {
            Console.WriteLine("Для того чтобы:" +
    "\nредактировать текущую страницу нажмите 1" +
    "\nдля создания заметок на этой странице нажмите 2" +
    "\nдля того чтобы выйти в главное меню нажмите 3");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    EditPageDiary(ListNote, datePageDiary);
                    break;
                case ConsoleKey.D2:
                    CreatePage.CreatePageDiary(datePageDiary);
                    break;
                case ConsoleKey.D3:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Неверный вводб Попробуйте ещё раз");
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

        public static int CheckNumber(string enter,int min, int max)
        {
            if (int.TryParse(enter, out int result))
            {
                if (result > min && result <= max)
                { 
                    return result; 
                }
                else
                {
                    Console.WriteLine("Выход за дипазонзначений! Попробуйте снова");
                   string enter2 = Console.ReadLine();
                   return CheckNumber(enter2, min, max);
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                string enter2 = Console.ReadLine();
                return CheckNumber(enter2, min, max);
            }
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
