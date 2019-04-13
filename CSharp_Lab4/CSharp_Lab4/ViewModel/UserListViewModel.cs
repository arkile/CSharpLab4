using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Lab4.Model;
using CSharp_Lab4.Tools;
using CSharp_Lab4.Tools.Manager;
using CSharp_Lab4.View;

namespace CSharp_Lab4.ViewModel
{
    class UserListViewModel : BaseViewModel, IUserListOwner
    {
        private ObservableCollection<Person> _users;

        private string _nameFilter;
        private string _surnameFilter;
        private string _emailFilter;
        private DateTime _dateTimeFilter;
        private bool _isAdultFilter;
        private string _sunSignFilter;
        private string _chineseSignFilter;
        private bool _isBirthdayTodayFilter;

        private string _sortBy;


        private RelayCommand<object> _filterCommand;
        private RelayCommand<object> _sortCommand;
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _removeCommand;

        private Person _selected;



        public ObservableCollection<Person> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public string NameFilter
        {
            set => _nameFilter = value;
        }

        public string SurnameFilter
        {
            set => _surnameFilter = value;
        }

        public string EMailFilter
        {
            set => _emailFilter = value;
        }

        public DateTime DateTimeFilter
        {
            set => _dateTimeFilter = value;
        }

        public bool IsAdultFilter
        {
            set => _isAdultFilter = value;
        }

        public string SunSignFilter
        {
            set => _sunSignFilter = value;
        }

        public string ChineseSignFilter
        {

            set => _chineseSignFilter = value;
        }

        public bool IsBirthdayTodayFilter
        {
            set => _isBirthdayTodayFilter = value;
        }


        public string SortBy
        {
            set => _sortBy = value;
        }

        public Person Selected
        {
            set
            {
                _selected = value;
                UserListManager.PersonToEdit = _selected;
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ?? (_filterCommand = new RelayCommand<object>(
                           Filter, o => true));
            }
        }



        public RelayCommand<object> SortCommand
        {
            get
            {
                return _sortCommand ?? (_sortCommand = new RelayCommand<object>(
                           Sort, o => true));
            }
        }

        public RelayCommand<object> AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand<object>(
                           OpenAddWindow, o => true));
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand<object>(
                           OpenEditWindow, o => _selected != null));
            }
        }

        public RelayCommand<object> RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand<object>(
                           Delete, o => _selected != null));
            }
        }


        internal UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            UserListManager.Initialize(this);
        }



        private void Filter(object obj)
        {
            var res = StationManager.DataStorage.PersonsList;
            res = FilterWithName(res);
            res = FilterWithSurname(res);
            res = FilterWithEmail(res);
            res = FilterWithBirthdayDate(res);
            res = FilterWithIsAdult(res);
            res = FilterWithSunSign(res);
            res = FilterWithChineseSign(res);
            res = FilterWithIsBirthdayToday(res);
            Users = new ObservableCollection<Person>(res);
        }

        private List<Person> FilterWithName(List<Person> list)
        {
            return !string.IsNullOrEmpty(_nameFilter) ? list.Where(person => person.Name.StartsWith(_nameFilter)).ToList() : list;
        }

        private List<Person> FilterWithSurname(List<Person> list)
        {
            return !string.IsNullOrEmpty(_surnameFilter) ? list.Where(person => person.Surname.StartsWith(_surnameFilter)).ToList() : list;
        }

        private List<Person> FilterWithEmail(List<Person> list)
        {
            return !string.IsNullOrEmpty(_emailFilter) ? list.Where(person => person.Email.StartsWith(_emailFilter)).ToList() : list;
        }

        private List<Person> FilterWithBirthdayDate(List<Person> list)
        {
            return _dateTimeFilter != default(DateTime) ? list.Where(person => person.Birthday == _dateTimeFilter).ToList() : list;
        }

        private List<Person> FilterWithIsAdult(List<Person> list)
        {
            return _isAdultFilter ? list.Where(person => person.IsAdult == _isAdultFilter).ToList() : list;
        }

        private List<Person> FilterWithSunSign(List<Person> list)
        {
            if (!string.IsNullOrEmpty(_sunSignFilter) && !_sunSignFilter.Equals("None"))
            {
                return list.Where(person => person.SunSign == _sunSignFilter).ToList();
            }
            return list;
        }

        private List<Person> FilterWithChineseSign(List<Person> list)
        {

            if (!string.IsNullOrEmpty(_chineseSignFilter) && !_chineseSignFilter.Equals("None"))
            {
                return list.Where(person => person.ChineseSign == _chineseSignFilter).ToList();
            }
            return list;
        }

        private List<Person> FilterWithIsBirthdayToday(List<Person> list)
        {
            return _isBirthdayTodayFilter ? list.Where(person => person.IsBirthday == _isBirthdayTodayFilter).ToList() : list;
        }



        private void Sort(object obj)
        {
            var list = _users.ToList();
            switch (_sortBy)
            {
                case "Name":
                    list.Sort((person, person1) => string.Compare(person.Name, person1.Name, StringComparison.Ordinal));
                    break;
                case "Surname":
                    list.Sort((person, person1) => string.Compare(person.Surname, person1.Surname, StringComparison.Ordinal));
                    break;
                case "Email":
                    list.Sort((person, person1) => string.Compare(person.Email, person1.Email, StringComparison.Ordinal));
                    break;
                case "Birthday":
                    list.Sort((person, person1) => person.Birthday.CompareTo(person1.Birthday));
                    break;
                case "Is Adult":
                    list.Sort((person, person1) => person.IsAdult.CompareTo(person1.IsAdult));
                    break;
                case "Is Birthday":
                    list.Sort((person, person1) => person.IsBirthday.CompareTo(person1.IsBirthday));
                    break;
            }
            Users = new ObservableCollection<Person>(list);
        }

        private void OpenAddWindow(object obj)
        {
            AddPersonWindow addPersonWindow = new AddPersonWindow();
            addPersonWindow.ShowDialog();

            Users = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);

        }

        private void OpenEditWindow(object obj)
        {
            MessageBox.Show("//TODO Edit");
        }

        private async void Delete(object obj)
        {

            await Task.Run(() =>
            {

                StationManager.DataStorage.DeletePerson(_selected);
                Users = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            });

            UserListManager.PersonToEdit = null;
        }
    }
}