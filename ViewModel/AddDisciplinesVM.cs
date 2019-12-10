using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    internal class AddDisciplineVM
    {
        private readonly AddDiscipline addDialog;
        private MainVM mainVM;

        public AddDisciplineVM(AddDiscipline model, MainVM mainVM)
        {
            addDialog = model;
            addDialog.DataContext = this;
            this.mainVM = mainVM;
        }

        public DialogSession DialogSession { get; set; }
    }
}