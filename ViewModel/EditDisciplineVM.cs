using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class EditDisciplineVm : ViewModelBase
    {
        private string _newName;

        public MainVm Vm;

        public EditDisciplineVm(IView view, MainVm vm) : base(view)
        {
            View.ViewModel = this;
            Vm = vm;
            _newName = Vm.SelectedDiscipline.Name;
        }

        public DialogSession DialogSession { get; set; }


        public string NewName
        {
            get => _newName;
            set => Set(ref _newName, value);
        }

        public ICommand EditSelectedDiscipline =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.Disciplines
                        .Update(Vm.SelectedDiscipline, new Discipline {Name = NewName});
                    NewName = "";
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }
            );
    }
}