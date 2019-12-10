using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteSeeAlsoVM : ViewModelBase
    {
        public DialogSession DialogSession;
        private SeeAlso seeAlso;

        public DeleteSeeAlsoVM(IView view, SeeAlso reference) : base(view)
        {
            View.ViewModel = this;
            seeAlso = reference;
            View.Show();
        }
    }
}