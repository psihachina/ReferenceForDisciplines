using System.Windows;
using System.Windows.Controls;
using ReferenceForDisciplines.View;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get => DataContext as IViewModel;
            set => DataContext = value;
        }

        public ListView GetListView()
        {
            return DiscList;
        }

        public void UpdateList()
        {
        }
    }
}