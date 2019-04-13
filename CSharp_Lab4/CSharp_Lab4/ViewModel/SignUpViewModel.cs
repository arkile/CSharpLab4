using System;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CSharp_Lab4.Model;
using CSharp_Lab4.Tools;
using CSharp_Lab4.Tools.Exceptions;
using CSharp_Lab4.Tools.Manager;

namespace CSharp_Lab4.ViewModel
{
    internal class SignUpViewModel : BaseViewModel
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private string _sunSign;
        private string _chineseSign;
        private bool _isAdult;
        private bool _isBirthday;
        public Window _window;

        public SignUpViewModel()
        {

        }

        private RelayCommand<object> _proceedInfo;


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public string SunSign
        {
            get => _sunSign;
            private set
            {
                _sunSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseSign
        {
            get => _chineseSign;
            private set
            {
                _chineseSign = value;
                OnPropertyChanged();
            }
        }


        public bool IsAdult
        {
            get => _isAdult;
            private set
            {
                _isAdult = value;
                OnPropertyChanged();
            }
        }


        public bool IsBirthday
        {
            get => _isBirthday;
            private set
            {
                _isBirthday = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> Proceed
        {
            get
            {
                return _proceedInfo ?? (_proceedInfo = new RelayCommand<object>(
                           ProceedInfo, CanExecute));
            }
        }
        private bool CanExecute(Object obj)
        {

            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) &&
              !string.IsNullOrWhiteSpace(_email);
        }
        private async void ProceedInfo(object obj)
        {
            LoaderManager.Instance.ShowLoader();



            await Task.Run(() =>
            {
                Thread.Sleep(1000);

                try
                {

                    Person person = new Person(_name, _surname, _email, _birthday);


                    StationManager.DataStorage.AddPerson(person);



                }
                catch (PersonDataException e)
                {
                    MessageBox.Show(e.Message);
                }



            });



            LoaderManager.Instance.HideLoader();



        }



        private bool IsDateCorrect()
        {
            return _birthday.Year > 1890 && _birthday.CompareTo(DateTime.Today) <= 0;
        }
    }
}
