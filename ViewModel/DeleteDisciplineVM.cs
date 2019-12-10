using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteDisciplineVm: ViewModelBase
    {
        private readonly DeleteDialog deleteDialog;
        public MainVm Vm { get; }

        public DeleteDisciplineVm(IView view, MainVm mainVM): base(view)
        {
            View.ViewModel = this;
            this.Vm = mainVM;
        }

        public ICommand DeleteSelectedDiscipline =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.Disciplines.Remove(Vm.SelectedDiscipline);
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }
            );

        public DialogSession DialogSession { get; set; }
    }
}