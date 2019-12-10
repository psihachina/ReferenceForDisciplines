using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }
        void Show();
        void Close();
        ListView GetListView();
    }
}