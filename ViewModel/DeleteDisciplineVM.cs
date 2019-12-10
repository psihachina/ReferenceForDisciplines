using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class DeleteDisciplineVM
    {
        private readonly DeleteDialog deleteDialog;
        private MainVM mainVM;

        public DeleteDisciplineVM(DeleteDialog model, MainVM mainVM)
        {
            deleteDialog = model;
            deleteDialog.DataContext = this;
            this.mainVM = mainVM;
        }

        public DialogSession DialogSession { get; set; }
    }
}