using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    /// <summary>
    ///     Логика взаимодействия для DeleteDialog.xaml
    /// </summary>
    public partial class DeleteDialog : UserControl, IView
    {
        public DeleteDialog()
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