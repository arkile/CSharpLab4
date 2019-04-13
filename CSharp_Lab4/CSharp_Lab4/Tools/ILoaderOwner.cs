﻿using System.ComponentModel;
using System.Windows;

namespace CSharp_Lab4.Tools
{

    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}