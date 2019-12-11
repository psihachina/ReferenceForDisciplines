using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteDisciplineVm : ViewModelBase
    {
        public DeleteDisciplineVm(IView view, MainVm mainVm) : base(view)
        {
            View.ViewModel = this;
            Vm = mainVm;
        }

        public MainVm Vm { get; }

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