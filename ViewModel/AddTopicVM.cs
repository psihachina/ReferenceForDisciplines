using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class AddTopicVm : ViewModelBase
    {
        private readonly DefaultVm _defaultVm;
        private readonly Discipline _discipline;
        private string _name;
        private string _pathFile;
        public DialogSession DialogSession;

        public AddTopicVm(IView view, Discipline discipline, DefaultVm defaultVm) : base(view)
        {
            View.ViewModel = this;
            _defaultVm = defaultVm;
            _discipline = discipline;
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

        public ICommand AddTopic =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.References.Add(new Reference
                        {Disciplines = _discipline.Name, Document = PathFile, Name = Name});
                    DialogSession.Close();
                    _defaultVm.MainVm.SetDefault();
                }
            );
    }
}