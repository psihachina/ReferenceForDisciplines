using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class EditSeeAlsoVM : ViewModelBase
    {
        private readonly Reference reference;
        private readonly SeeAlso seeAlso;
        private string _name;
        public DialogSession DialogSession;

        public EditSeeAlsoVM(IView view, Reference reference, SeeAlso seeAlso) : base(view)
        {
            View.ViewModel = this;
            this.reference = reference;
            Name = seeAlso.ConnectedTopic;
            this.seeAlso = seeAlso;
            View.Show();
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public ICommand EditSeeAlso =>
            new UserCommand(() =>
                {
                    reference.Edges[reference.Edges.IndexOf(seeAlso)].ConnectedTopic = Name;
                    BaseOfManager.GetInstance().unitOfWork.References.Update(reference,
                        new Reference
                        {
                            Disciplines = reference.Disciplines,
                            Document = reference.Document,
                            Edges = reference.Edges,
                            Name = reference.Name
                        });
                    DialogSession.Close();
                }
            );
    }
}