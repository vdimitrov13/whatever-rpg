﻿namespace WhateverRPGEngine.Models
{
    using System.ComponentModel;
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;
        private string _characterClass;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged("CharacterClass");
            }
        }

        public int HitPoints
        {
            get => _hitPoints;
            set
            {
                _hitPoints = value;
                OnPropertyChanged("Hitpoints");
            }
        }

        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
