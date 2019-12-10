using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class AddTopicVM : ViewModelBase
    {
        private string _name;
        private string _pathFile;
        private readonly DefaultVM defaultVM;
        public DialogSession DialogSession;
        private readonly Discipline discipline;

        public AddTopicVM(IView view, Discipline discipline, DefaultVM defaultVM) : base(view)
        {
            View.ViewModel = this;
            this.defaultVM = defaultVM;
            this.discipline = discipline;
            View.Show();
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

        public ICommand AddSelectedDiscipline =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.References.Add(new Reference
                        {Disciplines = discipline.Name, Document = PathFile, Name = Name});
                    DialogSession.Close();
                    defaultVM.mainVM.SetDefault();
                }
            );
    }
}