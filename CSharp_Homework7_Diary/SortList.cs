using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.Program;

namespace CSharp_Homework7_Diary
{
    class SortList
    {
        public static DateTime GetListNote()
        {
            List<Note> ListNote= GetList();

            Console.Clear();
            Console.WriteLine("Хотите отсортировать ежедневник:" +
                "\nпо времени дела нажмите 1" +
               "\nпо названию дела нажмите 2" +
               "\nпо времени создания дела нажмите 3" +
               "\nпо типу задач нажмите 4" +
               "\nпо дате нажмите 5");


            ConsoleKeyInfo enter = Console.ReadKey(true);
            int numberItem = 0;
            DateTime enterDate;
            switch (enter.Key)
            { 
                case ConsoleKey.D1:
                    ListNote.Sort((a, b) => a.TimeBusines.CompareTo(b.TimeBusines));
                    for (int i = 0; i < ListNote.Count; i++)
                    {
                        numberItem++;
                        Console.WriteLine($"[№{numberItem}]{ListNote[i].TimeBusines.ToShortTimeString()}-{ListNote[i].NameBusines}[{ListNote[i].DateBusines.ToShortDateString()}]");
                    }
                    break;
                case ConsoleKey.D2:
                    ListNote.Sort((a, b) => a.NameBusines.CompareTo(b.NameBusines));
                    for (int i = 0; i < ListNote.Count; i++)
                    {
                        numberItem++;
                        Console.WriteLine($"[№{numberItem}]{ListNote[i].NameBusines}-{ListNote[i].TimeBusines.ToShortTimeString()}[{ListNote[i].DateBusines.ToShortDateString()}]");
                    }
                    break;
                case ConsoleKey.D3:
                    ListNote.Sort((a, b) => a.TimeCreateNote.CompareTo(b.TimeCreateNote));
                    for (int i = 0; i < ListNote.Count; i++)
                    {
                        numberItem++;
                        Console.WriteLine($"[№{numberItem}]{ListNote[i].TimeCreateNote.ToShortDateString()}");
                    }
                    break;
                case ConsoleKey.D4:
                    ListNote.Sort((a, b) => a.TypeNote.CompareTo(b.TypeNote));
                    for (int i = 0; i < ListNote.Count; i++)
                    {
                        numberItem++;
                        Console.WriteLine($"[№{numberItem}]{ListNote[i].TypeNote}");
                    }
                    break;
                case ConsoleKey.D5:
                    enterDate=GetListDate();
                    return enterDate;
                default:
                    Console.WriteLine("Некорректный ввод");
                    GetListNote();
                    break;
            }
            int enter1 = CheckNumber(Console.ReadLine(), 0, numberItem) - 1;
            enterDate = ListNote[enter1].DateBusines;
            return enterDate;
        }

        private static DateTime GetListDate()
        {
            List<Note> ListNote = GetList();

            using (StreamReader streamReader = new StreamReader("Diary.csv", Encoding.Unicode))
            {
                List<DateTime> ListDateResult = new List<DateTime>();

                ListNote.Sort((a, b) => a.DateBusines.CompareTo(b.DateBusines));
                ListDateResult.Add(ListNote[0].DateBusines);
                for (int i = 1; i < ListNote.Count; i++)
                {
                    if (ListNote[i - 1].DateBusines != ListNote[i].DateBusines)
                    {
                        ListDateResult.Add(ListNote[i].DateBusines);
                    }
                }

                int numberDate = 0;
                for (int i = 0; i < ListDateResult.Count; i++)
                {
                    numberDate++;
                    Console.WriteLine($"[№{numberDate}]{ListDateResult[i].ToShortDateString()}");
                }
                int enter = CheckNumber(Console.ReadLine(), 0, numberDate) - 1;
                return ListDateResult[enter];
            }
        }

       private static List<Note> GetList()
        {
            List<Note> ListNote = new List<Note>();
            using (StreamReader streamReader = new StreamReader("Diary.csv", Encoding.Unicode))
            {
                string allLine;

                while ((allLine = streamReader.ReadLine()) != null)
                {
                    string[] lines = allLine.Split('\t');

                    ListNote.Add(new Note()
                    {
                        DateBusines = DateTime.Parse(lines[0]),
                        TimeBusines = DateTime.Parse(lines[1]),
                        NameBusines = lines[2],
                        TimeCreateNote = DateTime.Parse(lines[3]),
                        TypeNote = char.Parse(lines[4])
                    });
                }
            }
            return ListNote;
        }
    }
}
