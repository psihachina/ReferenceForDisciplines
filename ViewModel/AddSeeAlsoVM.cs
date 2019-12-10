using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class AddSeeAlsoVM : ViewModelBase
    {
        private string _name;
        public DialogSession DialogSession;

        private readonly Reference reference;

        public AddSeeAlsoVM(IView view, Reference reference) : base(view)
        {
            View.ViewModel = this;
            this.reference = reference;
            View.Show();
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public ICommand ShowAddSeeAlso =>
            new UserCommand(() =>
                {
                    reference.Edges.Add(new SeeAlso {ConnectedTopic = Name});
                    BaseOfManager.GetInstance().unitOfWork.References.Update(reference,
                        new Reference
                        {
                            Disciplines = reference.Disciplines, Document = reference.Document, Edges = reference.Edges,
                            Name = reference.Name
                        });
                    DialogSession.Close();
                }
            );
    }
}