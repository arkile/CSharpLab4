using System.Windows;
using CSharp_Lab4.ViewModel;

namespace CSharp_Lab4.View
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {

        public AddPersonWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

    }
}
