using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public class MainVm : ViewModelBase
    {
        private UserControl _content;
        private ObservableCollection<Discipline> _disciplinesList = new ObservableCollection<Discipline>();
        private ObservableCollection<Reference> _referencesList = new ObservableCollection<Reference>();
        private Discipline _selectedDiscipline;
        private Reference _selectedReference;

        public MainVm(IView view) : base(view)
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
                    var viewModel = new AddDisciplineVm(new AddDiscipline(), this);
                    DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );


        public string Newname { get; set; }


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
            SetDefault();
        }

        public void SetDefault()
        {
            ReferencesList = BaseOfManager.GetInstance().unitOfWork.References.Get();
            var defaultUc = new Default();
            var defaultVm = new DefaultVm(defaultUc, this);
            defaultUc.DataContext = defaultVm;
            ContentWindow = defaultUc;
        }

        public void OnShowDialogDelete()
        {
            var viewModel = new DeleteDisciplineVm(new DeleteDialog(), this);
            DialogHost.Show(viewModel.View,
                new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
        }

        public void OnShowDialogEdit()
        {
            var viewModel = new EditDisciplineVm(new EditDialog(), this);
            DialogHost.Show(viewModel.View,
                new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
        }
    }
}