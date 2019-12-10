using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteSeeAlsoVm : ViewModelBase
    {
        public DialogSession DialogSession = null;
        private readonly SeeAlso _seeAlso;
        private readonly Reference _reference;

        public DeleteSeeAlsoVm(IView view, SeeAlso seeAlso, Reference reference) : base(view)
        {
            View.ViewModel = this;
            this._seeAlso = seeAlso;
            this._reference = reference;
            View.Show();
        }

        public ICommand Delete =>
            new UserCommand(() =>
                {   
                    
                    var value = _reference;
                    _reference.Edges.Remove(_seeAlso);
                    BaseOfManager.GetInstance().unitOfWork.References.Update(value, _reference);
                    DialogSession.Close();
                }
            );
    }
}