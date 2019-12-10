using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private UserControl _content;
        private ObservableCollection<Discipline> _disciplinesList = new ObservableCollection<Discipline>();
        private ObservableCollection<Reference> _referencesList = new ObservableCollection<Reference>();
        private Discipline _selectedDiscipline;
        private Reference _selectedReference;

        public MainVM(IView view) : base(view)
        {
            View.ViewModel = this;
            View.Show();
            _disciplinesList = BaseOfManager.GetInstance().unitOfWork.Disciplines.Get();
        }

        public Discipline SelectedDiscipline
        {
            get => _selectedDiscipline;
            set
            {
                if (Set(ref _selectedDiscipline, value)) ChangeReferencesList();
            }
        }


        public UserControl ContentWindow
        {
            get => _content;
            set => Set(ref _content, value);
        }

        public Reference SelectedReference
        {
            get => _selectedReference;
            set
            {
                if (Set(ref _selectedReference, value)) ChangeReferencesList();
            }
        }


        public ObservableCollection<Reference> ReferencesList
        {
            get => _referencesList;
            set => Set(ref _referencesList, value);
        }

        public ObservableCollection<Discipline> DisciplinesList
        {
            get => _disciplinesList;
            set => Set(ref _disciplinesList, value);
        }

        public ICommand Change =>
            new UserCommand(() => { ChangeReferencesList(); }
            );

        public ICommand OnShowDeleteDialog =>
            new UserCommand(() => { OnShowDialogDelete(); }
            );

        public ICommand OnShowEditDialog =>
            new UserCommand(() => { OnShowDialogEdit(); }
            );

        public ICommand OnShowAddDialog =>
            new UserCommand(() =>
                {
                    var viewModel = new AddDisciplineVM(new AddDiscipline(), this);
                    object dialogResult = DialogHost.Show(viewModel,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand DeleteSelectedDiscipline =>
            new UserCommand(() =>
                {
                    DeleteSelectedDisc();
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }
            );

        public string newname { get; set; }

        public ICommand EditSelectedDiscipline =>
            new UserCommand(() =>
                {
                    BaseOfManager.GetInstance().unitOfWork.Disciplines
                        .Update(SelectedDiscipline, new Discipline {Name = newname});
                    newname = "";
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    View.GetListView().UnselectAll();
                    SelectedDiscipline = null;
                }
            );

        public ICommand AddNewDiscipline =>
            new UserCommand(() =>
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);
                    BaseOfManager.GetInstance().unitOfWork.Disciplines.Add(new Discipline {Name = newname});
                    newname = "";
                }
            );

        public ICommand Close =>
            new UserCommand(() => { View.Close(); }
            );

        public ICommand Save =>
            new UserCommand(() => { BaseOfManager.GetInstance().unitOfWork.SaveChange(); }
            );

        protected override void PrepareViewModel()
        {
        }

        public void ChangeReferencesList()
        {
            SetDefaultUC();
        }

        public void SetDefaultUC()
        {
            ReferencesList = BaseOfManager.GetInstance().unitOfWork.References.Get();
            var defaultUC = new Default();
            var defaultUCVM = new DefaultVM(defaultUC, this);
            defaultUC.DataContext = defaultUCVM;
            ContentWindow = defaultUC;
        }

        public void OnShowDialogDelete()
        {
            var viewModel = new DeleteDisciplineVM(new DeleteDialog(), this);
            DialogHost.Show(new DeleteDialog(),
                new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
        }

        public void OnShowDialogEdit()
        {
            var viewModel = new EditDisciplineVM(new EditDialog());
            object dialogResult = DialogHost.Show(new EditDialog(),
                new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
        }

        public void DeleteSelectedDisc()
        {
            BaseOfManager.GetInstance().unitOfWork.Disciplines.Remove(SelectedDiscipline);
            SelectedDiscipline = DisciplinesList[0];
        }

        public void UpdateSelectedDiscipline()
        {
            NotifyPropertyChanged(Convert.ToString(_selectedDiscipline));
        }
    }
}