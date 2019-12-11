using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class BrowsingVM : ViewModelBase
    {
        private readonly DefaultVm defaultVM;
        private readonly MainVm mainVM;
        private FixedDocumentSequence _document;
        private Reference _selectedReference;
        private SeeAlso _selectedReferenceEdge;

        public BrowsingVM(IView view, Reference reference, MainVm mainVM, DefaultVm defaultVM) : base(view)
        {
            View.ViewModel = this;
            this.defaultVM = defaultVM;
            SelectedReference = reference;
            this.mainVM = mainVM;
        }

        public Reference SelectedReference
        {
            get => _selectedReference;
            set
            {
                if (Set(ref _selectedReference, value))
                    Document = new XpsDocument(SelectedReference.Document, FileAccess.Read).GetFixedDocumentSequence();
            }
        }

        public SeeAlso SelectedReferenceEdge
        {
            get => _selectedReferenceEdge;
            set => Set(ref _selectedReferenceEdge, value);
        }

        public FixedDocumentSequence Document
        {
            get => _document;
            set => Set(ref _document, value);
        }

        public ICommand Back =>
            new UserCommand(() =>
                {
                    var defaultUc = new Default();
                    var defaultVm = new DefaultVm(defaultUc, mainVM) {ReferencesList = mainVM.ReferencesList};
                    defaultVm.ReferencesList = new ObservableCollection<Reference>(BaseOfManager.GetInstance()
                        .unitOfWork.References.Get().Where(x => x.Disciplines == mainVM.SelectedDiscipline.Name));
                    defaultUc.DataContext = defaultVm;
                    mainVM.ContentWindow = defaultUc;
                }
            );

        public ICommand OpenAddSeeAlso =>
            new UserCommand(() =>
                {
                    var viewModel = new AddSeeAlsoVM(new AddSeeAlso(), SelectedReference);
                    DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenEditSeeAlso =>
            new UserCommand(() =>
                {
                    var viewModel = new EditSeeAlsoVM(new EditSeeAlso(), SelectedReference, SelectedReferenceEdge);
                    DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenDeleteSeeAlso =>
            new UserCommand(() =>
                {
                    var viewModel = new DeleteSeeAlsoVm(new DeleteSeeAlso(), SelectedReferenceEdge, SelectedReference);
                    DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand Change =>
            new UserCommand(() => { ChangeSelectedEdge(); }
            );

        private void ChangeSelectedEdge()
        {
            defaultVM.SelectedReference = BaseOfManager.GetInstance().unitOfWork
                .FindTopic(_selectedReferenceEdge.ConnectedTopic);
            defaultVM.OnOpenBrowsing();
        }
    }
}