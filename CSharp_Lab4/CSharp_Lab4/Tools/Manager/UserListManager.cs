using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CSharp_Lab4.Model;

namespace CSharp_Lab4.Tools.Manager
{
    internal class UserListManager
    {
        private static Person _personToEdit;
        private static IUserListOwner _userListOwner;


        internal static Person PersonToEdit
        {
            get => _personToEdit;

            set => _personToEdit = value;
        }

        internal static void Initialize(IUserListOwner owner)
        {
            _userListOwner = owner;
        }

        internal static void Reload(List<Person> persons)
        {
            _userListOwner.Users = new ObservableCollection<Person>(persons);
        }

    }
}