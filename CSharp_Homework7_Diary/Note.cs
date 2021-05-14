using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Homework7_Diary
{
  public struct Note
    {
        /// <summary>
        /// Дата дела
        /// </summary>
        private DateTime _dateBusines;
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
        /// <summary>
        /// Тип заметки 'i'-важная ;'c'-концептуальная;'s'-обычная. 
        /// </summary>
        private char _typeNote; 
        public DateTime TimeBusines { get => _timeBisnes; set => _timeBisnes = value; }
        public string NameBusines { get => _nameBisnes; set => _nameBisnes = value; }
        public DateTime TimeCreateNote { get => _timeCreateNote; set => _timeCreateNote = value; }
        public char TypeNote { get => _typeNote; set => _typeNote = value; }
        public DateTime DateBusines { get => _dateBusines; set => _dateBusines = value; }

        public Note(DateTime DateBusines,DateTime TimeBisnes, string NameBisnes, DateTime TimeCreateNote, char TypeNote)
        {
            _dateBusines = DateBusines;
            _timeBisnes = TimeBisnes;
            _nameBisnes=NameBisnes;
            _timeCreateNote = TimeCreateNote;
            _typeNote = TypeNote;
        }
        public Note(string NameBisnes)
            :this(new DateTime(),new DateTime(),NameBisnes,new DateTime(),'s')
        {
        }

    }
}
