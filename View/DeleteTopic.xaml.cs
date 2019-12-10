using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    /// <summary>
    ///     Логика взаимодействия для DeleteTopic.xaml
    /// </summary>
    public partial class DeleteTopic : UserControl, IView
    {
        public DeleteTopic()
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

        public void UpdateList()
        {
        }
    }
}