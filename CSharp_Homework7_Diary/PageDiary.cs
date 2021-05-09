using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Homework7_Diary
{
  public  struct PageDiary
    {
        private DateTime _dataCreate;
        private DateTime _bisnesData;
        private Note _notes;
        private Note _impotantNotes;
        private Note _ideas;
        private string[] _usefulTips;

        /// <summary>
        /// Дата создания
        /// </summary>
       public DateTime DataCreate
        {
            get 
            {
                _dataCreate = new DateTime();
                _dataCreate = DateTime.Now;
                return _dataCreate;
            }
        }
        /// <summary>
        /// Дата реализации задачи
        /// </summary>
        public DateTime BisnesData { get => _bisnesData; set => _bisnesData = value; }
        /// <summary>
        /// Заметки
        /// </summary>
        public Note Notes { get => _notes; set => _notes = value; }
        /// <summary>
        /// Важное
        /// </summary>
        public Note ImpotantNotes { get => _impotantNotes; set => _impotantNotes = value; }
        /// <summary>
        /// Идеи
        /// </summary>
        public Note Ideas { get => _ideas; set => _ideas = value; }
        /// <summary>
        /// Полезные советы
        /// </summary>
        public string[] UsefulTips
        {
            get { return _usefulTips; }
        }
    }
}
