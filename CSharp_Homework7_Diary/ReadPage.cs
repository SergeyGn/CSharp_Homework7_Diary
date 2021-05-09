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
            using (StreamReader streamReader = new StreamReader("Diary.csv", Encoding.Unicode))
            {

                List<Note> ListNote = new List<Note>();
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
                    if (ListNote[i].TypeNote == ' ')
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
        }

    }
}

