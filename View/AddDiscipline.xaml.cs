using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    /// <summary>
    ///     Логика взаимодействия для AddDiscipline.xaml
    /// </summary>
    public partial class AddDiscipline : UserControl, IView
    {
        public AddDiscipline()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get => DataContext as IViewModel;
            set => DataContext = value;
        }

        public void Close()
        {
        }

        public ListView GetListView()
        {
            return null;
        }

        public void Show()
        {
        }
    }
}