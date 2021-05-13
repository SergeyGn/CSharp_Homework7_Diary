using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.Program;

namespace CSharp_Homework7_Diary
{
    struct ReadPage
    {
        public static void ReadPageDiary()
        {
            DateTime datePageDiary = CheckDate();
            string date = datePageDiary.ToShortDateString();
            List<Note> ListNote = new List<Note>();
            using (StreamReader streamReader = new StreamReader("Diary.csv", Encoding.Unicode))
            {
                string allLine;

                while ((allLine = streamReader.ReadLine()) != null)
                {
                    string[] lines = allLine.Split('\t');
                    if (date == lines[0])
                    {
                        ListNote.Add(new Note()
                        {
                            TimeBusines = DateTime.Parse(lines[1]),
                            NameBusines = lines[2],
                            TimeCreateNote = DateTime.Parse(lines[3]),
                            TypeNote = char.Parse(lines[4])
                        });
                    }
                }
                ListNote.Sort((a, b) => a.TimeBusines.CompareTo(b.TimeBusines));

                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition((Console.WindowWidth - date.Length) / 2, Console.CursorTop);
                Console.WriteLine($"Дата:{date}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(Console.WindowWidth - 46, 1);
                Console.WriteLine($"Дата создания странички ежедневника:{ListNote[0].TimeCreateNote.ToShortDateString()}");
                Console.ResetColor();

                for (int i = 0; i < ListNote.Count; i++)
                {
                    if (ListNote[i].TypeNote == 's')
                    {
                        Console.WriteLine($"{ListNote[i].TimeBusines.ToShortTimeString()}-{ListNote[i].NameBusines}");
                    }
                    if (ListNote[i].TypeNote == 'i')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{ListNote[i].TimeBusines.ToShortTimeString()}-{ListNote[i].NameBusines}");
                        Console.ResetColor();
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Идеи*");
                for (int i = 0; i < ListNote.Count; i++)
                {
                    if (ListNote[i].TypeNote == 'c')
                    {
                        Console.WriteLine($"{ListNote[i].NameBusines}");
                    }
                }

                Console.ResetColor();
            }
            if (AskQuestion("Хотите отредактировать заметки на этой странице?y/n") == true)
            {
                EditPage(ListNote, date);
            }


        }
        static void EditPage(List<Note> ListNote, string date)
        {
            int numberNote = 0;
            Console.Clear();
            for (int i = 0; i < ListNote.Count; i++)
            {
                if (ListNote[i].TypeNote == 's')
                {
                    numberNote++;
                    Console.WriteLine($"[№{numberNote}]{ListNote[i].TimeBusines.ToShortTimeString()}-{ListNote[i].NameBusines}");
                }
                if (ListNote[i].TypeNote == 'i')
                {
                    numberNote++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[№{numberNote}]{ListNote[i].TimeBusines.ToShortTimeString()}-{ListNote[i].NameBusines}");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Идеи*");
            for (int i = 0; i < ListNote.Count; i++)
            {
                if (ListNote[i].TypeNote == 'c')
                {
                    numberNote++;
                    Console.WriteLine($"[№{numberNote}]{ListNote[i].NameBusines}");
                }
            }
            Console.ResetColor();

            Console.WriteLine("Введите номер заметки которую нужно отредактировать");

            int numberNoteEdit = CheckNumber(Console.ReadLine(), 0, numberNote)-1;
            string noteText = $"{date}\t{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}" +
                    $"\t{ListNote[numberNoteEdit].NameBusines}" +
                    $"\t{ ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                    $"\t{ListNote[numberNoteEdit].TypeNote}";
            if (ListNote[numberNoteEdit].TypeNote == 'c')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ ListNote[numberNoteEdit].NameBusines}");
                Console.WriteLine("Для редактирования заметки нажмите 1");
            }
            else
            {
                Console.WriteLine($"{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}-{ListNote[numberNoteEdit].NameBusines}");
                Console.WriteLine("Для редактирования заметки нажмите 1" +
                                "\nДля редактирования времени нажмите 2");
            }

            string allLine = string.Empty;
            using (StreamReader sr = new StreamReader(PathInDiary))
            {
                allLine = sr.ReadToEnd();
            }
                File.Delete(PathInDiary);
            using (StreamWriter sw = new StreamWriter(PathInDiary))
            {

                ConsoleKeyInfo enter = Console.ReadKey(true);
                switch (enter.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Напишите эту заметку заново");
                        string enterBusines = Console.ReadLine();
                        allLine = allLine.Replace(noteText,$"{date}\t{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}" +
                            $"\t{enterBusines} " +
                            $"\t{ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                            $"\t{ListNote[numberNoteEdit].TypeNote}").ToString();
                        sw.WriteLine(allLine);
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Напишите время заново");
                        allLine=allLine.Replace(noteText, $"{date}\t{CheckTime()}" +
                            $"\t{ListNote[numberNoteEdit].NameBusines}" +
                            $"\t{ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                            $"\t{ListNote[numberNoteEdit].TypeNote}");
                        sw.WriteLine(allLine);
                        break;
                }
            }
       }
       
    }
}

