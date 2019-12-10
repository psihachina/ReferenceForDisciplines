using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    public partial class DeleteSeeAlso : UserControl, IView
    {
        public DeleteSeeAlso()
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