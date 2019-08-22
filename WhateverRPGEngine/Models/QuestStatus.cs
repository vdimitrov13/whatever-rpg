namespace WhateverRPGEngine.Models
{
    using WhateverRPGEngine.Utils;

    public class QuestStatus : BaseNotificationClass
    {
        private bool _isCompleted;

        public Quest PlayerQuest { get; }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }

        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
