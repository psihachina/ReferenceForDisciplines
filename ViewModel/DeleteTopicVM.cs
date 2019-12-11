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
        private readonly Reference _reference;
        private readonly ObservableCollection<Reference> _references;
        public DialogSession DialogSession;

        public DeleteTopicVm(IView view, Reference reference, ObservableCollection<Reference> references) : base(view)
        {
            View.ViewModel = this;
            _reference = reference;
            _references = references;
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