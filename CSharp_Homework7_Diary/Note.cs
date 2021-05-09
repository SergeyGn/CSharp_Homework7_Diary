using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Homework7_Diary
{
  public struct Note
    {
        /// <summary>
        /// Время когда выполнить дело
        /// </summary>
        private  DateTime _timeBisnes;
        /// <summary>
        /// Название дела
        /// </summary>
        private  string _nameBisnes;
        /// <summary>
        /// Время создания заметки
        /// </summary>
        private DateTime _timeCreateNote;
        public DateTime TimeBusines { get => _timeBisnes; set => _timeBisnes = value; }
        public string NameBusines { get => _nameBisnes; set => _nameBisnes = value; }
        public DateTime TimeCreateNote { get => _timeCreateNote; set => _timeCreateNote = value; }

        public Note(DateTime TimeBisnes, string NameBisnes, DateTime TimeCreateNote)
        {
            _timeBisnes = TimeBisnes;
            _nameBisnes=NameBisnes;
            _timeCreateNote = TimeCreateNote;
        }
        public Note(string NameBisnes)
            :this(new DateTime(),NameBisnes,new DateTime())
        {
        }

    }
}
