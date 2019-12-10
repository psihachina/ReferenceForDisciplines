using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class AddDisciplineVm: ViewModelBase
    {
        private string _newName;

        public DialogSession DialogSession;
        public string NewName
        {
            get => _newName;
            set => Set(ref _newName, value);
        }
        public MainVm Vm { get; }

        public AddDisciplineVm(IView view, MainVm mainVm): base(view)
        {
            View.ViewModel = this;
            this.Vm = mainVm;
        }

        public ICommand AddNewDiscipline =>
            new UserCommand(() =>
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    BaseOfManager.GetInstance().unitOfWork.Disciplines.Add(new Discipline {Name = NewName});
                }
            );
    }
}