using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteTopicVm : ViewModelBase
    {
        public DialogSession DialogSession;
        private readonly Reference _reference;
        private readonly ObservableCollection<Reference> _references;

        public DeleteTopicVm(IView view, Reference reference, ObservableCollection<Reference> references) : base(view)
        {
            View.ViewModel = this;
            this._reference = reference;
            this._references = references;
            View.Show();
        }

        public ICommand Delete =>
            new UserCommand(() =>
                {
                    _references.Remove(_reference);
                    DialogSession.Close();
                }
            );
    }
}