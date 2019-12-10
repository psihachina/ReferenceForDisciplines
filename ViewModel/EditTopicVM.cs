using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class EditTopicVM : ViewModelBase
    {
        private string _name;
        private string _pathFile;
        public DialogSession DialogSession;
        private readonly Reference reference;

        public EditTopicVM(IView view, Reference reference) : base(view)
        {
            View.ViewModel = this;
            this.reference = reference;
            View.Show();
            PathFile = reference.Document;
            Name = reference.Name;
        }

        public string PathFile
        {
            get => _pathFile;
            set => Set(ref _pathFile, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public ICommand OpenFile =>
            new UserCommand(() =>
                {
                    var openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                        PathFile = openFileDialog.FileName;
                }
            );

        public ICommand AddDiscipline =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.References.Update(reference,
                        new Reference
                        {
                            Disciplines = reference.Disciplines, Document = PathFile, Edges = reference.Edges,
                            Name = Name
                        });
                    DialogSession.Close();
                }
            );
    }
}