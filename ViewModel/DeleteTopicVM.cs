using System.Collections.ObjectModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteTopicVM : ViewModelBase
    {
        public DialogSession DialogSession;
        private readonly Reference reference;
        private readonly ObservableCollection<Reference> references;

        public DeleteTopicVM(IView view, Reference reference, ObservableCollection<Reference> references) : base(view)
        {
            View.ViewModel = this;
            this.reference = reference;
            this.references = references;
            View.Show();
        }

        public ICommand Delete =>
            new UserCommand(async () =>
                {
                    references.Remove(reference);
                    DialogSession.Close();
                }
            );
    }
}