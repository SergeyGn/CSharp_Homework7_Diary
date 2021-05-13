using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.Program;

namespace CSharp_Homework7_Diary
{
    struct CreatePage
    {
        public static void CreatePageDiary()
        {
            DateTime dataPageDiary = CheckDate();
            using (StreamWriter streamWriter = new StreamWriter($"Diary.csv", true, Encoding.Unicode))
            {
                CreateNotes(streamWriter, dataPageDiary, 's');
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
        private static void CreateNotes(StreamWriter sw, DateTime dataPageDiary, char label)
        {
            List<Note> ListNote = new List<Note>();
            char key = 'y';
            do
            {
                Console.WriteLine("Введите заметку");
                string business = Console.ReadLine();

                if (label == 'c')
                    ListNote.Add(new Note { NameBusines = business, TimeBusines = new DateTime(3333,1,1,23,59,59), TimeCreateNote = DateTime.Now });
                else
                ListNote.Add(new Note { NameBusines = business, TimeBusines = CheckTime(), TimeCreateNote = DateTime.Now });

                Console.WriteLine("Хотите добавить ещё заметку?y/n");
                key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'y');

            for (int i = 0; i < ListNote.Count; i++)
            {
                sw.WriteLine($"{dataPageDiary.ToShortDateString()}" +
                    $"\t{ListNote[i].TimeBusines.ToShortTimeString()}" +
                    $"\t{ListNote[i].NameBusines}" +
                    $"\t{ListNote[i].TimeCreateNote.ToShortDateString()}" +
                    $"\t{label}");
            }
        }
    }
}
