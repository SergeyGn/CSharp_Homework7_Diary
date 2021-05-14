using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CSharp_Homework7_Diary.Program;

namespace CSharp_Homework7_Diary
{
    class EditPage
    {
       public static void EditPageDiary(List<Note> ListNote, DateTime datePageDiary)
        {
            string date = datePageDiary.ToShortDateString().ToString();
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

            int numberNoteEdit = CheckNumber(Console.ReadLine(), 0, numberNote) - 1;
            string noteText = $"{date}\t{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}" +
                    $"\t{ListNote[numberNoteEdit].NameBusines}" +
                    $"\t{ ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                    $"\t{ListNote[numberNoteEdit].TypeNote}";
            if (ListNote[numberNoteEdit].TypeNote == 'c')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ ListNote[numberNoteEdit].NameBusines}");
                Console.WriteLine("Для редактирования или удаления заметки нажмите 1");
            }
            else
            {
                Console.WriteLine($"{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}-{ListNote[numberNoteEdit].NameBusines}");
                Console.WriteLine("Для редактирования заметки нажмите 1" +
                                "\nДля редактирования времени нажмите 2" +
                                "\nДля удаления заметки нажмите 3");
            }

            string allLine = string.Empty;
            using (StreamReader sr = new StreamReader(PathInDiary))
            {
                allLine = sr.ReadToEnd();
            }
            File.Delete(PathInDiary);
            using (StreamWriter sw = new StreamWriter("Diary.csv", true, Encoding.Unicode))
            {
                ConsoleKeyInfo enter = Console.ReadKey(true);
                switch (enter.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Напишите эту заметку заново");
                        string enterBusines = Console.ReadLine();
                        allLine = allLine.Replace(noteText, $"{date}\t{ListNote[numberNoteEdit].TimeBusines.ToShortTimeString()}" +
                            $"\t{enterBusines} " +
                            $"\t{ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                            $"\t{ListNote[numberNoteEdit].TypeNote}");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Напишите время заново");
                        allLine = allLine.Replace(noteText, $"{date}\t{CheckTime()}" +
                                $"\t{ListNote[numberNoteEdit].NameBusines}" +
                                $"\t{ListNote[numberNoteEdit].TimeCreateNote.ToShortDateString()}" +
                                $"\t{ListNote[numberNoteEdit].TypeNote}");
                        break;
                    case ConsoleKey.D3:
                        allLine = allLine.Replace($"{noteText}\r\n", null);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        EditPageDiary(ListNote, datePageDiary);
                        break;
                }
                sw.Write(allLine);
            }
            EndMenu(ListNote, datePageDiary);
            
        }
    }
}
