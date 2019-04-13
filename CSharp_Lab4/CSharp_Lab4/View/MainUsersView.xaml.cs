using System.ComponentModel;
using System.Windows;
using CSharp_Lab4.Tools.DataStorage;
using CSharp_Lab4.Tools.Manager;
using CSharp_Lab4.ViewModel;

namespace CSharp_Lab4.View
{
    /// <summary>
    /// Interaction logic for MainUsersView.xaml
    /// </summary>
    public partial class MainUsersView : Window
    {
        public MainUsersView()
        {
            InitializeApplication();
            InitializeComponent();
            DataContext = new MainViewModel();

        }

        private void InitializeApplication()
        {
            SerializedDataStorage u = new SerializedDataStorage();
            StationManager.Initialize(u);

        }

        private void UserListView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{

        //}
    }
}
