using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

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
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    CreatePageDiary(DateTime.Now);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        private static void CreatePageDiary(DateTime dateTime)
        {
            DateTime dataPageDiary = CheckDate();
            using (StreamWriter streamWriter = new StreamWriter($"Diary.csv", true, Encoding.Unicode))
            {
               CreateNotes(streamWriter, dataPageDiary,' ');
                Console.ForegroundColor = ConsoleColor.Red;

                while (AskQuestion("Хотите внести важные дела?y/n") == true)
                {
                        CreateNotes(streamWriter, dataPageDiary, 'i');
                }
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                while (AskQuestion("Есть идеи которые нужно записать?y/n") == true)
                {
                    CreateNotes(streamWriter, dataPageDiary, 'c');
                }
                Console.ResetColor();
            }
        }
        private static void CreateNotes(StreamWriter sw, DateTime dataPageDiary,char label)
        { 
            List<Note> ListNote = new List<Note>();
                char key = 'y';
                do
                {
                Console.WriteLine("Введите заметку");
                string business = Console.ReadLine();
                ListNote.Add(new Note { NameBusines = business, TimeBusines = CheckTime(),TimeCreateNote=DateTime.Now});
                    Console.WriteLine("Хотите добавить ещё заметку?y/n");
                    key = Console.ReadKey(true).KeyChar;
                }
                while (char.ToLower(key) == 'y');

            ListNote.Sort((a, b) => a.TimeBusines.CompareTo(b.TimeBusines));
            for (int i = 0; i < ListNote.Count; i++)
            {
                sw.WriteLine($"{label}\t{dataPageDiary.ToShortDateString()}" +
                    $"\t{ListNote[i].TimeBusines.ToShortTimeString()}" +
                    $"\t{ListNote[i].NameBusines}" +
                    $"\t{ListNote[i].TimeCreateNote.ToShortDateString()}");
            }

        }
        private static void DeletePageDiary()
        {

        }
        static DateTime CheckTime()
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
        static DateTime CheckDate()
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

        static bool AskQuestion(string question)
        {
            Console.WriteLine(question);
            bool IsYes=false;
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
