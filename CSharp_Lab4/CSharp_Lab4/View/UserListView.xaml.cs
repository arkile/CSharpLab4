using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CSharp_Lab4.ViewModel;

namespace CSharp_Lab4.View
{
    /// <summary>
    /// Логика взаимодействия для UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }
    }
}
