﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
//using HappyBirthdate.Day.Annotations;



namespace CSharp_Lab4.Tools
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

//        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}